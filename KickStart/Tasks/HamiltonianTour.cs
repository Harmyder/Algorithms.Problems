using System;
using System.Collections.Generic;
using System.Linq;

namespace KickStart.Tasks
{
    internal class HamiltonianTour
    {
        public static void Run(int testIndex)
        {
            var dims = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var board = new bool[dims[0], dims[1]];
            
            for (var i = 0; i < dims[0]; ++i)
            {
                var row = Console.ReadLine().Select(x => x == '#').ToArray();
                for (var j = 0; j < dims[1]; ++j)
                {
                    board[i, j] = row[j];
                }
            }

            var res = RunInternal(board);

            var readable = res == null ? "IMPOSSIBLE" :
                new string(res.Select(
                x =>
                {
                    switch (x)
                    {
                        case Dir.North: return 'N';
                        case Dir.East: return 'E';
                        case Dir.South: return 'S';
                        case Dir.West: return 'W';
                        default: throw new InvalidOperationException();
                    }
                }).ToArray());

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Case #{testIndex + 1}: {readable}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static List<Dir> RunInternal(bool[,] board)
        {
            var path = new List<Dir>();
            var smartBoard = new Board(board);
            var start = new Point(0, 0);
            Dfs(start, Dir.North, Dir.West, smartBoard, path);
            return smartBoard.AnyFree() ? null : path;
        }

        private static void Dfs(Point start, Dir fromDir, Dir sideDir, Board board, List<Dir> path)
        {
            board.Visit(start);

            if (board.IsFree(start + sideDir))
            {
                path.Add(sideDir);
                Dfs(start + sideDir, Reverse(sideDir), fromDir, board, path);
            }
            else
            {
                path.Add(Reverse(fromDir));
            }

            if (board.IsFree(start + Reverse(fromDir)))
            {
                path.Add(Reverse(fromDir));
                Dfs(start + Reverse(fromDir), fromDir, sideDir, board, path);
            }
            else
            {
                path.Add(Reverse(sideDir));
            }

            if (board.IsFree(start + Reverse(sideDir)))
            {
                path.Add(Reverse(sideDir));
                Dfs(start + Reverse(sideDir), sideDir, Reverse(fromDir), board, path);
            }
            else
            {
                path.Add(fromDir);
            }

            if (start.X == 0 && start.Y == 0)
            {
                path.Add(sideDir);
            }
            else
            {
                path.Add(fromDir);
            }
        }

        private struct Point
        {
            public static Point North = new Point(-1, 0);
            public static Point East = new Point(0, 1);
            public static Point South = new Point(1, 0);
            public static Point West = new Point(0, -1);

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; }
            public int Y { get; }

            public static Point operator +(Point a, Dir dir)
            {
                switch (dir)
                {
                    case Dir.North: return new Point(a.X - 1, a.Y);
                    case Dir.South: return new Point(a.X + 1, a.Y);
                    case Dir.East: return new Point(a.X, a.Y + 1);
                    case Dir.West: return new Point(a.X, a.Y - 1);
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }

        private class Board
        {
            private bool[,] _data;
            private bool[,] _wasVisited;

            public Board(bool[,] data)
            {
                _data = data;
                _wasVisited = new bool[data.GetLength(0), data.GetLength(1)];
            }

            public bool IsFree(Point point) =>
                0 <= point.X && point.X < _data.GetLength(0) &&
                0 <= point.Y && point.Y < _data.GetLength(1) &&
                !_data[point.X, point.Y] &&
                !_wasVisited[point.X, point.Y];

            public void Visit(Point point) => _wasVisited[point.X, point.Y] = true;

            public bool AnyFree()
            {
                for (var i = 0; i < _data.GetLength(0); ++i)
                {
                    for (var j = 0; j < _data.GetLength(1); ++j)
                    {
                        if (IsFree(new Point(i, j))) return true;
                    }
                }
                return false;
            }
        }

        private static Dir Reverse(Dir dir)
        {
            if (dir == Dir.North) return Dir.South;
            if (dir == Dir.East) return Dir.West;
            if (dir == Dir.South) return Dir.North;
            if (dir == Dir.West) return Dir.East;
            throw new ArgumentOutOfRangeException();
        }

        private enum Dir
        {
            _,
            North,
            East,
            South,
            West,
        }
    }
}
