using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirrd
{
    public partial class Form1 : Form
    {
        static Random random = new Random();
        int pipeSpeed = 9;
        int gravity = 13;
        int score = 0;
       

        public Form1()
        {
            InitializeComponent();
        }


        private void gameTimerEvent(object sender, EventArgs e)
        {
            int rand_respawn = random.Next(-80, 80);
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -150 && pipeTop.Left < -150)
            {
                pipeBottom.Top = 370;
                pipeBottom.Top += rand_respawn;
                pipeBottom.Left = 700;

                pipeTop.Top = -390;
                pipeTop.Top += rand_respawn;
                pipeTop.Left = 700;

                score++;

            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Location.Y >= Screen.PrimaryScreen.Bounds.Height)
            {
                endGame();

            }

            if(score > 5)
            {
                if (score > 10)
                {
                    pipeSpeed = 14;

                    if (score > 20)
                    {
                        pipeSpeed = 17;

                    }
                }
                else
                {
                    pipeSpeed = 12;
                }

            }
        }


        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

                gravity = -13;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

                gravity = 13;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "    Game over !";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}