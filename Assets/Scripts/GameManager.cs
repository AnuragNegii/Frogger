using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public static GameManager Instance{get; private set;}
    [SerializeField] private Canvas canvas;
    public bool isPaused;
    private void Awake(){
        if(Instance != null){
            Debug.LogError("There is more than one Game Manager");
        }
        Instance = this;
    }
    
    private void Start(){
        Time.timeScale = 1;
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }else{
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        canvas.gameObject.SetActive(true); 
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        canvas.gameObject.SetActive(false);
    }
}
