using Diplom;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Printing;
using System.ComponentModel;
using static iTextSharp.text.pdf.PdfDocument;

namespace Diplom
{
    public partial class Form1 : Form
    {
        public object ProductType { get; private set; }

        public Form1()
        {
            InitializeComponent();
            LoadDetails();
        }
        private void LoadDetails()
        {


            XmlDocument doc = new XmlDocument(); doc.Load("Details.xml");
            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node.Attributes["name"].Value; // Используйте маленькую букву 'n' для соответствия XML
                string designation = node["Designation"].InnerText; // Используйте InnerText для вложенных элементов
                string mass = node["Mass"].InnerText; // Используйте InnerText для вложенных элементов
                string litera = node["Litera"].InnerText; // Используйте InnerText для вложенных элементов
                string format = node["Format"].InnerText;
                string quantity = node["Quantity"].InnerText;
                listBox1.Items.Add(new Details(name,quantity, mass,format,designation,litera));
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void button1_click(object sender, EventArgs e)
        {



        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                propertyGrid1.SelectedObject = listBox1.SelectedItem;
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В программе существует несколько функций после входа в аккаунт, а именно импорт, который позволит вам посмотреть xml файл, который парсится, главное окно в которой по названию вы можете увидеть свойства у деталей и выход позволяющий вам выйти из программы. ","Справка",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void импортToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Import unforgiven = new Import();
            unforgiven.Show();
        }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Показываем диалоговое окно с подтверждением выхода
            DialogResult result = MessageBox.Show("Уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Проверяем результат нажатия кнопок в диалоговом окне
            if (result == DialogResult.Yes)
            {
                // Если пользователь выбрал "Да", закрываем приложение
                Close();
            }
            // Если пользователь выбрал "Нет", ничего не делаем
        }

        private void авторToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Программу сделал студент 4 курса 71 группы Елисеев Максим ", "Автор", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    Document document = new Document(PageSize.A4);
                    PdfWriter.GetInstance(document, stream);
                    document.Open();

                    // Создаем шрифт с поддержкой кириллицы
                    BaseFont bf = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    Font font = new Font(bf, 12);

                    PdfPTable table = new PdfPTable(6); // Создаем таблицу с 6 колонками
                    table.AddCell(new PdfPCell(new Phrase("Имя", font)));
                    table.AddCell(new PdfPCell(new Phrase("Количество", font)));
                    table.AddCell(new PdfPCell(new Phrase("Масса", font)));
                    table.AddCell(new PdfPCell(new Phrase("Формат", font)));
                    table.AddCell(new PdfPCell(new Phrase("Обозначение", font)));
                    table.AddCell(new PdfPCell(new Phrase("Литера", font)));

                    foreach (Details detail in listBox1.Items)
                    {
                        table.AddCell(new PdfPCell(new Phrase(detail.Name, font)));
                        table.AddCell(new PdfPCell(new Phrase(detail.Quantity, font)));
                        table.AddCell(new PdfPCell(new Phrase(detail.Mass, font)));
                        table.AddCell(new PdfPCell(new Phrase(detail.Format, font)));
                        table.AddCell(new PdfPCell(new Phrase(detail.Designation, font)));
                        table.AddCell(new PdfPCell(new Phrase(detail.Litera, font)));
                    }

                    document.Add(table); // Добавляем таблицу в документ
                    document.Close();
                }
            }
        }
    }
}