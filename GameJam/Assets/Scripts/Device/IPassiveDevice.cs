using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPassiveDevice : MonoBehaviour
{
    [SerializeField] List<IActiveDevice> activeDevices;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var device in activeDevices)
        {
            device.isPoweredEvent.AddListener(isPowered);
            device.isNotPoweredEvent.AddListener(isDepowered);
        }
    }
    
    protected virtual void isPowered()
    {

    }
    protected virtual void isDepowered()
    {

    }
}
