using UnityEngine;

public class Player : MonoBehaviour
{   
    private Animator animator;
    private void Awake(){
        animator = GetComponent<Animator>();
    }
    private void Update(){

    if(Input.GetKeyDown(KeyCode.W)){
        transform.position += new Vector3(0f, 1.0f, 0f);
        animator.SetTrigger("forward");
    }
    if(Input.GetKeyDown(KeyCode.S)){
        transform.position -= new Vector3(0f, 1.0f, 0f);
        animator.SetTrigger("Backward");
    }
    if(Input.GetKeyDown(KeyCode.A)){
        transform.position -= new Vector3(1.0f, 0f, 0f);
        animator.SetTrigger("Left");
    }
    if(Input.GetKeyDown(KeyCode.D)){
        transform.position += new Vector3(1.0f, 0f, 0f);
        animator.SetTrigger("Right");
    }
   }
}
