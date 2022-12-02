using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour
{
    
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeState()
    {
        if (isActive == false)
        {
            isActive = true;
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else 
        {
            isActive = false;
            GetComponent<SpriteRenderer>().color = Color.black;
        }
    
    }
}
