using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Vast.DC23.DataTransferClient;

namespace LibDevicesManager.DC23
{
    public enum ResultCommandDC23
    {
        Success,
        Exception,
        NotFound,
        OutOfTime,
        NoConnect
    }
    [Serializable]
    public class ManagerDC23
    {
        public static  ClientDC23 Client = new ClientDC23();
        
        public string RouteName
        {
            get;
            private set;
        } = string.Empty;
        public string СhannelFirstAddress
        {
            get;
            private set;
        } = string.Empty;
        public string СhannelSecondAddress
        {
            get;
            private set;
        } = string.Empty;
        public int TimeToAnswer = 30;
        public void SetRouteName(string address)
        {
            RouteName = address;
        }
        public void SetСhannelFirstAddress(string address)
        {
            СhannelFirstAddress = address;
        }
        public void SetСhannelSecondAddress(string address)
        {
            СhannelSecondAddress = address;
        }

        public ResultCommandDC23 OpenRoute()
        {
            string command = $"CONTROL_FROM_PC_OPEN_ROUTE_<{RouteName.Replace(" ","_")}>";
            string successAnswer = "IS_OPEN";
            return SendComand(command, successAnswer);
        }
        public ResultCommandDC23 SetChannelFirst()
        {
            string command = $"CONTROL_FROM_PC_SELECT_NODE_FERST_<{СhannelFirstAddress}>";
            string successAnswer = "SUCCESS";
            return SendComand(command, successAnswer);
        }
        public ResultCommandDC23 SetChannelSecond()
        {
            string command = $"CONTROL_FROM_PC_SELECT_NODE_SECOND_<{СhannelSecondAddress}>";
            string successAnswer = "SUCCESS";
            return SendComand(command, successAnswer);
        }
        public ResultCommandDC23 Meas()
        {
            string command = $"CONTROL_FROM_PC_MEAS";
            string successAnswer = "FINISH";
            return SendComand(command, successAnswer);
        }

        private  ResultCommandDC23 SendComand(string command, string successAnswer)
        {
            if (!Client.Connected)
            {
                return ResultCommandDC23.NoConnect;
            }
            Client.ReceivedMessageDC23Event += Client_ReceivedMessageDC23Event;
            bool isAnswerBeenReceived = false;
            ResultCommandDC23 resultCommandDC23 = ResultCommandDC23.Exception;
            Client.SendCommandDC23(command.Replace(" ", "_"));
            for (int i = 0; i < this.TimeToAnswer*10; i++)
            {
                if (isAnswerBeenReceived)
                {
                    Client.ReceivedMessageDC23Event -= Client_ReceivedMessageDC23Event;
                    return resultCommandDC23;
                }
                Thread.Sleep(100);
            }
            Client.ReceivedMessageDC23Event -= Client_ReceivedMessageDC23Event;
            return ResultCommandDC23.OutOfTime;

            void Client_ReceivedMessageDC23Event(string message)
            {
                if (message.Contains(successAnswer))
                {
                    resultCommandDC23 = ResultCommandDC23.Success;
                }
                if (message.Contains("EXCEPTION"))
                {
                    resultCommandDC23 = ResultCommandDC23.Exception;
                }
                if (message.Contains("NOT_FOUND"))
                {
                    resultCommandDC23 = ResultCommandDC23.NotFound;
                }
                if (message.Contains("NOT_FIND"))
                {
                    resultCommandDC23 = ResultCommandDC23.NotFound;
                }
                if (message.Contains("WAITING_TIME_EXCEEDED"))
                {
                    resultCommandDC23 = ResultCommandDC23.OutOfTime;
                }
                isAnswerBeenReceived = true;
            }
        }

        private static ResultCommandDC23 SendComand(string command, string successAnswer, int timeToAnswer)
        {
            if (!Client.Connected)
            {
                return ResultCommandDC23.NoConnect;
            }
            Client.ReceivedMessageDC23Event += Client_ReceivedMessageDC23Event;
            bool isAnswerBeenReceived = false;
            ResultCommandDC23 resultCommandDC23 = ResultCommandDC23.Exception;
            Client.SendCommandDC23(command);
            for (int i = 0; i < timeToAnswer*10; i++)
            {
                if (isAnswerBeenReceived)
                {
                    Client.ReceivedMessageDC23Event -= Client_ReceivedMessageDC23Event;
                    return resultCommandDC23;
                }
                Thread.Sleep(100);
            }
            Client.ReceivedMessageDC23Event -= Client_ReceivedMessageDC23Event;
            return ResultCommandDC23.OutOfTime;

            void Client_ReceivedMessageDC23Event(string message)
            {
                if (message.Contains(successAnswer))
                {
                    resultCommandDC23 = ResultCommandDC23.Success;
                }
                if (message.Contains("EXCEPTION"))
                {
                    resultCommandDC23 = ResultCommandDC23.Exception;
                }
                if (message.Contains("NOT_FOUND"))
                {
                    resultCommandDC23 = ResultCommandDC23.NotFound;
                }
                if (message.Contains("NOT_FIND"))
                {
                    resultCommandDC23 = ResultCommandDC23.NotFound;
                }
                if (message.Contains("WAITING_TIME_EXCEEDED"))
                {
                    resultCommandDC23 = ResultCommandDC23.OutOfTime;
                }
                isAnswerBeenReceived = true;
            }
        }
    }
}
