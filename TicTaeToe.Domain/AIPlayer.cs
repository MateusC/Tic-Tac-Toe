using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TicTaeToe.Domain
{
    public class AIPlayer : Player
    {
        private List<Int32> _enemyMoves = new List<Int32>();

        private List<Int32> _moves = new List<Int32>();

        private List<Int32> _allMoves = new List<Int32>();

        private Int32 _nextPlay;

        private List<Int32[]> _combinations = new List<Int32[]>  {
           new Int32[] {0,1,2},
           new Int32[] {3,4,5},
           new Int32[] {6,7,8},
           new Int32[] {0,3,6},
           new Int32[] {1,4,7},
           new Int32[] {2,5,8},
           new Int32[] {0,4,8},
           new Int32[] {2,4,6} };


        public Int32 Turn(List<PictureBox> slotsDefault)
        {
            if (slotsDefault.Where(x => x.BackgroundImage != null).Count() == 9)
                return 10;

            CleanMoves();

            GetMovesFromPlayers(slotsDefault);

            if (WillWin(2))
                return _nextPlay;

            if (WillLose())
                return 10; //jogada inexistente, o computador entenderá que ele não teve nenhuma ação. Poderia ser qualquer numero.

            return CheckMove();
        }

        private Int32 CheckMove()
        {
            while (_nextPlay.IsIn(_allMoves.ToArray()))
                _nextPlay = Game.RandomPlay(0, 1, 2, 3, 4, 5, 6, 7, 8);

            return _nextPlay;
        }

        public Int32 GetFirstMove()
        {
            do
            {
                _nextPlay = new Random().Next(0, 9);

            } while (!_nextPlay.IsIn(0, 2, 6, 8));

            return _nextPlay;
        }

        private Boolean WillLose()
        {
            if (!CalculateChances())
            {
                return PlayerWillWin();
            }

            return false;
        }

        private Boolean PlayerWillWin()
        {
            var list = _enemyMoves.Where(x => x.IsIn(0, 2, 6, 8)).Intersect(_allMoves);

            if (list.Count() >= 2 && _enemyMoves.Count < 3)
                foreach (var possibility in _combinations)
                {
                    Int32 count = 0;

                    foreach (var move in _enemyMoves)
                        if (move.IsIn(possibility)) count++;

                    if (count == 2)
                    {
                        _nextPlay = Game.RandomPlay(1, 3, 5, 7);

                        return false;
                    }
                }
            else
            {
                if (!4.IsIn(_allMoves.ToArray()) && _enemyMoves.All(x => x.IsIn(0, 2, 6, 8)))
                    _nextPlay = 4;
                else
                    _nextPlay = Game.RandomPlay(0, 2, 6, 8);

                return false;
            }

            return true;
        }

        private Boolean WillWin(Int32 plays)
        {
            Boolean victory = false;
            foreach (var possibility in _combinations)
            {
                Int32 count = 0;

                foreach (var move in _moves)
                    if (move.IsIn(possibility)) count++;

                if (count == plays)
                {
                    try
                    {
                        _nextPlay = possibility.Except(_allMoves).Last();

                        return victory = true;
                    }
                    catch (Exception)
                    {
                        victory = false;
                        continue;
                    }
                }
            }

            return victory;
        } //pronto

        private Boolean CalculateChances()
        {
            Boolean victory = false;

            foreach (var possibility in _combinations)
            {
                Int32 count = 0;

                foreach (var move in _enemyMoves)
                    if (move.IsIn(possibility)) count++;

                if (count == 2)
                {
                    try
                    {
                        _nextPlay = possibility.Except(_allMoves).Last();

                        return victory = true;
                    }
                    catch (Exception)
                    {
                        victory = false;
                        continue;
                    }
                }
            }

            if (_enemyMoves.Count < 3 || _moves.Count < 2)
            {
                if (_enemyMoves.FirstOrDefault().IsIn(0, 2, 6, 8) && !_allMoves.Contains(4))
                    _nextPlay = 4;
                else if (_enemyMoves.FirstOrDefault().Equals(4))
                    _nextPlay = Game.RandomPlay(0, 2, 6, 8);
                else if (_enemyMoves.Intersect(new List<Int32> { 0, 2, 6, 8 }).Count() == 2 && _allMoves.Contains(4))
                    _nextPlay = Game.RandomPlay(1, 3, 5, 7);
                else
                    _nextPlay = GodMethod();

                return victory = true;
            }

            return victory;
        }

        private Int32 GodMethod()
        {
            List<Int32[]> possibilities = new List<Int32[]>();

            for (int i = 0; i < _enemyMoves.Count; i++)
                foreach (var possibility in _combinations)
                    if (possibility.Contains(_enemyMoves[i]) && !possibilities.Contains(possibility))
                        possibilities.Add(possibility);

            for (int i = 0; i < _moves.Count; i++)
                for (int j = 0; j < possibilities.Count; j++)
                    if (possibilities[j].Contains(_moves[i]))
                    {
                        possibilities.Remove(possibilities[j]);
                        j--;
                    }

            List<Int32> plays = new List<Int32>();

            foreach (var possibility in possibilities)
                foreach (var play in possibility)
                    if (!plays.Contains(play))
                        plays.Add(play);
                    else if (!play.IsIn(_allMoves.ToArray()))
                        return play;

            return _nextPlay;
        }

        private void GetMovesFromPlayers(List<PictureBox> _slotsDefault)
        {
            for (int i = 0; i < _slotsDefault.Count; i++)
            {
                if (_slotsDefault[i].BackgroundImage == null) continue;

                if (_slotsDefault[i].BackgroundImage != Symbol)
                    _enemyMoves.Add(i);
                else
                    _moves.Add(i);

                _allMoves.Add(i);
            }
        }

        public String GameStatus(List<PictureBox> slotsDefault, Game game)
        {
            CleanMoves();

            GetMovesFromPlayers(slotsDefault);

            if (slotsDefault.Where(x => x.BackgroundImage != null).Count() > 8)
            {
                game.Drawn();
                return String.Format("Empatou, jogue novamente e tente ganhar dessa vez !");
            }

            foreach (var possibility in _combinations)
            {
                Int32 count = 0, countEnemy = 0;

                for (int i = 0; i < _allMoves.Count; i++)
                {

                    if (_allMoves[i].IsIn(_enemyMoves.ToArray()) && _allMoves[i].IsIn(possibility))
                        countEnemy++;
                    else if (_allMoves[i].IsIn(_moves.ToArray()) && _allMoves[i].IsIn(possibility))
                        count++;

                    if (count == 3)
                    {
                        game.Defeat();
                        return String.Format("Voce perdeu, tente novamente !");
                    }
                    else if (countEnemy == 3)
                    {
                        game.Victory();
                        return String.Format("Voce ganhou, parabens !");
                    }
                }
            }

            return String.Empty;
        }

        private void CleanMoves()
        {
            _enemyMoves.Clear();

            _moves.Clear();

            _allMoves.Clear();

            _nextPlay = 0x0;
        }
    }
}
