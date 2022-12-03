using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IActiveDevice : MonoBehaviour
{
    public UnityEvent onPowerUpEvent;
    
    [SerializeField] int powerLevel;
    [SerializeField] int maxPowerLevel;
    [SerializeField] Bulb myBulb;
    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0.0f)
        {
            time -= 0.01f;
        }
        else if (time == 0.0f && powerLevel > 0)
        {
            powerLevel = 0;
            myBulb.changeState();
        }
    }

    public int getCost()
    {
        if (powerLevel < maxPowerLevel)
            return 1;
        else
            return 0;
    }

    public void Active()
    {
        Debug.Log("w³¹czylem urzadzenie i odjo³em pront");
        myBulb.changeState();
        time += 2.0f;
        powerLevel++;
    }
    public void onPowerUp()
    {
        if (powerLevel < maxPowerLevel)
        {
             powerLevel++;
             Debug.Log(powerLevel);
             onPowerUpEvent.Invoke();    
        }
    }
}
