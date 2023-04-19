using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerDS360
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmManagerDS360());

            //тестовая строка
        }
    }

    public class DAO
    {
        List<FileInfo> RouteFileInfoList = new List<FileInfo>();

        public DAO()
        {
            RouteFileInfoList.AddRange(new DirectoryInfo("W:\\8.Технический отдел\\Общая\\Группа C#\\Папка пользователя").GetFiles());
            
        }

    }
     public class  Constants
    {

    }
}
