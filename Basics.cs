using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Basics : MonoBehaviour
{
    #region SINGLETON PATTERN
    public static Basics instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning: Multiple player stats instance");
        }
        instance = this;
    }
    #endregion

    public GameObject Player;
    public GameObject Spell_Spawn;
    public GameObject Main_Camera;
    public GameObject Selected_Spell;
    public GameObject Cast_Bar_Background;
    //public GameObject Hotbar_Cooldown;
    public Image Fire_Castfill;
    public Image Frost_Castfill;
    public Image Air_Castfill;
    public Image Earth_Castfill;
    public GameObject SpellMenu_Canvas;
    public GameObject Fire_Hotbar;
    public GameObject Action_UI;
    public Transform Drag_Front;
    //public GameObject spell_charge_canvas;
    public float Main_Game_Timer;
    public Image Game_Timer_UI;

    public GameObject UI_Drag_Begin;
    public GameObject Confirm_Delete_Popup;

    //public GameObject Cast_Aura_GameObject;
    //public AudioSource Cast_Audio_Source;
    public AudioClip Cast_Audio_Loop_Fire;
    public AudioClip Cast_Audio_Loop_Frost;
    public AudioClip Cast_Audio_Loop_Air;
    public AudioClip Cast_Audio_Loop_Earth;

    public Material Frost_Status_Mat;
    public Material Air_Status_Mat;
    public Material Earth_Status_Mat;

    public GameObject[] Cooldown_Slots;

    public GameObject Floating_Damage_Holder;
    public GameObject ToolTip_Canvas;

    public GameObject display_passives_canvas;
    public GameObject settings_panel;
    public GameObject controls_panel;
    public GameObject air_display_prefab;
    public GameObject fire_display_prefab;
    public GameObject ice_display_prefab;
    public GameObject earth_display_prefab;

    public int Low_Force;
    public int Medium_Force;
    public int Large_Force;

    public GameObject End_Game_Screen;
    private bool end_game_once;
    private bool Start_End_Sequence;
    private float Game_Length;
    public GameObject Crystal_Fracture;
    GameObject crystal_fract_inst;
    public GameObject CrystalGuardian1;
    public bool GuardianBoss_Dead;
    public GameObject EndGamePanel;

    public bool WorldPhysicsEnabled;

    void Start()
    {
        end_game_once = false;
        Game_Length = 1200;
        GuardianBoss_Dead = false;
        Start_End_Sequence = false;

        ClosePauseMenu();
        //test endgame
        //GuardianBoss_Dead = true;
        //Main_Game_Timer = 800;
    }

    // Update is called once per frame
    void Update()
    {
        Main_Game_Timer += Time.deltaTime;
        Game_Timer_UI.fillAmount = Main_Game_Timer / Game_Length;

        //REMOVE ON BUILD
        //if (Input.GetKeyDown(KeyCode.Z))
        //{

        //    SpellMenu_Canvas.SetActive(!SpellMenu_Canvas.activeSelf);

        //    if (SpellMenu_Canvas.activeSelf)
        //    {
        //        Cursor.lockState = CursorLockMode.None;
        //        Main_Camera.GetComponent<CameraController>().enabled = false;
        //        Time.timeScale = 0;
        //    }
        //    else
        //    {
        //        Cursor.lockState = CursorLockMode.Locked;
        //        Main_Camera.GetComponent<CameraController>().enabled = true;
        //        Time.timeScale = 1;
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab) && !Game_Logic.instance.Level_Up_Window.activeSelf && !Game_Logic.instance.Passive_Level_Up_Window.activeSelf)
        {

            display_passives_canvas.SetActive(!display_passives_canvas.activeSelf);

            if (display_passives_canvas.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Main_Camera.GetComponent<CameraController>().enabled = false;
                Time.timeScale = 0;
            }
            else
            {
                if (settings_panel.activeSelf)
                {
                    settings_panel.SetActive(false);
                }
                if (controls_panel.activeSelf)
                {
                    controls_panel.SetActive(false);
                }
                ClosePauseMenu();
            }
        }

        //END GAME STUFF
        if (Main_Game_Timer > 1000 && CrystalGuardian1.gameObject != null)
        {
            CrystalGuardian1.gameObject.SetActive(true);
        }
        if (Main_Game_Timer >= Game_Length && GuardianBoss_Dead)
        {
            Start_End_Sequence = true;
            PlayerStats.instance.player_current_shield = PlayerStats.instance.player_max_shield;
            PlayerStats.instance.Experience_Count = 0;

            if (crystal_fract_inst != null)
            {
                Quaternion toRotation = Quaternion.LookRotation(crystal_fract_inst.transform.position - Main_Camera.transform.position);
                Main_Camera.transform.rotation = Quaternion.Lerp(Main_Camera.transform.rotation, toRotation, 5 * Time.deltaTime);
            }
        }
        if (Start_End_Sequence && !end_game_once)
        {
            StartCoroutine(End_Game_Sequence());

            end_game_once = true;
        }


    }

    IEnumerator End_Game_Sequence()
    {
        if (PlayerPrefs.HasKey("Crystals"))
        {
            int Crystals_toAdd = PlayerPrefs.GetInt("Crystals") + 100;
            PlayerPrefs.SetInt("Crystals", Crystals_toAdd);
        }
        else PlayerPrefs.SetInt("Crystals", 100);

        GameObject center_crystal = GameObject.Find("CenterCrystal");
        Vector3 crystal_pos = center_crystal.transform.position;
        Quaternion crystal_rot = center_crystal.transform.rotation;
        Destroy(center_crystal);
        crystal_fract_inst = Instantiate(Crystal_Fracture, crystal_pos, crystal_rot);

        Main_Camera.transform.parent = null;
        Main_Camera.transform.GetComponent<CameraController>().enabled = false;

        yield return new WaitForSeconds(6);
        EndGamePanel.SetActive(true);
        Basics.instance.Action_UI.GetComponent<Animator>().Play("EndGameFade");
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        End_Game_Screen.SetActive(true);
        float currentDisplayScore = 0;
        while (currentDisplayScore < 100)
        {
            currentDisplayScore += Time.unscaledDeltaTime * 20; // or whatever to get the speed you like
            currentDisplayScore = Mathf.Clamp(currentDisplayScore, 0f, 100);
            End_Game_Screen.transform.GetChild(0).GetComponent<TMP_Text>().text = "+ " + ((int)currentDisplayScore).ToString();
            yield return null;
        }
        Main_Camera.transform.LookAt(crystal_fract_inst.transform);
    }

    public void Return_to_Main()
    {
        SceneManager.LoadScene(0);
    }

    public void ClosePauseMenu()
    {
        display_passives_canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Main_Camera.GetComponent<CameraController>().enabled = true;
        Time.timeScale = 1;
        ToolTip_Canvas.SetActive(false);
    }


    public void BasicDamage(int spell_damage, int radius, Vector3 hit_position)
    {
        Game_Logic.instance.OnSpellHit(hit_position);
        Collider[] damaged_enemies = Physics.OverlapSphere(hit_position, radius);
        foreach (Collider col in damaged_enemies)
        {
            if (col.tag == "Enemy")
            {
                IDamageable<float> damageable = col.GetComponent<IDamageable<float>>();
                //Debug.Log(col.name);
                if (damageable != null)
                {
                    damageable.Damage(spell_damage);
                }
            }

        }
    }

    public IEnumerator PeriodicDamage(Vector3 damage_position, int tick_count, int tick_damage, int radius)
    {
        for (int x = 0; x < tick_count; x++)
        {
            TickDamage(damage_position, tick_damage, radius);
            yield return new WaitForSeconds(1);
        }
    }
    void TickDamage(Vector3 _damage_position, int _tick_damage, int _radius)
    {
        Collider[] damaged_enemies = Physics.OverlapSphere(_damage_position, _radius);
        foreach (Collider col in damaged_enemies)
        {
            if (col.tag == "Enemy")
            {
                IDamageable<float> damageable = col.GetComponent<IDamageable<float>>();
                //Debug.Log(col.name);
                if (damageable != null)
                {
                    damageable.Damage(_tick_damage);
                }
            }
        }
    }

    public void DamageAndForce(int spell_damage, int radius, Vector3 hit_position, int spell_force)
    {
        Game_Logic.instance.OnSpellHit(hit_position);
        Collider[] damaged_enemies = Physics.OverlapSphere(hit_position, radius);
        foreach (Collider col in damaged_enemies)
        {
            if (col.tag == "Enemy")
            {
                IDamageable<float> damageable = col.GetComponent<IDamageable<float>>();
                //Debug.Log(col.name);
                if (damageable != null)
                {
                    damageable.Damage(spell_damage);
                }
            }

        }
        StartCoroutine(Add_Force(radius, hit_position, spell_force));
    }

    public void Damage_and_Status(int spell_damage, int radius, Vector3 hit_position, string element, int status_duration)
    {
        Collider[] damaged_enemies = Physics.OverlapSphere(hit_position, radius);
        foreach (Collider col in damaged_enemies)
        {
            if (col.tag == "Enemy" || col.tag == "Ragdoll")
            {
                IdamageableStatus<string, int> damageable = col.GetComponent<IdamageableStatus<string, int>>();
                //Debug.Log(col.name);
                if (damageable != null)
                {
                    damageable.Damage(spell_damage);
                    damageable.Status(element, status_duration);
                }
            }

        }
    }
    IEnumerator Add_Force(int force_radius, Vector3 force_position, int force_amount)
    {
        Rigidbody _rb;
        yield return new WaitForSeconds(.15f);
        Collider[] ragdoll = Physics.OverlapSphere(force_position, force_radius);
        foreach (Collider hits in ragdoll)
        {
            if (hits.tag == "Enemy" || hits.tag == "Ragdoll")
            {

                //_rb = hits.transform.gameObject.GetComponent<Rigidbody>();
                if (hits.transform.gameObject.TryGetComponent<Rigidbody>(out _rb))
                {
                    _rb.AddExplosionForce(force_amount, force_position, force_radius, 3.0f);
                }

            }
        }
    }
}
