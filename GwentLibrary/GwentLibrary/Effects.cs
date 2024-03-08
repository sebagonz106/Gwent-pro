using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public static class Effects
    {
        public static void PlaceBonus(params object[] parameters)//List<Card>, Bonus
        {
            foreach (Unit item in (List<Card>)parameters[0])
            {
                item.Damage *= ((Bonus)parameters[1]).Increase;
            }
        }
        public static void PlaceWeather(params object[] parameters)//Weather, Board, int
        {
            ((Weather)parameters[0]).Effect((Board)parameters[1], (int)parameters[2]); //aplica un clima mas leve pero que no puede ser removido por ninguna carta de despeje
        }
        public static void RemovePowerfulCard(params object[] parameters)//Board
        {
            List<object> listPlayer1 = ((Board)parameters[0]).Player1.Battlefield.MostPowerfulCard();
            List<object> listPlayer2 = ((Board)parameters[0]).Player2.Battlefield.MostPowerfulCard();

            if (((Unit)listPlayer1[0]).Damage< ((Unit)listPlayer2[0]).Damage) //analiza si la carta mas poderosa del jugador 1 es mas poderosa que la del jugador 2, y si se ejecuta la envia al cementerio
            {
                ((Board)parameters[0]).Player2.Battlefield.ToGraveyard(((Unit)listPlayer2[0]), ((List<Card>)listPlayer2[1]));
            }
            else if (((Unit)listPlayer1[0]).Damage > ((Unit)listPlayer2[0]).Damage) //analiza si la carta mas poderosa del jugador 2 es mas poderosa que la del jugador 1, y si se ejecuta la envia al cementerio
            {
                ((Board)parameters[0]).Player1.Battlefield.ToGraveyard(((Unit)listPlayer1[0]), ((List<Card>)listPlayer1[1]));
            }
            else if (((Unit)listPlayer1[0]).Damage == ((Unit)listPlayer2[0]).Damage) //analiza si las cartas mas poderosas de ambos jugadores son iguales, y si se ejecuta manda ambas al cementerio.
            {
                ((Board)parameters[0]).Player2.Battlefield.ToGraveyard(((Unit)listPlayer2[0]), ((List<Card>)listPlayer2[1]));
                ((Board)parameters[0]).Player1.Battlefield.ToGraveyard(((Unit)listPlayer1[0]), ((List<Card>)listPlayer1[1]));
            }
            //si no hay ninguna carta jugada al momento de activarse el poder, no hace nada (cosa que no va a pasar pues al menos va a estar en el campo la carta que activa este poder)
        }



        #region Sin Usar
        //sin usar, no los borro por si me hacen falta mas adelante
        public static void Decrement(List<Battlefield> battlefields, List<CardType> affectedTypes, int value)
        {
            foreach (Battlefield item in battlefields)
            {
                if (affectedTypes.Contains(CardType.Melee))
                {
                    foreach (Unit card in item.Melee)
                    {
                        card.Damage -= value;
                    }
                }
                if (affectedTypes.Contains(CardType.Range))
                {
                    foreach (Unit card in item.Range)
                    {
                        card.Damage -= value;
                    }
                }
                if (affectedTypes.Contains(CardType.Siege))
                {
                    foreach (Unit card in item.Siege)
                    {
                        card.Damage -= value;
                    }
                }
            }
        }
        public static void Increment(List<Card> line, int value)
        {
            foreach (Unit item in line)
            {
                item.Damage += value;
            }
        }
        #endregion
    }
}
