using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsHandler : MonoBehaviour
{
    
    public TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public TMP_Dropdown qualityDropDown;

    private static readonly string volumePref = "volumePref";

    private void Start() {
        
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
        qualityDropDown.value = QualitySettings.GetQualityLevel();
        volumeSlider.value = PlayerPrefs.GetFloat("volumePref", 1f);
    }

    public void setVolume(float volume){

        PlayerPrefs.SetFloat(volumePref, volume);
        audioMixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("volumePref")) * 20);

    }

    public void setQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    public void setResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
    }
}
