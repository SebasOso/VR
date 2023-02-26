using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music = this.GetComponent<AudioSource>();
    }

    public void Music()
    {
        if (!music.isPlaying)
        {
            music.Play();
        }
    }
}
