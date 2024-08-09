using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    [Header("PauseMenu")]
    [SerializeField] private GameObject pauseMenuGameObject;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    [Header("GameOver Menu")]
    [SerializeField] private GameObject gameOverMenuGameObject;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private bool isDead;
    private float timer = 0;

    private void Start(){
        GameManager.Instance.PauseGamePressed += GameManager_PauseGamePressed;
        GameManager.Instance.ResumeGamePressed += GameManager_ResumeGamePressed;
        Player.Instance.IsDeadEvent += Player_IsDeadEvent;
        
        pauseMenuGameObject.SetActive(false);
        gameOverMenuGameObject.SetActive(false);

        resumeButton.onClick.AddListener(OnResumeButtonClicked);
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);

        playAgainButton.onClick.AddListener(OnPlayAgainButtonClicked);
        quitButton.onClick.AddListener(QuitButtonPressed);
    }

    private void Update(){
        if(isDead){
            timer += Time.deltaTime;
            if(timer > 1){
                gameOverMenuGameObject.SetActive(true);
            }
        }
    }

    private void Player_IsDeadEvent(object sender, EventArgs e)
    {
        isDead = true;
    }

    private void QuitButtonPressed()
    {
        Debug.Log("quit");
    }

    private void OnPlayAgainButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void GameManager_ResumeGamePressed(object sender, EventArgs e)
    {
        pauseMenuGameObject.SetActive(false);
    }

    private void GameManager_PauseGamePressed(object sender, EventArgs e)
    {
       pauseMenuGameObject.SetActive(true);
    }

    private void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnResumeButtonClicked()
    {
        GameManager.Instance.ResumeGame();
    }
}