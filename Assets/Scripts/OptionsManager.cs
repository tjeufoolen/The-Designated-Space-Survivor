using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{

    public Dropdown QualityDropdown;
    public Toggle FullscreenToggle;

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

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetQualityLevel(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
