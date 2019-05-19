public class MapTileData {

    public int _x { get; set; } 
    public int _y { get; set; }

    public Enums.MapTileType _type { get; set; }
    public StructureData _structure { get; set; }

    public MapTileData(int x, int y) {
        _x = x;
        _y = y;

        _type = Enums.MapTileType.Empty;
    }

    public void SetStructureData(StructureData structure) {
        _structure = structure;
    }
}
