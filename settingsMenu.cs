using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class settingsMenu : MonoBehaviour {

    public AudioMixer mixer;
    public Dropdown resDropDown;
    Resolution[] res;
    private void Start()
    {
        res = Screen.resolutions;
        resDropDown.ClearOptions();
        List<string> options = new List<string>();
        int currentres = 0;

        for (int i = 0; i < res.Length; i++)
        {
            string option = res[i].width + " X " + res[i].height;
            options.Add(option);
            if (res[i].width == Screen.currentResolution.width && res[i].height == Screen.currentResolution.height)
            {
                currentres = i;
            }
        }
        resDropDown.AddOptions(options);
        resDropDown.value = currentres;
        resDropDown.RefreshShownValue();
    }
    public void setVol(float volume)
    {
        mixer.SetFloat("Volume", volume);
    }
    public void setQuality(int Quality)
    {
        QualitySettings.SetQualityLevel(Quality);
    }
    public void FullScreen(bool isfull)
    {
        Screen.fullScreen = isfull;
    }
    public void SetRes(int resolutionindex)
    {
        Resolution resolutions = res[resolutionindex];
        Screen.SetResolution(resolutions.width, resolutions.height, Screen.fullScreen);
    }
}
