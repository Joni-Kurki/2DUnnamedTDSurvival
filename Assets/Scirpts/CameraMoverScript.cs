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

    // Start is called before the first frame update
    void Start()
    {
        _map = GameObject.FindGameObjectWithTag(Constants.TAG_MAP_MANAGER).GetComponent<MapManagerScript>();
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
        zoom = true;
        //_camera.orthographicSize = INITIALSIZE;
    }

    public void SetZoomedPosition(Vector3 pos) {
        transform.position = pos;
        targetZoom = ZOOMEDSIZE;
        zoom = true;
        //_camera.orthographicSize = ZOOMEDSIZE;
    }

}
