using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    void Start()
    {
        audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("volumePref"));
    }

}