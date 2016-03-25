using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TicTaeToe.Domain;

namespace TicTacToeApplication
{
    public partial class GameScreen : Form
    {
        private Game _game;
        private List<PictureBox> _slotsDefault;
        private AIPlayer _npc;
        private Player _player;
        private Boolean _npcStarts;

        private const String PLAYER_TURN = "Seu turno";
        private const String NPC_TURN = "Turno Adversário";

        public GameScreen(Player player, AIPlayer npc, Boolean IsPlayerInitiator)
        {
            InitializeComponent();

            _player = player;

            _npc = npc;

            _slotsDefault = new List<PictureBox> { pb1, pb2, pb3, pb4, pb5, pb6, pb7, pb8, pb9 };

            _slotsDefault.ForEach(x => x.Click += ChangeBackGround);

            _slotsDefault.ForEach(x => x.MouseHover += CheckPlayable);

            _slotsDefault.ForEach(x => x.MouseLeave += UpdateWindow);

            _game = new Game();

            lblTurn.Text = IsPlayerInitiator ? PLAYER_TURN : NPC_TURN;

            lblScore.Text = _game.GetScore();

            _npcStarts = !IsPlayerInitiator;

            if (_npcStarts)
            {
                FirstPlay();
            }
        }

        private void UpdateWindow(object sender, EventArgs e)
        {
            Refresh();
        }

        private void CheckPlayable(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb.Enabled)
            {
                Graphics graphics = CreateGraphics();

                graphics.DrawRectangle(new Pen(Color.Blue, 5), pb.Location.X, pb.Location.Y, pb.Width, pb.Height);
            }
        }

        private void ChangeBackGround(object sender, EventArgs e)
        {
            _slotsDefault.Find(x => x == sender as PictureBox).BackgroundImage = _player.Symbol;

            _slotsDefault.Find(x => x == sender as PictureBox).Enabled = false;

            lblTurn.Text = NPC_TURN;

            Refresh();

            lblTurn.Text = PLAYER_TURN;

            Int32 indexPlayed = _npc.Turn(_slotsDefault);
            if (indexPlayed <= 8)
            {
                _slotsDefault.ElementAt(indexPlayed).BackgroundImage = _npc.Symbol;

                _slotsDefault.ElementAt(indexPlayed).Enabled = false;
            }

            String result = _npc.GameStatus(_slotsDefault, _game);

            if (!result.Equals(String.Empty))
            {
                MessageBox.Show(result, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRetry_Click(this, new EventArgs());

                return;
            }

        }

        private void FirstPlay()
        {
            Int32 indexPlayed = _npc.GetFirstMove();

            _slotsDefault.ElementAt(indexPlayed).BackgroundImage = _npc.Symbol;

            _slotsDefault.ElementAt(indexPlayed).Enabled = false;

            lblTurn.Text = PLAYER_TURN;
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            _slotsDefault.ForEach(x => x.BackgroundImage = null);

            _slotsDefault.ForEach(x => x.Enabled = true);

            lblScore.Text = _game.GetScore();

            if (_npcStarts)
                FirstPlay();

            Refresh();
        }
    }
}
