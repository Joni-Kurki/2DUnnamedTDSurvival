using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StateManagerScript : MonoBehaviour
{

    public bool _isSelecting;
    public bool _isBuilding;

    public bool _isZoomedToChunk = false;

    ChunkBuilderScript _cBuilder;
    TileBuilderScript _tBuilder;
    CameraMoverScript _camera;

    [SerializeField]
    public bool _waveFinished = true;

    [SerializeField]
    public int _waveNumber = 0;

    public Text _waveInfoText;

    MapManagerScript _map;

    private bool _prevTBuilderState;
    private bool _prevCBuilderState;

    private bool _prevIsBuildingState;

    // Start is called before the first frame update
    void Start()
    {
        _cBuilder = GameObject.FindGameObjectWithTag(Constants.TAG_CHUNK_BUILDER).GetComponent<ChunkBuilderScript>();
        _tBuilder = GameObject.FindGameObjectWithTag(Constants.TAG_TILE_BUILDER).GetComponent<TileBuilderScript>();
        _camera = GameObject.FindGameObjectWithTag(Constants.TAG_MAIN_CAMERA).GetComponent<CameraMoverScript>();
        _map = GameObject.FindGameObjectWithTag(Constants.TAG_MAP_MANAGER).GetComponent<MapManagerScript>();

        UpdateWaveInfoText();
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

    public void NextWave()
    {
        _waveNumber++;
        

        var spawners = GameObject.FindGameObjectsWithTag(Constants.TAG_SPAWNER_CHUNK);
        Debug.Log("Found spawners: " + spawners.Length);

        if (spawners.Length > 0)
        {
            for (int i = 0; i < 3; i++)
            {
                var currentChunk = spawners[0].GetComponent<MapChunkController>();
                var currentMinTiles = currentChunk.NumberOfFreeTiles();

                foreach (var spawner in spawners)
                {
                    var currentTiles = spawner.GetComponent<MapChunkController>().NumberOfFreeTiles();
                    if (currentTiles < currentMinTiles)
                    {
                        currentMinTiles = currentTiles;
                        currentChunk = spawner.GetComponent<MapChunkController>();
                    }
                }

                var tileToBuild = currentChunk.GetFreeTile();
                if (tileToBuild != null)
                    currentChunk.SetTileToStructureAt(tileToBuild._x, tileToBuild._y, Enums.StructureType.Spawner);
            }
        }
        UpdateWaveInfoText();
    }

    private void UpdateWaveInfoText()
    {
        _waveInfoText.text = "Current wave: " + _waveNumber;
    }

    public void ToggleBuilders(bool isEnter)
    {

        _prevCBuilderState = _cBuilder.enabled;
        _prevTBuilderState = _tBuilder.enabled;

        _prevIsBuildingState = _isBuilding;

        if (_isBuilding)
        {
            _cBuilder.gameObject.SetActive(false);
            _tBuilder.gameObject.SetActive(false);

            _isBuilding = false;
        }
        else
        {
            _cBuilder.gameObject.SetActive(_prevCBuilderState);
            _tBuilder.gameObject.SetActive(_prevTBuilderState);

            _isBuilding = true;
        }
    }
}
