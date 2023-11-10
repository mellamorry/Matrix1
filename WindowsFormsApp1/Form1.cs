using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static int dim = 3; //размерность (dimention)
        int[,] OrigMatrix = new int [dim,dim]; //исходная матрица (original matrix)
        int i, j;

        public Form1()
        {
            InitializeComponent();
        }

        //При загрузке формы настраивается оформление: 3 строки и 3 столбца, заголовки строк и столбцов не видно
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();     
            dataGridView1.ColumnCount = dim;
            dataGridView1.RowCount= dim;
            for (i = 0; i < dim; i++)
            {
                dataGridView1.Columns[i].Width = Convert.ToInt32(dataGridView1.Width / dim-1);
            }
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;   
        }
        
        //Обработка значений, введённых в dataGridView1: если в ячейку введено что-то отличное от целого числа, то
        //в ячейку записывается 0. Событие - изменение значения в ячейке
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //пытаемся выполнить
            try 
                {
                //e.RowIndex и e.ColumnIndex - это индексы той ячейки, на которую сработало событие (которая была изменена)
                int MatrixValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                }
            //что делать, если не получилось выполнить блок try
            catch 
                {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                listBox1.Items.Add($"В матрице элемент {e.RowIndex+1}x{e.ColumnIndex+1} был заменён на 0.");
                }
        }

        //Заполнение матрицы значениями, введенными в dataGridView1
        private void button2_Click(object sender, EventArgs e)
        {
            for (i = 0; i < dim; i++)
            {
                for (j = 0; j < dim; j++)
                {
                    OrigMatrix[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                }
            }
        }

        //Заполнение матрицы случайными значениями и вывод в dataGridView1
        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (i = 0; i < dim; i++)
                {
                for (j=0; j < dim; j++ )
                    {
                    OrigMatrix[i, j] = rnd.Next(0, 10);
                    dataGridView1.Rows[i].Cells[j].Value = OrigMatrix[i, j];
                    }
                }
            
        }

    }
}
