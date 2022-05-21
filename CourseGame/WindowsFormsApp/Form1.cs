using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EngineLibrary.EngineComponents;
using GameLibrary;
using GameLibrary.Game;
using GameLibrary.Platformer;
using Color = System.Drawing.Color;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private  RenderingApplication application;
        private  PlatformerScene mazeScene;
        public Form1()
        {
            InitializeComponent();

            GameEvents.ChangeHealth += ChangeHealth;
            GameEvents.EndGame += EndGame;
            GameEvents.ChangeCount += ChangeCout;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            this.ClientSize = new System.Drawing.Size(258, 104);
            application = new RenderingApplication(); 
            mazeScene = new PlatformerScene();
            application.SetScene(mazeScene);
            application.Run();
        }
        private void EndGame(string winPlayer)
        {
            this.ClientSize = new System.Drawing.Size(900, 600);
            BluePlayerHealth.Visible = false;
            RedPlayerHealth.Visible = false;
            BPCountBullets.Visible = false;
            RPCountBullets.Visible = false;
            BluePlayerHealth.Text = "";
            RedPlayerHealth.Text = "";
            BPCountBullets.Text = "";
            RPCountBullets.Text = "";
            button1.Visible = false;
            WinPlayer.Visible = true;
            WinPlayer.Top = 300;
            WinPlayer.Left = 300;
            WinPlayer.ForeColor = Color.Yellow;
            WinPlayer.BackColor = Color.Transparent;
            WinPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            WinPlayer.Size = new System.Drawing.Size(100, 100);
            WinPlayer.Font = new System.Drawing.Font("Arial", 32, System.Drawing.FontStyle.Bold);
            this.BackgroundImage = new Bitmap("Resources/Фон.png");
            WinPlayer.Text = winPlayer + " Win!";
            GameEvents.EndGame -= EndGame;
            
           
        }

        private void ChangeHealth(string player, int value)
        {
            if (player == "Blue Player")
                BluePlayerHealth.Text = value.ToString();
            else
                RedPlayerHealth.Text = value.ToString();
            if (BluePlayerHealth.Text == "0")
            {
                EndGame("Second Player");
            }
            else if (RedPlayerHealth.Text == "0")
            {
                
                EndGame("First Player");
            }
        }
        private void ChangeCout(string player, int count)
        {
            if (player == "Blue Player")
                BPCountBullets.Text = count.ToString();
            else
                RPCountBullets.Text = count.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void WinPlayer_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
