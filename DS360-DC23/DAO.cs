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
using System.Windows.Forms;

namespace ManagerDS360
{
    public enum MethodResultStatus
    {
        Ok,
        Fault
    }
    public static class DAO
    {
        /// <summary>
        /// Сохранение/Сериализация объекта в файл
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="serObject"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Ивлечение/десериализация объекта из файла
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="serObject"></param>
        /// <param name="fullPathFileName"></param>
        /// <param name="methodResultStatus"></param>
        /// <returns></returns>
        public static Type binReadFileToObject<Type>(Type serObject, string fullPathFileName, out MethodResultStatus methodResultStatus)
        {
            if (!File.Exists(fullPathFileName))
            {
                methodResultStatus = MethodResultStatus.Fault;
                return serObject;
            }
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
        /// <summary>
        /// получение пути специальной деректории пользователя для данногого приложения
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetApplicationDataPath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Маршруты\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + fileName;
        }
        //получение пути для сохранения маршрута: 
        /// <summary>
        /// Запускает диалог выбора папки 
        /// </summary>
        /// <param name="TitleDiolog"></param>
        /// <param name="resultStatus"></param>
        /// <returns></returns>
        public static string GetFolderNameDialog(string TitleDiolog, out MethodResultStatus resultStatus)
        {
            CommonOpenFileDialog FolderDialog = new CommonOpenFileDialog();
            FolderDialog.IsFolderPicker = true;
            FolderDialog.Title = TitleDiolog;
            string path = "";
            if (FolderDialog.ShowDialog() != CommonFileDialogResult.Ok)
            {
                resultStatus = MethodResultStatus.Fault;
                return path;
            }
            path = FolderDialog.FileName;
            resultStatus = MethodResultStatus.Ok;
            return path;
        }
    }
}
