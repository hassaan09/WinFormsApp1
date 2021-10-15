using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //This will filter the text files from other type files
            openFileDialog1.Filter = "Text Files |*.txt";
            openFileDialog1.ShowDialog();
            textBox.Text = File.ReadAllText(openFileDialog1.FileName);
            lblFileName.Text = openFileDialog1.FileName;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            textBox.Text = "";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*This line of code will check for file and path whether it exists or not
             saveFileDialog1.CheckFileExists = true;
             saveFileDialog1.CheckPathExists = true;
             //By default the extension will be set as txt file, so user doesn't have to do it himself
             saveFileDialog1.DefaultExt = "txt";
             saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            /*saveFileDialog1.FilterIndex = 2;
             saveFileDialog1.RestoreDirectory = true;*
             if (saveFileDialog1.ShowDialog() == DialogResult.OK)
             {
                 textBox.Text = saveFileDialog1.FileName;
             }
             */
            SaveFile();
        }
        private void SaveFile()
        {
            if (lblFileName.Text.Length == 0)
            {
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                 
                    File.WriteAllText(saveFileDialog1.FileName, textBox.Text);
                    lblFileName.Text = this.saveFileDialog1.FileName;
                    lblFileFreshStatus.Text = "";
                    lblStatus.Text = " saved";


                }
                else
                {
                    lblStatus.Text = "No name entered ";

                }

            }
            else
            {
                File.WriteAllText(fileToolStripMenuItem.Text, textBox.Text);
                lblFileFreshStatus.Text = "";
            }
        }
        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            lblFileFreshStatus.Text = "*";
        }

        private void exirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lblFileFreshStatus.Text == "*")
            {
                DialogResult exirdiagResult = MessageBox.Show("There are Unsaved Changes to the file, Do you Want to Save these Cahnges?", "Alert!, Unsaved Changes", MessageBoxButtons.YesNo);

                if (exirdiagResult == DialogResult.Yes)
                {
                    SaveFile();

                }
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hassaan Moeed \n FA18-BCS-044 \n Visual Programming \n Fall 2018");
            
        }

        private void fontModificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox.Font = fontDialog1.Font;
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            lblFileFreshStatus.Text = "*";
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lblFileFreshStatus.Text == "*")
            {
                DialogResult exitdiagResult = MessageBox.Show("There are Unsaved Changes to the file, Do you Want to Save these Cahnges?", "Alert!, Unsaved Changes", MessageBoxButtons.YesNo);

                if (exitdiagResult == DialogResult.Yes)
                {
                    SaveFile();

                }
            }
        }
    }
}
