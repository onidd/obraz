using System.Runtime.CompilerServices;

namespace obraz
{
    public partial class Form1 : Form
    {
        private Image originalImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Wybierz obraz";
                ofd.Filter = "Pliki graficzne|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Wszystkie pliki|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    originalImage = Image.FromFile(ofd.FileName);
                    pictureBox1.Image = (Image)originalImage.Clone();
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; 
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Najpierw wczytaj plik!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RotateFlipType rotateType = RotateFlipType.RotateNoneFlipNone;
            if (radioButton1.Checked) rotateType = RotateFlipType.Rotate90FlipNone;
            if (radioButton2.Checked) rotateType = RotateFlipType.Rotate180FlipNone;
            if (radioButton3.Checked) rotateType = RotateFlipType.Rotate270FlipNone;

            Image rotatedImage = (Image)originalImage.Clone();
            rotatedImage.RotateFlip(rotateType);
            pictureBox1.Image = rotatedImage;

        }
    }
}
