using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public struct Images
        {
            public string name;
            public string path;
            public string height;
            public string width;
            public Bitmap image;
            public Bitmap copyimage;
            public Bitmap flagimage;
            public bool usedBefore;
        }
        static public Images[] images = new Images[200];
        public struct Copyright
        {
            public string text;
            public Font font;
            public Brush brush;
            public PointF point;
        }
        public static Copyright copyright = new Copyright();
        public static string PathSave = @"D:\";
        public Form1()
        {
            InitializeComponent();
            copyright.text = "BAN";
            copyright.font = new Font("Arial", 100);
            copyright.brush = new SolidBrush(Color.FromArgb(100,250,0,0));
            copyright.point = new Point(100,100);

        }
        //Функция для сортировки массива
        public void Sort()
        {
            bool flag = true;
            while(flag == true)
            {
                flag = false;
                for(int i = images.Length-1; i > 1; i--)
                {
                    if (images[i-1].name == null && images[i].name != null)
                    {
                        flag = true;
                        images[i - 1].name = images[i].name;
                        images[i - 1].path = images[i].path;
                        images[i - 1].height = images[i].height;
                        images[i - 1].width = images[i].width;
                        images[i - 1].image = images[i].image;
                        images[i - 1].copyimage = images[i].copyimage;
                        images[i - 1].usedBefore = images[i].usedBefore;
                    }
                }

            }
        }
        //Функция для прорисовки элементов в ленте
        public void DrawLargeImage()
        {
            imageList1.Images.Clear();
            listView1.Items.Clear();
            for (int i = 0; i < Form1.images.Length - 1; i++) 
            { 
                if (Form1.images[i].image != null) 
                {
                    images[i].flagimage = images[i].image;
                    images[i].copyimage = images[i].image;
                    if (images[i].usedBefore == false)
                    {
                        imageList1.Images.Add(images[i].image);
                        ListViewItem lvi = new ListViewItem();
                        lvi.ImageIndex = i;
                        listView1.Items.Add(lvi);
                    }
                    else
                    {
                        imageList1.Images.Add(images[i].flagimage);
                        ListViewItem lvi = new ListViewItem();
                        lvi.ImageIndex = i;
                        listView1.Items.Add(lvi);
                    }
                } 
                else 
                { 
                    break; 
                } 
            }
        }
        //Функция для накладывания текста на фото
        public void DrawCopyright()
        {
            try
            {
                int selectIndex = listView1.FocusedItem.Index;
                images[selectIndex].copyimage = images[selectIndex].image;
                Graphics g = Graphics.FromImage(images[selectIndex].copyimage);
                g.DrawString(copyright.text, copyright.font, copyright.brush, copyright.point);
                pictureBox1.Image = images[selectIndex].copyimage;
                Bitmap b = new Bitmap(imageList2.Images[0]);
                Graphics dc = Graphics.FromImage(images[selectIndex].flagimage);
                g.DrawImage(b, 0, 0);
            }
            catch
            {
            }
        }
        public void DrawCopyrightAll()
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (images[i].image != null)
                {
                    images[i].copyimage = images[i].image;
                    Graphics g = Graphics.FromImage(images[i].copyimage);
                    g.DrawString(copyright.text, copyright.font, copyright.brush, copyright.point);
                    images[i].copyimage.Save(@"D:\Test\"+i+".bmp",System.Drawing.Imaging.ImageFormat.Bmp);
                    Bitmap b = new Bitmap(imageList2.Images[0]);
                    Graphics dc = Graphics.FromImage(images[i].flagimage);
                    g.DrawImage(b, 0, 0);
                }
                else
                    break;
            }
        }
        //Открытиe файлов
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opd = new OpenFileDialog();
                if (opd.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < images.Length; i++)
                    {
                        if (images[i].name == null)
                        {
                            images[i].name = opd.SafeFileName;
                            images[i].path = opd.FileName;
                            images[i].image = (new Bitmap(opd.FileName));
                            images[i].height = Convert.ToString(images[i].image.PhysicalDimension.Height);
                            images[i].width = Convert.ToString(images[i].image.PhysicalDimension.Width);
                            images[i].usedBefore = false;
                            break;
                        }
                    }
                    DrawLargeImage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog(); 
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { 
                foreach(string imagefile in Directory.EnumerateFiles(fbd.SelectedPath))
                { 
                    try 
                    {
                        for (int i = 0; i < images.Length; i++)
                        {
                            if (images[i].name == null)
                            {
                                images[i].name = imagefile;
                                images[i].path = imagefile;
                                images[i].image = (new Bitmap(imagefile));
                                images[i].height = Convert.ToString(images[i].image.PhysicalDimension.Height);
                                images[i].width = Convert.ToString(images[i].image.PhysicalDimension.Width);
                                images[i].usedBefore = false;
                                break;
                            }
                        }
                    } 
                    catch (Exception ex) 
                    { 
                    }
                }
                DrawLargeImage();
            }
        }
        //Выход
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Загрузка выбранного элемента в окно
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIndex = listView1.FocusedItem.Index;
            pictureBox1.Image = images[selectIndex].copyimage;
        }
        //Копирайт и загрузка в DataGridView
        private void button1_Click(object sender, EventArgs e)
        {
            DrawCopyright();
            DrawLargeImage();
            for (int i = 0; i < images.Length; i++)
            {
                if (images[i].name != null && images[i].usedBefore == false)
                {
                    dataGridView1.Rows.Add(new string[] { images[i].name, images[i].width, images[i].height, copyright.text });
                    images[i].usedBefore = true;
                    break;
                }
                else
                    continue;
            }
        }
        //Batch mod
        private void button3_Click(object sender, EventArgs e)
        {
            DrawCopyrightAll();
            for (int i = 0; i < images.Length; i++)
            {
                if (images[i].name != null && images[i].usedBefore == false)
                {
                    images[i].usedBefore = true;
                    dataGridView1.Rows.Add(new string[] { images[i].name, images[i].width, images[i].height, copyright.text });
                }
                else
                    break;
            }
        }
        //Сохранение одной картинки
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    sfd.Title = "Сохранить картинку как...";
                    sfd.OverwritePrompt = true;
                    sfd.CheckPathExists = true;
                    sfd.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                    sfd.ShowHelp = true;
                    int selectedIndex = listView1.FocusedItem.Index;
                    images[selectedIndex].copyimage.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Инфо
        private void памагитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Я вижу ты отчаялся, раз пришел ко мне:)");
        }
        //Изменение текста, шрифта и цвета копирайта
        private void текстКопирайтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
        //Изменение директории сохранения
        private void папкаСКопирайтамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            PathSave = fbd.SelectedPath;
        }
        //Удаление с ленты
        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int selectIndex = listView1.FocusedItem.Index;
                images[selectIndex].name = null;
                images[selectIndex].path = null;
                images[selectIndex].height = null;
                images[selectIndex].width = null;
                images[selectIndex].image = null;
                images[selectIndex].copyimage = null;
                images[selectIndex].usedBefore = false;
            }
            Sort();
            DrawLargeImage();
        }
    }
}
