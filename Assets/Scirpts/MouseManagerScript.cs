using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManagerScript : MonoBehaviour
{
    ChunkBuilderScript _builder;
    MapManagerScript _map;
    StateManagerScript _state;
    CameraMoverScript _camera;

    // Start is called before the first frame update
    void Start()
    {
        _map = GameObject.FindGameObjectWithTag(Constants.TAG_MAP_MANAGER).GetComponent<MapManagerScript>();
        _state = GameObject.FindGameObjectWithTag(Constants.TAG_STATE_MANAGER).GetComponent<StateManagerScript>();
        _builder = GameObject.FindGameObjectWithTag(Constants.TAG_CHUNK_BUILDER).GetComponent<ChunkBuilderScript>();
        _camera = GameObject.FindGameObjectWithTag(Constants.TAG_MAIN_CAMERA).GetComponent<CameraMoverScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _state._isSelecting) {
            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var x = Mathf.RoundToInt(point.x);
            var y = Mathf.RoundToInt(point.y);

            if (_map != null) {
                var chunk = _map._mapChunks[x, y];

                if (chunk != null && chunk._chunkType == Enums.MapChunkType.Initial) {
                    _camera.SetZoomedPosition(new Vector3(x, y, -1));   
                }
            }
        }
    }
}
