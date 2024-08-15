using System;
using UnityEngine;

public class PlayerAudio : MonoBehaviour{

    [Header("sfx Audio")]
    [SerializeField] private AudioClip deadOnRoadAudioClip;
    [SerializeField] private AudioClip deadOnWaterAudioClip;
    [SerializeField] private AudioClip landedSafeAudioClip;
    [SerializeField] private AudioClip youWonAudioClip;

    AudioSource audioSource;
    Player player;

    private void Start(){
        audioSource = SoundManager.Instance.GetAudioSourceForSfx();
        player = Player.Instance;
        player.LandedSafeEvent += Player_LandedSafeEvent;
        player.YouWonEvent += Player_YouWonEvent;
    }

    private void Update(){
        if(player.GetIsDead() && player.GetIsOnWater()){
            audioSource.PlayOneShot(deadOnWaterAudioClip);
        }
        if(player.GetIsDead() && !player.GetIsOnWater()){
            audioSource.PlayOneShot(deadOnRoadAudioClip);
        }
    }

    private void Player_LandedSafeEvent(object sender, EventArgs e){
        audioSource.PlayOneShot(landedSafeAudioClip);
    }
    private void Player_YouWonEvent(object sender, EventArgs e)
    {
        audioSource.PlayOneShot(youWonAudioClip);
    }

}
