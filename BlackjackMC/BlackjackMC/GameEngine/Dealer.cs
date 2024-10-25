namespace BlackjackMC.GameEngine
{
    
        public class Dealer : Participant
            {
                public void PlayTurn(Deck deck)
                {
                    while (GetHandValue() < 17)
                    {
                        TakeCard(deck.DrawCard());
                    }
                }
            }
        }
    

