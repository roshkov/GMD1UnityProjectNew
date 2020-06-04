﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    
public TMPro.TMP_Dropdown resolutionDropdown;
 
public AudioMixer audioMixer;

Resolution[] resolutions;



 void Start() {
     resolutions = Screen.resolutions;
     resolutionDropdown.ClearOptions();
     
     //Put all array elements into list as strings
     List<string> resOptions = new List <string>();
     int currentResolutionIndex = 0;
     for (int i=0; i<resolutions.Length; i++) {
         string option = resolutions[i].width+"x" +resolutions[i].height;
         resOptions.Add(option);

         if (resolutions[i].width == Screen.currentResolution.width && 
             resolutions[i].height == Screen.currentResolution.height)
         {
             currentResolutionIndex = i;
         }
     }
     resolutionDropdown.AddOptions(resOptions);
     resolutionDropdown.value = currentResolutionIndex;
     resolutionDropdown.RefreshShownValue();
 }


public void SetResolution (int resolutionIndex) {
    Resolution resolution = resolutions[resolutionIndex];
    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
}
 public void SetVolume (float volume) {
    Debug.Log (volume); 
    audioMixer.SetFloat("MainVolume",volume);
 }

 public void SetQuality (int qualityIndex) {
     Debug.Log ("quality " + qualityIndex);
     QualitySettings.SetQualityLevel(qualityIndex);
 } 

 public void SetFullscreen (bool isFullscreen) {
     Screen.fullScreen = isFullscreen;
 }
}
