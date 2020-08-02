using System;
using TurtleChallange.Definitions;

namespace TurtleChallange.Application.Ex
{
    internal static class StringEx
    {
        public static Move ToMoveType(this string move)
        {
            return move.ToUpperInvariant() switch
            {
                ("LEFT") => Move.Left,
                ("L") => Move.Left,
                ("RIGHT") => Move.Right,
                ("R") => Move.Right,
                ("UP") => Move.Up,
                ("U") => Move.Up,
                ("DOWN") => Move.Down,
                ("D") => Move.Down,
                _        => throw new ArgumentException($"{move} is not a valid direction to move")
            };
        }
    }
}
