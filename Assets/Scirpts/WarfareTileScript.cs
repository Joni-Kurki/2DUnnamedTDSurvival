using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarfareTileScript : MonoBehaviour
{
    public GameObject _linePrefab;
    public GameObject _target = null;

    public WarfareData _warfareData;

    [SerializeField]
    public float _speed;

    [SerializeField]
    public float _damage;

    [SerializeField]
    public float _range;

    public Enums.WarfareState _state = Enums.WarfareState.Idle;



    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_linePrefab, transform);
        _state = Enums.WarfareState.LookForTargetInRange; 
    }

    // Update is called once per frame
    void Update()
    {
        if(_state == Enums.WarfareState.Idle)
        {

        }
        else if(_state == Enums.WarfareState.LookForTargetInRange)
        {
            if(_target == null || (_target != null && Vector2.Distance(transform.position, _target.transform.position) >= _range))
                LookForTargets();

            if (_target != null && Vector2.Distance(transform.position, _target.transform.position) <= _range)
                _state = Enums.WarfareState.Shoot;
        }
        else if(_state == Enums.WarfareState.Shoot)
        {
            _target.GetComponent<SpawnController>().TakeDamage(_damage);
        }

        if (_target != null && _target.activeInHierarchy == false)
        {
            _target = null;
            _state = Enums.WarfareState.LookForTargetInRange;
        }
    }

    public void SetWarfareData(WarfareData data)
    {
        _warfareData = data;
        _speed = _warfareData._attackSpeed;
        _damage = _warfareData._attackDamage;
        _range = _warfareData._range;
    }

    private void LookForTargets()
    {
        var allTargets = GameObject.FindGameObjectsWithTag(Constants.TAG_SPAWN);

        if (allTargets.Length > 0)
        {
            var currentMinDistance = Mathf.Infinity;

            foreach (var go in allTargets)
            {
                var tempD = Vector2.Distance(gameObject.transform.position, go.transform.position);

                if (tempD < currentMinDistance)
                {
                    currentMinDistance = tempD;
                    _target = go;
                }
            }
        }

        //if (_target != null )
        //    _state = Enums.WarfareState.Shoot;
    }
}
