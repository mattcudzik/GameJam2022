using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionFrefab;

    private PlayerEventHandler playerEventHandler;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Transform playerLight;
    private IVelocity velocity;
    void Start()
    {
        playerEventHandler = gameObject.GetComponent<PlayerEventHandler>();
        playerEventHandler.OnTurn.AddListener(onTurn);
        playerEventHandler.OnWalkStart.AddListener(onWalkStart);
        playerEventHandler.OnWalkFinished.AddListener(onWalkFinished);
        playerEventHandler.OnDeath.AddListener(onDeath);

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();

        playerLight = gameObject.transform.Find("playerLight");
        velocity = gameObject.GetComponent<IVelocity>();
    }

    void Update()
    {
        Vector2 vector =  velocity.GetVelocity();
        if(vector.sqrMagnitude > 0)
        {
            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            angle -= 90;
            playerLight.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }

    private void onTurn() 
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
    private void onWalkStart()
    {
        animator.SetBool("walking", true);
    }
    private void onWalkFinished()
    {
        animator.SetBool("walking", false);
    }

    private void onDeath()
    {
        Instantiate(explosionFrefab,transform.position,Quaternion.identity);
        transform.Translate(Vector3.back * 20);
        var playerController = transform.GetComponent<KeyboardControlls>();
        playerController.enabled = false;
        spriteRenderer.enabled = false;
        var obj = GameObject.FindGameObjectsWithTag("PlayerPopUp");
        obj[0].GetComponent<Canvas>().enabled = false;
        obj[1].GetComponent<Canvas>().enabled = false;
        //Destroy(gameObject);
    }
}
