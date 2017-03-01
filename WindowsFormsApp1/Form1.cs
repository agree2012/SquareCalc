using SquareCalculator.BI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();
        }
        
        public void button_activate_Click_1(object sender, EventArgs e)
        {   
            pictureBox1.Load(Application.StartupPath + @"\cbmp2.bmp");
            Bitmap bmp = new Bitmap(pictureBox1.Image.Width+1, pictureBox1.Image.Height+1);
            pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height));
            pictureBox1.Image = bmp;
            var res = Processor.Calc(bmp);
            MessageBox.Show($"Количество квадратов: {res.Square} Количество прямоугольников: {res.Rectangle} ", @"Количество квадратов", MessageBoxButtons.OK);                    
        }   
    }          
}

