using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class Door : IPassiveDevice
{
    
    // Start is called before the first frame update
    protected override void isPowered()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<ShadowCaster2D>().enabled = false;
    }
    protected override void isDepowered()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<ShadowCaster2D>().enabled = true;
    }
}