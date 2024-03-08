using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Clear : Card
    {
        List<CardType> clearableTypes;

        public Clear(Faction faction, CardType cardType, string name, string description, List<CardType> clearableTypes) : base(faction, cardType, name, description)
        {
            this.clearableTypes = clearableTypes;
        }

        public void Effect (Board board) //elimina todas las cartas de clima colocadas en las filas que puede despejar, tanto de un jugador como de otro
        {
            if (this.clearableTypes.Contains(CardType.Melee))
            {
                foreach (Weather item in board.Player1.Battlefield.Melee)
                {
                    board.Player1.Battlefield.ToGraveyard(item, board.Player1.Battlefield.Melee);
                }
                foreach (Weather item in board.Player2.Battlefield.Melee)
                {
                    board.Player2.Battlefield.ToGraveyard(item, board.Player2.Battlefield.Melee);
                }
            }
            if (this.clearableTypes.Contains(CardType.Range))
            {
                foreach (Weather item in board.Player1.Battlefield.Range)
                {
                    board.Player1.Battlefield.ToGraveyard(item, board.Player1.Battlefield.Range);
                }
                foreach (Weather item in board.Player2.Battlefield.Range)
                {
                    board.Player2.Battlefield.ToGraveyard(item, board.Player2.Battlefield.Range);
                }
            }
            if (this.clearableTypes.Contains(CardType.Siege))
            {
                foreach (Weather item in board.Player1.Battlefield.Siege)
                {
                    board.Player1.Battlefield.ToGraveyard(item, board.Player1.Battlefield.Siege);
                }
                foreach (Weather item in board.Player2.Battlefield.Siege)
                {
                    board.Player2.Battlefield.ToGraveyard(item, board.Player2.Battlefield.Siege);
                }
            }
        }
    }
}
