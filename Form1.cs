using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Что_такое_переменная
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Column", "Столбик");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++) dataGridView1[1, i].Value = Convert.ToString(Math.Pow(Convert.ToInt32(dataGridView1[0, i].Value), 2));
            }
            catch (Exception)
            {
                MessageBox.Show("Дорогой дневник... Мне не передать всю боль и унижение, что я получаю, когда Вы ошибаетесь");
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            //сохраняем текст в файл
                for(int i = 0; i < dataGridView1.RowCount; i++)
                {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    System.IO.File.AppendAllText(filename, Convert.ToString(dataGridView1[j, i].Value) + " ");
                }
                System.IO.File.AppendAllText(filename, "\n");
                }
            
            //System.IO.File.WriteAllText(filename, Convert.ToString(dataGridView1.Rows));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string[] fileText = System.IO.File.ReadAllLines(filename);

            dataGridView1.Rows.Add(fileText.Length-1);

               for (int i = 0; i < dataGridView1.RowCount; i++ )
                {
                    for(int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        
                        switch(j)
                        {
                            case 0:
                                dataGridView1[j, i].Value = fileText[i].Substring(0, fileText[i].IndexOf(' ')); ;
                                
                                break;
                            case 1:
                                dataGridView1[j, i].Value = fileText[i].Substring(fileText[i].IndexOf(' '), fileText[i].Length-1); ;
                                break;
                        }
                        
                    }
                }
                //string l = fileText[k].Substring(fileText[k].IndexOf(' '), fileText.Length);
                //string l1 = fileText[k].Substring(fileText[k].IndexOf(' '));
                
            
            
        }
    }
}
