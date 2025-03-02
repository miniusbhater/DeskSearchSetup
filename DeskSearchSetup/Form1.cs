using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Cryptography;
using IWshRuntimeLibrary;

namespace DeskSearchSetup
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string programfolder = textBox1.Text;
            if (!Directory.Exists(programfolder))
            {
                Directory.CreateDirectory(programfolder);
            }

            // desksearch cool yaeh
            string download = "https://github.com/miniusbhater/DeskSearch/raw/main/DeakSearch.exe";
            string directory = textBox1.Text;
            string file = "DeskSearch.exe";
            string full = Path.Combine(directory, file);

            using (WebClient webclient = new WebClient())
            {
                webclient.DownloadProgressChanged += (s, ev) =>
                {
                    label1.Text = $"Please wait {ev.ProgressPercentage}%";
                };
                webclient.DownloadFileCompleted += (s, ev) =>
                {
                    label1.Text = "If you instaled .net wait";
                    if (checkBox2.Checked)
                    {
                        Process.Start(full);
                    }

                    string shortcutName = "DeskSearch.lnk";
                    string targetPath = @"C:\Program Files (x86)\DeskSearch\DeskSearch.exe";
                    string startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
                    string shortcutPath = Path.Combine(startMenuPath, "Programs", shortcutName);
                    try
                    {
                        WshShell shell = new WshShell();
                        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                        shortcut.TargetPath = targetPath;
                        shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
                        shortcut.Save();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("something went beepy boopy wrong with making a start menu shortcut :(");
                    }




                }
            ;
                webclient.DownloadFileAsync(new Uri(download), full);
            }

            // readme download
            string download2 = "https://raw.githubusercontent.com/miniusbhater/DeskSearch/main/README.txt";
            string directory2 = textBox1.Text;
            string file2 = "README.txt";
            string full2 = Path.Combine(directory2, file2);

            using (WebClient webclient2 = new WebClient())
            {
                webclient2.DownloadProgressChanged += (s, ev) =>
                {
                    label1.Text = $"Please wait {ev.ProgressPercentage}%";
                };

                webclient2.DownloadFileCompleted += (s, ev) =>
                {
                    label1.Text = "If you downloaded .net then wait";
                    if (checkBox3.Checked)
                    {
                        Process.Start(full2);
                    }
                };
                webclient2.DownloadFileAsync(new Uri(download2), full2);
            }

            // .net x64
            if (checkBox5.Checked)
            {
                string download1 = "https://download.visualstudio.microsoft.com/download/pr/fc8c9dea-8180-4dad-bf1b-5f229cf47477/c3f0536639ab40f1470b6bad5e1b95b8/windowsdesktop-runtime-8.0.13-win-x64.exe";
                string directory1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string file1 = "windowsdesktop-runtime-8.0.13-win-x64.exe";
                string full1 = Path.Combine(directory1, file1);

                using (WebClient webclient1 = new WebClient())
                {
                    webclient1.DownloadFileCompleted += (s, ev) =>
                    {
                        if (ev.Error == null)
                        {
                            Process.Start(full1);
                        }
                        else
                        {
                            MessageBox.Show("Download failed: " + ev.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };
                    webclient1.DownloadFileAsync(new Uri(download1), full1);
                }
            }

            // .net x86
            if (checkBox6.Checked)
            {
                string download11 = "https://download.visualstudio.microsoft.com/download/pr/b1827c52-ec83-4b3e-8d24-f321276bcdea/812e8d5871111cdc02cc82209c7d45fd/windowsdesktop-runtime-8.0.13-win-x86.exe";
                string directory11 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string file11 = "windowsdesktop-runtime-8.0.13-win-x86.exe";
                string full11 = Path.Combine(directory11, file11);

                using (WebClient webclient11 = new WebClient())
                {
                    webclient11.DownloadFileCompleted += (s, ev) =>
                    {
                        if (ev.Error == null)
                        {
                            Process.Start(full11);
                        }
                    };
                    webclient11.DownloadFileAsync(new Uri(download11), full11);
                }
            }

            // Download again to startup because im lazy :P
            if (checkBox1.Checked)
            {
                string download111 = "https://github.com/miniusbhater/DeskSearch/raw/main/DeakSearch.exe";
                string directory111 = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                string file111 = "DeskSearch.exe";
                string full111 = Path.Combine(directory111, file111);

                using (WebClient webclient111 = new WebClient())
                {
                    webclient111.DownloadProgressChanged += (s, ev) =>
                    {
                        label1.Text = $"Installing: {ev.ProgressPercentage}%";
                    };

                    webclient111.DownloadFileCompleted += (s, ev) =>
                    {
                        label1.Text = "Installed!";
                    };
                    webclient111.DownloadFileAsync(new Uri(download111), full111);
                }
            }

            // Discord
            if (checkBox4.Checked)
            {
                var open = new ProcessStartInfo
                {
                    FileName = "https://discord.gg/vgGVHhfBcf",
                    UseShellExecute = true
                };
                Process.Start(open);




            }
        }
        







        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
