using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{   
    public static Player Instance{get; private set;}
    private Animator animator;
    [SerializeField] private LayerMask waterLayerMask;
    [SerializeField] private LayerMask logLayerMask;
    [SerializeField] private LayerMask finishLineLayerMask;
    [SerializeField] private bool inWater;
    [SerializeField] private bool isDead;
    [SerializeField] private bool isOnLog;

    public bool dieOnRoad;
    public event EventHandler IsDeadEvent;

    private Vector3 startingPosition;
    private BoxCollider2D boxCollider2D;
    private void Awake(){
        if(Instance != null){
            Debug.LogError("More than One Player in the game");
        }
        Instance= this;
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponentInChildren<Animator>();

        startingPosition = transform.position;
    }
    private void Update()
    {
        if(!isOnLog && inWater){            
            isDead = true;
            Debug.Log("Is Dead");
        }
        if(isDead){
            IsDeadEvent?.Invoke(this, EventArgs.Empty);
            animator.SetBool("isDead",isDead);
            boxCollider2D.enabled = false;
            return;
        }
        if(GameManager.Instance.isPaused){
            return;
        }
        CheckForWater();
        PlayerMovement();
    }

    private void CheckForWater(){
        float rayDistance = 0.5f;
        Vector3 transformOffset = new Vector3(0f, 0.3f, 0f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + transformOffset, transform.up, rayDistance, waterLayerMask);
        if(hit){
            inWater = true;
        }else{
            inWater = false;
        }
        RaycastHit2D logHit = Physics2D.Raycast(transform.position + transformOffset, transform.up, rayDistance, logLayerMask);
        if(logHit){
            transform.parent = logHit.collider.transform;
            isOnLog = true;
        }else{
            transform.parent = null;
            isOnLog = false;
        }
        RaycastHit2D finishLineHit = Physics2D.Raycast(transform.position + transformOffset, transform.up, rayDistance, finishLineLayerMask);
        if(finishLineHit){
            finishLineHit.collider.GetComponent<BoxCollider2D>().enabled = false;
            SpriteRenderer spriteRenderer = finishLineHit.collider.GetComponent<SpriteRenderer>();
            spriteRenderer.color += new Color(0, 0, 0, 255);
            transform.position = startingPosition;
            //This is for testing
            Debug.Log("Finish");
        }

    //Debug.DrawRay(transform.position + transformOffset, transform.up * rayDistance, Color.red, float.MaxValue);
    }
    private void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0f, 1.0f, 0f);
            animator.SetTrigger("forward");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= new Vector3(0f, 1.0f, 0f);
            animator.SetTrigger("Backward");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position -= new Vector3(1.0f, 0f, 0f);
            animator.SetTrigger("Left");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1.0f, 0f, 0f);
            animator.SetTrigger("Right");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            isDead = true;
            dieOnRoad=true;
        }
    }
}
