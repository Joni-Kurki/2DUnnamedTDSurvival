using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoverScript : MonoBehaviour
{
    MapManagerScript _map;
    Vector3 _initialPosition;

    private const float INITIALSIZE = 5f;
    private const float ZOOMEDSIZE = .75f;

    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _map = GameObject.FindGameObjectWithTag(Constants.TAG_MAP_MANAGER).GetComponent<MapManagerScript>();
        _camera = GetComponent<Camera>();
        SetInitialPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInitialPosition() {
        var xy = _map._chunkHeightAndWidth / 2;

        transform.position = new Vector3(xy, xy, -10);
        _camera.orthographicSize = INITIALSIZE;
    }

    public void SetZoomedPosition(Vector3 pos) {
        transform.position = pos;
        _camera.orthographicSize = ZOOMEDSIZE;
    }

}
