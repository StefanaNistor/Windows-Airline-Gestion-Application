using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlinePAW.views
{
    public partial class GiveRatingView : Form
    {
        public GiveRatingView()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInView logInView = new LogInView();
            logInView.ShowDialog();
            this.Close();

        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            nameTB.DoDragDrop(nameTB.Text, DragDropEffects.Copy);
        }

        private void dateTimePicker1_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker1.DoDragDrop(dateTimePicker1.Value.ToString(), DragDropEffects.Copy);
        }

        private void ratingTB_MouseDown(object sender, MouseEventArgs e)
        {
            ratingTB.DoDragDrop(ratingTB.Text, DragDropEffects.Copy);
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            
            if (e.Data.GetDataPresent(DataFormats.Text) || e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Copy;
            }

            // create a new ListViewItem from the string
            ListViewItem item = new ListViewItem();
            item.Text = e.Data.GetData(DataFormats.Text).ToString();
            item.SubItems.Add(e.Data.GetData(DataFormats.StringFormat).ToString());
            listView1.Items.Add(item);

        }

        private void GiveRatingView_Load(object sender, EventArgs e)
        {

        }
    }
}
