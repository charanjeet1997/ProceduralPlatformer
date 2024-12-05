using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Games.Platformer2D
{
    public class ObstacleGenerator : IObstacleGenerator
    {
        private GameObject[] obstaclePrefabs;
        private float obstacleSpawnChance;

        public ObstacleGenerator(GameObject[] obstaclePrefabs, float obstacleSpawnChance = 0.3f)
        {
            this.obstaclePrefabs = obstaclePrefabs;
            this.obstacleSpawnChance = obstacleSpawnChance;
        }

        public void GenerateObstacles(GameObject chunk, int widthTiles, int heightTiles)
        {
            if (Random.value < obstacleSpawnChance)
            {
                GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
                GameObject obstacle = GameObject.Instantiate(obstaclePrefab, chunk.transform.position + new Vector3((float)widthTiles/2,0,0),quaternion.identity); 
                
            }
        }
    }
}