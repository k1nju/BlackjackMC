namespace BlackjackMC.GameEngine
{
    
        public class Deck
            {
                private List<Card> _cards;
                private Random _random;

                public Deck()
                {
                    _cards = new List<Card>();
                    _random = new Random();
                    string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
                    string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
                    foreach (var suit in suits)
                    {
                        foreach (var rank in ranks)
                        {
                            _cards.Add(new Card(suit, rank));
                        }
                    }

                    Shuffle();
                }

                public void Shuffle()
                {
                    for (int i = 0; i < _cards.Count; i++)
                    {
                        int j = _random.Next(i, _cards.Count);
                        var temp = _cards[i];
                        _cards[i] = _cards[j];
                        _cards[j] = temp;
                    }
                }

                public Card DrawCard()
                {
                    if (_cards.Count == 0)
                        throw new InvalidOperationException("The deck is empty!");

                    var card = _cards[0];
                    _cards.RemoveAt(0);
                    return card;
                }
            }
        }
    

