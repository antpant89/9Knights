using System.Collections.Generic;
using System.Linq;

namespace _9Knights.Models
{
    internal class Board
    {
        public readonly int NumberOfRows;
        public readonly int NumberOfColumns;
        public readonly IList<IGamePiece> GamePieces = new List<IGamePiece>();

        public Board(int numberOfRows, int numberOfColumns)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }

        private bool IsPositionWithinRowBoundary(IPositionable position)
        {
            return position.Row >= 0 && position.Row < NumberOfRows;
        }

        private bool IsPositionWithinColumnBoundary(IPositionable position)
        {
            return position.Column >= 0 && position.Column < NumberOfColumns;
        }

        public bool IsPositionAvailable(IPositionable position)
        {
            if (GamePieces.Any(x => x.CurrentPosition == position))
            {
                return false;
            }

            return true;
        }

        public bool IsPositionWithinBoardSize(IPositionable position)
        {
            if (IsPositionWithinRowBoundary(position) && IsPositionWithinColumnBoundary(position))
            {
                return true;
            }

            return false;
        }
    }
}
