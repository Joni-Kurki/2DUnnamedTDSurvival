using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManagerScript : MonoBehaviour
{

    [SerializeField]
    public int _chunkHeightAndWidth;

    public MapChunkData [,] _mapChunks;
    public GameObject [,] _mapChunkControllers;

    public GameObject _mapChunkPrefab;

    public SpriteLibraryScript _sLib;

    // Start is called before the first frame update
    void Start()
    {
        _sLib = GameObject.FindGameObjectWithTag(Constants.TAG_SPRITE_LIBRARY).GetComponent<SpriteLibraryScript>();

        if (_chunkHeightAndWidth % 2 == 0)
            _chunkHeightAndWidth++;

        _mapChunks = new MapChunkData[_chunkHeightAndWidth, _chunkHeightAndWidth];
        _mapChunkControllers = new GameObject[_chunkHeightAndWidth, _chunkHeightAndWidth];

        for (int x = 0; x < _chunkHeightAndWidth; x++)
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
                var chunk = go.GetComponent<MapChunkController>();
                chunk._chunkData = _mapChunks[x, y];

                _mapChunkControllers[x, y] = go;

                // Set Borders to spawner chunks
                if (x == 0 || y == 0 || x == _chunkHeightAndWidth -1 || y == _chunkHeightAndWidth - 1)
                {
                    go.GetComponent<SpriteRenderer>().sprite = _sLib.GetChunkSpriteByIndex((int)Enums.MapChunkType.MonsterSpawner);
                    _mapChunks[x, y].SetMapChunkType(Enums.MapChunkType.MonsterSpawner);
                    go.tag = Constants.TAG_SPAWNER_CHUNK;
                } // Check middle chunk to player start
                else if(x == _chunkHeightAndWidth / 2 && y == _chunkHeightAndWidth / 2)
                {
                    go.GetComponent<SpriteRenderer>().sprite = _sLib.GetChunkSpriteByIndex((int)Enums.MapChunkType.Initial);
                    _mapChunks[x, y].SetMapChunkType(Enums.MapChunkType.Initial);
                    go.tag = Constants.TAG_PLAYER_CHUNK;
                }
                else
                {
                    go.GetComponent<SpriteRenderer>().sprite = _sLib.GetChunkSpriteByIndex((int)Enums.MapChunkType.Empty_Buildable);
                    _mapChunks[x, y].SetMapChunkType(Enums.MapChunkType.Empty_Buildable);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public MapChunkData GetChunkAt(int x, int y)
    {
        return _mapChunks[x, y];
    }

    public GameObject GetMapChunkControllerAt(int x, int y)
    {
        return _mapChunkControllers[x, y];
    }
}
