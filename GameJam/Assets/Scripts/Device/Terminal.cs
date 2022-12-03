using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Terminal : IPassiveDevice
{
    [SerializeField] protected Sprite poweredSprite;
    [SerializeField] protected Sprite depoweredSprite;
    [SerializeField] protected Canvas popUp;
    [SerializeField] protected TextMeshProUGUI popTMP;
    [SerializeField] protected String popUPText;

    protected override void isPowered()
    {
        GetComponent<SpriteRenderer>().sprite = poweredSprite;
        popUp.enabled = true;
        popTMP.text = popUPText;

    }
    protected override void isDepowered()
    {

        GetComponent<SpriteRenderer>().sprite = depoweredSprite;
        popUp.enabled = false;
    }
}
