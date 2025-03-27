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

        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Najpierw wczytaj obraz!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Bitmap bmp = new Bitmap(pictureBox1.Image);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);

                    if (!(pixelColor.G > pixelColor.R && pixelColor.G > pixelColor.B))
                    {
                        bmp.SetPixel(x, y, Color.Black); 
                    }
                }
            }
            pictureBox1.Image = bmp;
            pictureBox1.Refresh(); 
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

            pictureBox1.Image.RotateFlip(rotateType);
            pictureBox1.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Najpierw wczytaj obraz!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    Color negativeColor = Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                    bmp.SetPixel(x, y, negativeColor);
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Najpierw wczytaj obraz!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
