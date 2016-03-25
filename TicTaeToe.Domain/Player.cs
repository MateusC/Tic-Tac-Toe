using System;
using System.Collections.Generic;
using System.Drawing;

namespace TicTaeToe.Domain
{
    public class Player
    {
        public List<Int32> PositionsPlayed { get; set; }
       
        public Image Symbol { get; set; }
    }
}
