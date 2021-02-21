using Assest.Scripts.General;
using Assest.Scripts.Hexagons;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Hexagons
{
    class HexagonManager : MonoBehaviour
    {
        private int[] oddXFactorsOf, oddYFactorsOf, evenXFactorsOf, evenYFactorsOf, xFactorsOf, yFactorsOf;
        private int mapWidth;
        private int mapHeight;

        private TileMapGeneratorManager mapGenerator;

        private void Awake()
        {
            mapGenerator = FindObjectOfType<TileMapGeneratorManager>();

            oddXFactorsOf = new int[] { 0, 1, 1, 0, -1, -1, 0 };
            oddYFactorsOf = new int[] { 1, 0, -1, -1, -1, 0, 1 };

            evenXFactorsOf = new int[] { 0, 1, 1, 0, -1, -1, 1 };
            evenYFactorsOf = new int[] { 1, 1, 0, -1, 0, 1, 0 };

            mapWidth = mapGenerator.MapWidth;
            mapHeight = mapGenerator.MapHeight;
        }

        public void PickNeighbours(Hexagon hexagon)
        {
            if (hexagon.X % 2 == 1)
            {
                xFactorsOf = oddXFactorsOf;
                yFactorsOf = oddYFactorsOf;
            }
            else
            {
                xFactorsOf = evenXFactorsOf;
                yFactorsOf = evenYFactorsOf;
            }
            List<Hexagon> selectedHexagons;
            int x1, y1, x2, y2;
            for (int i = 0; i < oddXFactorsOf.Length - 1; i++)
            {
                x1 = xFactorsOf[i];
                y1 = yFactorsOf[i];
                x2 = xFactorsOf[i + 1];
                y2 = yFactorsOf[i + 1];
                if ((x1 + hexagon.X >= 0 && x1 + hexagon.X < mapWidth) && (y1 + hexagon.Y >= 0 && y1 + hexagon.Y < mapHeight)
                    && (x2 + hexagon.X >= 0 && x2 + hexagon.X < mapWidth) && (y2 + hexagon.Y >= 0 && y2 + hexagon.Y < mapHeight))
                {
                    selectedHexagons = new List<Hexagon>();
                    selectedHexagons.Add(GridManager.grid[hexagon.X, hexagon.Y].GetComponent<Hexagon>());
                    selectedHexagons.Add(GridManager.grid[x1 + hexagon.X, y1 + hexagon.Y].GetComponent<Hexagon>());
                    selectedHexagons.Add(GridManager.grid[x2 + hexagon.X, y2 + hexagon.Y].GetComponent<Hexagon>());
                    SwitchHexagons(selectedHexagons);
                    return;
                }
            }
        }

        private void SwitchHexagons(List<Hexagon> selectedHexagons)
        {
            Color temporarayHexagonColor = selectedHexagons[0].SpriteRenderer.color;
            selectedHexagons[0].SpriteRenderer.color = selectedHexagons[1].SpriteRenderer.color;
            selectedHexagons[1].SpriteRenderer.color = temporarayHexagonColor;
            temporarayHexagonColor = selectedHexagons[2].SpriteRenderer.color;
            selectedHexagons[2].SpriteRenderer.color = selectedHexagons[0].SpriteRenderer.color;
            selectedHexagons[0].SpriteRenderer.color = temporarayHexagonColor;
            CheckHexagons(selectedHexagons);
            CheckHexagons(selectedHexagons);
        }

        private void CheckHexagons(List<Hexagon> selectedHexagons)
        {
            for (int i = 0; i < selectedHexagons.Count; i++)
            {
                if (selectedHexagons[i].Y - 1 >= 0 && GridManager.grid[selectedHexagons[i].X, selectedHexagons[i].Y].GetComponent<SpriteRenderer>().color
                         == GridManager.grid[selectedHexagons[i].X, selectedHexagons[i].Y - 1].GetComponent<SpriteRenderer>().color)
                {
                    GridManager.grid[selectedHexagons[i].X, selectedHexagons[i].Y].GetComponent<Hexagon>().gameObject.SetActive(false);
                    ChangeHexagonColor(GridManager.grid[selectedHexagons[i].X, selectedHexagons[i].Y].GetComponent<Hexagon>());
                    GridManager.grid[selectedHexagons[i].X, selectedHexagons[i].Y - 1].GetComponent<Hexagon>().gameObject.SetActive(false);
                    ChangeHexagonColor(GridManager.grid[selectedHexagons[i].X, selectedHexagons[i].Y - 1].GetComponent<Hexagon>());
                    StartCoroutine(FindObjectOfType<GridManager>().FillGrid());
                }
            }
        }

        private void ChangeHexagonColor(Hexagon hexagon)
        {
            hexagon.GetComponent<SpriteRenderer>().color = mapGenerator.HexagonColors[Random.Range(0, mapGenerator.HexagonColors.Length)];
        }
    }
}