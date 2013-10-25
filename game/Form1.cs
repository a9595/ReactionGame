using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        Random _r = new Random(Environment.TickCount);
        List<int> _generatedNumbers = new List<int>();
        Button[] buttons = new Button[16];
        ToolTip _myTip = new ToolTip();
        RadioButton[] Level = new RadioButton[3];
        int _minGenerated, _maxGenerated;
        float CorrectSelectedDigitsCount;
        public Form1()
        {
            InitializeComponent();
            CreateControl();
            //Randomizer();
        }

        public new void CreateControl()
        {
            #region створення кнопок(круглих причьом) і навішуєм подсказкі на контроли

            for (int i = 0, x = 120, y = 15; i < buttons.Length; i++, x += 65)
            {
                if (i % 4 == 0 && i >= 4) //і>=4 - шоб не здвигався самий перший ряд вниз
                {
                    y += 55;
                    x = 120;
                }
                buttons[i] = new Button
                                 {
                                     BackColor = Color.DarkSeaGreen,
                                     Font = new Font("Microsoft Sans Serif", 14),
                                     Size = new Size(60, 50),
                                     Location = new Point(x, y),
                                     Enabled = false,
                                     Text = "?",
                                     Name = Convert.ToString(i) //називаєм кожну кнопку її індексом, шоб легше було доступатись
                                 };
                buttons[i].Click += DigitsClick;
                //робимо регіон кнопки - круглим
                var buttonPath = new GraphicsPath();
                buttonPath.AddEllipse(0, 0, buttons[i].Width, buttons[i].Height);
                Region buttonRegion = new Region(buttonPath);
                buttons[i].Region = buttonRegion;
                //убераєм рамку, а то не гарне коло виходить (з якойсь рамкой)
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].FlatAppearance.BorderSize = 0;

                _myTip.SetToolTip(buttons[i], "цифра"); //ставим подсказку
                Controls.Add(buttons[i]);
            }
            labelPercents.Text = "0%";
            labelSeconds.Text = "0";
            //вішаєм подсказкі
            _myTip.SetToolTip(StartButton, "Розпочати гру");
            _myTip.SetToolTip(trackBarScores, "Кількість очків");
            _myTip.SetToolTip(progressBarTime, "Залишилось часу");
            _myTip.SetToolTip(listBox, "Правильні числа");
            _myTip.SetToolTip(labelPercents, "Відсоток вгаданих чисел");
            _myTip.SetToolTip(labelSeconds, "Залишилось часу");
            _myTip.SetToolTip(TimeSetter, "Час гри (в секундах)");
            #endregion

            #region рівні складності(радіобатони)

            for (int i = 0; i < 3; i++)
                Level[i] = new RadioButton();
            Level[0].Text = "Легко";
            Level[0].Checked = true;
            Level[0].Location = new Point(11, 290);
            Level[0].ForeColor = Color.Green;
            _myTip.SetToolTip(Level[0], "Числа від 1 до 16");
            Level[1].Text = "Нормально";
            Level[1].Location = new Point(11, 315);
            Level[1].ForeColor = Color.DarkSalmon;
            _myTip.SetToolTip(Level[1], "Числа від 1 до 30");
            Level[2].Text = "Party Hard";
            Level[2].Location = new Point(11, 340);
            Level[2].ForeColor = Color.Red;
            _myTip.SetToolTip(Level[2], "Числа від -50 до 50");
            for (int i = 0; i < 3; i++)
                Controls.Add(Level[i]);

            #endregion
        }
        /// <summary>
        /// Заповнення кнопок випадковими унікальними числами
        /// </summary>
        public void Randomizer()
        {
            _generatedNumbers.Clear();
            do
            {
                int random = 0;
                if (Level[0].Checked)//easy level selected
                    random = _r.Next(1, 17);
                if (Level[1].Checked) //normal
                    random = _r.Next(1, 31);
                if (Level[2].Checked) //partyHard
                    random = _r.Next(-50, 51);
                if (!_generatedNumbers.Contains(random))
                    _generatedNumbers.Add(random);
            } while (_generatedNumbers.Count < 16);
            for (int i = 0; i < 16; i++)
            {
                buttons[i].Text = _generatedNumbers[i].ToString(CultureInfo.InvariantCulture);
            }
            _minGenerated = _generatedNumbers.Min();
            _maxGenerated = _generatedNumbers.Max();

        }
        /// <summary>
        /// Клікі по цифрам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigitsClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int digit = Convert.ToInt32(clickedButton.Text);
            if (listBox.Items.Count != 0 && digit > Int32.Parse(listBox.Items[(listBox.Items.Count - 1)].ToString()))
            {
                CorrectSelectedDigitsCount++;
                labelPercents.Text = (CorrectSelectedDigitsCount / 16 * 100).ToString(CultureInfo.InvariantCulture) + "%";
                trackBarScores.Value = (int)CorrectSelectedDigitsCount;
                listBox.Items.Add(digit);
                buttons[Int32.Parse(clickedButton.Name)].Enabled = false;
                buttons[Int32.Parse(clickedButton.Name)].BackColor = Color.Gray;
                if (digit == _maxGenerated)
                {
                    //MessageBox.Show("Game over");
                    GameOver();
                }
            }

            if (listBox.Items.Count == 0) //при виборі самого першого числа
            {
                CorrectSelectedDigitsCount++;
                labelPercents.Text = (CorrectSelectedDigitsCount / 16 * 100).ToString(CultureInfo.InvariantCulture) + "%";
                trackBarScores.Value = (int)CorrectSelectedDigitsCount;
                listBox.Items.Add(digit);
                buttons[Int32.Parse(clickedButton.Name)].Enabled = false;
                buttons[Int32.Parse(clickedButton.Name)].BackColor = Color.Gray;
                if (digit == _maxGenerated)
                {
                    //MessageBox.Show("Game over");
                    GameOver();
                }
            }

        }

        /// <summary>
        /// Натиснення кнопки старту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameStartClick(object sender, EventArgs e)
        {
            if (StartButton.Text.StartsWith("Lat"))
            {
                listBox.Items.Clear();
                Randomizer();
                for (int i = 0; i < 16; i++)
                {
                    buttons[i].Enabled = true;
                    buttons[i].BackColor = Color.DarkSeaGreen;
                }
                for (int i = 0; i < 3; i++)
                    Level[i].Enabled = false;
                StartButton.Text = "Здатися. Завершити гру";
                HelpButton.Enabled = false;
                TimeSetter.Enabled = false;
                labelPercents.Text = "0%";
                labelSeconds.Text = "0";
                CorrectSelectedDigitsCount = 0;

                progressBarTime.Value = 0;
                progressBarTime.Minimum = 0;
                progressBarTime.Maximum = (int)TimeSetter.Value * 10;
                progressBarTime.Step = 1;
                timer.Start();
            }
            else
            {
                GameOver();
            }
        }

        /// <summary>
        /// шо робиться при завершенні гри
        /// </summary>
        void GameOver()
        {
            timer.Stop();
            for (int i = 0; i < 16; i++)
            {
                buttons[i].Enabled = false;
                buttons[i].BackColor = Color.Gray;
            }
            TimeSetter.Enabled = true;
            StartButton.Enabled = true;
            HelpButton.Enabled = true;

            string finalText = "Ви підібрали " + labelPercents.Text + " чисел \n за " +
                               (progressBarTime.Value / 10).ToString(CultureInfo.InvariantCulture) + "секунд";
            string rezultGeneral = "";
            if ((CorrectSelectedDigitsCount / 16 * 100) < 30)
                rezultGeneral = "\nВам потрібно ще трохі пограти і Ваш результат обов'язково покращиться =)";
            else if ((CorrectSelectedDigitsCount / 16 * 100) >= 30 && (CorrectSelectedDigitsCount / 16 * 100) < 60)
                rezultGeneral = "\nХмм.. доволі непоганий результат. Ви схильні до швидкого розвитку уваги";
            else if ((CorrectSelectedDigitsCount / 16 * 100) >= 60 && (CorrectSelectedDigitsCount / 16 * 100) < 85)
                rezultGeneral = "\nДуже добре. Реакція мов у професійного боксера =)";
            else if ((CorrectSelectedDigitsCount / 16 * 100) >= 85 && (CorrectSelectedDigitsCount / 16 * 100) <= 99)
                rezultGeneral = "\nПрекрасно. Ви майже встановили світовий рекорд. Ще трошки захоплюючої гри і результат не заставить Вас чекати";
            else if ((CorrectSelectedDigitsCount / 16 * 100) == 100)
                rezultGeneral = "\nОоогооо. Це неймовірно. ВИ встановили світовий рекорд!!! У Вас прекрасний потенціал до розвитку. Я в шооці прям";

            MessageBox.Show(finalText + rezultGeneral, "Гру завершенно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            for (int i = 0; i < 3; i++)
                Level[i].Enabled = true;
            progressBarTime.Value = 0;
            trackBarScores.Value = 0;
            StartButton.Text = "Lat's play bro";
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (progressBarTime.Value == (int)TimeSetter.Value * 10)
            {
                timer.Stop();
                GameOver();
            }


            progressBarTime.PerformStep();
            labelSeconds.Text = (TimeSetter.Value - progressBarTime.Value / 10).ToString() + " sec";
        }

        private void HelpButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show(@"Цільи гри:натискати на цифри в порядку зростання за максимально велику швидкість.

Правила: натиснути кнопку Let's play і грати

Для чого грати: Британські вчені довели, що ця гра сприяє розвитку уваги та швидкості реакції.", "Правила гри", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }


}
