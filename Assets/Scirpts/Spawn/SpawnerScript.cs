using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    public int _numberOfEnemiesPerWave;

    [SerializeField]
    public float _enemySpawnInterval;

    [SerializeField]
    public GameObject _spawnPrefab;

    SpriteLibraryScript _sLib;

    // Start is called before the first frame update
    void Start()
    {
        _sLib = GameObject.FindGameObjectWithTag(Constants.TAG_SPRITE_LIBRARY).GetComponent<SpriteLibraryScript>();
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < _numberOfEnemiesPerWave; i++)
        {
            SpawnMob();
            yield return new WaitForSeconds(_enemySpawnInterval);
        }
    }

    void SpawnMob()
    {
        var spawnerGo = GameObject.FindGameObjectWithTag(Constants.TAG_SPAWNER_SPAWNS).transform;

        var enemy = Instantiate(_spawnPrefab, transform.position, Quaternion.identity, spawnerGo);
        enemy.GetComponent<SpawnController>().SetSprite(_sLib.GetTileSpriteByIndex(2));
    }
}
