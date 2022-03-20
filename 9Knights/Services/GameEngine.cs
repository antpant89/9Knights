using _9Knights.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _9Knights.Services
{
    internal class GameEngine
    {
        public readonly Board Board;

        public GameEngine(Board board)
        {
            Board = board;
        }

        private bool positionIsUnplaceable(IGamePiece gamePiece) => !Board.IsPositionWithinBoardSize(gamePiece.CurrentPosition) || !Board.IsPositionAvailable(gamePiece.CurrentPosition);

        private IEnumerable<IPositionable> FilterOnMovesWithinBoard(IList<IPositionable> moves) => moves.Where(move => Board.IsPositionWithinBoardSize(move));

        public void PlaceNewGamePiece(IGamePiece gamePiece)
        {
            if (positionIsUnplaceable(gamePiece))
            {
                throw new Exception("Board placement is not possible.");
            }

            Board.GamePieces.Add(gamePiece);
        }

        public IList<IPositionable> GetAvailableMovesForGamePiece(IMovable gamePiece)
        {
            var result = new List<IPositionable>();
            foreach (var availableMove in FilterOnMovesWithinBoard(gamePiece.AvailableMoves))
            {
                // Console.WriteLine(availableMove.ToString());
                result.Add(availableMove);
            };

            return result;
        }
    }
}
