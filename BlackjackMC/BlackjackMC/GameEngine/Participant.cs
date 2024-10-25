namespace BlackjackMC.GameEngine
{
   
        public abstract class Participant
            {
                public List<Card> _hand { get; private set; }

                public Participant()
                {
                    _hand = new List<Card>();
                }

                public void TakeCard(Card card)
                {
                    _hand.Add(card);
                }

                public int GetHandValue()
                {
                    int value = 0;
                    int aceCount = 0;

                    foreach (var card in _hand)
                    {
                        value += card.GetValue();
                        if (card.Rank == "Ace")
                        {
                            aceCount++;
                        }
                    }

                    while (value > 21 && aceCount > 0)
                    {
                        value -= 10;
                        aceCount--;
                    }

                    return value;
                }

                public bool IsBusted => GetHandValue() > 21;

                public bool HasBlackjack => GetHandValue() == 21 && _hand.Count == 2;
            }
        }
    

