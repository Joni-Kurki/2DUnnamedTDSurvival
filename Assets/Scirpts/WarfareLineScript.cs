using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarfareLineScript : MonoBehaviour
{
    private LineRenderer _line;
    public Vector3 _point;

    public bool _shooting;

    public float _shotDuration = .25f;
    public float _shotStart;
    public float _shotEnd;

    public bool _canShoot;
    public bool _shotDone;

    WarfareTileScript _war;

    // Start is called before the first frame update
    void Start()
    {
        _war = GetComponent<WarfareTileScript>();

        _line = GetComponent<LineRenderer>();
        _line.enabled = false;
        _line.useWorldSpace = true;

        _line.SetPosition(0, transform.parent.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(_war != null && _war._target != null)
        {
            _line.SetPosition(1, _war._target.transform.position);
        }
    }

    private void Shoot()
    {
        _shotStart = Time.time;
        _shotEnd = _shotStart + _shotDuration;
        _shotDone = false;
        _line.SetPosition(1, _point);
    }
}
