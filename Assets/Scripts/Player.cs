using UnityEngine;

public class Player : MonoBehaviour
{   
    private Animator animator;
    [SerializeField] private LayerMask waterLayerMask;
    [SerializeField] private bool inWater;
    [SerializeField] private LayerMask LogLayerMask;
    private void Awake(){
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
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
        RaycastHit2D platform = Physics2D.Raycast(transform.position + transformOffset, transform.up, rayDistance, LogLayerMask);

        if(platform){
           transform.position = hit.collider.gameObject.GetComponent<Transform>().position;
        }
   // Debug.DrawRay(transform.position + transformOffset, transform.up * rayDistance, Color.red, float.MaxValue);

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
}
