using Assest.Scripts.General;
using Assets.Scripts.Hexagons;
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

        private HexagonManager hexagonManager;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public SpriteRenderer SpriteRenderer { get { return spriteRenderer; } set { spriteRenderer = value; } }

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            hexagonManager = FindObjectOfType<HexagonManager>();
        }

        private void OnMouseDown()
        {
            hexagonManager.PickNeighbours(GetSelectedHexagon());
        }

        private Hexagon GetSelectedHexagon()
        {
            return gameObject.GetComponent<Hexagon>();
        }
    }
}