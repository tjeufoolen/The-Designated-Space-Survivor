using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] private Dropdown QualityDropdown = null;
    [SerializeField] private Toggle FullscreenToggle = null;
    [SerializeField] private GameObject MusicSliderGameObject = null;
    [SerializeField] private GameObject EffectsSliderGameObject = null;

    void Awake()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();

        MusicSliderGameObject.GetComponent<Slider>().value = audioManager.GetSoundVolume("MainTheme");
        EffectsSliderGameObject.GetComponent<Slider>().value = audioManager.GetSoundVolume("Hit");
    }

    void Start()
    {
        #region Quality
        QualityDropdown.ClearOptions();
        QualityDropdown.AddOptions(QualitySettings.names.ToList());
        QualityDropdown.value = QualitySettings.GetQualityLevel();
        QualityDropdown.RefreshShownValue();
        #endregion Quality

        #region Fullscreen
        FullscreenToggle.isOn = Screen.fullScreen;
        #endregion Fullscreen
    }

    public void SetQualityLevel(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetMusicVolume(float volume)
    {
        FindObjectOfType<AudioManager>().SetSoundVolume("MainTheme", volume);
    }

    public void SetEffectsVolume(float volume)
    {
        string[] effects = { "Hit" };
        Array.ForEach(effects, effect =>
        {
            FindObjectOfType<AudioManager>().SetSoundVolume(effect, volume);
        });
    }
}
