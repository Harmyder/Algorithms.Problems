namespace LeetCode.Tasks
{
    internal class BookMyShow
    {
        private int _width;
        private int[] _rows;
        private long[] _takenInRowsRange;
        private long[] _availableTillRow;

        private const int BigStepSize = 100;

        public BookMyShow(int rowsCount, int m)
        {
            _rows = new int[rowsCount];
            _width = m;
            _availableTillRow = new long[rowsCount / BigStepSize + 1];
            _takenInRowsRange = new long[rowsCount / BigStepSize + 1];

            for (long i = 0; i < _availableTillRow.Length; i++)
            {
                _availableTillRow[i] = i * BigStepSize * m;
            }
        }

        public int[] Gather(int k, int maxRow)
        {
            if (k > _width) return new int[0];
            for (var i = 0; i <= maxRow; i++)
            {
                if (_width - _rows[i] >= k)
                {
                    TakeInRow(i, k);
                    ApplyTaken();
                    return new int[] { i, _rows[i] - k };
                }
            }
            return new int[0];
        }

        public bool Scatter(int toAllocate, int maxRow)
        {
            if (toAllocate <= AvailableByRow(maxRow))
            {
                for (var i = 0; i <= maxRow; ++i)
                {
                    var available = _width - _rows[i];
                    if (available > toAllocate)
                    {
                        TakeInRow(i, toAllocate);
                        break;
                    }
                    TakeInRow(i, available);
                    toAllocate -= available;
                }
                ApplyTaken();
                return true;
            }
            return false;
        }

        private long AvailableByRow(int row)
        {
            var bigStepsCount = row / BigStepSize;
            var smallStepsCount = row % BigStepSize;
            long availInSmallSteps = 0;
            for (var i = 0; i <= smallStepsCount; ++i)
            {
                availInSmallSteps += _width - _rows[i + bigStepsCount * BigStepSize];
            }
            return _availableTillRow[bigStepsCount] + availInSmallSteps;

        }

        private void TakeInRow(int row, int number)
        {
            _rows[row] += number;
            _takenInRowsRange[row / BigStepSize] += number;
        }

        private void ApplyTaken()
        {
            long partial = 0;
            for (var i = 0; i < _takenInRowsRange.Length - 1; i++)
            {
                partial += _takenInRowsRange[i];
                _availableTillRow[i + 1] -= partial;
            }

            Array.Clear(_takenInRowsRange);
        }
    }
}
