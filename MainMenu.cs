using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public GameObject Settings_Menu;
    public GameObject MainMenuCamera;
    private Animator TitleAnimator;
    private Animator MainMenuButtonsAnimator;
    public GameObject SpellSelectMenu;
    public GameObject CrystalFragDisplay;
    public GameObject UnlockPopup;
    public Button UnlockButton;
    public GameObject NotEnoughPanel;
    public GameObject NoSpellSelectedPanel;
    private int Map_Selction;
    public GameObject Map_Selection_Root;
    public GameObject Tooltip;
    public GameObject LoadingPanel;
    public GameObject ControlsPanel;

    public GameObject SelectedSpell;
    public GameObject Fireball_Button;
    public GameObject WaveCannon_Button;
    public GameObject FrostBlades_Button;
    public GameObject ChainLight_button;
    public GameObject Static_Button;
    public GameObject RockBarrage_Button;
    public GameObject EarthBend_Button;
    public GameObject SolarFlare_Button;
    public GameObject IceRay_Button;
    public GameObject MoltenSmash_Button;

    private void Start()
    {
        PlayerPrefs.DeleteKey("StartSpell");
        Map_Selction = 0;

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        MainMenuButtonsAnimator = transform.GetComponent<Animator>();
        TitleAnimator = MainMenuCamera.transform.GetComponent<Animator>();
        TitleAnimator.Play("OpenScene");

        #region Unlocked Spells
        if (PlayerPrefs.HasKey("WaveCannon"))
        {
            WaveCannon_Button.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        if (PlayerPrefs.HasKey("Static"))
        {
            Static_Button.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        if (PlayerPrefs.HasKey("EarthBend"))
        {
            EarthBend_Button.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        if (PlayerPrefs.HasKey("SolarFlare"))
        {
            SolarFlare_Button.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        if (PlayerPrefs.HasKey("IceRay"))
        {
            IceRay_Button.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        if (PlayerPrefs.HasKey("MoltenSmash"))
        {
            MoltenSmash_Button.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        #endregion
        #region Initialize Runes
        if (!PlayerPrefs.HasKey("Fire Damage"))
        {
            PlayerPrefs.SetInt("Fire Damage", 0);
        }
        if (!PlayerPrefs.HasKey("Fire Speed"))
        {
            PlayerPrefs.SetInt("Fire Speed", 0);
        }
        if (!PlayerPrefs.HasKey("Frost Damage"))
        {
            PlayerPrefs.SetInt("Frost Damage", 0);
        }
        if (!PlayerPrefs.HasKey("Frost Speed"))
        {
            PlayerPrefs.SetInt("Frost Speed", 0);
        }
        if (!PlayerPrefs.HasKey("Air Damage"))
        {
            PlayerPrefs.SetInt("Air Damage", 0);
        }
        if (!PlayerPrefs.HasKey("Air Speed"))
        {
            PlayerPrefs.SetInt("Air Speed", 0);
        }
        if (!PlayerPrefs.HasKey("Earth Damage"))
        {
            PlayerPrefs.SetInt("Earth Damage", 0);
        }
        if (!PlayerPrefs.HasKey("Earth Speed"))
        {
            PlayerPrefs.SetInt("Earth Speed", 0);
        }
        if (!PlayerPrefs.HasKey("Health Total"))
        {
            PlayerPrefs.SetInt("Health Total", 0);
        }
        if (!PlayerPrefs.HasKey("Health Regen"))
        {
            PlayerPrefs.SetInt("Health Regen", 0);
        }
        if (!PlayerPrefs.HasKey("Ward Regen"))
        {
            PlayerPrefs.SetInt("Ward Regen", 0);
        }
        if (!PlayerPrefs.HasKey("Ward Regen"))
        {
            PlayerPrefs.SetInt("Ward Regen", 0);
        }
        #endregion
        DisplayCrystalCount();
        //PlayerPrefs.DeleteKey("Static");
        //PlayerPrefs.DeleteKey("Earth Bend");
        //PlayerPrefs.DeleteKey("WaveCannon");
        //PlayerPrefs.SetInt("Crystals", 1000);
    }


    public void ExitGameButton()
    {
        Application.Quit();

    }

    public void DisplayCrystalCount()
    {
        if (PlayerPrefs.HasKey("Crystals"))
        {
            CrystalFragDisplay.GetComponent<TMP_Text>().text = (PlayerPrefs.GetInt("Crystals").ToString());
        }
        else CrystalFragDisplay.GetComponent<TMP_Text>().text = "0";
    }
    

    public void StartGameButton()
    {
        StartCoroutine(StartGameKaboom());

    }
    public void BacktoMain()
    {
        TitleAnimator.Play("OpenScene");
        MainMenuButtonsAnimator.Play("RollUpMainMenu");
        SpellSelectMenu.SetActive(false);
    }

    //public void CloseSettingsButton()
    //{
    //    Settings_Menu.SetActive(!Settings_Menu.activeSelf);

    //    //SAVE OPTIONS SETTINGS
    //    PlayerPrefs.SetInt("QualitySettingPreference",
    //       qualityDropdown.value);
    //    PlayerPrefs.SetInt("ResolutionPreference",
    //               resolutionDropdown.value);
    //    PlayerPrefs.SetInt("FullscreenPreference",
    //       windowDropdown.value);
    //    PlayerPrefs.SetFloat("VolumePreference",
    //               GlobalVolumeSlider.value);
    //}

    IEnumerator StartGameKaboom()
    {
        //Pan is actually just the disolve font
        TitleAnimator.Play("StartGamePan");
        MainMenuButtonsAnimator.Play("RollDownMainMenu");
        yield return new WaitForSeconds(1);
        SpellSelectMenu.SetActive(true);
        PlayerPrefs.DeleteKey("StartSpell");
        Map_Selction = 0;
        Reset_Tooltip();
        SelectedSpell.transform.position = new Vector2(3000, 0);
        DisplayCrystalCount();

        if (!PlayerPrefs.HasKey("FirstRun"))
        {
            ControlsPanel.SetActive(true);
            PlayerPrefs.SetInt("FirstRun", 1);
        }
        //yield return new WaitForSeconds(3);

        //int random_scene = Random.Range(1, 3);
        //SceneManager.LoadScene(random_scene);
    }
    public void Random_Map_Select()
    {
        Map_Selection_Root.transform.GetChild(0).transform.position = Map_Selection_Root.transform.GetChild(1).transform.position;
        Map_Selction = 0;
    }
    public void Forest_Select()
    {
        Map_Selection_Root.transform.GetChild(0).transform.position = Map_Selection_Root.transform.GetChild(2).transform.position;
        Map_Selction = 1;
    }
    public void Desert_Select()
    {
        Map_Selection_Root.transform.GetChild(0).transform.position = Map_Selection_Root.transform.GetChild(3).transform.position;
        Map_Selction = 2;
    }
    public void Snow_Select()
    {
        Map_Selection_Root.transform.GetChild(0).transform.position = Map_Selection_Root.transform.GetChild(4).transform.position;
        Map_Selction = 3;
    }
    public void Volcano_Select()
    {
        Map_Selection_Root.transform.GetChild(0).transform.position = Map_Selection_Root.transform.GetChild(5).transform.position;
        Map_Selction = 4;
    }

    public void Fireball_Select()
    {
        SelectedSpell.transform.position = Fireball_Button.transform.position;
        PlayerPrefs.SetString("StartSpell", "Fireball");
        Tooltip.transform.GetChild(0).GetComponent<TMP_Text>().text = "A ball of fire that explodes in a small area";
        Tooltip.transform.GetChild(1).GetComponent<TMP_Text>().text = "";
    }
    public void MoltenSmash_Select()
    {
        Tooltip.transform.GetChild(0).GetComponent<TMP_Text>().text = "Smash down with a giant molten mace leaving a scorched area";
        Tooltip.transform.GetChild(1).GetComponent<TMP_Text>().text = "";
        if (PlayerPrefs.HasKey("MoltenSmash"))
        {
            SelectedSpell.transform.position = MoltenSmash_Button.transform.position;
            PlayerPrefs.SetString("StartSpell", "MoltenSmash");
        }
        else
        {
            UnlockPopup.SetActive(true);
            UnlockPopup.transform.GetChild(0).GetComponent<TMP_Text>().text = "Unlock Molten Smash for 100 crystal fragments?";
            UnlockButton.onClick.RemoveAllListeners();
            UnlockButton.onClick.AddListener(MoltenSmash_Unlock);
        }
    }
    public void MoltenSmash_Unlock()
    {
        int current_crystals = PlayerPrefs.GetInt("Crystals");
        if (current_crystals >= 100)
        {
            PlayerPrefs.SetInt("MoltenSmash", 1);
            MoltenSmash_Button.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            current_crystals -= 100;
            PlayerPrefs.SetInt("Crystals", current_crystals);
            DisplayCrystalCount();
            UnlockPopup.SetActive(false);
        }
        else NotEnoughPanel.SetActive(true);
    }
    public void IceRay_Select()
    {
        Tooltip.transform.GetChild(0).GetComponent<TMP_Text>().text = "An icy ray that damages and freezes foes";
        Tooltip.transform.GetChild(1).GetComponent<TMP_Text>().text = "";
        if (PlayerPrefs.HasKey("IceRay"))
        {
            SelectedSpell.transform.position = IceRay_Button.transform.position;
            PlayerPrefs.SetString("StartSpell", "IceRay");
        }
        else
        {
            UnlockPopup.SetActive(true);
            UnlockPopup.transform.GetChild(0).GetComponent<TMP_Text>().text = "Unlock Ice Ray for 100 crystal fragments?";
            UnlockButton.onClick.RemoveAllListeners();
            UnlockButton.onClick.AddListener(IceRay_Unlock);
        }
    }
    public void IceRay_Unlock()
    {
        int current_crystals = PlayerPrefs.GetInt("Crystals");
        if (current_crystals >= 100)
        {
            PlayerPrefs.SetInt("IceRay", 1);
            IceRay_Button.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            current_crystals -= 100;
            PlayerPrefs.SetInt("Crystals", current_crystals);
            DisplayCrystalCount();
            UnlockPopup.SetActive(false);
        }
        else NotEnoughPanel.SetActive(true);
    }
    public void WaveCannon_Select()
    {
        Tooltip.transform.GetChild(0).GetComponent<TMP_Text>().text = "Dual cannons of water that shoot blasts of water";
        Tooltip.transform.GetChild(1).GetComponent<TMP_Text>().text = "";
        if (PlayerPrefs.HasKey("WaveCannon"))
        {
            SelectedSpell.transform.position = WaveCannon_Button.transform.position;
            PlayerPrefs.SetString("StartSpell", "WaveCannon");
        } else
        {
            UnlockPopup.SetActive(true);
            UnlockPopup.transform.GetChild(0).GetComponent<TMP_Text>().text = "Unlock Wave Cannon for 100 crystal fragments?";
            UnlockButton.onClick.RemoveAllListeners();
            UnlockButton.onClick.AddListener(WaveCannon_Unlock);
        }
    }
    public void WaveCannon_Unlock()
    {
        int current_crystals = PlayerPrefs.GetInt("Crystals");
        if (current_crystals >= 100)
        {
            PlayerPrefs.SetInt("WaveCannon", 1);
            WaveCannon_Button.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            current_crystals -= 100;
            PlayerPrefs.SetInt("Crystals", current_crystals);
            DisplayCrystalCount();
            UnlockPopup.SetActive(false);
        }
        else NotEnoughPanel.SetActive(true);
    }
    public void FrostBlades_Select()
    {
        Tooltip.transform.GetChild(0).GetComponent<TMP_Text>().text = "Icy blades that quickly slash nearby foes";
        Tooltip.transform.GetChild(1).GetComponent<TMP_Text>().text = "";
        SelectedSpell.transform.position = FrostBlades_Button.transform.position;
        PlayerPrefs.SetString("StartSpell", "FrostBlades");
    }
    public void ChainLightning_Select()
    {
        SelectedSpell.transform.position = ChainLight_button.transform.position;
        PlayerPrefs.SetString("StartSpell", "ChainLightning");
        Tooltip.transform.GetChild(0).GetComponent<TMP_Text>().text = "";
        Tooltip.transform.GetChild(1).GetComponent<TMP_Text>().text = "A bolt of lightning that chains between enemies";
    }
    public void Static_Select()
    {
        Tooltip.transform.GetChild(0).GetComponent<TMP_Text>().text = "";
        Tooltip.transform.GetChild(1).GetComponent<TMP_Text>().text = "A channeled cone of deadly electricity";
        if (PlayerPrefs.HasKey("Static"))
        {
            SelectedSpell.transform.position = Static_Button.transform.position;
            PlayerPrefs.SetString("StartSpell", "Static");
        }
        else
        {
            UnlockPopup.SetActive(true);
            UnlockPopup.transform.GetChild(0).GetComponent<TMP_Text>().text = "Unlock Static for 100 crystal fragments?";
            UnlockButton.onClick.RemoveAllListeners();
            UnlockButton.onClick.AddListener(Static_Unlock);
        }
    }
    public void Static_Unlock()
    {
        int current_crystals = PlayerPrefs.GetInt("Crystals");
        if (current_crystals >= 100)
        {
            PlayerPrefs.SetInt("Static", 1);
            Static_Button.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            current_crystals -= 100;
            PlayerPrefs.SetInt("Crystals", current_crystals);
            DisplayCrystalCount();
            UnlockPopup.SetActive(false);
        }
        else NotEnoughPanel.SetActive(true);
    }
    public void RockBarrage_Select()
    {
        Tooltip.transform.GetChild(0).GetComponent<TMP_Text>().text = "";
        Tooltip.transform.GetChild(1).GetComponent<TMP_Text>().text = "Shoot a barrage of stone chunks";
        SelectedSpell.transform.position = RockBarrage_Button.transform.position;
        PlayerPrefs.SetString("StartSpell", "RockBarrage");
    }
    public void Earth_Bend_Select()
    {
        Tooltip.transform.GetChild(0).GetComponent<TMP_Text>().text = "";
        Tooltip.transform.GetChild(1).GetComponent<TMP_Text>().text = "An impaling spike of earth";
        if (PlayerPrefs.HasKey("EarthBend"))
        {
            SelectedSpell.transform.position = EarthBend_Button.transform.position;
            PlayerPrefs.SetString("StartSpell", "EarthBend");
        }
        else
        {
            UnlockPopup.SetActive(true);
            UnlockPopup.transform.GetChild(0).GetComponent<TMP_Text>().text = "Unlock Earth Bend for 100 crystal fragments?";
            UnlockButton.onClick.RemoveAllListeners();
            UnlockButton.onClick.AddListener(Earth_Bend_Unlock);
        }
    }
    public void Earth_Bend_Unlock()
    {
        int current_crystals = PlayerPrefs.GetInt("Crystals");
        if (current_crystals >= 100)
        {
            PlayerPrefs.SetInt("EarthBend", 1);
            EarthBend_Button.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            current_crystals -= 100;
            PlayerPrefs.SetInt("Crystals", current_crystals);
            DisplayCrystalCount();
            UnlockPopup.SetActive(false);
        }
        else NotEnoughPanel.SetActive(true);
    }
    public void Solar_Flare_Select()
    {
        Tooltip.transform.GetChild(0).GetComponent<TMP_Text>().text = "An area explodes in fire after a small delay";
        Tooltip.transform.GetChild(1).GetComponent<TMP_Text>().text = "";
        if (PlayerPrefs.HasKey("SolarFlare"))
        {
            SelectedSpell.transform.position = SolarFlare_Button.transform.position;
            PlayerPrefs.SetString("StartSpell", "SolarFlare");
        }
        else
        {
            UnlockPopup.SetActive(true);
            UnlockPopup.transform.GetChild(0).GetComponent<TMP_Text>().text = "Unlock Solar Flare for 100 crystal fragments?";
            UnlockButton.onClick.RemoveAllListeners();
            UnlockButton.onClick.AddListener(Solar_Flare_Unlock);
        }
    }
    public void Solar_Flare_Unlock()
    {
        int current_crystals = PlayerPrefs.GetInt("Crystals");
        if (current_crystals >= 100)
        {
            PlayerPrefs.SetInt("SolarFlare", 1);
            SolarFlare_Button.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            current_crystals -= 100;
            PlayerPrefs.SetInt("Crystals", current_crystals);
            DisplayCrystalCount();
            UnlockPopup.SetActive(false);
        }
        else NotEnoughPanel.SetActive(true);
    }

    public void Reset_Tooltip()
    {
        if (PlayerPrefs.GetString("StartSpell") == "Fireball")
        {
            Fireball_Select();
        }
        else if (PlayerPrefs.GetString("StartSpell") == "SolarFlare")
        {
            Solar_Flare_Select();
        }
        else if (PlayerPrefs.GetString("StartSpell") == "FrostBlades")
        {
            FrostBlades_Select();
        }
        else if (PlayerPrefs.GetString("StartSpell") == "WaveCannon")
        {
            WaveCannon_Select();
        }
        else if (PlayerPrefs.GetString("StartSpell") == "IceRay")
        {
            IceRay_Select();
        }
        else if (PlayerPrefs.GetString("StartSpell") == "ChainLightning")
        {
            ChainLightning_Select();
        }
        else if (PlayerPrefs.GetString("StartSpell") == "Static")
        {
            Static_Select();
        }
        else if (PlayerPrefs.GetString("StartSpell") == "RockBarrage")
        {
            RockBarrage_Select();
        }
        else if (PlayerPrefs.GetString("StartSpell") == "EarthBend")
        {
            Earth_Bend_Select();
        }
        else if (PlayerPrefs.GetString("StartSpell") == "IceRay")
        {
            IceRay_Select();
        }
        else if (PlayerPrefs.GetString("StartSpell") == "MoltenSmash")
        {
            MoltenSmash_Select();
        }
        else
        {
            Tooltip.transform.GetChild(0).GetComponent<TMP_Text>().text = "";
            Tooltip.transform.GetChild(1).GetComponent<TMP_Text>().text = "";
        }
    }

    public void Actually_Start_Game_Button()
    {
        if (PlayerPrefs.HasKey("StartSpell"))
        {
            if (Map_Selction == 0)
            {
                int random_scene = Random.Range(1, 5);
                SceneManager.LoadScene(random_scene);
            }
            else
            {
                LoadingPanel.SetActive(true);
                SceneManager.LoadScene(Map_Selction);
            }
        }
        else NoSpellSelectedPanel.SetActive(true);
    }

}
