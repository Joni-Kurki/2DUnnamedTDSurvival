using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBuilderScript : MonoBehaviour
{

    [SerializeField]
    public bool _isEnabled = true;

    public bool _validBuild = true;

    const float MOUSE_OFFSET = 0;

    MapManagerScript _map;
    StateManagerScript _stateManager;

    // Start is called before the first frame update
    void Start()
    {
        _map = GameObject.FindGameObjectWithTag(Constants.TAG_MAP_MANAGER).GetComponent<MapManagerScript>();
        _stateManager = GameObject.FindGameObjectWithTag(Constants.TAG_STATE_MANAGER).GetComponent<StateManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_map != null && _isEnabled)
        {
            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var x = Mathf.RoundToInt(point.x);
            var y = Mathf.RoundToInt(point.y);

            transform.position = new Vector3(Mathf.RoundToInt(x), Mathf.RoundToInt(y), 0);

            // If mouse is within game area
            if (x >= 0 && y >= 0 && x < _map._chunkHeightAndWidth && y < _map._chunkHeightAndWidth)
            {
                var chunk = _map.GetChunkAt(Mathf.RoundToInt(point.x), Mathf.RoundToInt(point.y));

                // Check chunks type
                if (chunk._chunkType != Enums.MapChunkType.Empty_Buildable)
                {
                    _validBuild = false;
                }
                else if(chunk._chunkType == Enums.MapChunkType.Empty_Buildable)
                {
                    _validBuild = true;
                }

                // If can build and clicked
                if (Input.GetKeyDown(KeyCode.Mouse0) && _validBuild && chunk != null)
                {
                    var go = _map.GetMapChunkControllerAt(x, y);
                    go.GetComponent<SpriteRenderer>().sprite = _map._sLib.GetChunkSpriteByIndex((int)Enums.MapChunkType.Initial);
                    go.GetComponent<MapChunkController>()._chunkData._chunkType = Enums.MapChunkType.Initial;
                    go.tag = Constants.TAG_PLAYER_CHUNK;
                }
            }

            // Cursor color
            if (_validBuild)
                transform.GetComponent<SpriteRenderer>().material.color = new Color(0, 225, 0, .7f);
            else
                transform.GetComponent<SpriteRenderer>().material.color = new Color(225, 0, 0, .7f);
        }

    }

    void OnDisable() {
        Cursor.visible = true;
    }

    void OnEnable() {
        Cursor.visible = false;
    }
}
