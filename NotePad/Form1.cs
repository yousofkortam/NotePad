using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NotePad
{
    public partial class NotePad_Form : Form
    {
        string path;
        public NotePad_Form()
        {
            InitializeComponent();
            path = null;
        }

        private void ResultText_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void wrapToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            if (save_FD.ShowDialog() == DialogResult.OK)
            {
                path = save_FD.FileName;
                ResultText.SaveFile(save_FD.FileName);
            }
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (open_FD.ShowDialog() == DialogResult.OK)
            {
                ResultText.LoadFile(open_FD.FileName);
                path = open_FD.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path == null)
            {
                SaveAs_Click(sender, e);
            }
            else
            {
                ResultText.SaveFile(path);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultText.Clear();
            path = null;
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotePad_Form newForm = new NotePad_Form();
            newForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ResultText.Text != "")
            {
                if (MessageBox.Show($"Do you want to save changes to {path}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
            }
            path = null;
            this.Close();
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                if (ResultText.SelectedText != "")
                {
                    ResultText.SelectionFont = fontDialog.Font;
                }else
                {
                    ResultText.Font = fontDialog.Font;  
                }
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (ResultText.SelectedText != "")
                {
                    ResultText.SelectionColor = colorDialog.Color;
                }
                else
                {
                    ResultText.ForeColor = colorDialog.Color;
                }
            }
        }
    }
}