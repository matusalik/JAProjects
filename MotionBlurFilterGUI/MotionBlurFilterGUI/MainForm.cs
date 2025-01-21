using System.Drawing.Imaging;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MotionBlurFilterGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.newSourceChosen = false;
            InitializeComponent();
            initComboBox();
            loadImages();
        }

        private void loadImages()
        {
            string ArrowPath = Path.Combine(Application.StartupPath, "Resources", "arrow.png");
            ArrowPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap ArrowImage = new Bitmap(ArrowPath);
            ArrowPicture.Image = ArrowImage;

            this.sourcePath = Path.Combine(Application.StartupPath, "Resources", "setter.jpg");
            SourcePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap SetterImage = new Bitmap(this.sourcePath);
            SourcePicture.Image = SetterImage;

            OutcomePicture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void initComboBox()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("C");
            comboBox1.Items.Add("Assembly");
            comboBox1.SelectedIndex = 0;
        }

        private void NewSourceButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Wybierz obraz",
                Filter = "Obrazy (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Wszystkie pliki (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Za³aduj obraz do PictureBox lub innego komponentu
                Bitmap selectedImage = new Bitmap(openFileDialog.FileName);
                SourcePicture.Image = selectedImage; // Przyk³ad: przypisanie do PictureBox
                this.sourcePath = openFileDialog.FileName;
            }
        }

        private void ApplyFilterButton_Click(object sender, EventArgs e)
        {
            Bitmap sourceBitmap = new Bitmap(this.sourcePath);
            Bitmap tempBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            int numberOfThreads = (int)NumberOfThreads.Value;
            int radius = 5;
            int width = sourceBitmap.Width;
            int height = sourceBitmap.Height;
            int chunkWidth = width / numberOfThreads;
            BitmapData bmpData = sourceBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            IntPtr ptr = bmpData.Scan0;
            BitmapData tempData = tempBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            IntPtr tempPtr = tempData.Scan0;
            Thread[] threads = new Thread[numberOfThreads];
            Stopwatch stopwatch = new Stopwatch();
            if (comboBox1.SelectedIndex == 0)
            {
                stopwatch.Start();
                for (int i = 0; i < numberOfThreads; i++)
                {
                    int startX = i * chunkWidth; //Starting point for this thread
                    int endX = (i == numberOfThreads - 1) ? width : (i + 1) * chunkWidth; //End point for this thread
                    threads[i] = new Thread(() => Program.ProcessChunkC(ptr, tempPtr, startX, endX, width, height, radius));
                    threads[i].Start();
                }
                foreach (Thread thread in threads)
                {
                    thread.Join();
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                stopwatch.Start();
                for (int i = 0; i < numberOfThreads; i++)
                {
                    int startX = i * chunkWidth; //Starting point for this thread
                    int endX = (i == numberOfThreads - 1) ? width : (i + 1) * chunkWidth; //End point for this thread
                    threads[i] = new Thread(() => Program.ProcessChunkASM(ptr, tempPtr, startX, endX, width, height, radius));
                    threads[i].Start();
                }
                foreach (Thread thread in threads)
                {
                    thread.Join();
                }
            }
            stopwatch.Stop();
            sourceBitmap.UnlockBits(bmpData);
            tempBitmap.UnlockBits(tempData);   
            String outputImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "blurredDog.jpg");
            tempBitmap.Save(outputImage, ImageFormat.Jpeg);
            OutcomePicture.Image = tempBitmap;
            TimeValueLabel.Text = stopwatch.ElapsedMilliseconds.ToString() + "ms";
        }
    }
}
