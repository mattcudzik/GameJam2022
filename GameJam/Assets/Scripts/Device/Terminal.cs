using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : IPassiveDevice
{
    [SerializeField] Sprite poweredSprite;
    [SerializeField] Sprite depoweredSprite;

    protected override void isPowered()
    {
        GetComponent<SpriteRenderer>().sprite = poweredSprite;
        Debug.Log("ds");
    }
    protected override void isDepowered()
    {
        Debug.Log("ds");
        GetComponent<SpriteRenderer>().sprite = depoweredSprite;
        
    }
}
