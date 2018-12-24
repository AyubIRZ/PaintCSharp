using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace paint_ayub
{
    public partial class Form1 : Form
    {
        Graphics j;
        public Form1()
        {
            InitializeComponent();
            j = pictureBox1.CreateGraphics();

        }
        public string shape;
        public bool draw=false;
        private void button_selectColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button_color.BackColor = colorDialog1.Color;
        }

        int x, y, lx, ly = 0;
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public void mainMouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            x = e.X;
            y = e.Y;
            initX = null;
            initY = null;

        }
        int? initX = null;
        int? initY = null;
        public void mainMouseMove(object sender, MouseEventArgs e)
        {
            
            if (draw)
            {
                
                if(shape=="pen")
                {
                    j.DrawLine(new Pen(button_color.BackColor,float.Parse(toolStripComboBox1.SelectedItem.ToString())), new Point(initX ?? e.X, initY ?? e.Y), new Point(e.X, e.Y));
                }
                if (shape == "eraser")
                {
                    j.DrawLine(new Pen(Color.White, float.Parse(toolStripComboBox1.SelectedItem.ToString())), new Point(initX ?? e.X, initY ?? e.Y), new Point(e.X, e.Y));
                }
                initX = e.X;
                initY = e.Y;
            }
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
            lx = e.X;
            ly = e.Y;
            if(shape=="line")
            {
                Graphics l = pictureBox1.CreateGraphics();
                l.DrawLine(new Pen(new SolidBrush(button_color.BackColor), Convert.ToInt32(toolStripComboBox1.SelectedItem)), new Point(x, y), new Point(lx, ly));
            }
            Graphics g = pictureBox1.CreateGraphics();
            switch (shape)
            {
                case "rectangle":
                    g.DrawRectangle(new Pen(new SolidBrush(button_color.BackColor),Convert.ToInt32(toolStripComboBox1.SelectedItem)), x, y, lx - x, ly - y);
                    break;
                case "ellipse":
                    g.DrawEllipse(new Pen(new SolidBrush(button_color.BackColor), Convert.ToInt32(toolStripComboBox1.SelectedItem)), x, y, lx - x, ly - y);
                    break;
                case "triangle":
                    g.DrawPolygon(new Pen(new SolidBrush(button_color.BackColor),float.Parse(toolStripComboBox1.SelectedItem.ToString())),new Point[] {new Point(x, e.Y+y), new Point(e.X , e.Y), new Point(e.X / 2+x, y) });
                    break;
                case "ab":
                    g.DrawString(toolStripTextBox1.Text,new Font(family[toolStripComboBox2.SelectedIndex],float.Parse(toolStripComboBox3.Text),FontStyle.Regular),new SolidBrush(button_color.BackColor),new PointF(e.X,e.Y));
                    break;


            }

        }

        ///////////////////////////////////////////////// End of Main Panel  ///////////////////////////////////////////////////

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(" Are you sure you want to exit? ","",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button_pen_Click(object sender, EventArgs e)
        {
            shape = "pen";
        }

        private void button_line_Click(object sender, EventArgs e)
        {
            shape = "line";
        }

        private void button_ellipse_Click(object sender, EventArgs e)
        {
            shape = "ellipse";
        }

        private void button_rectangle_Click(object sender, EventArgs e)
        {
            shape = "rectangle";
        }

        private void button_triangle_Click(object sender, EventArgs e)
        {
            shape = "triangle";
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            button_color.BackColor = button_1.BackColor;
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            button_color.BackColor = button_2.BackColor;
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            button_color.BackColor = button_3.BackColor;
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            button_color.BackColor = button_4.BackColor;
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            button_color.BackColor = button_5.BackColor;
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            button_color.BackColor = button_6.BackColor;
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            button_color.BackColor = button_7.BackColor;
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            button_color.BackColor = button_8.BackColor;
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            button_color.BackColor = button_9.BackColor;
        }

        private void button_10_Click(object sender, EventArgs e)
        {
            button_color.BackColor = button_10.BackColor;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button_color.BackColor = button11.BackColor;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button_color.BackColor = button12.BackColor;
        }

        private void button_ab_Click(object sender, EventArgs e)
        {
            shape = "ab";
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "jpeg file |*.jpg| bmp file |*.bmp| png file |*.png";
            op.Title = "open a picture";
            
            if(op.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = (Image)Image.FromFile(op.FileName).Clone();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "jpeg file |*.jpg| bitmap file |*.bmp| png file |*.png";
            op.Title = "open a picture";

            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = (Image)Image.FromFile(op.FileName).Clone();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Rectangle rect = pictureBox1.RectangleToScreen(pictureBox1.ClientRectangle);
            g.CopyFromScreen(rect.Location, Point.Empty, pictureBox1.Size);
            g.Dispose();
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Save your picture";
            sf.Filter = "jpeg file |*.jpg| bitmap file |*.bmp| png file |*.png";
            sf.FileName = "Untiteld";
            if (sf.ShowDialog()==DialogResult.OK)
            {
                bool ex = false;
                if(File.Exists(sf.FileName))
                {
                    if (MessageBox.Show("File already exists!\nDo you want to replace it?\n", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        File.Delete(sf.FileName);
                        ex = false;
                    }
                    else
                        ex = true;
                }
                if(ex==false)
                {
                    if (sf.FileName.Contains(".jpg"))
                    {
                        bmp.Save(sf.FileName, ImageFormat.Jpeg);
                    }
                    else if (sf.FileName.Contains(".bmp"))
                    {
                        bmp.Save(sf.FileName, ImageFormat.Bmp);
                    }
                    else if (sf.FileName.Contains(".png"))
                    {
                        bmp.Save(sf.FileName, ImageFormat.Png);
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = button_color.BackColor;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem.PerformClick();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" This project is presented to Mr. Ghasemzadeh\n The hardworking and great master of us\n Thank you for everything you thaught us\n");
        }

        private void button_eraser_Click(object sender, EventArgs e)
        {
            shape = "eraser";
        }
        FontFamily[] family = FontFamily.Families;
        private void Form1_Load(object sender, EventArgs e)
        {
            FontFamily[] family = FontFamily.Families;
            foreach(FontFamily fs in FontFamily.Families)
            {
                toolStripComboBox2.Items.Add(fs.Name);
            }
            toolStripComboBox2.SelectedIndex = 0;
        }

    }
}
