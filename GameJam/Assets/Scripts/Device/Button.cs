using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : IActiveDevice
{
    [SerializeField] float timePerUnit;
    float timeRemaining;
    bool isActive = false;
    //[SerializeField] new protected int powerLevel;
    //[SerializeField] new protected int maxPowerLevel;
    // Start is called before the first frame update
    void Start()
    {
        requiredPower = 1;
        powerLevel=0;
        maxPowerLevel=3;
        timeRemaining = timePerUnit;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                powerLevel--;
                timeRemaining = timePerUnit;

            }
            if (powerLevel < requiredPower)
            {
                isNotPoweredEvent?.Invoke();
                isActive = false;
            } 
        }

    }
    override public void ActivateDevice()
    {
        
        if (powerLevel >= requiredPower && isActive == false)
        {
            isActive = true;
            isPoweredEvent?.Invoke();
        } 
            
    }
}
