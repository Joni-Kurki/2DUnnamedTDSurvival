using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBuilderScript : MonoBehaviour
{

    [SerializeField]
    public bool _isEnabled = true;

    public bool _validBuild = true;

    const float MOUSE_OFFSET = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isEnabled && _validBuild)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, .8f);

            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(Mathf.RoundToInt(point.x + MOUSE_OFFSET), Mathf.RoundToInt(point.y + MOUSE_OFFSET), 0);
        }
        else if(_isEnabled && !_validBuild)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, .8f);

            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(Mathf.RoundToInt(point.x + MOUSE_OFFSET), Mathf.RoundToInt(point.y + MOUSE_OFFSET), 0);
        }
        else if(!_isEnabled)
        {
            GetComponent<SpriteRenderer>().color = Color.clear;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }

        // TODO for test
        if (Input.GetKeyDown(KeyCode.Mouse1)){
            _validBuild = !_validBuild;
        }
    }
}
