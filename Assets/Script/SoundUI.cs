using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class SoundUI : MonoBehaviour
{
    [SerializeField] private SoundManager soundmanager;
    [SerializeField] private AudioSource musicManager;
    private TextMeshProUGUI soundText, musicText;
    private int volume;
    private void Awake() {
        transform.Find("Sound").Find("siv").GetComponent<Button>().onClick.AddListener(() => {
            soundmanager.VolumeIncreas();
            SetSoundVolume();

        });
        transform.Find("Sound").Find("sdv").GetComponent<Button>().onClick.AddListener(() => {
            soundmanager.VolumeDcrease();
            SetSoundVolume();
        });
        transform.Find("Music").Find("mdv").GetComponent<Button>().onClick.AddListener(() => {
            DecreaseMusicVolume();
            SetMusicVolume();
        });
        transform.Find("Music").Find("miv").GetComponent<Button>().onClick.AddListener(() => {
            IncreaseMusicVolume();
            SetMusicVolume();
        });
        soundText = transform.Find("Sound").Find("soundtext").GetComponent<TextMeshProUGUI>();
        musicText = transform.Find("Music").Find("musictext").GetComponent<TextMeshProUGUI>();
        transform.Find("MenuMenuBtn").GetComponent<Button>().onClick.AddListener(() => {SceneManager.LoadScene(0);});
    }
    private void Start() {
        GetMusicVolume();
        SetSoundVolume();
    }
    private void GetMusicVolume()
    {
        volume = (int)musicManager.volume*10;
        SetMusicVolume();
    }

    private void IncreaseMusicVolume()
    {
        volume ++;
        volume= Mathf.Clamp(volume,0,10);
        musicManager.volume = (float)volume/10;
         
    }
    private void DecreaseMusicVolume()
    {
        volume --;
        volume= Mathf.Clamp(volume,0,10);
        musicManager.volume = (float)volume/10;
        
    }
    private void SetSoundVolume()
    {
        soundText.SetText(soundmanager.Volume().ToString());
    }
    private void SetMusicVolume()
    {
        musicText.SetText(volume.ToString());

    }
}
