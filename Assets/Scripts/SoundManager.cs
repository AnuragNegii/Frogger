using UnityEngine;

public class SoundManager : MonoBehaviour {
    
    public static SoundManager Instance{get; private set;}
    [SerializeField] private AudioClip mainAudioClip;

    private AudioSource audioSource;

    private void Awake() {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();    
    }

    private void Start(){
        audioSource.clip = mainAudioClip;
        audioSource.Play();
    }
}
