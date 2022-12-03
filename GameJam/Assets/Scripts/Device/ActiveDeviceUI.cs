using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDeviceUI : MonoBehaviour
{

    private IActiveDevice activeDevice;
    private bool isUIActive;

    [SerializeField]
    private Sprite unChargedPointSprite;
    [SerializeField]
    private Sprite chargedPointSprite;
    [SerializeField]
    private GameObject chargePointObject;
    [SerializeField]
    private GameObject chargeBar;

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
        if (!isUIActive)
        {
            isUIActive = true;
            int maxCharge = activeDevice.getMaxPowerLelvel();
            for(int i = 0; i < maxCharge; i++)
            {
                if(maxCharge%2 != 0)
                {
                    GameObject point = Instantiate(chargePointObject, chargeBar.transform);
                    point.transform.Translate(new Vector3(i * 0.375f - 0.375f*(maxCharge/2), 0, 0)); 
                }
                else
                {
                    GameObject point = Instantiate(chargePointObject, chargeBar.transform);
                    point.transform.Translate(new Vector3(i * 0.375f - 0.1875f - 0.375f * ((maxCharge / 2)-1), 0, 0));
                }
            }
            


        }
    }
}
