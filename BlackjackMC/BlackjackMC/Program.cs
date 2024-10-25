using BlackjackMC.GameEngine;
using BlackjackMC.Strategy;

BlackjackGame game = new BlackjackGame();
game.StartGame();
const int simulations = 10000;
GameAnalyzer analyzer = new GameAnalyzer(simulations);
analyzer.Run();
Console.ReadKey();

