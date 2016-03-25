using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TicTaeToe.Domain
{
    public class Game
    {
        public Int32 Victories { get; private set; }

        public Int32 Losses { get; private set; }

        public Int32 Drawns { get; private set; }
         
        public void Victory()
        {
            Victories++;
        }

        public void Defeat()
        {
            Losses++;
        }

        public void Drawn()
        {
            Drawns++;
        }

        public void ResetResults()
        {
            Victories = default(Int32);

            Losses = default(Int32);
        }

        public String GetScore()
        {
            return String.Format(@"{0} / {1} / {2}", Victories, Losses, Drawns);
        }

        public static Int32 RandomPlay(params Int32[] @params)
        {
            Int32 choice = 0;

            Random rd = new Random();

            do
            {
                choice = rd.Next(0, 9);

            } while (!choice.IsIn(@params));

            return choice;
        }
    }
}
