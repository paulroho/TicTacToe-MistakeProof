using System;
using System.Linq;

namespace TicTacToe
{
    public class Position
    {
        // complete

        private readonly Row _row;

        private readonly Column _column;

        public Position(Row row, Column column)
        {
            // Enums in C# cannot be null
            _row = row;
            _column = column;
        }

        public override string ToString()
        {
            return $"{_row} {_column}";
        }

        public static Position Parse(string text)
        {
            var parts = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return new Position(ParseRowFromLetter(parts[0]), ParseColumnFromLetter(parts[1]));
        }

        private static Row ParseRowFromLetter(string letter)
        {
            return ParseEnumFromLetter<Row>(letter);
        }

        private static Column ParseColumnFromLetter(string letter)
        {
            return ParseEnumFromLetter<Column>(letter);
        }

        private static T ParseEnumFromLetter<T>(string letter) 
            where T : struct
        {
            var enumName = Enum.GetNames(typeof(T)).First(n => n.ToLowerInvariant().StartsWith(letter));
            T value;
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