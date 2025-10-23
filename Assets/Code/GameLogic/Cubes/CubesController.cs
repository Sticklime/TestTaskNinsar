using UnityEngine;

namespace Code.GameLogic.Cubes
{
    namespace Code.GameLogic.Cubes
    {
        public class CubesController : MonoBehaviour
        {
            private CubesModel _model;

            public void Construct(CubesModel model)
            {
                _model = model;
            }

            private void Update()
            {
                if (Input.GetKeyDown(KeyCode.E)) _model.AddCube();
                if (Input.GetKeyDown(KeyCode.Q)) _model.RemoveCube();
            }
        }
    }
}