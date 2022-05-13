using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : Stats
{
    public static PlayerHandler playerHandlerInstance;
    // Start is called before the first frame update
    void Awake()
    {
        if (playerHandlerInstance != null && playerHandlerInstance != this)
        {
            Destroy(this);
        }
        else
        {
            playerHandlerInstance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
