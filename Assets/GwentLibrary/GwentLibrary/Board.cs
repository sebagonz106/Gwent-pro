using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Board
    {
        #region Fields
        Player player1;
        Player player2;
        #endregion

        #region Properties and Builder
        public Board(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }
        public Player Player1 { get => player1; }
        public Player Player2 { get => player2; }
        #endregion

        #region Methods
        public double TotalDamage(Player player)
        {
            double totalDamage = 0;
            foreach (Card item in player.Battlefield.Melee)
            {
                if (item is Weather weather) weather.Effect(this);
                if (item is Unit unit) totalDamage += player.Battlefield.Bonus[0].Increase * unit.Damage;
            }
            foreach (Card item in player.Battlefield.Range)
            {
                if (item is Weather weather) weather.Effect(this);
                if (item is Unit unit) totalDamage += player.Battlefield.Bonus[1].Increase * unit.Damage;
            }
            foreach (Card item in player.Battlefield.Range)
            {
                if (item is Weather weather) weather.Effect(this);
                if (item is Unit unit) totalDamage += player.Battlefield.Bonus[2].Increase * unit.Damage;
            }
            return totalDamage;
        }

        public void NextRound()
        {
            if (this.Player1.EndRound && this.Player2.EndRound)
            {
                if (TotalDamage(this.Player1) > TotalDamage(this.Player2))
                {
                    this.Player1.score += 2;
                }
                else if (TotalDamage(this.Player1) < TotalDamage(this.Player2))
                {
                    this.Player2.score += 2;
                }
                else
                {
                    this.Player1.score += 1;
                    this.Player2.score += 1;
                }
                this.Player1.Battlefield.Clear();
                this.Player2.Battlefield.Clear();
            }
        }
        #endregion
    }
}
