namespace Games.Platformer2D
{
    public interface IChunkGenerator
    {
        Chunk GenerateChunk(float currentX, int platformWidthTiles, int tilesHeight);
    }
}