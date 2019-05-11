using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChunkController : MonoBehaviour
{

    public MapChunkData _chunkData;
    public MapTileData[,] _tileData;

    const int CHUNKSIZE = 3;

    // Start is called before the first frame update
    void Start()
    {
        _tileData = new MapTileData[CHUNKSIZE, CHUNKSIZE];

        for (int x = 0; x < CHUNKSIZE; x++) {
            for (int y = 0; y < CHUNKSIZE; y++) {
                MapTileData tile = new MapTileData(x, y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChunkData(MapChunkData chunkData)
    {
        _chunkData = chunkData;
    }
}
