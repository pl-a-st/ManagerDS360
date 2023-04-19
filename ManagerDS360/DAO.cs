using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ManagerDS360
{
    public class DAO
    {
        List<FileInfo> RouteFileInfoList = new List<FileInfo>();

        public DAO()
        {
            //RouteFileInfoList.AddRange(new DirectoryInfo("W:\\8.Технический отдел\\Общая\\Группа C#\\Папка пользователя").GetFiles());
            

        }


        получение пути:
        public static string TakeUserPath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Time schedule\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + fileName;
        }
    }
}
