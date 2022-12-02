using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControlls : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
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

        if (Input.GetKey(KeyCode.W))
            direction.y = 1f;
        if (Input.GetKey(KeyCode.S))
            direction.y = -1f;

        if (Input.GetKey(KeyCode.A))
            direction.x = -1f;
        if (Input.GetKey(KeyCode.D))
            direction.x = 1f;

        direction.Normalize();

        velocity.SetVelocity(direction * movementSpeed);
    }
}
