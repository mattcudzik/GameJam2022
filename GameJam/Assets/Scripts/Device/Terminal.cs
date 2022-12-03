using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : IPassiveDevice
{
    [SerializeField] protected Sprite poweredSprite;
    [SerializeField] protected Sprite depoweredSprite;

    protected override void isPowered()
    {
        GetComponent<SpriteRenderer>().sprite = poweredSprite;

    }
    protected override void isDepowered()
    {

        GetComponent<SpriteRenderer>().sprite = depoweredSprite;
        
    }
}
