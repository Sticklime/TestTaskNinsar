using System;
using Code.Config;
using UnityEngine;

namespace Code.GameLogic.Map
{
    [RequireComponent(typeof(Renderer))]
    public class MapView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;

        public int Columns { get; private set; }
        public int Row { get; private set; }

        private MapModel _model;
        private CubeConfig _cubeConfig;

        public void Construct(int row, int column, MapModel model, CubeConfig cubeConfig)
        {
            Row = row;
            Columns = column;
            _model = model;
            _cubeConfig = cubeConfig;
        }

        public void Initialize() => 
            _model.IsChanged += OnModelChanged;

        private void OnModelChanged()
        {
            int indexByOffset = _model.GetColorIndexByOffset(Columns, Row);

            SetColor(_cubeConfig.GetColor(indexByOffset));
        }

        private void SetColor(Color color) =>
            _renderer.material.color = color;

        private void OnDestroy() => 
            _model.IsChanged -= OnModelChanged;
    }
}