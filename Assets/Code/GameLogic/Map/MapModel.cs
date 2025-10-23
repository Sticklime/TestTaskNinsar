using System;
using Code.Config;

namespace Code.GameLogic.Map
{
    public class MapModel
    {
        private readonly int[,] _matrix;
        private int _currentRow;
        private int _currentColumns;

        public event Action IsChanged;

        public int Rows => _matrix.GetLength(0);
        public int Columns => _matrix.GetLength(1);

        public MapModel(GridData gridData)
        {
            _matrix = gridData.CubeColorMatrix;
            _currentRow = 0;
            _currentColumns = 0;
        }

        public void Initialize() => 
            SetRandomPosition();

        private void SetRandomPosition()
        {
            _currentRow = UnityEngine.Random.Range(0, Rows);
            _currentColumns = UnityEngine.Random.Range(0, Columns);

            IsChanged?.Invoke();
        }

        public void Move(int deltaX, int deltaY)
        {
            _currentColumns = Mod(_currentColumns + deltaX, Columns);
            _currentRow = Mod(_currentRow + deltaY, Rows);

            IsChanged?.Invoke();
        }

        public int GetColorIndexByOffset(int offsetX, int offsetY)
        {
            int row = Mod(_currentRow + offsetY, Rows);
            int col = Mod(_currentColumns + offsetX, Columns);

            return _matrix[row, col];
        }

        private int Mod(int value, int size)
        {
            value %= size;
            return value < 0 ? value + size : value;
        }
    }
}