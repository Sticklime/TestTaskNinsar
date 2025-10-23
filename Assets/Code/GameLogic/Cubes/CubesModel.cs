using System;
using Code.Config;
using Code.Providers.Config;
using UnityEngine;

namespace Code.GameLogic.Cubes
{
    public class CubesModel
    {
        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }

        private readonly GridData _gridData;
        private readonly CubeConfig _cubeConfig;

        public event Action<int, int> OnCubeCountChanged;

        public CubesModel(IConfigProvider configProvider)
        {
            _cubeConfig = configProvider.GetCubeConfig();
            _gridData = configProvider.GetGridData();
        }

        public void Initialize()
        {
            int maxRows = _gridData.CubeColorMatrix.GetLength(0);
            int maxCols = _gridData.CubeColorMatrix.GetLength(1);

            RowCount = Mathf.Clamp(_cubeConfig.CountRows, 1, maxRows);
            ColumnCount = Mathf.Clamp(_cubeConfig.CountColumns, 1, maxCols);

            OnCubeCountChanged?.Invoke(RowCount, ColumnCount);
        }

        public void AddCube()
        {
            int maxRows = _gridData.CubeColorMatrix.GetLength(0);
            int maxCols = _gridData.CubeColorMatrix.GetLength(1);
            
            if (RowCount >= maxRows || ColumnCount >= maxCols)
                return;

            RowCount++;
            ColumnCount++;

            OnCubeCountChanged?.Invoke(RowCount, ColumnCount);
        }

        public void RemoveCube()
        {
            if (RowCount <= 1 || ColumnCount <= 1)
                return;

            RowCount--;
            ColumnCount--;

            OnCubeCountChanged?.Invoke(RowCount, ColumnCount);
        }
    }
}