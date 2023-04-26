using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace ManagerDS360
{
    public class DAO
    {
        List<FileInfo> RouteFileInfoList = new List<FileInfo>();

        public DAO()
        {
            //RouteFileInfoList.AddRange(new DirectoryInfo("W:\\8.Технический отдел\\Общая\\Группа C#\\Папка пользователя").GetFiles());
            

        }


        //получение пути:
        public static string TakeUserPath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\DS360\\Настройки маршрутов\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + fileName;
        }
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
