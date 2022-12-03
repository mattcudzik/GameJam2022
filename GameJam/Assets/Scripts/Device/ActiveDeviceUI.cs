using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDeviceUI : MonoBehaviour
{

    private IActiveDevice activeDevice;
    private bool isUIActive;
    void Start()
    {
        activeDevice = transform.GetComponent<IActiveDevice>();
        activeDevice.onPowerUpEvent.AddListener(UpdateUI);
        isUIActive = false;
    }

    void Update()
    {
        
    }
    private void UpdateUI()
    {
        if (isUIActive)
        {

        }
    }
}
