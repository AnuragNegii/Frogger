using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObstacle : MonoBehaviour
{
    public float moveSpeed =5f;
    public bool moveRight= false;

    void Start()
    {
       
    }
    private void Update(){
       Vector2 pos=transform.localPosition;

       if(moveRight){
        
          pos.x+=Vector2.right.x * moveSpeed * Time.deltaTime;

          if(pos.x>=11){
            pos.x=-11;
          }
       }

       else{
        pos.x+=Vector2.left.x * moveSpeed * Time.deltaTime;

         if(pos.x<=-11)
         {
            pos.x =11;
         }
       }
       transform.localPosition=pos; 
    }
}
