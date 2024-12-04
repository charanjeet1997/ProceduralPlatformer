namespace Games.Platformer2D
{
    public interface IPlatformGenerator
    {
        void GenerateNextPlatform();
        void RecyclePlatform(Chunk chunk);
    }
}