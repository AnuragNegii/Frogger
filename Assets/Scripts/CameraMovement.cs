using UnityEngine;

public class CameraMovement : MonoBehaviour {
    
    private float yDampTop =  3.0f;
    private float yDampBottom = 0f;

    private float xDampPos = 0f;
    private float zPos = -10f;
    [SerializeField] private Player player;
    
    private void LateUpdate(){
        transform.position = player.transform.position + new Vector3(0 , 0, zPos);
        if(transform.position.y < yDampBottom){
            transform.position = new Vector3(0, yDampBottom, zPos);
        }else if(transform.position.y > yDampTop){
            transform.position = new Vector3(0, yDampTop, zPos);
        } 
        if(transform.position.x > xDampPos){
            transform.position = new Vector3(xDampPos, transform.position.y, zPos);
        }else if(transform.position.x < xDampPos){
            transform.position = new Vector3(xDampPos, transform.position.y, zPos);
        }
    }
}