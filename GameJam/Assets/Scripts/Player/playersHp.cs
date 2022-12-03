using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersHp : MonoBehaviour
{
    [SerializeField] public float hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100.0f;
    }

    
    // Update is called once per frame
    void Update()
    {
    }
}
