using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;


namespace ManagerDS360
{
    public class DAO
    {
        List<FileInfo> RouteFileInfoList = new List<FileInfo>();

        public DAO()
        {
            //RouteFileInfoList.AddRange(new DirectoryInfo(fileName).GetFiles());


        }

        //сохранение объекта в bin
        internal void SerializeObject(string fileName, object obj)
        {
            FileStream fstream = File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fstream, obj);
            fstream.Close();
        }
        //извлечение из bin
        internal object DeserializeObject(string fileName)
        {
            object obj = null;
            FileStream fstream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            obj = (object)binaryFormatter.Deserialize(fstream);
            fstream.Close();
            return obj;
        }

        [Serializable]
        internal class SerializableObject
        {
            public SerializableObject() { }
        }

            //получение пути для сохранения настроек:
            public static string TakeUserPath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Маршруты\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + fileName;
        }
        //получение пути для сохранения маршрута: 
        public static string GetFolderNameDialog(string TitleDiolog)
        {
            CommonOpenFileDialog FolderDialog = new CommonOpenFileDialog();
            FolderDialog.IsFolderPicker = true;
            FolderDialog.Title = TitleDiolog;
            string path = "";
            if (FolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                path = FolderDialog.FileName;
            }
            return path;
        }
    }
}
