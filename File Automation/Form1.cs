using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using System.Linq;
namespace File_Automation
{
    public partial class Form1 : Form
    {
        private FolderBrowserDialog folderBrowserDialog1;
        private OpenFileDialog openFileDialog1;

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
                listBox1.Items.Add(textBox1.Text);

                /* foreach (string folderPath in folderBrowserDialog1.SelectedPath.Split(';'))
                 {
                     listBox1.Items.Add(folderPath); // Add selected paths to the list box
                 }*/

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.Items)
            {
                string folderPath = item.ToString();

                if(string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Please enter the number of days to delete files older than.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double days = Convert.ToDouble(textBox2.Text);

                if (Directory.Exists(folderPath))
                {
                    try
                    {
                        string[] files = Directory.GetFiles(folderPath);
                        DateTime today = DateTime.Now;

                        foreach (string file in files)
                        {
                            DateTime creationDate = File.GetLastWriteTime(file);
                            if ((DateTime.Now - creationDate).TotalDays >= days)
                            {
                                File.Delete(file);
                            }
                        }

                        MessageBox.Show($"Successfully Deleted files in '{folderPath}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting files in '{folderPath}': " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"The specified folder '{folderPath}' does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
