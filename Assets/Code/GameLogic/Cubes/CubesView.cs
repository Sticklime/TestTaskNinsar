using Code.Config;
using Code.GameLogic.Map;
using Code.Providers.Asset;
using Code.Providers.Config;
using UnityEngine;

namespace Code.GameLogic.Cubes
{
    public class CubesView : MonoBehaviour
    {
        private MapView[,] _cubes;
        private IAssetProvider _assetProvider;
        private CubeConfig _cubeConfig;
        private MapModel _mapModel;
        private CubesModel _cubesModel;
        private GridData _gridData;

        public void Construct(
            CubesModel cubesModel,
            MapModel mapModel,
            IAssetProvider assetProvider,
            IConfigProvider configProvider)
        {
            _assetProvider = assetProvider;
            _mapModel = mapModel;
            _cubesModel = cubesModel;
            _cubeConfig = configProvider.GetCubeConfig();
            _gridData = configProvider.GetGridData();
        }

        public void Initialize()
        {
            int rows = _gridData.CubeColorMatrix.GetLength(0);
            int cols = _gridData.CubeColorMatrix.GetLength(1);

            _cubes = new MapView[rows, cols];
            SpawnCubes(rows, cols);
            RecenterCubes(rows, cols);

            _cubesModel.OnCubeCountChanged += UpdateGrid;
        }

        private void SpawnCubes(int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    MapView cube = _assetProvider.Instantiate<MapView>(AssetPath.CubePrefabPath, Vector3.zero);
                    cube.Construct(i, j, _mapModel, _cubeConfig);
                    cube.Initialize();

					cube.transform.SetParent(transform, false);

                    _cubes[i, j] = cube;
                }
            }
        }

        private void RecenterCubes(int rows, int cols)
        {
            float spacing = _cubeConfig.SpacingBetweenCube;
            
            float offsetX = (cols - 1) * spacing / 2f;
            float offsetZ = (rows - 1) * spacing / 2f;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (_cubes[i, j] == null) continue;

                    Vector3 position = new Vector3(
                        j * spacing - offsetX,
                        0,
                        -(i * spacing - offsetZ)
                    );

                    _cubes[i, j].transform.localPosition = position;
                }
            }
        }

        private void UpdateGrid(int visibleRows, int visibleCols)
        {
            int totalRows = _cubes.GetLength(0);
            int totalCols = _cubes.GetLength(1);

            for (int i = 0; i < totalRows; i++)
            {
                for (int j = 0; j < totalCols; j++)
                {
                    bool isActive = i < visibleRows && j < visibleCols;
                    _cubes[i, j].gameObject.SetActive(isActive);
                }
            }
            
            RecenterCubes(visibleRows, visibleCols);
        }

        private void OnDestroy()
        {
            _cubesModel.OnCubeCountChanged -= UpdateGrid;
        }
    }
}
