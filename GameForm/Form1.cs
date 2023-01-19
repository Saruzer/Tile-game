using System;
using System.Drawing;
using System.Windows.Forms;
namespace GameForm
{
    public partial class GameForm : Form
    {
        private int playerScore = 0;
        private int enemyScore = 0;
        private int attempts = 5;
        private Button[] playerTile = new Button[100];
        private Button[] EnemyTile = new Button[100];

        private Button[] startButtonPlayer = new Button[100];
        private Button[] startButtonEnemy = new Button[100];
        public GameForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RestartButton.Click += delegate //Логика кнопки рестарта игры
            {
                enemyScore = 0;
                playerScore = 0;
                ShowGame(true);
                botTurnCount = 0;
            };
            botTurnCount = 0;
            SkipTurnButton.Click += delegate//Логика кнопки "пропуска хода"
            {
                attempts--;
                TryLabelInGame.Text = "Попыток осталось: " + attempts.ToString();
                if (attempts <= 0)
                {
                    SkipTurnButton.Enabled = false;
                }
                EnemyClick();
            };
            ExitMenuButton.Click += delegate //Логика выходы из игры в меню
            {
                botTurnCount = 0;
                ShowGame(false);
            };
            InitializeButtons(); //Происходит инициализация
            EventHandler myPlayerHandler = (object obj, EventArgs args) => //Задаём всем PlayerTile событие при нажатии
            {
                Button btn = (Button)obj;
                Random rand = new Random();
                Tile tile = new Tile(rand.Next(-15, 30));
                playerScore += tile.score;
                setColorRand(tile.score, btn);
                btn.Text = tile.score.ToString();
                btn.Enabled = false;
                --attempts;
                textUpdate();
                EnemyClick(); //Происходит нажатие врага
                tryCheck();

            };
            for (int i = 0; i < 100; i++)
            {
                playerTile[i].Click += myPlayerHandler;
            }
            startButtonPlayer = playerTile;
            startButtonEnemy = EnemyTile;
            ShowGame(false);
            MenuPanel.Location = new Point(180, 70);
        }
        public void ShowGame(bool isShow) // Начало/конец игры
        {
            playerTile = startButtonPlayer;
            EnemyTile = startButtonEnemy;
            playerScore = 0;
            enemyScore = 0;
            for (int i = 0; i < 100; i++)
            {
                EnemyTile[i].Enabled = true;
                playerTile[i].Enabled = true;
                playerTile[i].BackColor = SystemColors.Control;
                EnemyTile[i].BackColor = SystemColors.Control;
                playerTile[i].ForeColor = SystemColors.ControlText;
                EnemyTile[i].ForeColor = SystemColors.ControlText;
                playerTile[i].Text = "?";
                EnemyTile[i].Text = "?";
            }
            EnemyPlace.Enabled = isShow;
            EnemyPlace.Visible = isShow;
            PlayerPlace.Enabled = isShow;
            PlayerPlace.Visible = isShow;
            PlayerScoreLabel.Visible = isShow;
            PlayerScoreLabel.Enabled = isShow;
            EnemyScoreLabel.Visible = isShow;
            EnemyScoreLabel.Enabled = isShow;
            TryLabelInGame.Visible = isShow;
            TryLabelInGame.Enabled = isShow;
            IsntrumentPanel.Visible = isShow;
            IsntrumentPanel.Enabled = isShow;
            MenuPanel.Visible = !isShow;
            MenuPanel.Enabled = !isShow;
            ResultLabel.Visible = false;
            ResultLabel.Enabled = false;
            SkipTurnButton.Enabled = true;
            attempts = (int)numericUpDown1.Value;
            textUpdate(); // Обновления текста в ходе игры
        }
        public int botTurnCount = 0;
        public void EnemyClick() // Логика противника(Открытие карточки)
        {
            bool isNotClick = true;
            botTurnCount++;
            if(botTurnCount >= 100)
            {
                return;
            }
            while (isNotClick)
            {
                Random rand = new Random();
                int randTile = rand.Next(0, 100);
                while(EnemyTile[randTile].Enabled == false)
                {
                    randTile = rand.Next(0, 100);
                }
                if (EnemyTile[randTile].Enabled == true)
                {
                    Tile tile = new Tile(rand.Next(-15, 30));
                    enemyScore += tile.score;
                    setColorRand(tile.score, EnemyTile[randTile]);
                    EnemyTile[randTile].Text = tile.score.ToString();
                    EnemyScoreLabel.Text = "Очки врага: " + enemyScore.ToString();
                    EnemyTile[randTile].Enabled = false;
                    isNotClick = false;
                }
            }
            tryCheck(); //Проверка на кол-во попыток.
        }
        public void InitializeButtons()
        {
            playerTile[0] = PlayerTile1;
            playerTile[1] = PlayerTile2;
            playerTile[2] = PlayerTile3;
            playerTile[3] = PlayerTile4;
            playerTile[4] = PlayerTile5;
            playerTile[5] = PlayerTile6;
            playerTile[6] = PlayerTile7;
            playerTile[7] = PlayerTile8;
            playerTile[8] = PlayerTile9;
            playerTile[9] = PlayerTile10;
            playerTile[10] = PlayerTile11;
            playerTile[11] = PlayerTile12;
            playerTile[12] = PlayerTile13;
            playerTile[13] = PlayerTile14;
            playerTile[14] = PlayerTile15;
            playerTile[15] = PlayerTile16;
            playerTile[16] = PlayerTile17;
            playerTile[17] = PlayerTile18;
            playerTile[18] = PlayerTile19;
            playerTile[19] = PlayerTile20;
            playerTile[20] = PlayerTile21;
            playerTile[21] = PlayerTile22;
            playerTile[22] = PlayerTile23;
            playerTile[23] = PlayerTile24;
            playerTile[24] = PlayerTile25;
            playerTile[25] = PlayerTile26;
            playerTile[26] = PlayerTile27;
            playerTile[27] = PlayerTile28;
            playerTile[28] = PlayerTile29;
            playerTile[29] = PlayerTile30;
            playerTile[30] = PlayerTile31;
            playerTile[31] = PlayerTile32;
            playerTile[32] = PlayerTile33;
            playerTile[33] = PlayerTile34;
            playerTile[34] = PlayerTile35;
            playerTile[35] = PlayerTile36;
            playerTile[36] = PlayerTile37;
            playerTile[37] = PlayerTile38;
            playerTile[38] = PlayerTile39;
            playerTile[39] = PlayerTile40;
            playerTile[40] = PlayerTile41;
            playerTile[41] = PlayerTile42;
            playerTile[42] = PlayerTile43;
            playerTile[43] = PlayerTile44;
            playerTile[44] = PlayerTile45;
            playerTile[45] = PlayerTile46;
            playerTile[46] = PlayerTile47;
            playerTile[47] = PlayerTile48;
            playerTile[48] = PlayerTile49;
            playerTile[49] = PlayerTile50;
            playerTile[50] = PlayerTile51;
            playerTile[51] = PlayerTile52;
            playerTile[52] = PlayerTile53;
            playerTile[53] = PlayerTile54;
            playerTile[54] = PlayerTile55;
            playerTile[55] = PlayerTile56;
            playerTile[56] = PlayerTile57;
            playerTile[57] = PlayerTile58;
            playerTile[58] = PlayerTile59;
            playerTile[59] = PlayerTile60;
            playerTile[60] = PlayerTile61;
            playerTile[61] = PlayerTile62;
            playerTile[62] = PlayerTile63;
            playerTile[63] = PlayerTile64;
            playerTile[64] = PlayerTile65;
            playerTile[65] = PlayerTile66;
            playerTile[66] = PlayerTile67;
            playerTile[67] = PlayerTile68;
            playerTile[68] = PlayerTile69;
            playerTile[69] = PlayerTile70;
            playerTile[70] = PlayerTile71;
            playerTile[71] = PlayerTile72;
            playerTile[72] = PlayerTile73;
            playerTile[73] = PlayerTile74;
            playerTile[74] = PlayerTile75;
            playerTile[75] = PlayerTile76;
            playerTile[76] = PlayerTile77;
            playerTile[77] = PlayerTile78;
            playerTile[78] = PlayerTile79;
            playerTile[79] = PlayerTile80;
            playerTile[80] = PlayerTile81;
            playerTile[81] = PlayerTile82;
            playerTile[82] = PlayerTile83;
            playerTile[83] = PlayerTile84;
            playerTile[84] = PlayerTile85;
            playerTile[85] = PlayerTile86;
            playerTile[86] = PlayerTile87;
            playerTile[87] = PlayerTile88;
            playerTile[88] = PlayerTile89;
            playerTile[89] = PlayerTile90;
            playerTile[90] = PlayerTile91;
            playerTile[91] = PlayerTile92;
            playerTile[92] = PlayerTile93;
            playerTile[93] = PlayerTile94;
            playerTile[94] = PlayerTile95;
            playerTile[95] = PlayerTile96;
            playerTile[96] = PlayerTile97;
            playerTile[97] = PlayerTile98;
            playerTile[98] = PlayerTile99;
            playerTile[99] = PlayerTile100;
            EnemyTile[0] = EnemyTile1;
            EnemyTile[1] = EnemyTile2;
            EnemyTile[2] = EnemyTile3;
            EnemyTile[3] = EnemyTile4;
            EnemyTile[4] = EnemyTile5;
            EnemyTile[5] = EnemyTile6;
            EnemyTile[6] = EnemyTile7;
            EnemyTile[7] = EnemyTile8;
            EnemyTile[8] = EnemyTile9;
            EnemyTile[9] = EnemyTile10;
            EnemyTile[10] = EnemyTile11;
            EnemyTile[11] = EnemyTile12;
            EnemyTile[12] = EnemyTile13;
            EnemyTile[13] = EnemyTile14;
            EnemyTile[14] = EnemyTile15;
            EnemyTile[15] = EnemyTile16;
            EnemyTile[16] = EnemyTile17;
            EnemyTile[17] = EnemyTile18;
            EnemyTile[18] = EnemyTile19;
            EnemyTile[19] = EnemyTile20;
            EnemyTile[20] = EnemyTile21;
            EnemyTile[21] = EnemyTile22;
            EnemyTile[22] = EnemyTile23;
            EnemyTile[23] = EnemyTile24;
            EnemyTile[24] = EnemyTile25;
            EnemyTile[25] = EnemyTile26;
            EnemyTile[26] = EnemyTile27;
            EnemyTile[27] = EnemyTile28;
            EnemyTile[28] = EnemyTile29;
            EnemyTile[29] = EnemyTile30;
            EnemyTile[30] = EnemyTile31;
            EnemyTile[31] = EnemyTile32;
            EnemyTile[32] = EnemyTile33;
            EnemyTile[33] = EnemyTile34;
            EnemyTile[34] = EnemyTile35;
            EnemyTile[35] = EnemyTile36;
            EnemyTile[36] = EnemyTile37;
            EnemyTile[37] = EnemyTile38;
            EnemyTile[38] = EnemyTile39;
            EnemyTile[39] = EnemyTile40;
            EnemyTile[40] = EnemyTile41;
            EnemyTile[41] = EnemyTile42;
            EnemyTile[42] = EnemyTile43;
            EnemyTile[43] = EnemyTile44;
            EnemyTile[44] = EnemyTile45;
            EnemyTile[45] = EnemyTile46;
            EnemyTile[46] = EnemyTile47;
            EnemyTile[47] = EnemyTile48;
            EnemyTile[48] = EnemyTile49;
            EnemyTile[49] = EnemyTile50;
            EnemyTile[50] = EnemyTile51;
            EnemyTile[51] = EnemyTile52;
            EnemyTile[52] = EnemyTile53;
            EnemyTile[53] = EnemyTile54;
            EnemyTile[54] = EnemyTile55;
            EnemyTile[55] = EnemyTile56;
            EnemyTile[56] = EnemyTile57;
            EnemyTile[57] = EnemyTile58;
            EnemyTile[58] = EnemyTile59;
            EnemyTile[59] = EnemyTile60;
            EnemyTile[60] = EnemyTile61;
            EnemyTile[61] = EnemyTile62;
            EnemyTile[62] = EnemyTile63;
            EnemyTile[63] = EnemyTile64;
            EnemyTile[64] = EnemyTile65;
            EnemyTile[65] = EnemyTile66;
            EnemyTile[66] = EnemyTile67;
            EnemyTile[67] = EnemyTile68;
            EnemyTile[68] = EnemyTile69;
            EnemyTile[69] = EnemyTile70;
            EnemyTile[70] = EnemyTile71;
            EnemyTile[71] = EnemyTile72;
            EnemyTile[72] = EnemyTile73;
            EnemyTile[73] = EnemyTile74;
            EnemyTile[74] = EnemyTile75;
            EnemyTile[75] = EnemyTile76;
            EnemyTile[76] = EnemyTile77;
            EnemyTile[77] = EnemyTile78;
            EnemyTile[78] = EnemyTile79;
            EnemyTile[79] = EnemyTile80;
            EnemyTile[80] = EnemyTile81;
            EnemyTile[81] = EnemyTile82;
            EnemyTile[82] = EnemyTile83;
            EnemyTile[83] = EnemyTile84;
            EnemyTile[84] = EnemyTile85;
            EnemyTile[85] = EnemyTile86;
            EnemyTile[86] = EnemyTile87;
            EnemyTile[87] = EnemyTile88;
            EnemyTile[88] = EnemyTile89;
            EnemyTile[89] = EnemyTile90;
            EnemyTile[90] = EnemyTile91;
            EnemyTile[91] = EnemyTile92;
            EnemyTile[92] = EnemyTile93;
            EnemyTile[93] = EnemyTile94;
            EnemyTile[94] = EnemyTile95;
            EnemyTile[95] = EnemyTile96;
            EnemyTile[96] = EnemyTile97;
            EnemyTile[97] = EnemyTile98;
            EnemyTile[98] = EnemyTile99;
            EnemyTile[99] = EnemyTile100;
        } //Инициализация всех кнопок
        public void tryCheck() //Проврерка на "попытки". Если 0 - заканчиваем игру
        {
            if (attempts <= 0)
            {
                SkipTurnButton.Enabled = false;
                for (int i = 0; i < 100; i++)
                {
                    EnemyTile[i].Enabled = false;
                    playerTile[i].Enabled = false;
                }
                if (enemyScore > playerScore)
                {
                    ResultLabel.ForeColor = Color.DarkRed;
                    ResultLabel.Text = "Победил враг!";
                }
                else if (playerScore > enemyScore)
                {
                    ResultLabel.ForeColor = Color.DarkGreen;
                    ResultLabel.Text = "Вы победили!";
                }
                else if (playerScore == enemyScore)
                {
                    ResultLabel.ForeColor = Color.DarkViolet;
                    ResultLabel.Text = "Ничья!";
                }
                ResultLabel.Visible = true;
                ResultLabel.Enabled = true;
            }
        }
        public void textUpdate() //Обновление текстов
        {
            PlayerScoreLabel.Text = "Ваши очки: " + playerScore.ToString();
            EnemyScoreLabel.Text = "Очки врага: " + enemyScore.ToString();
            TryLabelInGame.Text = "Попыток осталось: " + attempts.ToString();
        }
        private void ExitButton_Click(object sender, EventArgs e) //Выход из игры
        {
            Application.Exit();
        }
        private void PlayButton_Click(object sender, EventArgs e) //Логика нажатия на кнопку "Играть"
        {
            attempts = (int)numericUpDown1.Value;
            ShowGame(true);
        }
        public void setColor(Button btn,Color col) //Задаёт цвет плитки(кнопки)
        {
            btn.BackColor = col;
            btn.ForeColor = col;
        }
        public void setColorRand(int score,Button btn) //Зависимо от score задаёт цвет кнопке
        {
            if (score > 0 && score <= 25)
            {
                setColor(btn, Color.Green);
            }
            else if (score > 25)
            {
                setColor(btn, Color.MediumPurple);
            }
            else if (score < 0 && score >= -10)
            {
                setColor(btn, Color.Red);
            }
            else if (score < -10)
            {
                setColor(btn, Color.PaleVioletRed);
            }
            else if (score == 0)
            {
                setColor(btn, Color.Aqua);
            }
        }
    }
    public class Tile //Класс "Плитка", в которой находится score
    {
        public int score;
        public Tile(int num)
        {
            score = num;
        }
    }
}