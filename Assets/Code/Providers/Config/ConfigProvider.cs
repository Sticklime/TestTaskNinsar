using System;
using Code.Config;
using UnityEngine;

namespace Code.Providers.Config
{
    public class ConfigProvider : IConfigProvider
    {
        private CubeConfig _cubeConfig;
        private GridData _data;

        private const string GridDataPath = "Data/GridConfig";
        private const string CubeDataPath = "Data/CubeConfig";

        public void Initialize()
        {
            TextAsset file = Resources.Load<TextAsset>(GridDataPath);
            _data = new GridData(GetMatrixFromFile(file));

            _cubeConfig = Resources.Load<CubeConfig>(CubeDataPath);
        }

        public GridData GetGridData() => _data;
        public CubeConfig GetCubeConfig() => _cubeConfig;

        private static int[,] GetMatrixFromFile(TextAsset file)
        {
            var lines = file.text
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int rows = lines.Length;
            int cols = lines[0].Length;
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = lines[i][j] - '0';
            return matrix;
        }
    }
}