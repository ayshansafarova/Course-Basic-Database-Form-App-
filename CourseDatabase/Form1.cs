using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CourseDatabase
{
    public partial class Form1 : Form
    {
        CourseEntities db;
        SqlConnection connection;
        SqlDataAdapter dataAdapter;
        SqlCommandBuilder commandBuilder;
        DataTable dataTable;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hey! Look at this: \n" +
                "1 - By pressing 'Show' button, you will see the list of students. \n" +
                "2 - After filtering, editing, adding and deleting data, you should press 'Update' button if you want to save changes in the main database(!!!) \n" +
                "3 - You don't need 'Add' button in order to add data.\n" +
                "4 - You can also sort by columns.", "Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
            addCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB;initial catalog=Course;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            string command = "SELECT * FROM Student";
            connection.Open();
            dataAdapter = new SqlDataAdapter(command, connection);
            dataTable = new DataTable();
            //dataSet = new System.Data.DataSet();
            //dataGridView1.DataSource = dataSet.Tables[0];
            //dataAdapter.Fill(dataSet, "Student");
            dataGridView1.DataSource = dataTable;
            dataAdapter.Fill(dataTable);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            commandBuilder = new SqlCommandBuilder(dataAdapter);
            //dataAdapter.Update(dataSet, "Student");
            dataAdapter.Update(dataTable);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you serious to delete this row?!", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes) ;
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                //dataAdapter.Update(dataSet, "Student");
            }
        }

        private void addCombo()
        {
            db = new CourseEntities();
            comboBox1.DataSource = db.Lesson.ToList();
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Student.Where(x => 
                            x.lesson_id == comboBox1.SelectedIndex+1).ToList();

        }
    }
}

