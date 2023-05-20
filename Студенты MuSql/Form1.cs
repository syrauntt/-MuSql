using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Студенты_MuSql.Models;
using Студенты_MuSql.Repository;

namespace Студенты_MuSql
{
    public partial class Form1 : Form
    {
        int Updid = 0;
        IStudentsRepository rep;
        public Form1()
        {
            InitializeComponent();
            rep = new StudentsRepository("localhost", "University", "root", "root");
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Updid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            label5.Text = $"ID обновления : {Updid}";
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString() ; 
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString() ; 
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString() ; 
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString() ; 
            if (Updid > 0)
            {
                button3.Enabled = true;
            }
        }

        private void RefreshTable()
        {
            dataGridView1.DataSource = rep.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int RowsAffected = 0;
            RowsAffected = rep.Insert(new Students { Stu_Name = textBox1.Text, Stu_SurName = textBox2.Text , Stu_Age = int.Parse(textBox3.Text), Stu_AvgScore = int.Parse(textBox4.Text) });
            MessageBox.Show($"Rows Affected : {RowsAffected}");
            RefreshTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int RowsAffected = 0;
            RowsAffected = rep.Insert(new Students { Stu_Name = textBox1.Text, Stu_SurName = textBox2.Text, Stu_Age = int.Parse(textBox3.Text), Stu_AvgScore = int.Parse(textBox4.Text) });
            MessageBox.Show($"Rows Affected : {RowsAffected}");
            RefreshTable();
            Updid = 0;
            button3.Enabled = false;
        }
    }
}
