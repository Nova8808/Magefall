using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SettingsMenu : MonoBehaviour
{
    public GameObject Settings_Menu;
    public TMP_Dropdown qualityDropdown;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown windowDropdown;
    public TMP_Dropdown hotbarDropdown;
    public Slider GlobalVolumeSlider;
    Resolution[] resolutions;
    int scene;
    int currentResolutionIndex;

    public Sprite stone_frame;
    public Sprite minimal_frame;

    public Volume PostProcessing;
    private void Start()
    {

        scene = SceneManager.GetActiveScene().buildIndex;

        if (scene != 0)
        {
            InitializeHotbar_Style();
            GameObject VolumeObj = GameObject.Find("Global Volume");
            PostProcessing = VolumeObj.GetComponent<Volume>();
        }

        LoadSettings(currentResolutionIndex);
        Settings_Menu.SetActive(false);
        //if (!PlayerPrefs.HasKey("FirstLaunchMax"))
        //{
        //    Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        //    PlayerPrefs.SetInt("FirstLaunchMax", 1);
        //}
    }
    private void OnEnable()
    {
        //GET RESOLUTIONS AUTOMATICALLY
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        resolutionDropdown.AddOptions(options);
        LoadSettings(currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();
    }

    public void CloseSettingsButton()
    {
        Settings_Menu.SetActive(!Settings_Menu.activeSelf);

        //SAVE OPTIONS SETTINGS
        PlayerPrefs.SetInt("QualitySettingPreference",
           qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference",
                   resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference",
           windowDropdown.value);
        PlayerPrefs.SetFloat("VolumePreference",
                   GlobalVolumeSlider.value);
    }

    public void Volume_Slider()
    {
        AudioListener.volume = GlobalVolumeSlider.value;
    }

    public void Window_Change()
    {
        if (windowDropdown.value == 0)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        if (windowDropdown.value == 1)
        {
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        }
        if (windowDropdown.value == 2)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void SetResolution()
    {
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width,
                  resolution.height, Screen.fullScreen, resolution.refreshRate);

        //Debug.Log(resolution.width + " " + resolution.height + " " + resolution.refreshRate);
    }

    public void Quality_Settings()
    {
        QualitySettings.SetQualityLevel(qualityDropdown.value);
        
        if (qualityDropdown.value == 0 && scene != 0)
        {
            Basics.instance.WorldPhysicsEnabled = false;
            if (PostProcessing.profile.TryGet<MotionBlur>(out MotionBlur _motionblur))
            {
                _motionblur.active = false;
            }
            if (PostProcessing.profile.TryGet<AmbientOcclusion>(out AmbientOcclusion _ambientocc))
            {
                _ambientocc.active = false;
            }
            if (PostProcessing.profile.TryGet<Bloom>(out Bloom _bloom))
            {
                _bloom.quality.value = 0;
            }

        }
        else if (qualityDropdown.value >= 1 && scene != 0)
        {
            Basics.instance.WorldPhysicsEnabled = true;
            if (PostProcessing.profile.TryGet<MotionBlur>(out MotionBlur _motionblur))
            {
                _motionblur.active = true;
            }
            if (PostProcessing.profile.TryGet<AmbientOcclusion>(out AmbientOcclusion _ambientocc))
            {
                _ambientocc.active = true;
            }
            if (PostProcessing.profile.TryGet<Bloom>(out Bloom _bloom))
            {
                _bloom.quality.value = 1;
            }
        }
        //CAN ADD stuff to his based on dropdown value. like if low disable AA or something.
    }

    public void SetHotbarStyle()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 0)
        {
            if (hotbarDropdown.value == 0)
            {
                PlayerPrefs.SetInt("HotbarStyle", 0);
            }
            else if (hotbarDropdown.value == 1)
            {
                PlayerPrefs.SetInt("HotbarStyle", 1);
            }
        }
        else
        {
            if (hotbarDropdown.value == 0)
            {
                for (int i = 0; i < 7; i++)
                {
                    Basics.instance.Fire_Hotbar.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = stone_frame;
                    Basics.instance.Fire_Hotbar.transform.GetChild(i).transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                }
                Basics.instance.Selected_Spell.transform.GetChild(0).GetComponent<Image>().sprite = stone_frame;
                Basics.instance.Selected_Spell.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                PlayerPrefs.SetInt("HotbarStyle", 0);
            }
            else if (hotbarDropdown.value == 1)
            {
                for (int i = 0; i < 7; i++)
                {
                    Basics.instance.Fire_Hotbar.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = minimal_frame;
                    Basics.instance.Fire_Hotbar.transform.GetChild(i).transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(74, 74);
                }
                Basics.instance.Selected_Spell.transform.GetChild(0).GetComponent<Image>().sprite = minimal_frame;
                Basics.instance.Selected_Spell.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(74, 74);
                PlayerPrefs.SetInt("HotbarStyle", 1);
            }
        }
    }

    public void InitializeHotbar_Style()
    {
        if (PlayerPrefs.GetInt("HotbarStyle") == 0)
        {
            for (int i = 0; i < 7; i++)
            {
                Basics.instance.Fire_Hotbar.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = stone_frame;
                Basics.instance.Fire_Hotbar.transform.GetChild(i).transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
            }
            Basics.instance.Selected_Spell.transform.GetChild(0).GetComponent<Image>().sprite = stone_frame;
            Basics.instance.Selected_Spell.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
        }
        else if (PlayerPrefs.GetInt("HotbarStyle") == 1)
        {
            for (int i = 0; i < 7; i++)
            {
                Basics.instance.Fire_Hotbar.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = minimal_frame;
                Basics.instance.Fire_Hotbar.transform.GetChild(i).transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(74, 74);
            }
            Basics.instance.Selected_Spell.transform.GetChild(0).GetComponent<Image>().sprite = minimal_frame;
            Basics.instance.Selected_Spell.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(74, 74);
        }
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
            Quality_Settings();
        }
        else
            qualityDropdown.value = 0;
        if (PlayerPrefs.HasKey("ResolutionPreference"))
        {
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        }
        else
        {
            resolutionDropdown.value = currentResolutionIndex;
        }

            if (PlayerPrefs.HasKey("FullscreenPreference"))
        {
            windowDropdown.value = PlayerPrefs.GetInt("FullscreenPreference");
        }
        else
            windowDropdown.value = 0;

        if (PlayerPrefs.HasKey("VolumePreference"))
            GlobalVolumeSlider.value =
                        PlayerPrefs.GetFloat("VolumePreference");

        if (PlayerPrefs.HasKey("HotbarStyle"))
        {
            hotbarDropdown.value = PlayerPrefs.GetInt("HotbarStyle");
        }

    }
    
}
