using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace SteamScreenAdd
{
    public partial class Form1 : Form
    {
        // Variables
        string SteamDir = "";
        string UserID = "";
        string GameID = "";
        string SourceDir = "";

        public Form1()
        {
            InitializeComponent();
        }
        
        // Form Load Action
        private void Form1_Load(object sender, EventArgs e)
        {
            // Check config file
            if (!File.Exists(@"SteamScreenAdd.ini"))
            {
                // Get Steam Install Dir
                // TODO: Maybe add exception handling
                using (RegistryKey SteamDirKey = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam")) { SteamDir = (string)SteamDirKey.GetValue("SteamPath"); }

                // Try to fetch user ID automatically
                string UserDir = SteamDir + @"/userdata/";
                List<string> subfolders = new List<string>(Directory.EnumerateDirectories(UserDir));
                if (subfolders.Count > 1 || subfolders.Count < 1) { MessageBox.Show("Could not determine User ID automatically, please enter it in the text box yourself.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); } else { UserID = subfolders[0].Substring(subfolders[0].LastIndexOf("/") + 1); }

                // Write config file
                string[] settings = { SteamDir, UserID, GameID, SourceDir };
                using (StreamWriter defaultConfig = new StreamWriter(@"SteamScreenAdd.ini")) { foreach (string line in settings) defaultConfig.WriteLine(line); }
            }
            else
            {
                StreamReader ConfigReader = new StreamReader(@"SteamScreenAdd.ini");
                SteamDir = ConfigReader.ReadLine();
                UserID = ConfigReader.ReadLine();
                GameID = ConfigReader.ReadLine();
                SourceDir = ConfigReader.ReadLine();
                ConfigReader.Close();
            }

            // Fill boxes
            textBoxUserID.Text = UserID;
            textBoxGameID.Text = GameID;
            textBoxSource.Text = SourceDir;
        }

        // UserID Action
        private void UserID_Change(object sender, EventArgs e)
        {
            UserID = textBoxUserID.Text;
            var lines = File.ReadAllLines(@"SteamScreenAdd.ini");
            lines[1] = UserID;
            File.WriteAllLines(@"SteamScreenAdd.ini", lines);
        }

        // GameID Action
        private void GameID_Change(object sender, EventArgs e)
        {
            GameID = textBoxGameID.Text;
            var lines = File.ReadAllLines(@"SteamScreenAdd.ini");
            lines[2] = GameID;
            File.WriteAllLines(@"SteamScreenAdd.ini", lines);
        }

        // SourceDir Action
        private void SourceDir_Change(object sender, EventArgs e)
        {
            SourceDir = textBoxSource.Text;
            var lines = File.ReadAllLines(@"SteamScreenAdd.ini");
            lines[3] = SourceDir;
            File.WriteAllLines(@"SteamScreenAdd.ini", lines);
        }

        // Add images to Steam screenshot dir
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Check if source folder exists
            if (!Directory.Exists(SourceDir)) { MessageBox.Show("Image source directory does not exist, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            // Check if target folder exists
            string TargetDir = SteamDir + "/userdata/" + UserID + "/760/remote/" + GameID + "/screenshots/";
            if (!Directory.Exists(TargetDir)) { MessageBox.Show("Steam target directory does not exist, aborting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            // Setup file names
            string Date = DateTime.Now.ToString("yyyyMMddHHmmss") + "_";
            int Counter = 1;
            int FileCounter = 0;

            // Process jpg files
            foreach (string image in Directory.EnumerateFiles(SourceDir, "*.jpg", SearchOption.TopDirectoryOnly))
            {
                File.Copy(image, TargetDir + "/" + Date + Counter + ".jpg");

                // TODO: Create thumbnails
                Bitmap bitmap;
                using (Stream StreamBitmap = File.Open(image, FileMode.Open))
                {
                    Image StreamImage = Image.FromStream(StreamBitmap);
                    bitmap = new Bitmap(StreamImage);
                    ImageHandler.Save(bitmap, 300, 600, 90, TargetDir + "/thumbnails/" + Date + Counter + ".jpg");
                }

                Counter++;
                FileCounter++;
            }

            MessageBox.Show("Added " + FileCounter + " images to the Steam target directory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
