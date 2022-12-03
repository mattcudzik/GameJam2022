using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : IActiveDevice
{

    bool isActive = false;

    override public void ActivateDevice()
    {

        if (powerLevel >= requiredPower && isActive == false)
        {
            isActive = true;
            isPoweredEvent?.Invoke();
        }

    }
}
