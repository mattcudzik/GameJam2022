using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventHandler : MonoBehaviour
{
    public UnityEvent OnWalkStart;
    public UnityEvent OnWalkFinished;
    public UnityEvent OnTurn;
    public UnityEvent<int> OnDamage;
    public UnityEvent OnDeath;

    private IVelocity velocityComp;
    private Vector2 prevVelocity;

    private AnimationTriggerer animationTriggerer;

    private bool isWalking;
    private bool isDead;
    private bool isInContact;
    private GameObject interactableObject;
    void Start()
    {
        velocityComp = GetComponent<IVelocity>();
        prevVelocity = Vector2.right;
        if(velocityComp.GetVelocity() == Vector2.zero)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }
        //animationTriggerer = GetComponentInChildren<AnimationTriggerer>();
        //animationTriggerer.OnAnimationComplete.AddListener(OnAnimationFinished);
    }

    void Update()
    {
        if (isWalking)
        {
            Vector2 velocity = velocityComp.GetVelocity();
            if (prevVelocity.x > 0 && velocity.x < 0)
            {
                OnTurn?.Invoke();
            }
            else if (prevVelocity.x < 0 && velocity.x > 0)
            {
                OnTurn?.Invoke();
            }

            if (velocity.x != 0)
                prevVelocity = velocity;
        }

        if (!isWalking && velocityComp.GetVelocity() != Vector2.zero)
        {
            OnWalkStart?.Invoke();
            isWalking = true;
        }
        else if (isWalking && velocityComp.GetVelocity() == Vector2.zero)
        {
            OnWalkFinished?.Invoke();
            isWalking = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && isInContact==true)
        {
            print("EEEEEEEEEEE");
            interactableObject.GetComponent<SpriteRenderer>().color= Color.green;
        }

        //DEBUG
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnDamage?.Invoke(1);
        }
    }

    private void OnAnimationFinished(string name)
    {
        //if(name == "death")
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        //Debug.Log("punkt");
        if (other.tag == "Interactable")
        {
            Debug.Log("contact");
            isInContact = true;
            interactableObject = other.gameObject;
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        //Debug.Log("punkt");
        if (other.tag == "Interactable")
        {
            Debug.Log("RatherNot");
            isInContact = false;
        }

    }
}
