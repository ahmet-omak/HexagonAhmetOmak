using Assest.Scripts.General;
using Assest.Scripts.Hexagons;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Hexagons
{
    class HexagonManager:MonoBehaviour
    {
        private int[] xFactorsOf, yFactorsOf;
        

        private void Awake()
        {
            xFactorsOf = new int[] { 0, 1, 1, 0, -1, -1, 1 };
            yFactorsOf = new int[] { 1, 0, -1, -1, -1, 0, 0 };
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
                if ((x1 + hexagon.X >= 0 && x1 + hexagon.X <= 7) && (y1 + hexagon.Y >= 0 && y1 + hexagon.Y <= 8) && (x2 + hexagon.X >= 0 && x2 + hexagon.X <= 7) && (y2 + hexagon.Y >= 0 && y2 + hexagon.Y <= 8))
                {
                    selectedHexagons = new List<Hexagon>();
                    selectedHexagons.Add(GridManager.grid[x1 + hexagon.X, y1 + hexagon.Y].GetComponent<Hexagon>());
                    selectedHexagons.Add(GridManager.grid[x2 + hexagon.X, y2 + hexagon.Y].GetComponent<Hexagon>());
                    selectedHexagons.Add(GridManager.grid[hexagon.X, hexagon.Y].GetComponent<Hexagon>());
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
        }
    }
}
