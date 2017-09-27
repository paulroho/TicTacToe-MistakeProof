using System;
using System.Linq;

namespace TicTacToe.MistakeProof
{
    public class Position
    {
        // complete

        private readonly Row _row;

        private readonly Column _column;

        public Position(Row row, Column column)
        {
            _row = row;
            _column = column;
        }

        public static Position Parse(string text)
        {
            var parts = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return new Position(ParseRowFromLetter(parts[0]), ParseColumnFromLetter(parts[1]));
        }

        private static Row ParseRowFromLetter(string letter)
        {
            var enumName = Enum.GetNames(typeof(Row)).First(n => n.ToLowerInvariant().StartsWith(letter));
            Row value;
            Enum.TryParse(enumName, out value);
            return value;
        }

        private static Column ParseColumnFromLetter(string letter)
        {
            var enumName = Enum.GetNames(typeof(Column)).First(n => n.ToLowerInvariant().StartsWith(letter));
            Column value;
            Enum.TryParse(enumName, out value);
            return value;
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