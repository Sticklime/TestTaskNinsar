using UnityEngine;

namespace Code.GameLogic.Map
{
    public class MapController : MonoBehaviour
    {
        private MapModel _model;

        public void Construct(MapModel mapModel)
        {
            _model = mapModel;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W)) { _model.Move(0, -1); }
            if (Input.GetKeyDown(KeyCode.S)) { _model.Move(0, 1); }
            if (Input.GetKeyDown(KeyCode.A)) { _model.Move(-1, 0); }
            if (Input.GetKeyDown(KeyCode.D)) { _model.Move(1, 0);  }
        }
    }
}