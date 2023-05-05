using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerDS360
{
    //должны храниться:
    //экземпляр класса из длл управления генератором
    //экз. Enum тип ветви: папка, настр, настр. загружена, ошибка загр.
    //string для хранения названия настройки
    public class  TreeNodeWithSetup : TreeNode
    {
        public TreeNodeWithSetup():base()
        {

        }
        public TreeNodeWithSetup(string str):base(str)
        {

        }
    }
}
