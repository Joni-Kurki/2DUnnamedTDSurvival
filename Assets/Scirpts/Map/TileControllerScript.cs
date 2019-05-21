using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControllerScript : MonoBehaviour
{
    MapTileData _data;
    SpriteLibraryScript _sLib;

    bool _dataSet = false;

    [SerializeField]
    public float _currentHp;

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

        // Tile died
        if (_currentHp <= 0)
        {
            _data._state = Enums.MapTileState.Empty;
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(float amount)
    {
        _currentHp -= amount;
    }

    public void SetTileData(MapTileData data) {
        _data = data;

        _currentHp = _data._structure._hp;

        // If is spawner, enable spawner script
        if (_data._structure._type == Enums.StructureType.Spawner && _data._state == Enums.MapTileState.Struture)
            GetComponent<SpawnerScript>().enabled = true;
    }
}
