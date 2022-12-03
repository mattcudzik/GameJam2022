using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class Boost : IPassiveDevice
{
    // Start is called before the first frame update
    protected override void isPowered()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        var light = GameObject.FindGameObjectWithTag("GlobalLight").GetComponent<Light2D>();
        light.intensity = 0.3f;
    }
    protected override void isDepowered()
    {
        var light = GameObject.FindGameObjectWithTag("GlobalLight").GetComponent<Light2D>();
        light.intensity = 0.0f;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}