using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace epsxtractor
{
    public partial class Main : Form
    {
        private List<DriveInfo> driveInfoList = new List<DriveInfo>();
        private List<DirectoryInfo> dirInfoList = new List<DirectoryInfo>();

        public Main()
        {
            InitializeComponent();


            DirectoryInfo dir = new DirectoryInfo(@"C:\test");
            foreach (var files in dir.GetFiles())
            {
                textBox2.Text += ("Filename: " + files.Name + "\r\n");
            }
            //DirectoryInfo dir = new DirectoryInfo(@"C:\test");
            //foreach (var files in dir.GetFiles())
            //{
            //    textBox2.Text += ("Filename: " + files.Name + "\r\n");
            //}

            //DriveInfo[] drives = DriveInfo.GetDrives();
            //foreach (DriveInfo drive in drives)
            //{
            //    if (drive.IsReady)
            //    {
            //        // textBox1.Text = textBox1.Text + "\n" + drive.Name;
            //        comboBox1.Items.Add(drive.Name + " - " + drive.VolumeLabel);
            //    }
            //}

            //foreach (var Drives in Environment.GetLogicalDrives())
            //{
            //    DriveInfo DriveInf = new DriveInfo(Drives);
            //    if (DriveInf.IsReady == true)
            //    {
            //        driveInfoList.Add(DriveInf);
            //        //comboBox1.Items.Add(DriveInf.Name);
            //    }
            //}
        }

        private void comboBox1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Clear(); //or whatever clears the listbox of current items.
            if (comboBox1.SelectedItem != null)
            {
                DriveInfo driveInfo = (from DriveInfo d in driveInfoList where d.Name == comboBox1.Text select d).First(); //or whatever you need to do to get the corresponding item from the list.

                textBox1.Text = ("Drive Name: " + driveInfo.Name + "\r\n"
                    + "Drive Type: " + driveInfo.DriveType + "\r\n"
                    + "Total Size: " + driveInfo.TotalSize + "\r\n"
                    + "Available Space: " + driveInfo.AvailableFreeSpace + "\r\n"
                    + "Total Free Space: " + driveInfo.TotalFreeSpace + "\r\n");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var Drives in Environment.GetLogicalDrives())
            {
                DriveInfo DriveInf = new DriveInfo(Drives);
                if (DriveInf.IsReady == true)
                {
                    driveInfoList.Add(DriveInf);
                    comboBox1.Items.Add(DriveInf.Name);
                }
            }

        }
    }
}
