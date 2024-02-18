using System;
using System.Collections.Generic;
using System.Text;

namespace GwentLibrary
{
    public class Player
    {
        List<Card> hand = new List<Card>();
        List<Card> deck = new List<Card>();
        Leader leader;
        Battlefield battlefield;
        bool endRound = false;
        public int score = 0;

        public Player(List<Card> hand, List<Card> mazo,  Leader leader, Battlefield battlefield)
        {
            this.hand = hand;
            this.deck = mazo;
            this.leader = leader;
            this.battlefield = battlefield;
        }

        public List<Card> Hand { get => hand; }
        public List<Card> Deck { get => deck;  }
        public Leader Leader { get => leader; }
        public Battlefield Battlefield { get => battlefield;  }
        public bool EndRound { get => endRound; set => endRound = value; }

        public void GetCard(int i = 1)
        {
            for (int count = i; count>0; count--)
            {
                int index = Utils.Random(Deck.Count);
                hand.Add(deck[index]);
                deck.RemoveAt(index);
            }
            for (int count = i; hand.Count + count > 10; count--)
            {
                Battlefield.Graveyard.Add(hand[hand.Count - 1]);
                hand.RemoveAt(hand.Count - 1);
            }
        }

        public void PlayCard(int position, List<Card> place)
        {
            place.Add(Hand[position]);
            this.hand.RemoveAt(position);
        }

    }
}
