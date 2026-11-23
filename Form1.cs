using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Зображення (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.Title = "Оберіть фото профілю";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var oldImage = pictureBox1.Image;
                    using (var stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                    {
                        pictureBox1.Image = Image.FromStream(stream);
                    }
                    oldImage?.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не вдалося завантажити фото: " + ex.Message);
                }
            }
        }
    }
}