using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyDevice : IPassiveDevice
{
    // Start is called before the first frame update
    protected override void isPowered()
    {
        GetComponent<SpriteRenderer>().color= Color.yellow;
    }
    protected override void isDepowered()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
    }
}
