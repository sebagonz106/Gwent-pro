using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Board
    {
        Player player1;
        Player player2;

        public Board(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void NextRound()
        {
            if (player1.EndRound&&player2.EndRound)
            {
                if (player1.Battlefield.TotalDamage() > player2.Battlefield.TotalDamage())
                {
                    player1.score += 2;
                }
                else if (player1.Battlefield.TotalDamage() < player2.Battlefield.TotalDamage())
                {
                    player2.score += 2;
                }
                else
                {
                    player1.score += 1;
                    player2.score += 1;
                }
                player1.Battlefield.Clear();
                player2.Battlefield.Clear();
            }
        }
    }
}
