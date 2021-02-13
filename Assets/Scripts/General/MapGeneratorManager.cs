using UnityEngine;


namespace Assest.Scripts.General
{
    public class MapGeneratorManager : MonoBehaviour
    {
        [SerializeField]
        private int mapWidth;

        [SerializeField]
        private int mapHeight;

        [SerializeField]
        private GameObject hexagonPrefab;

        private Vector3 hexagonPosition;
        private float xOffset = .9f;
        private float yOffset = .8f;

        private void Start()
        {
            GenerateMap();
        }

        //Generates a hexagon-based map
        private void GenerateMap()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    float xPosition = x * xOffset;
                    if (y % 2 == 0)
                    {
                        xPosition += xOffset / 2;
                    }
                    hexagonPosition = new Vector3(xPosition, y * yOffset, 0);
                    GameObject hexagon = Instantiate(hexagonPrefab, hexagonPosition, Quaternion.identity);
                    hexagon.transform.SetParent(this.transform);
                }
            }
        }
    }
}
