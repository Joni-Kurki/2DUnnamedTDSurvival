using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBuilderMouseAnimation : MonoBehaviour
{
    public float _animationTickThreshold;

    public bool _isEnabled = true;

    const float _animationTick = .05f;
    const float _maxSize = 1f;
    const float _minSize = .65f;
    
    private float _lastCheck;
    public bool _playAnimation = true;
    private bool _isScalingDown = true;


    // Start is called before the first frame update
    void Start()
    {
        _lastCheck = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isEnabled && (Time.time > _lastCheck + _animationTickThreshold) && _playAnimation)
        {
            if (_isScalingDown)
            {
                transform.localScale = new Vector3(transform.localScale.x - _animationTick, transform.localScale.y - _animationTick, 0);

                if (transform.localScale.x <= _minSize)
                    _isScalingDown = false;

            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x + _animationTick, transform.localScale.y + _animationTick, 0);

                if (transform.localScale.x >= _maxSize)
                    _isScalingDown = true;
            }
            _lastCheck = Time.time;
        }
    }
}
