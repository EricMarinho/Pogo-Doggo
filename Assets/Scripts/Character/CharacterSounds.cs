using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSounds : MonoBehaviour
{
    
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip fallSound;
    [SerializeField] AudioClip pickBones;

    public void PlayJumpSound(){
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(jumpSound);
    }

    public void PlayFallSound(){
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(fallSound);
    }

    public void PlayPickBonesSound(){
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(pickBones);
    }

}
