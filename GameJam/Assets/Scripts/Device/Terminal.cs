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

    }
    // Start is called before the first frame update
    protected override void isPowered()
    {
        Debug.Log("powered");
        poweredSprite.enabled = true;
        depoweredSprite.enabled = false;
    }
    protected override void isDepowered()
    {
        poweredSprite.enabled = false;
        depoweredSprite.enabled = true;
    }
}
