using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLibraryScript : MonoBehaviour
{
    public Sprite[] _chunkSprites;
    public Sprite[] _tileSprites;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetChunkSpriteByIndex(int index)
    {
        return _chunkSprites[index];
    }

    public Sprite GetTileSpriteByIndex(int index) {
        return _tileSprites[index];
    }
}
