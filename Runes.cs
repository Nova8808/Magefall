using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Runes : MonoBehaviour
{
    private MainMenu MainMenuInst;
    public GameObject UnlockRunesPanel;
    public GameObject NotEnoughCrystalsPanel;
    public GameObject RuneMaxedPanel;
    private string Current_Rune_String;
    private int Current_Rune_Rank;
    void Start()
    {
        MainMenuInst = transform.parent.parent.GetComponent<MainMenu>();

    }
    #region Rune Button Methods
    public void Fire_Damage_Button()
    {
        Current_Rune_String = "Fire Damage";
        Current_Rune_Rank = PlayerPrefs.GetInt(Current_Rune_String);
        UnlockRunesPanel.SetActive(true);
        UnlockRunesPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Upgrade rank of " + Current_Rune_String + " from rank " + Current_Rune_Rank + " to " + (Current_Rune_Rank + 1) + " for 50 crystal fragments?";
    }
    public void Fire_Speed_Button()
    {
        Current_Rune_String = "Fire Speed";
        Current_Rune_Rank = PlayerPrefs.GetInt(Current_Rune_String);
        UnlockRunesPanel.SetActive(true);
        UnlockRunesPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Upgrade rank of " + Current_Rune_String + " from rank " + Current_Rune_Rank + " to " + (Current_Rune_Rank + 1) + " for 50 crystal fragments?";
    }
    public void Frost_Damage_Button()
    {
        Current_Rune_String = "Frost Damage";
        Current_Rune_Rank = PlayerPrefs.GetInt(Current_Rune_String);
        UnlockRunesPanel.SetActive(true);
        UnlockRunesPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Upgrade rank of " + Current_Rune_String + " from rank " + Current_Rune_Rank + " to " + (Current_Rune_Rank + 1) + " for 50 crystal fragments?";
    }
    public void Frost_Speed_Button()
    {
        Current_Rune_String = "Frost Speed";
        Current_Rune_Rank = PlayerPrefs.GetInt(Current_Rune_String);
        UnlockRunesPanel.SetActive(true);
        UnlockRunesPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Upgrade rank of " + Current_Rune_String + " from rank " + Current_Rune_Rank + " to " + (Current_Rune_Rank + 1) + " for 50 crystal fragments?";
    }
    public void Air_Damage_Button()
    {
        Current_Rune_String = "Air Damage";
        Current_Rune_Rank = PlayerPrefs.GetInt(Current_Rune_String);
        UnlockRunesPanel.SetActive(true);
        UnlockRunesPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Upgrade rank of " + Current_Rune_String + " from rank " + Current_Rune_Rank + " to " + (Current_Rune_Rank + 1) + " for 50 crystal fragments?";
    }
    public void Air_Speed_Button()
    {
        Current_Rune_String = "Air Speed";
        Current_Rune_Rank = PlayerPrefs.GetInt(Current_Rune_String);
        UnlockRunesPanel.SetActive(true);
        UnlockRunesPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Upgrade rank of " + Current_Rune_String + " from rank " + Current_Rune_Rank + " to " + (Current_Rune_Rank + 1) + " for 50 crystal fragments?";
    }
    public void Earth_Damage_Button()
    {
        Current_Rune_String = "Earth Damage";
        Current_Rune_Rank = PlayerPrefs.GetInt(Current_Rune_String);
        UnlockRunesPanel.SetActive(true);
        UnlockRunesPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Upgrade rank of " + Current_Rune_String + " from rank " + Current_Rune_Rank + " to " + (Current_Rune_Rank + 1) + " for 50 crystal fragments?";
    }
    public void Earth_Speed_Button()
    {
        Current_Rune_String = "Earth Speed";
        Current_Rune_Rank = PlayerPrefs.GetInt(Current_Rune_String);
        UnlockRunesPanel.SetActive(true);
        UnlockRunesPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Upgrade rank of " + Current_Rune_String + " from rank " + Current_Rune_Rank + " to " + (Current_Rune_Rank + 1) + " for 50 crystal fragments?";
    }
    public void Health_Total_Button()
    {
        Current_Rune_String = "Health Total";
        Current_Rune_Rank = PlayerPrefs.GetInt(Current_Rune_String);
        UnlockRunesPanel.SetActive(true);
        UnlockRunesPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Upgrade rank of " + Current_Rune_String + " from rank " + Current_Rune_Rank + " to " + (Current_Rune_Rank + 1) + " for 50 crystal fragments?";
    }
    public void Health_Regen_Button()
    {
        Current_Rune_String = "Health Regen";
        Current_Rune_Rank = PlayerPrefs.GetInt(Current_Rune_String);
        UnlockRunesPanel.SetActive(true);
        UnlockRunesPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Upgrade rank of " + Current_Rune_String + " from rank " + Current_Rune_Rank + " to " + (Current_Rune_Rank + 1) + " for 50 crystal fragments?";
    }
    public void Ward_Total_Button()
    {
        Current_Rune_String = "Ward Total";
        Current_Rune_Rank = PlayerPrefs.GetInt(Current_Rune_String);
        UnlockRunesPanel.SetActive(true);
        UnlockRunesPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Upgrade rank of " + Current_Rune_String + " from rank " + Current_Rune_Rank + " to " + (Current_Rune_Rank + 1) + " for 50 crystal fragments?";
    }
    public void Ward_Regen_Button()
    {
        Current_Rune_String = "Ward Regen";
        Current_Rune_Rank = PlayerPrefs.GetInt(Current_Rune_String);
        UnlockRunesPanel.SetActive(true);
        UnlockRunesPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Upgrade rank of " + Current_Rune_String + " from rank " + Current_Rune_Rank + " to " + (Current_Rune_Rank + 1) + " for 50 crystal fragments?";
    }
    #endregion
    public void Upgrade_Rune_Button()
    {
        if (PlayerPrefs.GetInt("Crystals") >= 50 && PlayerPrefs.GetInt(Current_Rune_String) < 10)
        {
            int current_crystals = PlayerPrefs.GetInt("Crystals");
            current_crystals -= 50;
            PlayerPrefs.SetInt("Crystals", current_crystals);

            int current_rune_rank = PlayerPrefs.GetInt(Current_Rune_String);
            current_rune_rank++;
            PlayerPrefs.SetInt(Current_Rune_String, current_rune_rank);
            UnlockRunesPanel.SetActive(false);
            MainMenuInst.DisplayCrystalCount();
        }
        if (PlayerPrefs.GetInt("Crystals") < 50)
        {
            NotEnoughCrystalsPanel.SetActive(true);
        }
        if (PlayerPrefs.GetInt(Current_Rune_String) >= 10)
        {
            RuneMaxedPanel.SetActive(true);
        }
    }


}
