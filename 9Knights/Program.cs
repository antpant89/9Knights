using System;
using System.Linq;
using _9Knights.Models;
using _9Knights.Services;

namespace _9Knights
{
    internal class Program
    {
        private static bool areAllKnightsUnattackable(GameEngine gameEngine)
        {
            var knights = gameEngine.Board.GamePieces.Where((IGamePiece gamePiece) => gamePiece.GetType() == typeof(Knight));
            foreach (Knight knight in knights)
            {
                //Console.WriteLine($"This knight's current position is: {knight.CurrentPosition}");
                //Console.WriteLine("This knight's available moves are:");
                var availableMoves = gameEngine.GetAvailableMovesForGamePiece(knight);
                foreach (IPositionable movePosition in availableMoves)
                {
                    if (gameEngine.Board.GamePieces.Any((gamePiece) => gamePiece.CurrentPosition.Equals(movePosition)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            Board board = new Board(5, 5);
            GameEngine gameEngine = new GameEngine(board);
            // Valid
            //gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 0, Column = 4 }));
            //gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 1, Column = 3 }));
            //gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 2, Column = 0 }));
            //gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 2, Column = 2 }));
            //gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 3, Column = 1 }));
            //gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 3, Column = 3 }));
            //gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 4, Column = 0 }));
            //gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 4, Column = 2 }));
            //gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 4, Column = 4 }));

            // Invalid
            gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 0, Column = 3 }));
            gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 1, Column = 3 }));
            gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 2, Column = 0 }));
            gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 2, Column = 2 }));
            gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 3, Column = 1 }));
            gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 3, Column = 3 }));
            gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 4, Column = 0 }));
            gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 4, Column = 2 }));
            gameEngine.PlaceNewGamePiece(new Knight(new Position { Row = 4, Column = 4 }));

            string result = "Invalid";
            if (areAllKnightsUnattackable(gameEngine))
            {
                result = "Valid";
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
