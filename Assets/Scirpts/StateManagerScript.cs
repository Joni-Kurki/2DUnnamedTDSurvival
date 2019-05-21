using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerScript : MonoBehaviour
{

    public bool _isSelecting;
    public bool _isBuilding;

    public bool _isZoomedToChunk = false;

    ChunkBuilderScript _cBuilder;
    TileBuilderScript _tBuilder;
    CameraMoverScript _camera;

    // Start is called before the first frame update
    void Start()
    {
        _cBuilder = GameObject.FindGameObjectWithTag(Constants.TAG_CHUNK_BUILDER).GetComponent<ChunkBuilderScript>();
        _tBuilder = GameObject.FindGameObjectWithTag(Constants.TAG_TILE_BUILDER).GetComponent<TileBuilderScript>();
        _camera = GameObject.FindGameObjectWithTag(Constants.TAG_MAIN_CAMERA).GetComponent<CameraMoverScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) {
            SetBuilding(!_isBuilding);
        }
    }

    public void SetBuilding(bool isBuilding) {
        _isBuilding = isBuilding;
        _isSelecting = !isBuilding;

        _cBuilder._isEnabled = _isBuilding;
        _tBuilder._isEnabled = !_isBuilding;
        SetBuilderEnabled(_isBuilding);
    }

    private void SetBuilderEnabled(bool enabled) {
        _cBuilder.gameObject.SetActive(enabled);
        _tBuilder.gameObject.SetActive(!enabled);
        _camera.SetInitialPosition();
    }
}
