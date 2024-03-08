using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public enum Faction
    {
        Fidel,
        Batista,
        Neutral,
    }

    public enum CardType
    {
        Melee,
        Range,
        Siege,
        Bonus,
        Leader,
        Weather,
        Clear,
        Bait,
    }

    public enum Level
    {
        Silver,
        Golden,
    }

    public delegate void Effect(params object[] parameters);

    public static class Utils
    {
        public static int Random(int max) => Convert.ToInt32(new System.Random()) % max;
        public static List<Card> RandomDeck(List<Card> cards) //Modern Fisher-Yates shuffle algorithm (algoritmo moderno de desorden de Fisher-Yates)
        {
            List<Card> deck = new List<Card>();
            System.Random random = new System.Random();
            int randomNumber;
            Card swapCard;

            for (int i = cards.Count-1; i >= 0; i--)
            {
                randomNumber = random.Next(i);
                swapCard = cards[randomNumber];
                cards[randomNumber] = cards[i];
                cards[i] = swapCard;
            }

            return deck;
        }
        public static bool ContainsWeather(List<Card> list)
        {
            foreach (Card item in list)
            {
                if (item is Weather) return true;
            }
            return false;
        }
        public static bool Equals(List<Card> list1, List<Card> list2)
        {
            if (list1.Count != list2.Count) return false;
            for (int i = 0; i < list1.Count-1; i++)
            {
                if (list1[i] != list2[i]) return false;
            }
            return true;
        }
    }
}
