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
                ReduceSilverCardPower(board.Player1.Battlefield.Melee, value);
                ReduceSilverCardPower(board.Player2.Battlefield.Melee, value);
            }
            if (this.affectedTypes.Contains(CardType.Range)) //si afecta range, reduce daño en las cartas de unidad de la fila range de ambos jugadores
            {
                ReduceSilverCardPower(board.Player1.Battlefield.Range, value);
                ReduceSilverCardPower(board.Player2.Battlefield.Range, value);
            }
            if (this.affectedTypes.Contains(CardType.Siege)) //si afecta Siege, reduce daño en las cartas de unidad de la fila Siege de ambos jugadores
            {
                ReduceSilverCardPower(board.Player1.Battlefield.Siege, value);
                ReduceSilverCardPower(board.Player2.Battlefield.Siege, value);
            }

        }
        private void ReduceSilverCardPower(List<Card> list, int value)
        {
            foreach (Unit item in list)
            {
                if (item.Level == Level.Silver) item.Damage -= value;
            }
        }
    }
}
