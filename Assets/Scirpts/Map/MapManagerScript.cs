﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManagerScript : MonoBehaviour
{

    [SerializeField]
    public int _chunkHeightAndWidth;

    public MapChunkData [,] _mapChunks;

    public GameObject _mapChunkPrefab;

    private SpriteLibraryScript _sLib;

    // Start is called before the first frame update
    void Start()
    {
        _sLib = GameObject.FindGameObjectWithTag(Constants.TAG_SPRITE_LIBRARY).GetComponent<SpriteLibraryScript>();

        if (_chunkHeightAndWidth % 2 == 0)
            _chunkHeightAndWidth++;

        _mapChunks = new MapChunkData[_chunkHeightAndWidth, _chunkHeightAndWidth];

        for(int x = 0; x < _chunkHeightAndWidth; x++)
        {
            for (int y = 0; y < _chunkHeightAndWidth; y++)
            {
                _mapChunks[x, y] = new MapChunkData(x, y);
            }
        }

        for (int x = 0; x < _chunkHeightAndWidth; x++)
        {
            for (int y = 0; y < _chunkHeightAndWidth; y++)
            {
                var go = Instantiate(_mapChunkPrefab, new Vector3Int(_mapChunks[x, y]._x, _mapChunks[x, y]._y, 0), Quaternion.identity, transform);


                if(x == 0 || y == 0 || x == _chunkHeightAndWidth -1 || y == _chunkHeightAndWidth - 1)
                {
                    go.GetComponent<SpriteRenderer>().sprite = _sLib.GetSpriteByIndex((int)Enums.MapChunkType.MonsterSpawner);
                }
                else if(x == _chunkHeightAndWidth / 2 && y == _chunkHeightAndWidth / 2)
                {
                    go.GetComponent<SpriteRenderer>().sprite = _sLib.GetSpriteByIndex((int)Enums.MapChunkType.Initial);
                }
                else
                {
                    go.GetComponent<SpriteRenderer>().sprite = _sLib.GetSpriteByIndex((int)Enums.MapChunkType.Empty_Buildable);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}