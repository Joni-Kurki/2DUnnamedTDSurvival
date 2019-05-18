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

    // TODO from data
    [SerializeField]
    public float _moveSpeed = 1f;

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
        if(Time.time >= _wakeUpTime && !_wokenUp)
        {
            _state = Enums.SpawnState.LookForTarget;
            _wokenUp = true;
        }

        if(_state == Enums.SpawnState.LookForTarget)
        {
            GetTarget();
        }
        else if(_state == Enums.SpawnState.MoveToTarget)
        {
            if(_currentTargetGo.activeInHierarchy == false) _state = Enums.SpawnState.LookForTarget;

            if(Vector2.Distance(transform.position, _currentTargetGo.transform.position) >= .25f)
                MoveToTarget();
        }
        else if (_state == Enums.SpawnState.DamageTarget)
        {
            if (_currentTargetGo == null) _state = Enums.SpawnState.LookForTarget;

            DamageTarget(_currentTargetGo);
        }
    }

    public void SetSprite(Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

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

    public void MoveToTarget()
    {
        // DOESNT LOOK FOR CHILD (warfare tile) COMPONENT YET
        //_direction = (_currentTargetGo.transform.position) - (transform.parent.parent.transform.position);

        //gameObject.transform.Translate(_direction.normalized * _moveSpeed * Time.deltaTime, Space.World);

        _direction = (_currentTargetGo.transform.position) - (transform.transform.position);
        gameObject.transform.Translate(_direction.normalized * _moveSpeed * Time.deltaTime, Space.World);
    }

    public void DamageTarget(GameObject target)
    {

    }
}
