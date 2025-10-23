using System.Collections.Generic;
using Code.Config;
using Code.GameLogic.Cubes;
using Code.GameLogic.Cubes.Code.GameLogic.Cubes;
using Code.GameLogic.Map;
using Code.Providers.Asset;
using Code.Providers.Config;
using UnityEngine;

namespace Code.Infrastruction
{
    public class LevelLoader
    {
        private readonly IConfigProvider _configProvider;
        private readonly IAssetProvider _assetProvider;

        private GridData _gridData;
        private CubeConfig _cubeConfig;

        private MapModel _mapModel;
        private CubesModel _cubesModel;
        private CubesController _cubesController;
        private MapController _mapController;
        private CubesView _cubesView;

        public LevelLoader(IConfigProvider configProvider, IAssetProvider assetProvider)
        {
            _configProvider = configProvider;
            _assetProvider = assetProvider;
        }

        public void InitLevel()
        {
            _gridData = _configProvider.GetGridData();
            _cubeConfig = _configProvider.GetCubeConfig();

            _mapModel = new MapModel(_gridData);
            _cubesModel = new CubesModel(_configProvider);

            _cubesView = CreateCubesView();
            _cubesController = CreateCubesController();
            _mapController =CreateMapController();

            _cubesView.Initialize();
            _mapModel.Initialize();
            _cubesModel.Initialize();
        }

        private CubesController CreateCubesController()
        {
            GameObject controllerObj = new GameObject("CubesController");
            var controller = controllerObj.AddComponent<CubesController>();

            controller.Construct(_cubesModel);

            return controller;
        }

        private MapController CreateMapController()
        {
            GameObject controllerObj = new GameObject("CubesController");
            var controller = controllerObj.AddComponent<MapController>();

            controller.Construct(_mapModel);

            return controller;
        }

        private CubesView CreateCubesView()
        {
            GameObject viewObj = new GameObject("CubesView");
            var view = viewObj.AddComponent<CubesView>();

            view.Construct(_cubesModel, _mapModel, _assetProvider, _configProvider);

            return view;
        }
    }
}