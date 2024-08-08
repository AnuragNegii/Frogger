using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGameClicked : MonoBehaviour {
    private Button button;

    private void Awake(){
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick(){
        SceneManager.LoadScene("GameScene");
    }
    
}