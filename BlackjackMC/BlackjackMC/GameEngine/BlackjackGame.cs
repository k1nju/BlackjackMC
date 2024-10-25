namespace BlackjackMC.GameEngine
{
        public class BlackjackGame
            {
                private Deck _deck;
                private Player _player;
                private Dealer _dealer;

                public void StartGame()
                {
                    _deck = new Deck();
                    _player = new Player();
                    _dealer = new Dealer();

                    // Initial deal
                    _player.TakeCard(_deck.DrawCard());
                    _player.TakeCard(_deck.DrawCard());
                    _dealer.TakeCard(_deck.DrawCard());
                    _dealer.TakeCard(_deck.DrawCard());

                    ShowGameState();

                    while (!_player.IsStanding && !_player.IsBusted && !_player.HasBlackjack)
                    {
                        Console.WriteLine("Choose action: (1) Hit (2) Stand");
                        string choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            _player.TakeCard(_deck.DrawCard());
                        }
                        else if (choice == "2")
                        {
                            _player.Stand();
                        }

                        ShowGameState();
                    }

                    if (_player.IsBusted)
                    {
                        Console.WriteLine("Player busted! Dealer wins. 😔");
                        return;
                    }

                    _dealer.PlayTurn(_deck);
                    ShowGameState(showAllDealerCards: true);

                    if (_dealer.IsBusted || _player.GetHandValue() > _dealer.GetHandValue())
                    {
                        Console.WriteLine("Player wins! 🎉");
                    }
                    else if (_player.GetHandValue() == _dealer.GetHandValue())
                    {
                        Console.WriteLine("It's a tie! 🤝");
                    }
                    else
                    {
                        Console.WriteLine("Dealer wins! 😐");
                    }
                }

                private void ShowGameState(bool showAllDealerCards = false)
                {
                    Console.WriteLine("\nPlayer's Hand:");
                    foreach (var card in _player._hand)
                    {
                        Console.WriteLine(card);
                    }
                    Console.WriteLine($"Hand Value: {_player.GetHandValue()}");

                    Console.WriteLine("\nDealer's Hand:");
                    if (showAllDealerCards)
                    {
                        foreach (var card in _dealer._hand)
                        {
                            Console.WriteLine(card);
                        }
                        Console.WriteLine($"Hand Value: {_dealer.GetHandValue()}");
                    }
                    else
                    {
                        Console.WriteLine(_dealer._hand.First());
                        Console.WriteLine("Hidden Card");
                    }
                }
            }
        }
