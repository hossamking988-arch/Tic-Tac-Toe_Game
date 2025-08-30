using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;
        enum enPlayer
        {
            Player1, 
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            InProgres
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }

        void EndGame()
        {
            lblTurn.Text = "Game Over";

            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player 1";
                    break;
                    case enWinner.Player2:
                    lblWinner.Text = "Player 2";
                    break;
                    default:
                    lblWinner.Text = "Draw";
                    break;

            }
            MessageBox.Show("Game Over","Game Over",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public bool CheckValues(Button btn1 ,  Button btn2, Button btn3)
        {
            if(btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.YellowGreen;
                btn2.BackColor = Color.YellowGreen;
                btn3.BackColor = Color.YellowGreen;

                if(btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    LoockButton();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    LoockButton();
                    return true;
                }
            }

            GameStatus.GameOver = false;
            return false;
        }


        public void CheckWinner()
        {
            if (CheckValues(button1, button2, button3))
                return;

            if (CheckValues(button4, button5, button6))
                return;
            if (CheckValues(button7, button8, button9))
                return;
            if (CheckValues(button1, button4, button7))
                return;
            if (CheckValues(button2, button5, button8))
                return;
            if (CheckValues(button3, button6, button9))
                return;
            if (CheckValues(button1, button5, button9))
                return;
            if (CheckValues(button3, button5, button7))
                return;


        }

        private void LoockButton()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }

        public void ChangeImage(Button btn)
        {
            if(btn.Tag.ToString() == "?")
            {
                switch(PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                     
                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;

                }
            }

            else
            {
                MessageBox.Show("Wrong Choice", "Wrong Choice", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            if(GameStatus.PlayCount == 9 && !GameStatus.GameOver)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
                LoockButton();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color white = Color.FromArgb(255, 255, 255, 255);

            Pen Pen = new Pen(white);
            Pen.Width = 5;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(Pen, 300, 150, 850, 150);
            e.Graphics.DrawLine(Pen, 300, 280, 850, 280);

            e.Graphics.DrawLine(Pen, 500, 50, 500, 395);
            e.Graphics.DrawLine(Pen, 650, 50, 650, 395);
        }

        private void ResetBtn(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
        }

        private void RestartGame()
        {
            ResetBtn(button1);
            ResetBtn(button2);
            ResetBtn(button3);
            ResetBtn(button4);
            ResetBtn(button5);
            ResetBtn(button6);
            ResetBtn(button7);
            ResetBtn(button8);
            ResetBtn(button9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.InProgres;
            lblWinner.Text = "In Progres";
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeImage(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeImage(button2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeImage(button3);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeImage(button4);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeImage(button5);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeImage(button6);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeImage(button7);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeImage(button8);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeImage(button9);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
