using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Diplom
{
    public partial class Import : Form
    {
        public Import()
        {
            InitializeComponent();
        }

        private void Import_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files |*.xml"; // Фильтр для всех типов файлов
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                textBox1.Text = selectedFilePath; // Записываем путь к файлу в текстовое поле
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string file = textBox1.Text;

            if (File.Exists(file))
            {
                try
                {
                    string fname = "";
                    OpenFileDialog dg = new OpenFileDialog();
                    dg.Filter = "XML Files | *.xml";
                    dg.FileName = "";
                    dg.ShowDialog();
                    fname = dg.FileName;
                    if (fname == "") return;
                    string readfile = File.ReadAllText(fname);
                    textBox2.Text = readfile;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}