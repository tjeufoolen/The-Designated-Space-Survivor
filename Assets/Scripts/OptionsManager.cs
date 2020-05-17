using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{

    public Dropdown ResolutionDropdown;

    private List<Resolution> resolutions;

    void Start()
    {
        #region Resolution
        this.resolutions = Screen.resolutions.ToList();

        // Reverse resolution options to get best on top
        this.resolutions.Reverse();

        // Convert list of resolutions to list of strings
        List<string> resolutionOptions = new List<string>();
        foreach (Resolution resolution in this.resolutions)
        {
            resolutionOptions.Add($"{resolution.width} x {resolution.height}");
        }

        // Set initial value
        ResolutionDropdown.ClearOptions();
        ResolutionDropdown.AddOptions(resolutionOptions);
        ResolutionDropdown.value = this.resolutions.FindIndex(x => (x.width == Screen.currentResolution.width && x.height == Screen.currentResolution.height));
        ResolutionDropdown.RefreshShownValue();
        #endregion Resolution
    }

    public void SetResolution(int index)
    {
        Resolution resolution = this.resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
