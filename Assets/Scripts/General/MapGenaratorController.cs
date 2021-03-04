using Assest.Scripts.Hexagons;
using UnityEngine;


namespace Assest.Scripts.General
{
    public class MapGenaratorController : MonoBehaviour
    {
        [Header("TileMap Properties")]
        [SerializeField]
        private int mapWidth;

        [SerializeField]
        private int mapHeight;

        [SerializeField]
        private GameObject hexagonPrefab;

        [SerializeField]
        private Color[] hexagonColors;

        private Vector3 hexagonPosition;
        private float hexagonXOffset = .8f;
        private float hexagonYOffset = .9f;

        public int MapWidth { get { return mapWidth; } set { mapWidth = value; } }
        public int MapHeight { get { return mapHeight; } set { mapHeight = value; } }
        public Color[] HexagonColors { get { return hexagonColors; } }

        private void Start()
        {
            GenerateTileMap();
        }

        //Generates a hexagon-based map
        private void GenerateTileMap()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    float hexagonPositionY = y * hexagonYOffset;
                    if (x % 2 == 0)
                    {
                        hexagonPositionY += hexagonYOffset / 2f;
                    }
                    SetHexagonPosition(x * hexagonXOffset, hexagonPositionY);
                    SetHexagonColor();
                    hexagonPrefab.GetComponent<Hexagon>().X = x;
                    hexagonPrefab.GetComponent<Hexagon>().Y = y;
                    GameObject hexagon = Instantiate(hexagonPrefab, hexagonPosition, Quaternion.Euler(new Vector3(0f, 0f, 90f)));
                    GridController.grid[x, y] = hexagon.transform;
                    hexagon.gameObject.name = $"Hexagon [{x}{y}]";
                    hexagon.transform.SetParent(this.transform);
                }
            }
        }

        private void SetHexagonPosition(float positionX, float positionY)
        {
            hexagonPosition = new Vector3(positionX, positionY, 0);
        }

        private void SetHexagonColor()
        {
            hexagonPrefab.GetComponent<SpriteRenderer>().color = hexagonColors[Random.Range(0, hexagonColors.Length)];
        }
    }
}