using System;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    
    public static SoundManager Instance{get; private set;}
    [SerializeField] private AudioSource mainAudioSource;
    [SerializeField] private AudioSource secondAudioSource;

    [SerializeField] private AudioClip mainAudioClip;

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
        mainAudioSource.loop = true;
    }

    public AudioSource GetAudioSourceForSfx(){
        return secondAudioSource;
    }
}
