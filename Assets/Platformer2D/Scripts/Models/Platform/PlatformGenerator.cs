using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Games.Platformer2D
{
    public class PlatformGenerator : MonoBehaviour, IPlatformGenerator
    {
        [SerializeField] private GameObject normalTilePrefab;
        [SerializeField] private GameObject topTilePrefab;
        [SerializeField] private int platformsCount = 10;
        [SerializeField] private int minTilesWidth = 3;
        [SerializeField] private int maxTilesWidth = 8;
        [SerializeField] private int tilesHeight = 10;
        [SerializeField] private float tileWidth = 1f;
        [SerializeField] private float tileHeight = 0.5f;
        [SerializeField] private float minGap = 2f;
        [SerializeField] private float maxGap = 5f;
        [SerializeField] private float amplitude = 2f;
        [SerializeField] private float frequency = 1f;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Vector3 startPosition;
        [SerializeField] private DifficultyManager difficultyManager;
        [SerializeField] private DifficultyLevel currentDifficulty;
        private IChunkGenerator chunkGenerator;
        private IPlatformTileGenerator platformTileGenerator;

        private Queue<Chunk> chunkPool = new Queue<Chunk>();
        [SerializeField]private List<Chunk> activeChunks = new List<Chunk>();

        private float recycleThreshold = 20f; // Distance before recycling chunks
        private float lastGeneratedX;

        public Vector3 StartPosition => startPosition;
        
        
        [SerializeField] private GameObject[] obstaclePrefabs;
        [SerializeField] private float obstacleSpawnChance = 0.3f;

        private IObstacleGenerator obstacleGenerator;

        private void Awake()
        {
            chunkGenerator = new ChunkGenerator();
            platformTileGenerator = new PlatformTileGenerator(
                normalTilePrefab,
                topTilePrefab
            );
            obstacleGenerator = new ObstacleGenerator(obstaclePrefabs, obstacleSpawnChance);
        }

        private void Start()
        {
            for (int i = 0; i < platformsCount; i++)
            {
                difficultyManager.SetDifficulty(currentDifficulty);
                GenerateNextPlatform();
                startPosition = activeChunks[0].chunk.transform.position + new Vector3(1, 0, 0);
            }
        }

        private void Update()
        {
            float playerX = playerTransform.position.x;

            if (activeChunks.Count > 0 && activeChunks[0].position.x + activeChunks[0].width < playerX - recycleThreshold)
            {
                RecyclePlatform(activeChunks[0]);
            }

            while (activeChunks[activeChunks.Count - 1].position.x < playerX + recycleThreshold)
            {
                GenerateNextPlatform();
            }
        }

        public void GenerateNextPlatform()
        {
            Chunk chunk = GetChunkFromPool();

            DifficultySettings settings = difficultyManager.CurrentSettings;

            int platformWidthTiles = Random.Range(settings.minPlatformWidth, settings.maxPlatformWidth);
            chunk.width = platformWidthTiles;
            chunk.height = tilesHeight;
            float gap = Random.Range(settings.minGap, settings.maxGap);

            if (activeChunks.Count > 0)
            {
                lastGeneratedX = activeChunks[activeChunks.Count - 1].position.x + activeChunks[activeChunks.Count - 1].width + gap;
            }

            float t = Time.time * settings.frequency;
            int i = activeChunks.Count();
            float a = Mathf.Sin(t + i);
            float b = Mathf.Cos(t + i);
            float y = settings.amplitude * Mathf.Max(a, b);
            Vector3 chunkPosition = new Vector3(lastGeneratedX, y, 0f);
            chunk.chunk.transform.position = chunkPosition;
            chunk.position = chunkPosition;
            platformTileGenerator.GenerateTiles(chunk.chunk, platformWidthTiles, tilesHeight);

            obstacleGenerator.GenerateObstacles(chunk.chunk, platformWidthTiles, tilesHeight);
            activeChunks.Add(chunk);
        }


        
        public void RecyclePlatform(Chunk chunk)
        {
            activeChunks.Remove(chunk);
            chunk.chunk.SetActive(false);
            chunkPool.Enqueue(chunk);
        }

        private Chunk GetChunkFromPool()
        {
            if (chunkPool.Count > 0)
            {
                Chunk chunk = chunkPool.Dequeue();
                chunk.chunk.SetActive(true);
                return chunk;
            }
            return chunkGenerator.GenerateChunk(0, 0, tilesHeight);
        }
    }
}
