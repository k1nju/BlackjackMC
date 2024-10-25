using BlackjackMC.GameEngine;
using BlackjackMC.GameEngine;
namespace BlackjackMC.Strategy
{
    public class GameAnalyzer
    {
        private int _numberOfSimulations;
        private int _playerWins;
        private int _dealerWins;
        private int _ties;

        public GameAnalyzer(int numberOfSimulations)
        {
            _numberOfSimulations = numberOfSimulations;
        }

        public void Run()
        {

            for (int i = 0; i < _numberOfSimulations; i++)
            {
                var result = SimulateGame();
                switch (result)
                {
                    case GameResult.PlayerWin:
                        _playerWins++;
                        break;
                    case GameResult.DealerWin:
                        _dealerWins++;
                        break;
                    case GameResult.Tie:
                        _ties++;
                        break;
                }
            }

            Console.WriteLine($"Games Simulated: {_numberOfSimulations}");
            Console.WriteLine($"Player Wins: {_playerWins} ({(_playerWins / (float)_numberOfSimulations) * 100:F2}%)");
            Console.WriteLine($"Dealer Wins: {_dealerWins} ({(_dealerWins / (float)_numberOfSimulations) * 100:F2}%)");
            Console.WriteLine($"Ties: {_ties} ({(_ties / (float)_numberOfSimulations) * 100:F2}%)");
        }

        private GameResult SimulateGame()
        {
            var deck = new Deck();
            var player = new Player();
            var dealer = new Dealer();
            // Начальная раздача
            player.TakeCard(deck.DrawCard());
            player.TakeCard(deck.DrawCard());
            dealer.TakeCard(deck.DrawCard());
            dealer.TakeCard(deck.DrawCard());

            // Ход игрока (базовая стратегия: тянуть карту, если меньше 17, и остановиться, если 17 или больше)
            while (player.GetHandValue() < 17)
            {
                player.TakeCard(deck.DrawCard());
            }

            if (player.IsBusted)
            {
                return GameResult.DealerWin;
            }

            // Ход дилера
            dealer.PlayTurn(deck);

            if (dealer.IsBusted)
            {
                return GameResult.PlayerWin;
            }

            // Определение победителя
            int playerHandValue = player.GetHandValue();
            int dealerHandValue = dealer.GetHandValue();

            if (playerHandValue > dealerHandValue)
            {
                return GameResult.PlayerWin;
            }
            else if (playerHandValue < dealerHandValue)
            {
                return GameResult.DealerWin;
            }
            else
            {
                return GameResult.Tie;
            }
        }

        private enum GameResult
        {
            PlayerWin,
            DealerWin,
            Tie
        }
    }
}
