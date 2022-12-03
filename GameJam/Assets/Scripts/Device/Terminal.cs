using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : IPassiveDevice
{
    [SerializeField] protected Sprite poweredSprite;
    [SerializeField] protected Sprite depoweredSprite;
    [SerializeField] protected Canvas popUp;

    protected override void isPowered()
    {
        GetComponent<SpriteRenderer>().sprite = poweredSprite;
        popUp.enabled = true;
      

    }
    protected override void isDepowered()
    {

        GetComponent<SpriteRenderer>().sprite = depoweredSprite;
        popUp.enabled = false;
    }
}
