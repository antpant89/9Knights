namespace _9Knights.Models
{
    internal struct Position: IPositionable
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public override string ToString()
        {
            return $"Row: {Row}, Column: {Column}";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Position))
            {
                return Row == ((Position)obj).Row && Column == ((Position)obj).Column;
            }

            return base.Equals(obj);
        }
    }
}
