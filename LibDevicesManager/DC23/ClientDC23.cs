using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Vast.DC23.DataTransferClient
{
    [Serializable]
    public class ClientDC23
    {
        public event EventHandler ConnectedEvent;
        public event EventHandler DisconnectedEvent;
        private static List<string> m_deniedPaths = new List<string>();
        public event EventHandler TimeSyncronized;
        //public event EventHandler<StateEventArgs> StateSent;
        public event EventHandler StartingShell;
        //public event EventHandler<ExceptionEventArgs> ProcessedExceptionRised;
        private AutoResetEvent m_manResetEvent = new AutoResetEvent(false);

        public delegate void MessageFromDC23Handler(string message);
        public event MessageFromDC23Handler ReceivedMessageDC23Event;

        static ClientDC23()
        {
            m_deniedPaths.Add("vast_meas_control_route");
            m_deniedPaths.Add("base_empty_route");
            //m_deniedPaths.Add(DC22.Tools.Settings.MetrologicalRouteName);
        }

        private bool m_ServerConnected = false;

        public bool Connected
        {
            get { return m_ServerConnected; }
        }

        private static bool CheckDeniedPath(string path)
        {
            foreach (string dp in m_deniedPaths)
                if (path.Contains(dp))
                    return true;
            return false;
        }

        private void OnServerConnected()
        {
            if (!m_ServerConnected)
            {
                m_ServerConnected = true;
                if (ConnectedEvent != null)
                    ThreadPool.QueueUserWorkItem(state => ConnectedEvent(this, EventArgs.Empty));
            }
        }

        private void OnServerDisconnected()
        {
            if (m_ServerConnected)
            {
                m_ServerConnected = false;
                ThreadPool.QueueUserWorkItem(state =>
                {
                    if (DisconnectedEvent != null)
                    {
                        try
                        {
                            DisconnectedEvent(this, EventArgs.Empty);
                        }
                        catch
                        {

                        }
                    }
                });
            }
        }

        //private void RiseProcessedExceptionEvent(Exception ex)
        //{
        //    if (ProcessedExceptionRised != null)
        //        ProcessedExceptionRised(this, new ExceptionEventArgs()
        //        {
        //            ProcessedException = ex
        //        });
        //}

        private string server = "";

        private string[] DFSCommandList;
        private Socket serversocket;
        private Socket clientsock = null;
        private string[] cmdList = null;
        private string local_file_path;
        private string remote_file_path;
        private string shared_file_size;
        //private string local_shared_dir = @"\Storage Card\Data\";
        private int total_clients_connected = 0;

        public string Password;

        private bool m_connected = false;
        private AutoResetEvent m_connectEvent;

        public void Connect(CancellationToken token)
        {
            m_connectEvent = new AutoResetEvent(false);


            try
            {
                serversocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serversocket.Blocking = true;

                //IPHostEntry IPHost = Dns.Resolve(textBox1.Text);
                //string[] aliases = IPHost.Aliases;
                //IPAddress[] addr = IPHost.AddressList;
                IPAddress ipaddress = IPAddress.Parse("169.254.0.82");

                IPEndPoint ipepServer = new IPEndPoint(ipaddress, 8090);
                m_connected = false;
                m_cancelConnect = false;
                while (!m_connected)
                {
                    try
                    {
                        serversocket.Connect(ipepServer);
                        m_connected = true;
                    }
                    catch (SocketException)
                    {
                        Thread.Sleep(100);
                        m_connected = false;

                    }
                    catch
                    {

                    }
                    if (token.IsCancellationRequested)
                    {
                        serversocket.Shutdown(SocketShutdown.Both);
                        serversocket.Disconnect(false);
                        serversocket.Close();
                        serversocket.Dispose();
                        serversocket = null;
                        return;
                    }

                }

                clientsock = serversocket;

                Thread MainThread = new Thread(new ThreadStart(listenclient));
                MainThread.IsBackground = true;
                MainThread.Start();

                m_connectEvent.WaitOne();

            }
            catch 
            {
                //FrameworkTools.ErrorProcessing.WriteInfo("socket exception in connect");
                //Console.WriteLine(se.Message);
                //AppendText(se.Message);             
            }

        }
        public void Connect()
        {
            m_connectEvent = new AutoResetEvent(false);
            //if (!Directory.Exists(local_shared_dir))
            //    Directory.CreateDirectory(local_shared_dir);

            try
            {
                serversocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serversocket.Blocking = true;

                //IPHostEntry IPHost = Dns.Resolve(textBox1.Text);
                //string[] aliases = IPHost.Aliases;
                //IPAddress[] addr = IPHost.AddressList;
                IPAddress ipaddress = IPAddress.Parse("169.254.0.82");

                IPEndPoint ipepServer = new IPEndPoint(ipaddress, 8090);
                m_connected = false;
                m_cancelConnect = false;
                while (!m_connected)
                {
                    try
                    {
                        serversocket.Connect(ipepServer);
                        m_connected = true;
                    }
                    catch (SocketException)
                    {
                        Thread.Sleep(100);
                        m_connected = false;
                    }
                    catch { }
                    if (m_cancelConnect)
                        return;
                }

                clientsock = serversocket;

                Thread MainThread = new Thread(new ThreadStart(listenclient));
                MainThread.IsBackground = true;
                MainThread.Start();

                m_connectEvent.WaitOne();

            }
            catch (SocketException se)
            {
                //FrameworkTools.ErrorProcessing.WriteInfo("socket exception in connect");
                //Console.WriteLine(se.Message);
                //AppendText(se.Message);
            }
            catch 
            {
                //FrameworkTools.ErrorProcessing.WriteInfo("common exception in connect");
               
            }
        }

        private bool m_disconnecting = false;

        /// <summary>
        /// Метод сигнализирует об отключении от сервера
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if (!m_disconnecting) //03.07.2014 связано с одновременным вызовом дисконнекта более одного раза
                {
                    m_disconnecting = true;
                    if (m_connected)
                    {
                        string cmd = "CLIENT_DISCONNECTING ";
                        Byte[] sb = new Byte[1024];
                        sb = Encoding.Unicode.GetBytes(cmd);
                        try
                        {
                            clientsock?.Send(sb, sb.Length, 0);
                        }
                        catch
                        {
                            return;
                        }

                        //if (clientsock != null)
                        //{
                        //    if (!clientsock.Connected)
                        //        return;
                        //}
                        //else
                        //    return;
                        try
                        {
                            clientsock.Shutdown(SocketShutdown.Both);
                            clientsock.Disconnect(false);
                            clientsock?.Close();
                            clientsock?.Dispose();
                        }
                        catch { }
                    }
                    else
                    {
                        m_cancelConnect = true;
                    }
                }
            }
            catch (SocketException)
            {
            }
            catch
            {

            }
            finally
            {
                OnServerDisconnected();
                try
                {
                    if (DisconnectedEvent != null)
                    {
                        DisconnectedEvent(this, EventArgs.Empty);
                    }

                }
                catch
                {

                }
                m_disconnecting = false;
            }
        }

        private bool m_cancelConnect = false;

        public void CancelConnecting()
        {
            m_cancelConnect = true;
            if (m_connectEvent != null)
                m_connectEvent.Set();
        }

        public void SendClientPrepared()
        {
            Socket sock = clientsock;
            string cmd = "SHELL_REWRITE_PREPARED";
            byte[] sender = System.Text.Encoding.Unicode.GetBytes(cmd);
            //FrameworkTools.ErrorProcessing.WriteInfo("Before sending SHELL_REWRITE_PREPARED");
            sock.Send(sender, sender.Length, 0);
            //FrameworkTools.ErrorProcessing.WriteInfo("After sending SHELL_REWRITE_PREPARED");
        }

        private bool m_ShellPreparedToRewrite = false;
        private AutoResetEvent m_shellRewritePreparedEvent;

        public void ShellRewritePrepare()
        {
            if (!m_ShellPreparedToRewrite)
            {
                m_shellRewritePreparedEvent = new AutoResetEvent(false);
                Socket sock = clientsock;

                string cmd = "SHELL_REWRITE_PREPARE";
                byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
                sock.Send(b, b.Length, 0);
                Thread.Sleep(10000);
                Thread thr = new Thread(state => Connect());
                thr.IsBackground = true;
                thr.Start();
                //ThreadPool.QueueUserWorkItem(state => Connect());
                m_shellRewritePreparedEvent.WaitOne();
            }
        }

        /// <summary>
        /// изменение строки состояния на приборе
        /// </summary>
        /// <param name="state"></param>
        public void SendState(string state)
        {
            Socket sock = clientsock;
            string cmd = "STATE " + state;
            byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
            sock.Send(b, b.Length, 0);
        }
        public void SendCommandDC23(string command)
        {
            Socket sock = clientsock;
            byte[] b = System.Text.Encoding.Unicode.GetBytes(command);
            sock.Send(b, b.Length, 0);
        }
        public void DeviceVersionAndSummsRewrite()
        {
            m_manResetEvent = new AutoResetEvent(false);
            Socket sock = clientsock;

            string cmd = "REWRITE_VER_SUMMS";
            byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
            sock.Send(b, b.Length, 0);
            m_manResetEvent.WaitOne();
        }

        public void DeviceWritePasswords(string dataExchangePwd, string tSettingsPwd)
        {
            m_manResetEvent = new AutoResetEvent(false);
            Socket sock = clientsock;

            string cmd = "WRITE_PASSWORDS " + dataExchangePwd + " " + tSettingsPwd;
            byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
            sock.Send(b, b.Length, 0);
            m_manResetEvent.WaitOne();
        }

        public void DevicePasswordsOnOf(bool dataExchangePwdOn, bool tSettingsPwdOn)
        {
            //m_manResetEvent = new AutoResetEvent(false);
            Socket sock = clientsock;

            string cmd = "PASSWORDS_ONOFF " + (dataExchangePwdOn ? "ON" : "OFF") + " " + (tSettingsPwdOn ? "ON" : "OFF");
            byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
            sock.Send(b, b.Length, 0);
            //m_manResetEvent.WaitOne();
        }

        public void StartShell()
        {
            //m_manResetEvent = new AutoResetEvent(false);
            Socket sock = clientsock;

            string cmd = "START_SHELL";
            byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
            sock.Send(b, b.Length, 0);
            //m_manResetEvent.WaitOne();
        }

        public void StartInternalApp(string appPath)
        {
            Socket sock = clientsock;

            string cmd = "STARTINTAPP " + appPath;
            byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
            sock.Send(b, b.Length, 0);
        }

        private bool m_existResponse;

        public bool DeviceFileExists(string fileName)
        {
            m_manResetEvent = new AutoResetEvent(false);
            Socket sock = clientsock;

            string cmd = "EXIST_FILE " + fileName;
            byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
            sock.Send(b, b.Length, 0);

            m_manResetEvent.WaitOne();

            CheckError();
            return m_existResponse;
        }

        private bool m_exceptionWasRised = false;

        private void CheckError()
        {
            if (m_exceptionWasRised)
            {
                m_exceptionWasRised = false;
                throw new DataExchangeIOException();
            }
        }

        public bool DeviceDirExists(string path)
        {
            m_manResetEvent = new AutoResetEvent(false);
            Socket sock = clientsock;

            string cmd = "EXIST_DIR " + path;
            byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
            sock.Send(b, b.Length, 0);

            m_manResetEvent.WaitOne();
            CheckError();

            return m_existResponse;
        }

        public void CreateDeviceDirectory(string path)
        {
            m_manResetEvent = new AutoResetEvent(false);
            Socket sock = clientsock;
            string cmd = "MAKE_DIR " + path;
            byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
            sock.Send(b, b.Length, 0);
            m_manResetEvent.WaitOne();
            CheckError();
        }

        public void RemoveDeviceDirectory(string path)
        {
            m_manResetEvent = new AutoResetEvent(false);
            Socket sock = clientsock;

            string cmd = "DELETE_DIR " + path;
            byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
            sock.Send(b, b.Length, 0);
            m_manResetEvent.WaitOne();
            CheckError();
        }

        public void DeleteDeviceFile(string fileName)
        {
            m_manResetEvent = new AutoResetEvent(false);
            Socket sock = clientsock;
            string cmd = "DELETE_FILE " + fileName;
            byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
            sock.Send(b, b.Length, 0);
            m_manResetEvent.WaitOne();

            CheckError();
        }

        private List<string> m_enumRespond;

        public List<string> EnumFiles(string path)
        {
            m_manResetEvent = new AutoResetEvent(false);
            m_enumRespond = new List<string>();
            Socket sock = clientsock;

            string cmd = "CLIENT_LISTING_FILES " + path;
            byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
            sock.Send(b, b.Length, 0);

            m_manResetEvent.WaitOne();
            CheckError();
            return m_enumRespond;
        }

        public List<string> EnumDirs(string path)
        {
            m_manResetEvent = new AutoResetEvent(false);
            m_enumRespond = new List<string>();
            Socket sock = clientsock;

            string cmd = "CLIENT_LISTING_DIRS " + path;
            byte[] b = System.Text.Encoding.Unicode.GetBytes(cmd);
            sock.Send(b, b.Length, 0);

            m_manResetEvent.WaitOne();
            CheckError();
            return m_enumRespond;
        }

        public void CopyFileFromDevice(string localFileName, string remoteFileName)
        {
            m_manResetEvent = new AutoResetEvent(false);
            Socket sock = clientsock;
            local_file_path = localFileName;
            remote_file_path = remoteFileName;

            // Send a Get to command .Server will reply GETOK if the file is avaialble
            string cmd = "GET " + remoteFileName;
            Byte[] sb = new Byte[1024];
            sb = Encoding.Unicode.GetBytes(cmd);
            sock.Send(sb, sb.Length, 0);

            m_manResetEvent.WaitOne();
            CheckError();
        }

        private AutoResetEvent m_copyFileToDeviceResetEvent;

        public void CopyFileToDevice(string localFileName, string remoteFileName)
        {
            //LogTools.WriteInfo("CopyFileToDevice " + Path.GetFileName(localFileName) + " started");
            m_copyFileToDeviceResetEvent = new AutoResetEvent(false);
            //LogTools.WriteInfo("To device entry");
            Socket sock = clientsock;

            FileInfo file = new FileInfo(localFileName);

            shared_file_size = file.Length.ToString();
            local_file_path = localFileName;
            remote_file_path = remoteFileName;

            // Send a Get to command .Server will reply GETOK if the file is avaialble
            string cmd = "GETOK " + remoteFileName + " " + shared_file_size;
            Byte[] sb = new Byte[1024];
            sb = Encoding.Unicode.GetBytes(cmd);
            sock.Send(sb, sb.Length, 0);
            //ServerDownloadingFromClient(sock);

            //LogTools.WriteInfo("To device before wait");
            m_copyFileToDeviceResetEvent.WaitOne();
            CheckError();
            //LogTools.WriteInfo("CopyFileToDevice " + Path.GetFileName(localFileName) + " finished");
        }

        public void SetDeviceDateTime()
        {
            m_manResetEvent = new AutoResetEvent(false);

            Socket sock = clientsock;
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
            string dtStr = DateTime.Now.ToString(cultureInfo);

            string cmd = "SET_DATETIME " + dtStr;
            Byte[] sb = new Byte[1024];
            sb = Encoding.Unicode.GetBytes(cmd);
            sock.Send(sb, sb.Length, 0);
            m_manResetEvent.WaitOne();
        }

        public void WriteProductIdAndModelId(string productId, string modelId)
        {
            m_manResetEvent = new AutoResetEvent(false);

            Socket sock = clientsock;
            string cmd = "WRITE_PRODUCTID_MODELID " + productId + " " + modelId;
            Byte[] sb = new Byte[1024];
            sb = Encoding.Unicode.GetBytes(cmd);
            sock.Send(sb, sb.Length, 0);
            m_manResetEvent.WaitOne();
            CheckError();
        }

        private string m_getDeviceShellVersionRespond;

        public string GetDeviceShellVersion()
        {
            m_manResetEvent = new AutoResetEvent(false);

            Socket sock = clientsock;
            string cmd = "GET_VERSION";
            Byte[] sb = new Byte[1024];
            sb = Encoding.Unicode.GetBytes(cmd);
            sock.Send(sb, sb.Length, 0);
            m_manResetEvent.WaitOne();
            CheckError();
            return m_getDeviceShellVersionRespond;
        }

        private string m_productId, m_modelId;

        public void GetProductIdModelId(out string productId, out string modelId)
        {
            m_manResetEvent = new AutoResetEvent(false);

            Socket sock = clientsock;
            string cmd = "GET_PRODUCTID_MODELID";
            Byte[] sb = new Byte[1024];
            sb = Encoding.Unicode.GetBytes(cmd);
            sock.Send(sb, sb.Length, 0);
            m_manResetEvent.WaitOne();
            CheckError();
            productId = m_productId;
            modelId = m_modelId;
        }

        private string m_formatRes;

        public string FormatDeviceSD()
        {
            m_manResetEvent = new AutoResetEvent(false);

            Socket sock = clientsock;
            string cmd = "FORMAT_STORAGECARD";
            Byte[] sb = new Byte[1024];
            sb = Encoding.Unicode.GetBytes(cmd);
            sock.Send(sb, sb.Length, 0);
            m_manResetEvent.WaitOne();
            return m_formatRes;
        }

        private string m_scanRes;

        public string ScanDeviceSD()
        {
            m_manResetEvent = new AutoResetEvent(false);

            Socket sock = clientsock;
            string cmd = "SCAN_STORAGECARD";
            Byte[] sb = new Byte[1024];
            sb = Encoding.Unicode.GetBytes(cmd);
            sock.Send(sb, sb.Length, 0);
            m_manResetEvent.WaitOne();
            return m_scanRes;
        }

        private string m_scanMsg;

        public string GetScanSDMessage()
        {
            m_manResetEvent = new AutoResetEvent(false);

            Socket sock = clientsock;
            string cmd = "SCAN_RESULT";
            Byte[] sb = new Byte[1024];
            sb = Encoding.Unicode.GetBytes(cmd);
            sock.Send(sb, sb.Length, 0);
            m_manResetEvent.WaitOne();
            return m_scanMsg;
        }

        //List<string> m_appendableText = new List<string>();
        //void AppendText(string mtxt)
        //{
        //    m_appendableText.Add(mtxt);
        //}

        //private void PopulateServer_MyFiles()
        //{
        //    //listView1.Items.Clear();
        //    string[] mCList = Directory.GetFiles(local_shared_dir);
        //    Populate(mCList);
        //}
        private List<string[]> list2 = new List<string[]>();

        private void PopulateList(string servermessage)
        {
            list2.Clear();
            string[] lines = servermessage.Split('\n');
            for (int i = 1; i < lines.Length - 1; i++)
            {
                lines[i] = lines[i].Substring(0, lines[i].Length - 1);
                string[] listviewitems = lines[i].Split(',');
                list2.Add(listviewitems);
            }
        }

        private void listenclient()
        {
            bool wasDisconnectOnSocketExc = false;
            Socket sock = clientsock;
            string cmd = server;
            byte[] sender = System.Text.Encoding.Unicode.GetBytes("CLIENT" + cmd);
            sock.Send(sender, sender.Length, 0);

            try
            {
                while (sock != null)
                {
                    cmd = "";
                    byte[] recs = new byte[131068];
                    int rcount = sock.Receive(recs, recs.Length, 0);
                    string clientmessage = System.Text.Encoding.Unicode.GetString(recs);
                    if (rcount < clientmessage.Length)
                        clientmessage = clientmessage.Substring(0, rcount);

                    string smk = clientmessage;

                    cmdList = null;
                    cmdList = clientmessage.Split(' ');
                    string execmd = cmdList[0].Replace("\0", string.Empty);
                    AppendText("COMMAND==>" + execmd);

                    sender = null;
                    sender = new Byte[131068];

                    //Console.WriteLine("CLIENT COMMAND = " + execmd + "\r\n");

                    string parm1 = "";
                    if (execmd.Contains("ANSWER"))
                    {
                        ReceivedMessageDC23Event?.Invoke(execmd);
                        continue;
                    }
                    if (execmd == "SERVER")
                    {
                        m_connectEvent.Set();

                        OnServerConnected();
                        AppendText("Connected TO Server :" + cmdList[1]);

                        continue;
                    }

                    if (execmd == "GET")
                    {
                        // GET <FileName>
                        for (int i = 1; i < cmdList.Length; i++)
                            parm1 = parm1 + " " + cmdList[i];
                        parm1 = parm1.Trim();
                        FileInfo fi = new FileInfo(parm1);
                        if (fi.Exists)
                        {
                            cmd = "GETOK " + parm1 + " " + fi.Length.ToString();
                            local_file_path = parm1;
                            shared_file_size = fi.Length.ToString();
                        }
                        else
                            cmd = "GETOK_FAILED ";
                        sender = System.Text.Encoding.Unicode.GetBytes(cmd);
                        sock.Send(sender, sender.Length, 0);
                        continue;
                    }

                    if (execmd.Contains("EXIST"))
                    {
                        parm1 = cmdList[1];
                        m_existResponse = parm1.Contains("True");
                        m_manResetEvent.Set();
                        continue;
                    }

                    if (execmd == "LISTING_SIZE")
                    {
                        m_enumRespond.Clear();
                        //string[] lines = clientmessage.Split('\n');
                        sender = System.Text.Encoding.Unicode.GetBytes("GET_LISTING");
                        sock.Send(sender, sender.Length, 0);

                        int dataSize = int.Parse(cmdList[cmdList.Length - 1].Replace("\0", string.Empty));
                        byte[] allAnswerData = new byte[dataSize];
                        int readedSize = 0;
                        byte[] dataBuf = new byte[1000];
                        using (NetworkStream netStream = new NetworkStream(sock))
                        {
                            while (readedSize < dataSize)
                            {
                                int partSize = netStream.Read(dataBuf, 0, dataBuf.Length);
                                for (int i = 0; i < partSize; i++)
                                {
                                    allAnswerData[i + readedSize] = dataBuf[i];
                                }
                                readedSize += partSize;
                            }
                        }
                        string strAnswer = System.Text.Encoding.Unicode.GetString(allAnswerData);
                        string[] lines = strAnswer.Split('\n');
                        for (int i = 0; i < lines.Length - 1; i++)
                        {
                            lines[i] = lines[i].Substring(0, lines[i].Length - 1);
                            m_enumRespond.Add(lines[i]);
                        }
                        m_manResetEvent.Set();
                        continue;
                    }

                    if (execmd.Contains("NOOP"))
                    {
                        // do nothing 
                        //LogTools.WriteInfo("To device before set");
                        m_manResetEvent.Set();
                        continue;
                    }

                    if (execmd == "DISCONNECT")
                    {
                        total_clients_connected++;
                        continue;
                    }


                    if (execmd.Contains("FILEOK"))
                    {
                        cmd = "NOOP ";
                        sender = System.Text.Encoding.Unicode.GetBytes(cmd);
                        sock.Send(sender, sender.Length, 0);

                        //LogTools.WriteInfo("FILEOK request received");
                        m_copyFileToDeviceResetEvent.Set();
                        continue;
                    }

                    if (execmd == "GETOK")
                    {
                        //GETOK <file_path> <file_size>
                        for (int i = 1; i < cmdList.Length - 1; i++)
                            parm1 = parm1 + " " + cmdList[i];
                        parm1 = parm1.Trim();

                        remote_file_path = parm1;
                        shared_file_size = cmdList[cmdList.Length - 1].Replace("\0", string.Empty);

                        cmd = "BEGINSEND";
                        sender = new Byte[1024];
                        sender = Encoding.Unicode.GetBytes(cmd);
                        sock.Send(sender, sender.Length, 0);
                        ServerDownloadingFromClient(sock);
                        continue;
                    }

                    if (execmd.Contains("SHELL_REWRITE_PREPARED"))
                    {
                        if (m_shellRewritePreparedEvent != null)
                            m_shellRewritePreparedEvent.Set();
                        m_ShellPreparedToRewrite = true;
                        continue;
                    }

                    if (execmd.Contains("VERSION"))
                    {
                        parm1 = cmdList[1];
                        m_getDeviceShellVersionRespond = cmdList[1].Replace("\0", string.Empty);
                        ;
                        m_manResetEvent.Set();
                        continue;
                    }

                    if (execmd.Contains("PRODUCTID_MODELID"))
                    {
                        m_productId = cmdList[1].Replace("\0", string.Empty);
                        ;
                        m_modelId = cmdList[2].Replace("\0", string.Empty);
                        ;
                        m_manResetEvent.Set();
                        continue;
                    }

                    if (execmd.Contains("FORMAT_STORAGECARD"))
                    {
                        parm1 = MergeParam(parm1);
                        m_formatRes = parm1.Replace("\0", string.Empty);
                        ;
                        m_manResetEvent.Set();
                        continue;
                    }

                    if (execmd.Contains("SCAN_STORAGECARD"))
                    {
                        parm1 = MergeParam(parm1);
                        m_scanRes = parm1.Replace("\0", string.Empty);
                        ;
                        m_manResetEvent.Set();
                        continue;
                    }

                    if (execmd.Contains("SCAN_RESULT"))
                    {
                        parm1 = MergeParam(parm1);
                        m_scanMsg = parm1.Replace("\0", string.Empty);
                        ;
                        m_manResetEvent.Set();
                        continue;
                    }

                    if (execmd.Contains("BEGINSEND"))
                    {
                        ClientDownloadingFromServer(cmdList, sock);
                        continue;
                    }

                    if (execmd.Contains("SERVER_DISCONNECT"))
                    {
                        //FrameworkTools.ErrorProcessing.WriteInfo("SERVER_DISCONNECT");
                        Disconnect();
                        continue;
                    }

                    if (execmd.Contains("CLIENT_CLOSE"))
                    {
                        //FrameworkTools.ErrorProcessing.WriteInfo("CLIENT_CLOSE");
                        break;
                    }
                }
            }
            catch (SocketException sEx)
            {
                try
                {
                    sock.Shutdown(SocketShutdown.Both);
                    sock.Disconnect(false);
                    sock.Close();
                }
                catch
                {
                }

                wasDisconnectOnSocketExc = true;

                OnServerDisconnected();
            }
            catch (IOException ioEx)
            {
                m_exceptionWasRised = true;
                m_manResetEvent.Set();
                if (m_copyFileToDeviceResetEvent != null)
                {
                    //LogTools.WriteInfo("catch (IOException ioEx) m_copyFileToDeviceResetEvent.Set();");
                    m_copyFileToDeviceResetEvent.Set();
                }

                Thread.CurrentThread.Abort();
            }
            catch
            {
                try
                {
                    sock.Shutdown(SocketShutdown.Both);
                    sock.Disconnect(false);
                    sock.Close();
                }
                catch
                {
                }
            }
            finally
            {
                m_manResetEvent.Set();
                if (m_copyFileToDeviceResetEvent != null)
                {
                    //LogTools.WriteInfo("finally m_copyFileToDeviceResetEvent.Set();");
                    m_copyFileToDeviceResetEvent.Set();
                }

                if (wasDisconnectOnSocketExc)
                {
                    try
                    {
                        if (serversocket.Connected)
                        {
                            serversocket?.Disconnect(true);
                        }
                    }
                    catch { }
                    serversocket?.Close();
                    //if (AutoRestartServer)
                    //    Start();
                }
            }
        }

        private string MergeParam(string parm1)
        {
            for (int i = 1; i < cmdList.Length; i++)
                parm1 = parm1 + " " + cmdList[i];
            parm1 = parm1.Trim();
            return parm1;
        }

        private string m_appendableString = string.Empty;

        private void AppendText(string mtxt)
        {
            mtxt = mtxt + "\r\n";
            m_appendableString += mtxt;
            //textBox1.AppendText(mtxt);
            //textBox1.Select(textBox1.Text.Length,0);
        }

        private void ServerDownloadingFromClient(Socket s)
        {
            //int cnt = listView3.Items.Count;
            Socket sock = s;
            string[] mDownloading = new String[5];

            FileStream fout = new FileStream(local_file_path, FileMode.Create, FileAccess.Write);
            NetworkStream nfs = new NetworkStream(sock);

            long size = int.Parse(shared_file_size);
            long rby = 0;

            //mDownloading[0]=shared_file_name;
            //mDownloading[1]=size.ToString();
            //mDownloading[2]="0";
            //mDownloading[3]="";
            //mDownloading[4]=login_client_machine;

            //listView3.Items.Add(new ListViewItem(mDownloading));

            try
            {
                //loop till the Full bytes have been read
                while (rby < size)
                {
                    byte[] buffer = new byte[1024];
                    //Read from the Network Stream
                    int i = nfs.Read(buffer, 0, buffer.Length);
                    fout.Write(buffer, 0, (int)i);
                    rby = rby + i;

                    int pc = (int)(((double)rby / (double)size) * 100.00);
                    string perc = pc.ToString() + "%";
                    //listView3.Items[cnt].SubItems[3].Text = perc;
                    //listView3.Items[cnt].SubItems[2].Text = rby.ToString();

                }
                fout.Close();
                string cmd = "FILEOK";
                Byte[] sender = new Byte[1024];
                sender = new Byte[1024];
                sender = Encoding.Unicode.GetBytes(cmd);
                sock.Send(sender, sender.Length, 0);
            }
            catch (Exception ed)
            {
                // "A Exception occured in file transfer"+ed.ToString();
                throw ed;
            }
            finally
            {
            }
        }

        private void ClientDownloadingFromServer(string[] cmdList, Socket s)
        {
            //LogTools.WriteInfo("ClientDownloadingFromServer entry");
            DFSCommandList = cmdList;
            //int cnt = listView4.Items.Count;
            //string[] mUploading = new String[5];
            Socket sock = s;
            //string parm1 = "";
            //string parm2 = "";

            //for ( int i=1 ; i < DFSCommandList.Length-1;i++)
            //    parm1 = parm1 + " " + DFSCommandList[i];
            //parm1 = parm1.Trim();
            //parm2 = DFSCommandList[DFSCommandList.Length-1];

            try
            {
                FileInfo ftemp = new FileInfo(local_file_path);
                long total = ftemp.Length;
                long rdby = 0;
                int len = 0;

                //mUploading[0] = parm1;
                //mUploading[1] = total.ToString();
                //mUploading[2] = "0";
                //mUploading[3] = "";
                //mUploading[4] = login_client_machine;

                //listView4.Items.Add(new ListViewItem(mUploading));

                byte[] buffed = new byte[1024];
                //Open the file requested for download 
                FileStream fin = new FileStream(local_file_path, FileMode.Open, FileAccess.Read);
                //One way of transfer over sockets is Using a NetworkStream 
                //It provides some useful ways to transfer data 
                NetworkStream nfs = new NetworkStream(sock);

                //lock the Thread here
                //				lock(this)
                while (rdby < total && nfs.CanWrite)
                {
                    //Read from the File (len contains the number of bytes read)
                    len = fin.Read(buffed, 0, buffed.Length);
                    //Write the Bytes on the Socket
                    nfs.Write(buffed, 0, len);
                    //Increase the bytes Read counter
                    rdby = rdby + len;

                    int pc = (int)(((double)rdby / (double)total) * 100.00);
                    string perc = pc.ToString() + "%";
                    //listView4.Items[cnt].SubItems[3].Text = perc;
                    //listView4.Items[cnt].SubItems[2].Text = rdby.ToString();
                }
                //Display a Message Showing Sucessful File Transfer
                fin.Close();
            }
            catch (Exception ed)
            {
                throw ed;
            }
            finally
            {
            }
        }

        //string SearchDatabase(string pattern)
        //{
        //    string retCmd ="";
        //    ArrayList arr = clientcollection.SearchFiles(pattern);
        //    for ( int i=0; i < arr.Count ;i++)
        //    {
        //        ClientInfo obj = (ClientInfo)arr[i];
        //        retCmd  = retCmd  + obj.sharedfileName + "," + obj.sharedfilesSize + "," + obj.sharedfilesPath + "," + obj.username + "\r\n";
        //    }
        //    return retCmd ;
        //}

        //public class ResponseEventArgs : EventArgs
        //{
        //    public ResponseTypes ResponseType;
        //    public object Arg;
        //}

        //enum ResponseTypes
        //{
        //    DeleteComplete,
        //}
    }

    public class DataExchangeIOException : Exception
    {
    }
}