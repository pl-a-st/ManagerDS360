using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;


namespace ManagerDS360
{
    public enum MethodResultStatus
    {
        Ok,
        Fault
    }
    public class DAO
    {
        List<FileInfo> RouteFileInfoList = new List<FileInfo>();

        public DAO()
        {
            //RouteFileInfoList.AddRange(new DirectoryInfo(fileName).GetFiles());


        }

        //сохранение объекта/сериализация

        public static MethodResultStatus binWriteObjectToFile<Type>(Type serObject, string fileName)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream stream = new FileStream(fileName, FileMode.Create))
                {
                    bf.Serialize(stream, serObject);
                }
                return MethodResultStatus.Ok;
            }
            catch (Exception ex)
            {
            }
            return MethodResultStatus.Fault;
        }

        //извлечение/десериализация
        public static Type binReadFileToObject<Type>(Type serObject, string fullPathFileName, out MethodResultStatus methodResultStatus)
        {
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                using (FileStream stream = new FileStream(fullPathFileName, FileMode.Open))
                {
                    serObject = (Type)bf.Deserialize(stream);
                }
                methodResultStatus = MethodResultStatus.Ok;
            }
            catch (Exception ex)
            {
                methodResultStatus = MethodResultStatus.Fault;
            }
            return serObject;
        }


        //получение пути для сохранения настроек:
        public static string TakeUserPath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Маршруты\";
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
