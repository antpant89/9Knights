using System.Collections.Generic;

namespace _9Knights.Models
{
    internal class Knight : IGamePiece, IMovable
    {
        private Position _position;

        public Knight(Position position)
        {
            _position = position;
        }

        public IPositionable CurrentPosition
        {
            get
            {
                return _position;
            }
        }

        public IList<IPositionable> AvailableMoves
        {
            get
            {
                IList<IPositionable> result = new List<IPositionable>();
                result.Add(new Position { Row = _position.Row + 1, Column = _position.Column + 2 });
                result.Add(new Position { Row = _position.Row + 1, Column = _position.Column - 2 });

                result.Add(new Position { Row = _position.Row - 1, Column = _position.Column + 2 });
                result.Add(new Position { Row = _position.Row - 1, Column = _position.Column - 2 });

                result.Add(new Position { Row = _position.Row + 2, Column = _position.Column + 1 });
                result.Add(new Position { Row = _position.Row + 2, Column = _position.Column - 1 });

                result.Add(new Position { Row = _position.Row - 2, Column = _position.Column + 1 });
                result.Add(new Position { Row = _position.Row - 2, Column = _position.Column - 1 });

                return result;
            }
        }
    }
}
