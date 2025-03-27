namespace obraz
{
    public partial class Form1 : Form
    {
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
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}
