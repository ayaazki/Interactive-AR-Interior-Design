using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    public AudioSource audioSource;
    public void PlayAudio(AudioClip audio)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audio);
    }
}