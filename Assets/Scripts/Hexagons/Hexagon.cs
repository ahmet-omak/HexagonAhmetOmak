using Assest.Scripts.General;
using UnityEngine;


namespace Assest.Scripts.Hexagons
{
    public class Hexagon : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private int x;

        [SerializeField]
        private int y;

        private int[] xFactorsOf, yFactorsOf;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        private void Awake()
        {
            xFactorsOf = new int[] { 0, 1, 1, 0, -1, -1, 1 };
            yFactorsOf = new int[] { 1, 0, -1, -1, -1, 0, 0 };
        }

        private void OnMouseDown()
        {
            PickNeighbours();
        }

        private void PickNeighbours()
        {
            int x1, y1, x2, y2;
            for (int i = 0; i < xFactorsOf.Length - 1; i++)
            {
                x1 = xFactorsOf[i];
                y1 = yFactorsOf[i];
                x2 = xFactorsOf[i + 1];
                y2 = yFactorsOf[i + 1];
                if ((x1 + x >= 0 && x1 + x <= 7) && (y1 + y >= 0 && y1 + y <= 8) && (x2 + x >= 0 && x2 + x <= 7) && (y2 + y >= 0 && y2 + y <= 8))
                {
                    GridManager.grid[x, y].GetComponent<SpriteRenderer>().color = Color.white;
                    GridManager.grid[x1 + x, y1 + y].GetComponent<SpriteRenderer>().color = Color.white;
                    GridManager.grid[x2 + x, y2 + y].GetComponent<SpriteRenderer>().color = Color.white;
                    return;
                }
            }
        }
    }
}