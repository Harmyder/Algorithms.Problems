namespace LeetCode.Tasks
{
    internal class Fancy
    {
        private enum Operation { None, Add, Multiply };

        private const int M = 1000 * 1000 * 1000 + 7;

        private readonly List<(Operation Operation, int Operand)> _history;

        private readonly List<(int Value, int Birthday)> _values;

        public Fancy()
        {
            _history = new List<(Operation, int)>();
            _values = new List<(int, int)>();
        }

        public void Append(int val)
        {
            _values.Add((val, _history.Count));
        }

        public void AddAll(int inc)
        {
            _history.Add((Operation.Add, inc));
        }

        public void MultAll(int m)
        {
            _history.Add((Operation.Multiply, m));
        }

        public int GetIndex(int idx)
        {
            if (idx > _values.Count - 1) return -1;

            long value = _values[idx].Value;
            for (var i = _values[idx].Birthday; i < _history.Count; ++i)
            {
                if (_history[i].Operation == Operation.Add)
                {
                    value = (value + _history[i].Operand) % M;
                }
                else if (_history[i].Operation == Operation.Multiply)
                {
                    value = (value * _history[i].Operand) % M;
                }
                else throw new InvalidDataException();
            }
            _values[idx] = ((int)value, _history.Count);
            return (int)value;
        }
    }
}
