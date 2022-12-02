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
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
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
