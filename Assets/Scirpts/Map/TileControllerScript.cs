using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControllerScript : MonoBehaviour
{
    MapTileData _data;
    SpriteLibraryScript _sLib;

    bool _dataSet = false;

    // Start is called before the first frame update
    void Start()
    {
        _sLib = GameObject.FindGameObjectWithTag(Constants.TAG_SPRITE_LIBRARY).GetComponent<SpriteLibraryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_data != null) {
            GetComponent<SpriteRenderer>().sprite = _sLib.GetTileSpriteByIndex((int)_data._structure._type);
        }
    }

    public void SetTileData(MapTileData data) {
        _data = data;

        if (_data._structure._type == Enums.StructureType.Spawner && _data._type == Enums.MapTileType.Struture)
            GetComponent<SpawnerScript>().enabled = true;
    }
}
