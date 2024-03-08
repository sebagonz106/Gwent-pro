using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Weather : Card
    {
        public readonly List<CardType> affectedTypes;

        public Weather(Faction faction, CardType cardType, string name, string description, List<CardType> affectedTypes) : base(faction, cardType, name, description)
        {
            this.affectedTypes = affectedTypes;
        }

        public void Effect(Board board, int value = 2)
        {
            if (this.affectedTypes.Contains(CardType.Melee)) //si afecta melee, reduce daño en las cartas de unidad de la fila melee de ambos jugadores
            {
                foreach (Unit item in board.Player1.Battlefield.Melee)
                {
                    item.Damage -= value;
                }
                foreach (Unit item in board.Player2.Battlefield.Melee)
                {
                    item.Damage -= value;
                }
            }
            if (this.affectedTypes.Contains(CardType.Range)) //si afecta range, reduce daño en las cartas de unidad de la fila range de ambos jugadores
            {
                foreach (Unit item in board.Player1.Battlefield.Range)
                {
                    item.Damage -= value;
                }
                foreach (Unit item in board.Player2.Battlefield.Range)
                {
                    item.Damage -= value;
                }
            }
            if (this.affectedTypes.Contains(CardType.Siege)) //si afecta Siege, reduce daño en las cartas de unidad de la fila Siege de ambos jugadores
            {
                foreach (Unit item in board.Player1.Battlefield.Siege)
                {
                    item.Damage -= value;
                }
                foreach (Unit item in board.Player2.Battlefield.Siege)
                {
                    item.Damage -= value;
                }
            }

        }
    }
}
