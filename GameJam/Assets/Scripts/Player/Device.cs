using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Device : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Speed()
    {
        double speed = 0.0;
        speed = distance / hour;
        Console.WriteLine("Vehicle Speed is {0:0.00}", speed);
    }
}
