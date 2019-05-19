using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField]
    public Enums.SpawnState _state = Enums.SpawnState.DoNothing;

    [SerializeField]
    public GameObject _currentTargetGo;

    [SerializeField]
    public float _wakeUpTime;

    public SpawnData _data = null;

    // TODO: this is from data
    [SerializeField]
    public float _moveSpeed = 0f;

    [SerializeField]
    public Vector2 _direction;

    private bool _wokenUp = false;


    // Start is called before the first frame update
    void Start()
    {
        _wakeUpTime = Time.time + Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        // If the spawn has awoken
        if(Time.time >= _wakeUpTime && !_wokenUp)
        {
            _state = Enums.SpawnState.LookForTarget;
            _wokenUp = true;
        }
        // If spawner data has been set
        if (_data != null)
        {
            if (_state == Enums.SpawnState.LookForTarget)
            {
                GetTarget();
            }
            else if (_state == Enums.SpawnState.MoveToTarget)
            {
                // If current target has not been destroyed already.
                if (_currentTargetGo.activeInHierarchy == false) _state = Enums.SpawnState.LookForTarget;

                // If spawn is not next to target
                if (Vector2.Distance(transform.position, _currentTargetGo.transform.position) >= _data._range)
                    MoveToTarget();
                else
                    _state = Enums.SpawnState.DamageTarget;
            }
            else if (_state == Enums.SpawnState.DamageTarget)
            {
                // If current target has not been destroyed already.
                if (_currentTargetGo.activeInHierarchy == false) _state = Enums.SpawnState.LookForTarget;

                DamageTarget(_currentTargetGo);
            }
        }
    }

    // TODO: Merge these setters?
    public void SetSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
    // TODO: Merge these setters?
    public void SetSpawnData(SpawnData data)
    {
        _data = data;
        _moveSpeed = _data._speed;
    }
    
    // Gets clsoest target with tag "PlayerTile"
    public void GetTarget()
    {
        var allTargets = GameObject.FindGameObjectsWithTag(Constants.TAG_PLAYER_TILE);

        if (allTargets.Length > 0)
        {
            var currentMinDistance = Mathf.Infinity;

            foreach (var go in allTargets)
            {
                var tempD = Vector2.Distance(gameObject.transform.position, go.transform.position);

                if (tempD < currentMinDistance)
                {
                    currentMinDistance = tempD;
                    _currentTargetGo = go;
                }
            }
        }

        if (_currentTargetGo != null)
            _state = Enums.SpawnState.MoveToTarget;
    }

    // Moves towards target with normalized speed
    public void MoveToTarget()
    {
        // DOESNT LOOK FOR CHILD (warfare tile) COMPONENT YET
        //_direction = (_currentTargetGo.transform.position) - (transform.parent.parent.transform.position);

        //gameObject.transform.Translate(_direction.normalized * _moveSpeed * Time.deltaTime, Space.World);

        _direction = (_currentTargetGo.transform.position) - (transform.transform.position);
        gameObject.transform.Translate(_direction.normalized * _moveSpeed * Time.deltaTime, Space.World);
    }

    // Damages target
    public void DamageTarget(GameObject target)
    {
        _currentTargetGo.GetComponent<TileControllerScript>().TakeDamage(_data._damage);
    }
}
