using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SmallLightBehaviour : MonoBehaviour
{
    Light2D light;
    bool outOfRange=true;
    [SerializeField] float Timeout = 2;
    [SerializeField] float lightIntensity = 0.2f;
    private void Start()
    {
         light= GetComponent<Light2D>();
         light.intensity = 0;
    }
    private void Update()
    {
        if (outOfRange)
        {
            if (Timeout > 0)
                Timeout -= Time.deltaTime;
            else
                light.intensity = 0;
  
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        //Debug.Log("punkt");
        if (other.tag == "Player")
        {
            outOfRange= false;
            Timeout = 2;
            light.intensity = lightIntensity;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        //Debug.Log("punkt");
        if (other.tag == "Player")
        {
            outOfRange = true;
        }

    }
}
