using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public struct ColorText
    {
        public Color graphic;
        public Color documents;
        public Color archive;
        public Color other;
    }
    public partial class Form1 : Form
    {
        public static ColorText ct;
        ListViewItem[] Savelist = new ListViewItem[50];
        public Form1()
        {
            InitializeComponent();
            ct.graphic = Color.DarkRed;
            ct.documents = Color.DarkOrange;
            ct.archive = Color.Gold;
            ct.other = Color.Green;
        }
        public void SaveList()
        {
            FileStream file = new FileStream(@"Files.dat", FileMode.Create, FileAccess.Write);
            StreamWriter sWriter = new StreamWriter(file);
            for (int i = 1; i < Savelist.Length; i++)
            {
                if (Savelist[i] == null)
                    continue;
                sWriter.WriteLine(Savelist[i].SubItems[0].Text + ";" + Savelist[i].SubItems[1].Text + ";" + Savelist[i].SubItems[2].Text);
            }
            sWriter.Close();
            file.Close();
        }
        public void GetFont()
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                listView1.Font = fd.Font;
            }
        }
        public void GetFiles(FileInfo[] file)
        {
            listView1.Items.Clear();
            for (int i = 0; i < file.Length; i++)
            {
                ListViewItem lvi = new ListViewItem(GetFileName(file[i].Name));
                string SizeFile = Convert.ToString(file[i].Length);
                string TypeFile = Convert.ToString(GetFileExtension(file[i].Name));
                lvi.Checked = true;
                if (TypeFile == "png" || TypeFile == "jpg" || TypeFile == "bmp" || TypeFile == "gif")
                {
                    lvi.ForeColor = ct.graphic;
                }
                else if (TypeFile == "docx" || TypeFile == "xlsx" || TypeFile == "pdf" || TypeFile == "txt")
                {
                    lvi.ForeColor = ct.documents;
                }
                else if (TypeFile == "zip" || TypeFile == "rar" || TypeFile == "7z")
                {
                    lvi.ForeColor = ct.archive;
                }
                else
                {
                    lvi.ForeColor = ct.other;
                }
                lvi.SubItems.Add(SizeFile);
                lvi.SubItems.Add(TypeFile);
                listView1.Items.Add(lvi);
                for (int y = 0; y < Savelist.Length; y++)
                {
                    if (Savelist[y] == null)
                    {
                        Savelist[y] = lvi;
                        break;
                    }
                }
            }

        }
        public string GetFileName(string fileName)
        {
            string name = "";
            char[] arr = fileName.ToCharArray();
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '.')
                {
                    index = i;
                }
            }
            for (int x = 0; x < index; x++)
            {
                name = name + arr[x];
            }
            return name;
        }
        public string GetFileExtension(string fileName)
        {
            string extension = "";
            char[] arr = fileName.ToCharArray();
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '.')
                {
                    index = i;
                }
            }
            for (int x = index + 1; x < arr.Length; x++)
            {
                extension = extension + arr[x];
            }
            return extension;
        }
        public TreeNode GetDir(DirectoryInfo dir)
        {
            treeView1.Nodes.Clear();
            DirectoryInfo[] LittleNode;
            TreeNode BossNode = new TreeNode(dir.FullName);
            try
            {
                FileInfo[] file = dir.GetFiles();
                GetFiles(file);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                LittleNode = dir.GetDirectories();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return BossNode;
            }
            foreach (DirectoryInfo d in LittleNode)
            {
                BossNode.Nodes.Add(GetDir(d));
            }

            return BossNode;

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(fbd.SelectedPath);
                treeView1.Nodes.Add(GetDir(dir));
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(e.Node.Text);
                FileInfo[] fInfo = dInfo.GetFiles();
                GetFiles(fInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            toolStripStatusLabel2.Text = listView1.CheckedItems.Count + " of " + listView1.Items.Count;
            long bytes = 0;
            for (int i = 0; i < listView1.CheckedItems.Count; bytes += int.Parse(listView1.CheckedItems[i].SubItems[1].Text), i++) { }
            toolStripStatusLabel1.Text = "Total bytes: " + bytes;
            int ShortCount = 0;
            int MediumCount = 0;
            int LongCount = 0;
            for (int i = 0; i < listView1.CheckedItems.Count; i++)
            {
                string Lenght = listView1.CheckedItems[i].SubItems[0].Text;
                var s = Lenght.ToCharArray();
                if (s.Length <= 8)
                {
                    ShortCount++;
                }
                if (s.Length > 8 && s.Length < 15)
                {
                    MediumCount++;
                }
                if (s.Length >= 15)
                {
                    LongCount++;
                }
            }
            chart1.Series[0].Points.Clear();
            DataPoint dpShort = new DataPoint(0, ShortCount);
            dpShort.AxisLabel = "Short";
            chart1.Series[0].Points.Add(dpShort);
            DataPoint dpMedium = new DataPoint(0, MediumCount);
            dpMedium.AxisLabel = "Medium";
            chart1.Series[0].Points.Add(dpMedium);
            DataPoint dpLong = new DataPoint(0, LongCount);
            dpLong.AxisLabel = "Long";
            chart1.Series[0].Points.Add(dpLong);
        }
        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(fbd.SelectedPath);
                treeView1.Nodes.Add(GetDir(dir));
            }
        }
        private void safeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveList();
        }
        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            SaveList();
        }
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFont();
        }
    }
}
