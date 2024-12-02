using System.Collections.Generic;

namespace Games.Platformer2D
{
    using UnityEngine;
    using System;
    using System.Collections;

    public class PlatformGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject normalTilePrefab;
        [SerializeField] private GameObject topTilePrefab;
        [SerializeField] private int platformsCount = 10;
        [SerializeField] private int minTilesWidth = 3;
        [SerializeField] private int maxTilesWidth = 8;
        [SerializeField] private int minTilesHeight = 1;
        [SerializeField] private int maxTilesHeight = 10;
        [SerializeField] private float tileWidth = 1f;
        [SerializeField] private float tileHeight = 0.5f;
        [SerializeField] private float minGap = 2f;
        [SerializeField] private float maxGap = 5f;
        [SerializeField] private float amplitude = 2f;
        [SerializeField] private float frequency1 = 1f;
        
        [SerializeField] private List<Chunk> chunks = new List<Chunk>();
        
        private void Start()
        {
            GenerateChunks();
        }

        private void GenerateChunks()
        {
            float currentX = 0f;

            for (int i = 0; i < platformsCount; i++)
            {
                int platformWidthTiles = UnityEngine.Random.Range(minTilesWidth, maxTilesWidth);
                int heightTiles = UnityEngine.Random.Range(minTilesHeight, maxTilesHeight);

                float gap = UnityEngine.Random.Range(minGap, maxGap);
                if (chunks.Count > 0)
                {
                    Chunk lastChunk = chunks[chunks.Count - 1];
                    currentX = lastChunk.position.x + lastChunk.width * tileWidth + gap;
                }
                else
                {
                    currentX += gap;
                }

                float y = amplitude * Mathf.Max(
                    Mathf.Sin(Time.time * frequency1 + i * 0.1f),
                    Mathf.Cos(Time.time * frequency1 + i * 0.2f)
                );

                Vector3 chunkPosition = new Vector3(currentX, y, 0f);

                GameObject chunk = new GameObject($"Chunk_{i}");
                chunk.transform.position = chunkPosition;

                GeneratePlatformTiles(chunk, platformWidthTiles, heightTiles);

                chunks.Add(new Chunk(chunk, chunkPosition, platformWidthTiles, heightTiles));
            }
        }

        private void GeneratePlatformTiles(GameObject chunk, int widthTiles, int heightTiles)
        {
            for (int y = 0; y < heightTiles; y++)
            {
                for (int x = 0; x < widthTiles; x++)
                {
                    Vector3 tilePosition = new Vector3(x , y , 0f);

                    GameObject tilePrefab = (y == heightTiles - 1) ? topTilePrefab : normalTilePrefab;

                    GameObject tile = Instantiate(tilePrefab, chunk.transform);
                    tile.transform.localPosition = tilePosition;
                }
            }
        }

    }
    
    [Serializable]
    public class Chunk
    {
        public GameObject chunk;
        public Vector3 position;
        public int width;
        public int height;

        public Chunk(GameObject chunk, Vector3 position, int width, int height)
        {
            this.chunk = chunk;
            this.position = position;
            this.width = width;
            this.height = height;
        }
    }
}