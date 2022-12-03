using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class Boost : IPassiveDevice
{
    int previousEvent=0;
    int numberOfEvents = 4;
    // Start is called before the first frame update
    protected override void isPowered()
    {
        if (previousEvent == 0)
        {
            GameObject.FindGameObjectWithTag("GlobalLight").GetComponent<Light2D>().intensity = 0.3f;
        }
        else if (previousEvent == 1)
        {
            playersHp.hp += 3;
        }
        else if (previousEvent == 2)
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<KeyboardControlls>().movementSpeed = 15f;
            GameObject.FindGameObjectsWithTag("Player")[1].GetComponent<KeyboardControlls>().movementSpeed = 15f;

        }
        else if (previousEvent == 3)
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<KeyboardControlls>().movementSpeed = 5f;
            GameObject.FindGameObjectsWithTag("Player")[1].GetComponent<KeyboardControlls>().movementSpeed = 5f;

        }

    }
    protected override void isDepowered()
    {
        if (previousEvent == 0)
        {
           GameObject.FindGameObjectWithTag("GlobalLight").GetComponent<Light2D>().intensity=0.1f;
        }
        else if (previousEvent == 2 || previousEvent == 3)
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<KeyboardControlls>().movementSpeed = 10f;
            GameObject.FindGameObjectsWithTag("Player")[1].GetComponent<KeyboardControlls>().movementSpeed = 10f;

        }
        previousEvent++;
        if (previousEvent == numberOfEvents) previousEvent = 0;
    }
}