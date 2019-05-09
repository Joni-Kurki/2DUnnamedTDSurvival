public class MapChunkData 
{

    public int _x { get; set; }
    public int _y { get; set; }

    public Enums.MapChunkType _chunkType { get; set; }

    public MapChunkData(int x, int y)
    {
        _x = x;
        _y = y;

        _chunkType = Enums.MapChunkType.Empty_Buildable;
    }

    public void SetMapChunkType(Enums.MapChunkType chunkType)
    {
        _chunkType = chunkType;
    }

}
