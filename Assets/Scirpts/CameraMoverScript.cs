using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoverScript : MonoBehaviour
{
    MapManagerScript _map;
    Vector3 _initialPosition;

    private const float INITIALSIZE = 5f;
    private const float ZOOMEDSIZE = .75f;

    private float zoomLerpSpeed = 5f;

    private Camera _camera;

    bool zoom = true;
    private float targetZoom;

    StateManagerScript _state;
    ChunkBuilderMouseAnimation _animation;
    // Start is called before the first frame update
    void Start()
    {
        _map = GameObject.FindGameObjectWithTag(Constants.TAG_MAP_MANAGER).GetComponent<MapManagerScript>();
        _state = GameObject.FindGameObjectWithTag(Constants.TAG_STATE_MANAGER).GetComponent<StateManagerScript>();
        _animation = GameObject.FindGameObjectWithTag(Constants.TAG_CHUNK_BUILDER).GetComponent<ChunkBuilderMouseAnimation>();
        _camera = GetComponent<Camera>();
        targetZoom = INITIALSIZE;
        SetInitialPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (zoom)
        {
            _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
            if (_camera.orthographicSize == targetZoom)
                zoom = false;
        }
    }

    public void SetInitialPosition() {
        var xy = _map._chunkHeightAndWidth / 2;

        transform.position = new Vector3(xy, xy, -10);
        targetZoom = INITIALSIZE;
        _state._isZoomedToChunk = false;
        zoom = true;
        _animation._playAnimation = true;
        //_camera.orthographicSize = INITIALSIZE;
    }

    public void SetZoomedPosition(Vector3 pos) {
        transform.position = pos;
        targetZoom = ZOOMEDSIZE;
        _state._isZoomedToChunk = true;
        zoom = true;
        _animation._playAnimation = false;
        //_camera.orthographicSize = ZOOMEDSIZE;
    }

}
