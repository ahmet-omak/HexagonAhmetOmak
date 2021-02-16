using UnityEngine;

namespace Assest.Scripts.General
{
    public class GridManager : MonoBehaviour
    {
        public static Transform[,] grid;

        private int gridWidth;

        private int gridHeight;

        private TileMapGeneratorManager tileMap;

        private void Awake()
        {
            tileMap = FindObjectOfType<TileMapGeneratorManager>();
            gridWidth = tileMap.MapWidth;
            gridHeight = tileMap.MapHeight;
            grid = new Transform[gridWidth, gridHeight];
        }
    }
}