using System;

namespace Code.Config
{
    [Serializable]
    public class GridData
    {
        public int[,] CubeColorMatrix { get; private set; }

        public GridData(int[,] cubeColorMatrix)
        {
            CubeColorMatrix = cubeColorMatrix;
        }
    }
}