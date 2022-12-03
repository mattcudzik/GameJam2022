using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : IPassiveDevice
{
    [SerializeField] SpriteRenderer poweredSprite;
    [SerializeField] SpriteRenderer depoweredSprite;
    private void Start()
    {
        poweredSprite.enabled = false;
        GetComponent<SpriteRenderer>().sprite=depoweredSprite.sprite;

    }
    protected override void isPowered()
    {
        GetComponent<SpriteRenderer>().sprite = poweredSprite.sprite;
    
    }
    protected override void isDepowered()
    {

        GetComponent<SpriteRenderer>().sprite = depoweredSprite.sprite;
        
    }
}
