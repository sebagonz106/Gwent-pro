using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public enum Faction
    {
        Fidel,
        Batista,
    }
    public enum CardType
    {
        Melee,
        Range,
        Siege,
        Bonus,
        Leader,
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
