using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ManagerDS360
{
    public partial class frmAboutAuthors : Form
    {
        public const int WithMax = 590;
        public frmAboutAuthors()
        {
            InitializeComponent();
        }

        private async void frmAboutAuthors_Load(object sender, EventArgs e)
        {

            Task[] tasks = {
                new Task(()=> GetSizeForm()),
                new Task(()=> AddLabel())
                };
            foreach (Task task in tasks)
            {
                task.Start();
            }
            await Task.Run(() => Task.WaitAll(tasks));
        }

        private async void AddLabel()
        {
            try
            {
                await Task.Delay(50);
                Label label = new Label();
                label.Location = new Point(x: 10, y: 20);
                label.Font = new Font("Verdana", 12);
                label.TextAlign = ContentAlignment.MiddleLeft;
                label.AutoSize = true;
                BeginInvoke(new Action(() => this.Controls.Add(label)));
                SetLabelPart1(label);
            }
            catch
            {

            }

        }

        private async void SetLabelPart1(Label label)
        {
            string aboutAutors = "Разработчики:\n\n" +
                "Руководитель проекта, архетектура: Верин С.Г.\n\n" +
                "Библиотека работы с генератором: Агальцов А.С.\n\n" +
               "Пользовательский интерфейс: Маяков А.Н., Кирдяшкин В.А., Верин С.Г.\n\n";

            foreach (char ch in aboutAutors)
            {
                Thread.Sleep(50);
                BeginInvoke(new Action(() =>
                {
                    label.Text += ch;
                }));
                while ((label.Location.X + label.Width + 5) >= this.Width)
                {
                    Thread.Sleep(50);
                    BeginInvoke(new Action(() =>
                    {
                        this.Width += 5;
                    }));
                }
            }
            while (this.ClientSize.Height >  label.ClientSize.Height + 30)
            {
                Thread.Sleep(50);
                BeginInvoke(new Action(() =>
                {
                    this.Height -= 15;
                }));
            }
        }

        private void GetSizeForm()
        {
            try
            {
                int step = 33;
                while (this.Width < WithMax)
                {
                    Thread.Sleep(10);
                    BeginInvoke(new Action(() =>
                    {

                        this.Width += step;
                        this.Height += step;
                        if (step > 2)
                        {
                            step = (int)(step * 0.956);
                        }

                    }));
                }
            }
            catch { }
        }
    }
}
