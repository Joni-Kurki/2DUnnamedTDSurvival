using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBuilderScript : MonoBehaviour
{
    [SerializeField]
    public bool _isEnabled = false;

    MapManagerScript _map;
    Camera _cam;

    MapChunkController _tile;

    const float _TILE_SIZE = .33f;
    const float _HALF_MOUSE_SIZE = .33f / 2;
    const float _HALF_CHUNK_SIZE = 1f / 2;

    // Start is called before the first frame update
    void Start()
    {
        _map = GameObject.FindGameObjectWithTag(Constants.TAG_MAP_MANAGER).GetComponent<MapManagerScript>();
        _cam = GameObject.FindGameObjectWithTag(Constants.TAG_MAIN_CAMERA).GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_map != null && _isEnabled)
        {
            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var x = (int)_cam.transform.position.x;
            var y = (int)_cam.transform.position.y;

            var chunk = _map.GetChunkAt(x, y);

            // Check if cursor is within chunk
            if (point.x >= x - _HALF_CHUNK_SIZE + _HALF_MOUSE_SIZE && 
                point.y >= y - _HALF_CHUNK_SIZE + _HALF_MOUSE_SIZE && 
                point.x <= x + _HALF_CHUNK_SIZE - _HALF_MOUSE_SIZE && 
                point.y <= y + _HALF_CHUNK_SIZE - _HALF_MOUSE_SIZE && chunk != null)
            {
                // Get the snapped position of the X and Y inside the chunk
                float snapToGridX = -1f;
                float snapToGridY = -1f;
                var locX = point.x - x + _HALF_CHUNK_SIZE;
                var locY = point.y - y + _HALF_CHUNK_SIZE;

                if (locX >= 0 && locX < _TILE_SIZE)
                    snapToGridX = 0;
                else if (locX >= _TILE_SIZE && locX < _TILE_SIZE * 2)
                    snapToGridX = 1;
                else if (locX >= _TILE_SIZE * 2 && locX < _TILE_SIZE * 3)
                    snapToGridX = 2;

                if (locY >= 0 && locY < _TILE_SIZE)
                    snapToGridY = 0;
                else if (locY >= _TILE_SIZE && locY < _TILE_SIZE * 2)
                    snapToGridY = 1;
                else if (locY >= _TILE_SIZE * 2 && locY < _TILE_SIZE * 3)
                    snapToGridY = 2;

                // If correct grid location was found
                if (snapToGridX > -1 && snapToGridY > -1)
                {
                    // Set cursor to location
                    transform.position = new Vector3(x + (snapToGridX * _TILE_SIZE) - _TILE_SIZE, y + (snapToGridY * _TILE_SIZE) - _TILE_SIZE, 0);
                    _tile = _map.GetMapChunkControllerAt(x, y).GetComponent<MapChunkController>();//._tileData[(int)snapToGridX, (int)snapToGridY];

                    // If got tile and mouse left pressed
                    if(_tile != null && Input.GetKeyDown(KeyCode.Mouse0)){
                        // Later buy these 
                        _tile.SetTileToStructureAt((int)snapToGridX, (int)snapToGridY, Enums.StructureType.Warfare);
                    }
                }
                else
                    _tile = null;
            }
        }
    }
}
