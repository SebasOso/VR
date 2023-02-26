using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource musicSource;
    [SerializeField] public AudioClip radioMusic;

    public void StartMusic()
    {
        musicSource.PlayOneShot(radioMusic);
    }
}
