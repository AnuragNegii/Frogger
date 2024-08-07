using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   private void Update(){
    if(Input.GetKeyDown(KeyCode.W)){
        transform.position += new Vector3(0f, 1.0f, 0f);
    }
    if(Input.GetKeyDown(KeyCode.S)){
        transform.position -= new Vector3(0f, 1.0f, 0f);
    }
    if(Input.GetKeyDown(KeyCode.A)){
        transform.position -= new Vector3(1.0f, 0f, 0f);
    }
    if(Input.GetKeyDown(KeyCode.D)){
        transform.position += new Vector3(1.0f, 0f, 0f);
    }
   }
}
