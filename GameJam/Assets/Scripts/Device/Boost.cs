using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class Boost : Terminal
{
    int previousEvent=0;
    int numberOfEvents = 4;
    float remainingTime = 5f;
    bool isActive = false;
    // Start is called before the first frame update
    protected override void isPowered()
    {
        popUp.enabled = true;
        isActive = true;
         remainingTime = 5f;
        GetComponent<SpriteRenderer>().sprite = poweredSprite;
        if (previousEvent == 0)
        {
            GameObject.FindGameObjectWithTag("GlobalLight").GetComponent<Light2D>().intensity = 0.3f;
            popTMP.text = "Bonus Light";
            Debug.Log(popUp);
        }
        else if (previousEvent == 1)
        {
            GameObject.FindGameObjectWithTag("HP").GetComponent<playersHp>().hp += 3;
            popTMP.text = "Bonus Energy";
            Debug.Log(popUp);
        }
        else if (previousEvent == 2)
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<KeyboardControlls>().movementSpeed = 15f;
            GameObject.FindGameObjectsWithTag("Player")[1].GetComponent<KeyboardControlls>().movementSpeed = 15f;
            popTMP.text = "Additional Speed";
            Debug.Log(popUp);

        }
        else if (previousEvent == 3)
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<KeyboardControlls>().movementSpeed = 5f;
            GameObject.FindGameObjectsWithTag("Player")[1].GetComponent<KeyboardControlls>().movementSpeed = 5f;
            popTMP.text = "Lowered Speed";
            Debug.Log(popUp);
        }

    }


        void Update()
        {
        if (isActive)
        {
            if (remainingTime > 0f)
            {
                remainingTime -= Time.deltaTime;
            }
            else
            {
                popUp.enabled = false;
                //GetComponent<SpriteRenderer>().sprite = depoweredSprite;
                if (previousEvent == 0)
                {
                    GameObject.FindGameObjectWithTag("GlobalLight").GetComponent<Light2D>().intensity = 0.1f;
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
    }
           

}