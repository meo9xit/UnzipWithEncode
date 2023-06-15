using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

namespace ExtractWithEncodingTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var encodings = Encoding.GetEncodings();
            comboBox1.DataSource = encodings;
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Zip file (.zip)|*.zip|All files (*.*)|*.*";
            ofd.Multiselect = false;
            ofd.ShowDialog();
            txtPath.Text = ofd.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var dir = Path.GetDirectoryName(txtPath.Text);
                ZipFile.ExtractToDirectory(txtPath.Text, dir, (comboBox1.SelectedItem as EncodingInfo).GetEncoding(), true);
                MessageBox.Show("Done!", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Somethings went wrong. \nCheck path in text box or you can now cast the tool into fire of Mount Doom!\n{ex.Message}", "Error");
            }
        }

        private void txtPath_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0)
            {
                txtPath.Text = files[0];
            }
        }

        private void txtPath_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
