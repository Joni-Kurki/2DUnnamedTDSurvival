using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBuilderScript : MonoBehaviour
{

    [SerializeField]
    public bool _isEnabled = true;

    const float MOUSE_OFFSET = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isEnabled)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, .8f);

            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            
            transform.position = new Vector3(Mathf.RoundToInt(point.x + MOUSE_OFFSET), Mathf.RoundToInt(point.y + MOUSE_OFFSET), 0);

            
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.clear;
        }
    }
}
