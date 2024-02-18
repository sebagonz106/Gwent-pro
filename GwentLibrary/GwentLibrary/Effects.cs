using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public static class Effects
    {
        public static void PlaceBonus(params object[] parameters)//List<Card>, Bonus bonus
        {
            foreach (Unit item in (List<Card>)parameters[0])
            {
                item.Damage *= ((Bonus)parameters[1]).Increase;
            }
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
