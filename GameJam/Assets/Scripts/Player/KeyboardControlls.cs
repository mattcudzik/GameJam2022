using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControlls : MonoBehaviour
{
    [SerializeField] PlayerSettingsSO PSO;
    [SerializeField] public float movementSpeed;
    private Vector2 direction = Vector2.zero;
    IVelocity velocity;
    void Awake()
    {
        
        velocity = gameObject.GetComponent<IVelocity>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector2.zero;
        

        if (Input.GetKey(PSO.upKey))
            direction.y = 1f;
        
        if (Input.GetKey(PSO.downKey))
            direction.y = -1f;

        if (Input.GetKey(PSO.leftKey))
            direction.x = -1f;
        if (Input.GetKey(PSO.rightKey))
            direction.x = 1f;
        if (Input.GetKeyDown(PSO.interact))
        {
            GetComponent<PlayerEventHandler>().Interact();
        }
        direction.Normalize();

        velocity.SetVelocity(direction * movementSpeed);
    }
}
