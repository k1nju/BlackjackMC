namespace BlackjackMC.GameEngine
{
    
        public enum Suit
        {
            Hearts, Diamonds, Clubs, Spades
        }

        public enum Rank
        {
            Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
        }
        public class Card
            {
                public string Suit { get; }
                public string Rank { get; }

                public Card(string suit, string rank)
                {
                    Suit = suit;
                    Rank = rank;
                }

                public int GetValue()
                {
                    switch (Rank)
                    {
                        case "Ace":
                            return 11;
                        case "2":
                            return 2;
                        case "3":
                            return 3;
                        case "4":
                            return 4;
                        case "5":
                            return 5;
                        case "6":
                            return 6;
                        case "7":
                            return 7;
                        case "8":
                            return 8;
                        case "9":
                            return 9;
                        case "10":
                        case "Jack":
                        case "Queen":
                        case "King":
                            return 10;
                        default:
                            return 0;
                    }
                }

                public override string ToString()
                {
                    return $"{Rank} of {Suit}";
                }
            }
        }
    

