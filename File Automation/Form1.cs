using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace File_Automation
{
    public partial class Form1 : Form
    {
        private FolderBrowserDialog folderBrowserDialog1;

        public Form1()
        {
            InitializeComponent();
            folderBrowserDialog1 = new FolderBrowserDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string folderPath = textBox1.Text;
            
            double days = Convert.ToDouble(textBox2.Text);

           
            if (Directory.Exists(folderPath))
            {
                try
                {
          
                    string[] files = Directory.GetFiles(folderPath);

     
                    int timeZoneOffsetHours = 6;

                
                    DateTime utcTime = DateTime.UtcNow;

                
                    TimeSpan timeZoneOffset = TimeSpan.FromHours(timeZoneOffsetHours);

                   
                    DateTime today = utcTime + timeZoneOffset;

                 
                    foreach (string file in files)
                    {
                        /*    DateTime creationDate = File.GetCreationTime(file);
                            DateTime modification = File.GetLastWriteTime(file);*/
                        DateTime creationDate = File.GetLastWriteTime(file);
                        if ((Double)((today-creationDate).TotalDays) >= days)
                        {
                            File.Delete(file);
                        }
                    }

                    MessageBox.Show("successfully Deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting files: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The specified folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text, out _))
            {
                if (textBox2.Text.Length > 0)
                {
                    textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                    textBox2.SelectionStart = textBox2.Text.Length;
                }
            }
        }

    }
}
