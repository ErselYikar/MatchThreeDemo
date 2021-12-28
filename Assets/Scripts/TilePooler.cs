using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePooler : MonoBehaviour
{
    public static TilePooler TileInstance;
    public List<Sprite> tileSprites;
    public Sprite tileToPool;

    private void Awake()
    {
        TileInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
