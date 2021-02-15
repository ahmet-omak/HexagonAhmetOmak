using UnityEngine;

namespace Assest.Scripts.General
{
    public class GridManager : MonoBehaviour
    {
        public static Transform[,] grid;

        [SerializeField]
        private int gridWidth;

        [SerializeField]
        private int gridHeight;

        private void Awake()
        {
            grid = new Transform[gridWidth, gridHeight];
        }
    }
}