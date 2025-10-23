using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Config
{
    [CreateAssetMenu(fileName = "CubeConfig", menuName = "Configs/CubeConfig")]
    public class CubeConfig : ScriptableObject
    {
        [field: SerializeField] public List<NumberColorPair> NumberColorPairs { get; private set; }
        [field: SerializeField] public int CountRows { get; private set; }
        [field: SerializeField] public int CountColumns { get; private set; }
        [field: SerializeField] public float SpacingBetweenCube { get; private set; }

        public Color GetColor(int number)
        {
            foreach (NumberColorPair numberColorPair in NumberColorPairs)
            {
                if (numberColorPair.number == number)
                    return numberColorPair.color;
            }

            return Color.white;
        }
    }
}