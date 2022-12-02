using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyVelocity : MonoBehaviour, IVelocity
{
    private Rigidbody2D rigidbody;
    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    public void SetVelocity(Vector2 _velocity)
    {
        rigidbody.velocity = _velocity;
    }

    public Vector2 GetVelocity()
    {
        return rigidbody.velocity;
    }
}
