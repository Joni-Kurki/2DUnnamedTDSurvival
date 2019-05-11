using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerScript : MonoBehaviour
{

    public bool _isSelecting;
    public bool _isBuilding;

    public bool _isZoomedToChunk = false;

    ChunkBuilderScript _builder;
    CameraMoverScript _camera;

    // Start is called before the first frame update
    void Start()
    {
        _builder = GameObject.FindGameObjectWithTag(Constants.TAG_CHUNK_BUILDER).GetComponent<ChunkBuilderScript>();
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

        _builder._isEnabled = _isBuilding;
        SetBuilderEnabled(_isBuilding);
    }

    private void SetBuilderEnabled(bool enabled) {
        _builder.gameObject.SetActive(enabled);
        _camera.SetInitialPosition();
    }
}
