﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibDevicesManager;

namespace ManagerDS360
{
    public partial class frmManagerRoutse : Form
    {
        public frmManagerRoutse()
        {
            InitializeComponent();
        }

        private void lblLisеComPorts_Click(object sender, EventArgs e)
        {
            //ничего не надо
        }

        private void frmDefaultGenerator_Load(object sender, EventArgs e)
        {

            //this.cboListComPorts.Items.AddRange ( DS360Setting.GetComPortList().ToArray());
            this.cboListComPorts.Items.AddRange(DS360Setting.GetDevicesArray());
            cboListComPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void cboListComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butFindGenerator_Click(object sender, EventArgs e)
        {

        }

        private void butSave_Click(object sender, EventArgs e)
        {
            //сохранить выбранный генератор как по умолчанию и отправить имя на главную страницу в лейбл 
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
