using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SimpleSteamIdler
{
    public partial class Form1 : Form
    {               
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("SteamAppID", textBox1.Text);
            Steamworks.SteamAPI.Init();                    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("SteamAppID", textBox1.Text);
            Steamworks.SteamAPI.Init();

            uint AchCount = Steamworks.SteamUserStats.GetNumAchievements();
            for (uint i = 0; i < AchCount; i++ )
            {
                string AchName = Steamworks.SteamUserStats.GetAchievementName(i);
                bool Unlocked;
                Steamworks.SteamUserStats.GetAchievement(AchName, out Unlocked);
                if (!Unlocked) Steamworks.SteamUserStats.SetAchievement(AchName);
            }

            Steamworks.SteamUserStats.StoreStats();
        }
    }
}
