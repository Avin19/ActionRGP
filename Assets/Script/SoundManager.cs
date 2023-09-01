using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameObject playerController;
    private AudioSource audioSource;
    [SerializeField] private  List<AudioClip> audioClips;
    private int volume ;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        volume = (int)audioSource.volume*10;
        
    }
    private void Start()
    {
        HealthSystem healthSystem = playerController.GetComponent<HealthSystem>();
        playerController.GetComponent<PlayerController>().OnCoinCollection += Player_CoinCollected;
        healthSystem.OnHurt += Player_OnHurt;
        healthSystem.OnDead += Player_OnDead;
        
    }

    private void Player_OnDead(object sender, EventArgs e)
    {
        audioSource.PlayOneShot(audioClips[2]);
        
    }

    private void Player_OnHurt(object sender, EventArgs e)
    {
        audioSource.PlayOneShot(audioClips[3]);
    }

    private void Player_CoinCollected(object sender, EventArgs e)
    {
       audioSource.PlayOneShot(audioClips[0]);
    }
    public int Volume()
    {
        return volume;
    }
    public void VolumeIncreas()
    {
        volume ++;
        volume = Mathf.Clamp(volume, 0, 10);
        audioSource.volume = (float)volume/10;
    }
    public void VolumeDcrease()
    {
        volume --;
        volume = Mathf.Clamp(volume, 0, 10);
        audioSource.volume =(float)volume/10;
    }
}
