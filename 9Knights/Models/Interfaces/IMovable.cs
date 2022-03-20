using System.Collections.Generic;

namespace _9Knights.Models
{
    internal interface IMovable
    {
        IList<IPositionable> AvailableMoves { get; }
    }
}
