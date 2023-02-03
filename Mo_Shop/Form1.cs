using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mo_Shop
{
    public partial class Form1 : Form
    {
        #region MyRegion
        db db = new db();
        mobile mob = new mobile();
        int id;
        bool save = false;
        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (save)
            {
                mob.updat(new mobile { name = textBox1.Text , price = Convert.ToInt16(textBox2.Text) , number = Convert.ToInt16(textBox3.Text)}, id);
                button1.Text = "ثبت";
                save = false;
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = new db().mob.ToList();
            }
            else
            {
                mob.create(new mobile { name = textBox1.Text.ToString(), price = Convert.ToDouble(textBox2.Text), number = Convert.ToInt16(textBox3.Text) });
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                dataGridView1.DataSource = db.mob.ToList();
            }
                
            
               
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = mob.read(textBox4.Text);
            textBox4.Text = null;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.mob.ToList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mob = mob.read(id);
            textBox1.Text = mob.name;
            textBox2.Text = mob.price.ToString();
            textBox3.Text = mob.number.ToString();
            button1.Text  = "به روز رسانی";
            save = true;

        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult;
            result = MessageBox.Show("Are you sure you want to permanently delete this product?", "Delete product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if(result == DialogResult.Yes)
            {
                var q = from i in db.mob where i.id == id select i;
                if (q.Count() == 1)
                {
                    mobile m = new mobile();
                    m = q.Single();
                    m.delete(m, id);

                }
                
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = new db().mob.ToList();
            }

        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
        }
    }
    
}
