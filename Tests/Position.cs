using System;

namespace Tests
{
    public class Position
    {
        private readonly Row _row;
        private readonly Column _column;

        public Position(Row row, Column column)
        {
            _row = row;
            _column = column;
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(null, obj) || obj.GetType() != this.GetType())
            {
                return false;
            }
            Position that = (Position) obj;
            return this._row == that._row && this._column == that._column;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) _row * 397) ^ (int) _column;
            }
        }
    }
}