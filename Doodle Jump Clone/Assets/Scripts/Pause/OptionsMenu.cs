using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    #region Audio

    public AudioMixer mixer;
    public AudioClip[] audioClips;
    public AudioClip currentClips;
    public AudioSource audioSource;
    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("savedVolume",volume);
        PlayerPrefs.Save();
    }
    public void Start()
    {
        PlayClip();
        mixer.SetFloat("volume", PlayerPrefs.GetFloat("savedVolume"));
        
    }
    public void PlayClip()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }
    #endregion
}
