using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLibraryScript : MonoBehaviour
{
    public Sprite[] _sprites;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetSpriteByIndex(int index)
    {
        return _sprites[index];
    }
}
