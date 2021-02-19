using Assest.Scripts.General;
using Assest.Scripts.Hexagons;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Hexagons
{
    class HexagonManager : MonoBehaviour
    {
        private int[] xFactorsOf, yFactorsOf;
        private int mapWidth = 8;
        private int mapHeight = 9;


        private void Awake()
        {
            xFactorsOf = new int[] { 0, 1, 1, 0, -1, -1, 0 };
            yFactorsOf = new int[] { 1, 0, -1, -1, -1, 0, 1 };
        }

        public void PickNeighbours(Hexagon hexagon)
        {
            List<Hexagon> selectedHexagons;
            int x1, y1, x2, y2;
            for (int i = 0; i < xFactorsOf.Length - 1; i++)
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
        }

        private void CheckHexagons(List<Hexagon> selectedHexagons)
        {
            for (int i = 0; i < selectedHexagons.Count; i++)
            {
                if (selectedHexagons[i].Y >= 0 && GridManager.grid[selectedHexagons[i].X, selectedHexagons[i].Y].GetComponent<SpriteRenderer>().color
                         == GridManager.grid[selectedHexagons[i].X, selectedHexagons[i].Y - 1].GetComponent<SpriteRenderer>().color)
                {
                    GridManager.grid[selectedHexagons[i].X, selectedHexagons[i].Y].GetComponent<Hexagon>().gameObject.SetActive(false);
                    GridManager.grid[selectedHexagons[i].X, selectedHexagons[i].Y - 1].GetComponent<Hexagon>().gameObject.SetActive(false);
                    StartCoroutine(FindObjectOfType<GridManager>().FillGrid());
                }
            }
        }
    }
}