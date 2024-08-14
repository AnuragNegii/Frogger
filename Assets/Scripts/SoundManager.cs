using UnityEngine;

public class SoundManager : MonoBehaviour {
    
    public static SoundManager Instance{get; private set;}
    [SerializeField] private AudioSource mainAudioSource;
    [SerializeField] private AudioSource secondAudioSource;

    [SerializeField] private AudioClip mainAudioClip;
    [SerializeField] private AudioClip dieOnRoadAudioClip;


    private void Awake() {
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        mainAudioSource.volume=0.4f;
        secondAudioSource.volume=0.1f;
           
    }

    private void Start(){
        mainAudioSource.clip = mainAudioClip;
        mainAudioSource.Play();
        
    }
    private void Update(){
        if(Player.Instance!=null && Player.Instance.dieOnRoad){
          
            secondAudioSource.PlayOneShot(dieOnRoadAudioClip);
        }
    }
}
