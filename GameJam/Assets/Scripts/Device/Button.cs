using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : IActiveDevice
{
    [SerializeField] protected Sprite poweredSprite;
    [SerializeField] protected Sprite depoweredSprite;
    [SerializeField] float timePerUnit;
    float timeRemaining;
    bool isActive = false;
    //[SerializeField] new protected int powerLevel;
    //[SerializeField] new protected int maxPowerLevel;
    // Start is called before the first frame update
    void Start()
    {
        
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
                powerLevel-= PowerUsage;
                timeRemaining = timePerUnit;
                onPowerDownEvent?.Invoke();
            }
            if (powerLevel < requiredPower)
            {
                isNotPoweredEvent?.Invoke();
                isActive = false;
                GetComponent<SpriteRenderer>().sprite = depoweredSprite;
            } 
        }

    }
    override public void ActivateDevice()
    {
        if (powerLevel >= requiredPower && isActive == false)
        {
            isActive = true;
            isPoweredEvent?.Invoke();
            GetComponent<SpriteRenderer>().sprite = poweredSprite;
        } 
            
    }
}
