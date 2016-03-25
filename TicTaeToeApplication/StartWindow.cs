using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TicTaeToe.Domain;

namespace TicTacToeApplication
{
    public partial class StartWindow : Form
    {
        private Player _player;
        private AIPlayer _npc;

        private Graphics _graphics;

        public StartWindow()
        {
            InitializeComponent();

            _player = new Player();

            _npc = new AIPlayer();

            _graphics = CreateGraphics();
        }

        private void pbCross_Click(object sender, EventArgs e)
        {
            Refresh();

            _graphics.DrawRectangle(new Pen(Color.Blue, 5), new Rectangle(pbCross.Location, pbCross.Size));

            _player.Symbol = pbCross.BackgroundImage;

            _npc.Symbol = pbCircle.BackgroundImage;
        }

        private void pbCircle_Click(object sender, EventArgs e)
        {
            Refresh();

            _graphics.DrawRectangle(new Pen(Color.Red, 5), new Rectangle(pbCircle.Location, pbCircle.Size));

            _player.Symbol = pbCircle.BackgroundImage;

            _npc.Symbol = pbCross.BackgroundImage;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (!chbMachine.Checked && !chbUser.Checked)
                sb.Append("- Deve selecionar algum jogador para fazer a primeira jogada.\n");

            if (_player.Symbol == default(Image))
                sb.Append("- Selecione um simbolo antes de iniciar a partida.\n");

            if (sb.ToString() != String.Empty)
                MessageBox.Show(sb.ToString(), "ATENCAO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                WindowState = FormWindowState.Minimized;

                new GameScreen(_player, _npc, chbUser.Checked).ShowDialog();

                WindowState = FormWindowState.Normal;
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void chbUser_CheckedChanged(object sender, EventArgs e)
        {
            if (chbUser.Checked)
                chbMachine.Checked = false;
        }

        private void chbMachine_CheckedChanged(object sender, EventArgs e)
        {
            if(chbMachine.Checked)
                chbUser.Checked = false;
        }
    }
}
