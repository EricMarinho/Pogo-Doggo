using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    void Start()
    {
        audioMixer.SetFloat("volume", Mathf.Log10(PlayerPrefs.GetFloat("volumePref")) * 20);
    }

}