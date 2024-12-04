using UnityEngine;

namespace Games.Platformer2D
{
    public class ChunkGenerator : IChunkGenerator
    {
        public Chunk GenerateChunk(float currentX, int platformWidthTiles, int tilesHeight)
        {
            GameObject chunk = new GameObject($"Chunk_{currentX}");
            return new Chunk(chunk, new Vector3(currentX, 0f, 0f), platformWidthTiles, tilesHeight);
        }
    }
}