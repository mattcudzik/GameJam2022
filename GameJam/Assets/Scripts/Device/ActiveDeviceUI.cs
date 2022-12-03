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
    private GameObject chargePointPrefab;

    private Transform chargeBar;
    private List<GameObject> chargePointsObjects;
    void Start()
    {
        activeDevice = transform.GetComponent<IActiveDevice>();
        activeDevice.onPowerUpEvent.AddListener(PowerUpUI);
        activeDevice.onPowerDownEvent.AddListener(PowerDownUI);
        
        chargeBar = transform.Find("Charge Bar");
        isUIActive = false;
        chargePointsObjects = new List<GameObject>(activeDevice.getMaxPowerLelvel());

    }

    private void PowerDownUI()
    {
        int charge = activeDevice.getPowerLelvel();
        int maxCharge = activeDevice.getMaxPowerLelvel();

        for (int i = charge; i < maxCharge; i++)
        {
            var spriteRenderer = chargePointsObjects[i].GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = unChargedPointSprite;
        }

        if(charge <= 0)
        {
            isUIActive = false;
            for (int i = 0; i < maxCharge; i++)
            {
                Destroy(chargePointsObjects[i]);
            }

            chargePointsObjects.Clear();
        }
    }

    private void PowerUpUI()
    {
        if (!isUIActive)
        {
            isUIActive = true;
            int maxCharge = activeDevice.getMaxPowerLelvel();
            for(int i = 0; i < maxCharge; i++)
            {
                GameObject point = Instantiate(chargePointPrefab, chargeBar);

                if (maxCharge%2 != 0)
                {    
                    point.transform.Translate(new Vector3(i * 0.375f - 0.375f*(maxCharge/2), 0, 0)); 
                }
                else
                {
                    point.transform.Translate(new Vector3(i * 0.375f - 0.1875f - 0.375f * ((maxCharge / 2)-1), 0, 0));
                }

                chargePointsObjects.Add(point);
            }

            chargePointsObjects[0].GetComponent<SpriteRenderer>().sprite = chargedPointSprite;
        }
        else
        {
            int charge = activeDevice.getPowerLelvel();
            for (int i = 0; i < charge; i++)
            {
                var spriteRenderer = chargePointsObjects[i].GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = chargedPointSprite;
            }
        }
    }
}
