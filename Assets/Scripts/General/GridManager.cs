using Assest.Scripts.Hexagons;
using System.Collections;
using UnityEngine;

namespace Assest.Scripts.General
{
    public class GridManager : MonoBehaviour
    {
        public static Transform[,] grid;

        private int gridWidth;

        private int gridHeight;

        private TileMapGeneratorManager tileMap;

        [SerializeField] private GameObject hexagonPrefab;

        private void Awake()
        {
            tileMap = FindObjectOfType<TileMapGeneratorManager>();
            gridWidth = tileMap.MapWidth;
            gridHeight = tileMap.MapHeight;
            grid = new Transform[gridWidth, gridHeight];
        }

        public IEnumerator FillGrid()
        {
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridHeight; j++)
                {
                    if (!grid[i, j].GetComponent<Hexagon>().gameObject.activeSelf)
                    {
                        yield return new WaitForSeconds(.6f);
                        grid[i, j].GetComponent<Hexagon>().gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}