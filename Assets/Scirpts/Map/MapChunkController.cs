﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChunkController : MonoBehaviour
{

    public MapChunkData _chunkData;
    public MapTileData[,] _tileData;

    const int CHUNKSIZE = 3;

    public GameObject _tilePrefab;

    private bool _tilesUpdated = false;

    // Start is called before the first frame update
    void Start()
    {
        _tileData = new MapTileData[CHUNKSIZE, CHUNKSIZE];

        for (int x = 0; x < CHUNKSIZE; x++) {
            for (int y = 0; y < CHUNKSIZE; y++) {
                _tileData[x,y] = new MapTileData(x, y);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if tiles need to be refreshed again.
        if (_chunkData != null && _chunkData._chunkType == Enums.MapChunkType.MonsterSpawner && !_tilesUpdated) {
            for (int x = 0; x < 1; x++) {
                    //var rX = Random.Range(0, 3);
                    //var rY = Random.Range(0, 3);

                    //SetTileToStructureAt(rX, rY, Enums.StructureType.Spawner);
            }
            _tilesUpdated = true;
        } else if (_chunkData != null && _chunkData._chunkType == Enums.MapChunkType.Initial && !_tilesUpdated) {
            //var rX = Random.Range(0, 3);
            //var rY = Random.Range(0, 3);

            //SetTileToStructureAt(rX, rY, Enums.StructureType.Warfare);

            _tilesUpdated = true;
        }
    }

    // Sets chunkdata
    public void SetChunkData(MapChunkData chunkData)
    {
        _chunkData = chunkData;
    }

    // Sets selected tile to structure with desired type
    public void SetTileToStructureAt(int x, int y, Enums.StructureType sType) {
        // Check if tile is empty
        if (_tileData[x, y]._state == Enums.MapTileState.Empty) {
            _tileData[x, y]._state = Enums.MapTileState.Struture;
            _tileData[x, y]._structure = StoreService.GetStructureData(sType);

            const float offset = .33f;
            // TODO : fix for aligning tiles correctly because of sprite pivot is middle
            var tileLoc = new Vector3(transform.position.x + (offset * x) - .33f, transform.position.y + (offset * y) - .33f, 0);

            var go = Instantiate(_tilePrefab, tileLoc, Quaternion.identity, transform);
            go.GetComponent<TileControllerScript>().SetTileData(_tileData[x, y]);

            // If player tile, set appropriate tag
            if (sType == Enums.StructureType.Warfare)
            {
                go.tag = Constants.TAG_PLAYER_TILE;
            }
        }
    }

    public int NumberOfFreeTiles()
    {
        int num = 0;
        for (int x = 0; x < CHUNKSIZE; x++)
        {
            for (int y = 0; y < CHUNKSIZE; y++)
            {
                if (_tileData[x, y]._state == Enums.MapTileState.Empty && _tileData[x, y]._structure == null)
                    num++;
            }
        }
        return num;
    }

    public MapTileData GetFreeTile()
    {
        MapTileData returnedTile = null;
        for (int x = 0; x < CHUNKSIZE; x++)
        {
            for (int y = 0; y < CHUNKSIZE; y++)
            {
                if (_tileData[x, y]._state == Enums.MapTileState.Empty && _tileData[x, y]._structure == null)
                    return _tileData[x, y];
            }
        }

        return returnedTile;
    }
}
