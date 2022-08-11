using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game_Logic : MonoBehaviour
{
    #region SINGLETON PATTERN
    public static Game_Logic instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning: Multiple player stats instance");
        }
        instance = this;
    }
    #endregion

    public GameObject Level_DisplayUI;
    public GameObject Level_Up_Window;
    public GameObject Passive_Level_Up_Window;
    private int[] random;
    private int[] passive_random;

    public GameObject[] Random_Spells;
    public string[] Random_Passives;

    //public GameObject[] spell_options;
    public List<GameObject> spell_options;
    public Image Exp_Fill;
    public float Exp_to_level;
    private float fill_division;

    public List<string> Passive_Class_Option_List;

    public Sprite fire_sprite;
    public Sprite air_sprite;
    public Sprite water_sprite;
    public Sprite earth_sprite;

    private float On_Spell_Hit_Timer;
    private GameObject SpellSearch;

    public GameObject Static_UI;
    public GameObject Wave_cannon_UI;
    public GameObject Earth_bend_UI;
    public GameObject Solarflare_UI;
    public GameObject IceRay_UI;
    public GameObject MoltenSmash_UI;

    #region Passives variables and Prefabs
    private float thunder_aura_timer;
    public GameObject thunder_strike_prefab;

    public GameObject pressure_vacuum_prefab;

    public GameObject arc_prefab;

    public GameObject rolling_charge_prefab;

    public GameObject Hot_foot_prefab;

    private float starfall_timer;
    public GameObject starfall_prefab;

    public GameObject sun_call_prefab;

    public GameObject sprite_prefab;
    public GameObject homing_flare_prefab;
    public GameObject icicle_prefab;
    [HideInInspector]public float ice_barrier_timer;
    private float frost_nova_timer;
    public GameObject Frost_nova_prefab;
    public GameObject healing_rain_prefab;
    private float healing_rain_timer;
    public GameObject icy_impaler_prefab;
    private float icy_impaler_timer;
    private float spike_armor_timer;
    public GameObject spike_armor_prefab;
    private float stone_throw_timer;
    public GameObject stone_throw_prefab;
    public GameObject dust_cloud_prefab;
    public GameObject earth_elemental_prefab;
    public GameObject flarebeam_prefab;
    private float flare_beam_timer;

    #endregion

    private void Start()
    {
        #region Initialize Spell Passive Class List
        Passive_Class_Option_List = new List<string>();

        Passive_Class_Option_List.Add("Thunder Aura");
        Passive_Class_Option_List.Add("Tail Wind");
        Passive_Class_Option_List.Add("Wind Step");
        Passive_Class_Option_List.Add("Aero Momentum");
        Passive_Class_Option_List.Add("Pressure Vacuum");
        Passive_Class_Option_List.Add("Arc");
        Passive_Class_Option_List.Add("Rolling Charge");
        Passive_Class_Option_List.Add("Siphon Ward");
        Passive_Class_Option_List.Add("Supercharge Ward");

        Passive_Class_Option_List.Add("Hot Foot");
        Passive_Class_Option_List.Add("Cauterize");
        Passive_Class_Option_List.Add("Starfall");
        Passive_Class_Option_List.Add("Fire Sprite");
        Passive_Class_Option_List.Add("Homing Flares");
        Passive_Class_Option_List.Add("Sun Call");
        Passive_Class_Option_List.Add("Warmth");
        Passive_Class_Option_List.Add("Flame Dash");
        Passive_Class_Option_List.Add("Flare Beam");

        Passive_Class_Option_List.Add("Icicles");
        Passive_Class_Option_List.Add("Ice Barrier");
        Passive_Class_Option_List.Add("Frozen Armor");
        Passive_Class_Option_List.Add("Frost Nova");
        Passive_Class_Option_List.Add("Ice Block");
        Passive_Class_Option_List.Add("Healing Rain");
        Passive_Class_Option_List.Add("Frozen Ward");
        Passive_Class_Option_List.Add("Icy Impale");

        Passive_Class_Option_List.Add("Stone Skin");
        Passive_Class_Option_List.Add("Rejuvenation");
        Passive_Class_Option_List.Add("Spike Armor");
        Passive_Class_Option_List.Add("Dust Cloud");
        Passive_Class_Option_List.Add("Harden");
        Passive_Class_Option_List.Add("Stone Throw");
        Passive_Class_Option_List.Add("Rock Drill");
        Passive_Class_Option_List.Add("Earth Elemental");

        #endregion

        #region Load Starting Spell
        switch (PlayerPrefs.GetString("StartSpell"))
        {

            case "Fireball":
                for(int x = 0; x < spell_options.Count; x++)
                {
                    if (spell_options[x].name == "Fireball_UI")
                    {
                        SpellSearch = spell_options[x];
                    }
                }
                    break;
            case "WaveCannon":
                spell_options.Add(Wave_cannon_UI);
                SpellSearch = Wave_cannon_UI;
                //for (int x = 0; x < spell_options.Length; x++)
                //{
                //    if (spell_options[x].name == "Wave_Cannon_UI")
                //    {
                //        SpellSearch = spell_options[x];
                //    }
                //}
                break;
            case "FrostBlades":
                for (int x = 0; x < spell_options.Count; x++)
                {
                    if (spell_options[x].name == "Frost_Blades_UI")
                    {
                        SpellSearch = spell_options[x];
                    }
                }
                break;
            case "ChainLightning":
                for (int x = 0; x < spell_options.Count; x++)
                {
                    if (spell_options[x].name == "Chain_Lightning_UI")
                    {
                        SpellSearch = spell_options[x];
                    }
                }
                break;
            case "Static":
                for (int x = 0; x < spell_options.Count; x++)
                {
                    if (spell_options[x].name == "Static_UI")
                    {
                        SpellSearch = spell_options[x];
                    }
                }
                break;
            case "RockBarrage":
                for (int x = 0; x < spell_options.Count; x++)
                {
                    if (spell_options[x].name == "Rock_Barrage_UI")
                    {
                        SpellSearch = spell_options[x];
                    }
                }
                break;
            case "EarthBend":
                spell_options.Add(Earth_bend_UI);
                SpellSearch = Earth_bend_UI;
                break;
            case "SolarFlare":
                spell_options.Add(Solarflare_UI);
                SpellSearch = Solarflare_UI;
                break;
            case "IceRay":
                spell_options.Add(IceRay_UI);
                SpellSearch = IceRay_UI;
                break;
            case "MoltenSmash":
                spell_options.Add(MoltenSmash_UI);
                SpellSearch = MoltenSmash_UI;
                break;

        }
        GameObject StartSpellClone = Instantiate(SpellSearch, Basics.instance.Fire_Hotbar.transform.GetChild(0).transform);
        StartSpellClone.name = SpellSearch.name;
        StartSpellClone.transform.position = Basics.instance.Fire_Hotbar.transform.GetChild(0).transform.position;
        #endregion

    }

    void Update()
    {
        On_Spell_Hit_Timer += Time.deltaTime;
        fill_division = (PlayerStats.instance.Experience_Count / Exp_to_level);
        Exp_Fill.fillAmount = fill_division;

       
        if (PlayerStats.instance.Experience_Count >= Exp_to_level)
        {
            PlayerStats.instance.Experience_Count = 0;
            PlayerStats.instance.player_level++;
            Level_DisplayUI.transform.GetComponent<TMP_Text>().text = PlayerStats.instance.player_level.ToString();
            //Add if to check for which level is spell level and which is passive level
            if (PlayerStats.instance.player_level % 3 == 0)
            {
                Populate_Spell_Options();
            }
            else Populate_Passive_Options();

            //REQUIRED EXPERIENCE TO LEVEL
            if (PlayerStats.instance.player_level < 3)
            {
                Exp_to_level = 25;
            }
            if (PlayerStats.instance.player_level >= 3 && PlayerStats.instance.player_level < 6)
            {
                Exp_to_level = 45;
            }
            if (PlayerStats.instance.player_level >= 6 && PlayerStats.instance.player_level < 9)
            {
                Exp_to_level = 70;
            }
            if (PlayerStats.instance.player_level >= 9 && PlayerStats.instance.player_level < 12)
            {
                Exp_to_level = 90;
            }
            if (PlayerStats.instance.player_level >= 12 && PlayerStats.instance.player_level < 20)
            {
                Exp_to_level = 120;
            }

        }
        
        #region Always active passives
        #region Air

        //Thunder Aura
        if (PlayerStats.instance.Thunder_Aura_Active)
        {
            thunder_aura_timer += Time.deltaTime;
            if (PlayerStats.instance.Thunder_Aura_Rank == 1)
            {
                if (thunder_aura_timer > 12)
                {
                    List<GameObject> near_enemies = Find_Near_Enemies();
                    thunder_aura_timer = 0;
                    if (near_enemies.Count > 0)
                    {
                        GameObject thunderstrike = Instantiate(thunder_strike_prefab, near_enemies[0].transform.position, Quaternion.identity);
                        Basics.instance.BasicDamage(PlayerStats.instance.Thunder_Aura_Damage(), 2, near_enemies[0].transform.position);
                        IdamageableStatus<string, int> status = near_enemies[0].transform.GetComponent<IdamageableStatus<string, int>>();
                        if (status != null)
                        {
                            status.Status("air", 4);
                        }
                    }
                }
            }
            else if (PlayerStats.instance.Thunder_Aura_Rank == 2)
            {
                if (thunder_aura_timer > 8)
                {
                    List<GameObject> near_enemies = Find_Near_Enemies();
                    thunder_aura_timer = 0;
                    if (near_enemies.Count > 0)
                    {
                        GameObject thunderstrike = Instantiate(thunder_strike_prefab, near_enemies[0].transform.position, Quaternion.identity);
                        Basics.instance.BasicDamage(PlayerStats.instance.Thunder_Aura_Damage(), 2, near_enemies[0].transform.position);
                        IdamageableStatus<string, int> status = near_enemies[0].transform.GetComponent<IdamageableStatus<string, int>>();
                        if (status != null)
                        {
                            status.Status("air", 4);
                        }
                    }
                    
                }
            }
            else if (PlayerStats.instance.Thunder_Aura_Rank == 3)
            {
                if (thunder_aura_timer > 4)
                {
                    List<GameObject> near_enemies = Find_Near_Enemies();
                    thunder_aura_timer = 0;
                    if (near_enemies.Count > 0)
                    {
                        GameObject thunderstrike = Instantiate(thunder_strike_prefab, near_enemies[0].transform.position, Quaternion.identity);
                        Basics.instance.BasicDamage(PlayerStats.instance.Thunder_Aura_Damage(), 2, near_enemies[0].transform.position);
                        IdamageableStatus<string, int> status = near_enemies[0].transform.GetComponent<IdamageableStatus<string, int>>();
                        if (status != null)
                        {
                            status.Status("air", 4);
                        }
                    }
                   
                }
            }
        }

        
        #endregion
        #region Fire
        if (PlayerStats.instance.Starfall_Active)
        {
            starfall_timer += Time.deltaTime;
            if (starfall_timer > 5)
            {
                List<GameObject> near_enemies = Find_Near_Enemies();

                switch (PlayerStats.instance.Starfall_Rank)
                {
                    case 1: 
                        if (near_enemies.Count > 0)
                        {
                            Vector3 meteor_pos1 = near_enemies[0].transform.position;
                            meteor_pos1.y += 30;
                            meteor_pos1.x += 8;
                            GameObject starfall_inst = Instantiate(starfall_prefab, meteor_pos1, Quaternion.identity);
                            starfall_inst.transform.GetComponent<Starfall>().target = near_enemies[0];
                            Destroy(starfall_inst, 2);
                        }
                        if (near_enemies.Count > 1)
                        {
                            Vector3 meteor_pos2 = near_enemies[1].transform.position;
                            meteor_pos2.y += 30;
                            meteor_pos2.x += 8;
                            GameObject starfall_inst2 = Instantiate(starfall_prefab, meteor_pos2, Quaternion.identity);
                            starfall_inst2.transform.GetComponent<Starfall>().target = near_enemies[1];
                            Destroy(starfall_inst2, 2);
                        }
                        break;
                    case 2:
                        if (near_enemies.Count > 0)
                        {
                            Vector3 meteor_pos1 = near_enemies[0].transform.position;
                            meteor_pos1.y += 30;
                            meteor_pos1.x += 8;
                            GameObject starfall_inst = Instantiate(starfall_prefab, meteor_pos1, Quaternion.identity);
                            starfall_inst.transform.GetComponent<Starfall>().target = near_enemies[0];
                            Destroy(starfall_inst, 2);
                        }
                        if (near_enemies.Count > 1)
                        {
                            Vector3 meteor_pos2 = near_enemies[1].transform.position;
                            meteor_pos2.y += 30;
                            meteor_pos2.x += 8;
                            GameObject starfall_inst2 = Instantiate(starfall_prefab, meteor_pos2, Quaternion.identity);
                            starfall_inst2.transform.GetComponent<Starfall>().target = near_enemies[1];
                            Destroy(starfall_inst2, 2);
                        }
                        if (near_enemies.Count > 2)
                        {
                            Vector3 meteor_pos2 = near_enemies[2].transform.position;
                            meteor_pos2.y += 30;
                            meteor_pos2.x += 8;
                            GameObject starfall_inst3 = Instantiate(starfall_prefab, meteor_pos2, Quaternion.identity);
                            starfall_inst3.transform.GetComponent<Starfall>().target = near_enemies[2];
                            Destroy(starfall_inst3, 2);
                        }
                        if (near_enemies.Count > 3)
                        {
                            Vector3 meteor_pos2 = near_enemies[3].transform.position;
                            meteor_pos2.y += 30;
                            meteor_pos2.x += 8;
                            GameObject starfall_inst4 = Instantiate(starfall_prefab, meteor_pos2, Quaternion.identity);
                            starfall_inst4.transform.GetComponent<Starfall>().target = near_enemies[3];
                            Destroy(starfall_inst4, 2);
                        }
                        break;
                    case 3:
                        if (near_enemies.Count > 0)
                        {
                            Vector3 meteor_pos1 = near_enemies[0].transform.position;
                            meteor_pos1.y += 30;
                            meteor_pos1.x += 8;
                            GameObject starfall_inst = Instantiate(starfall_prefab, meteor_pos1, Quaternion.identity);
                            starfall_inst.transform.GetComponent<Starfall>().target = near_enemies[0];
                            Destroy(starfall_inst, 2);
                        }
                        if (near_enemies.Count > 1)
                        {
                            Vector3 meteor_pos2 = near_enemies[1].transform.position;
                            meteor_pos2.y += 30;
                            meteor_pos2.x += 8;
                            GameObject starfall_inst2 = Instantiate(starfall_prefab, meteor_pos2, Quaternion.identity);
                            starfall_inst2.transform.GetComponent<Starfall>().target = near_enemies[1];
                            Destroy(starfall_inst2, 2);
                        }
                        if (near_enemies.Count > 2)
                        {
                            Vector3 meteor_pos3 = near_enemies[2].transform.position;
                            meteor_pos3.y += 30;
                            meteor_pos3.x += 8;
                            GameObject starfall_inst3 = Instantiate(starfall_prefab, meteor_pos3, Quaternion.identity);
                            starfall_inst3.transform.GetComponent<Starfall>().target = near_enemies[2];
                            Destroy(starfall_inst3, 2);

                        }
                        if (near_enemies.Count > 3)
                        {
                            Vector3 meteor_pos2 = near_enemies[3].transform.position;
                            meteor_pos2.y += 30;
                            meteor_pos2.x += 8;
                            GameObject starfall_inst4 = Instantiate(starfall_prefab, meteor_pos2, Quaternion.identity);
                            starfall_inst4.transform.GetComponent<Starfall>().target = near_enemies[3];
                            Destroy(starfall_inst4, 2);
                        }
                        if (near_enemies.Count > 4)
                        {
                            Vector3 meteor_pos3 = near_enemies[4].transform.position;
                            meteor_pos3.y += 30;
                            meteor_pos3.x += 8;
                            GameObject starfall_inst5 = Instantiate(starfall_prefab, meteor_pos3, Quaternion.identity);
                            starfall_inst5.transform.GetComponent<Starfall>().target = near_enemies[4];
                            Destroy(starfall_inst5, 2);

                        }
                        if (near_enemies.Count > 5)
                        {
                            Vector3 meteor_pos2 = near_enemies[5].transform.position;
                            meteor_pos2.y += 30;
                            meteor_pos2.x += 8;
                            GameObject starfall_inst6 = Instantiate(starfall_prefab, meteor_pos2, Quaternion.identity);
                            starfall_inst6.transform.GetComponent<Starfall>().target = near_enemies[5];
                            Destroy(starfall_inst6, 2);
                        }
                        break;
                }

                starfall_timer = 0;
            }
        }

        if (PlayerStats.instance.Flare_Beam_Active)
        {
            flare_beam_timer += Time.deltaTime;
            if (flare_beam_timer > 10)
            {
                List<GameObject> near_enemies = Find_Near_Enemies(30);
                if (near_enemies.Count > 0)
                {
                    GameObject flarebeam_inst = Instantiate(flarebeam_prefab, Basics.instance.Spell_Spawn.transform.position, Quaternion.identity);
                    flarebeam_inst.transform.GetComponent<FlareBeam>().Spell_Stuff(near_enemies[0].transform.gameObject);
                    Destroy(flarebeam_inst, 1);
                }
                flare_beam_timer = 0;
            }
        }
        #endregion
        #region Ice
        if (PlayerStats.instance.Ice_Barrier_Active)
        {
            ice_barrier_timer += Time.deltaTime;
        }
        if (PlayerStats.instance.Frost_Nova_Active)
        {
            frost_nova_timer += Time.deltaTime;
            if (frost_nova_timer > 10)
            {
                GameObject frost_nova_inst = Instantiate(Frost_nova_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Player.transform.rotation);
                Destroy(frost_nova_inst, 3);
                frost_nova_timer = 0;
            }
        }
        if (PlayerStats.instance.Healing_Rain_Active)
        {
            healing_rain_timer += Time.deltaTime;
            if (healing_rain_timer > 30)
            {
                GameObject healing_rain_inst = Instantiate(healing_rain_prefab, Basics.instance.Player.transform.position, Quaternion.identity);
                healing_rain_timer = 0;
            }
        }
        if (PlayerStats.instance.Icy_Impale_Active)
        {
            icy_impaler_timer += Time.deltaTime;
            int icy_interval = 10;
            switch (PlayerStats.instance.Icy_Impale_Rank)
            {
                case 1:
                    icy_interval = 6;
                    break;
                case 2:
                    icy_interval = 4;
                    break;
                case 3:
                    icy_interval = 2;
                    break;
            }
            if (icy_impaler_timer > icy_interval)
            {
                List<GameObject> near_enemies = Find_Near_Enemies();
                if (near_enemies.Count > 0)
                {
                    Vector3 adjust_post = new Vector3(near_enemies[0].transform.position.x, near_enemies[0].transform.position.y-.5f, near_enemies[0].transform.position.z);
                    GameObject icy_impale_inst = Instantiate(icy_impaler_prefab, adjust_post, Quaternion.identity);
                    Destroy(icy_impale_inst, 1.5f);
                }
                icy_impaler_timer = 0;
            }
        }
        #endregion
        #region Earth
        if (PlayerStats.instance.Stone_Throw_Active)
        {
            stone_throw_timer += Time.deltaTime;
            int stone_interval = 10;
            switch (PlayerStats.instance.Stone_Throw_Rank)
            {
                case 1: stone_interval = 6;
                    break;
                case 2:
                    stone_interval = 4;
                    break;
                case 3:
                    stone_interval = 2;
                    break;
            }
            if (stone_throw_timer > stone_interval)
            {
                GameObject stone_throw_inst = Instantiate(stone_throw_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Main_Camera.transform.rotation);
                Destroy(stone_throw_inst, 5);
                stone_throw_timer = 0;
            }
        }
        if (PlayerStats.instance.Spike_Armor_Active)
        {
            spike_armor_timer += Time.deltaTime;
            if (spike_armor_timer > 5)
            {
                GameObject spike_armor_inst = Instantiate(spike_armor_prefab, Basics.instance.Player.transform.position, Basics.instance.Player.transform.rotation);
                Destroy(spike_armor_inst, 1);
                Collider[] enemies = Physics.OverlapSphere(Basics.instance.Player.transform.position, 20);
                foreach (Collider hits in enemies)
                {
                    if (hits.tag == "Enemy")
                    {
                        IDamageable<float> damageable = hits.transform.GetComponent<IDamageable<float>>();
                        if (damageable != null)
                        {
                            damageable.Damage(PlayerStats.instance.Spike_Armor_Damage());
                        }
                    }
                }
                spike_armor_timer = 0;
            }
        }
        #endregion
        #endregion

    }

    void Populate_Spell_Options()
    {
        Open_And_Pause();

        Level_Up_Window.transform.GetChild(0).transform.GetComponent<Animator>().Play("Level_Up_BG_Clip");

        //Get 4 random unique numbers
        random = new int[4] {200, 200, 200, 200};
        

        for (int x = 0; x < 4; x++)
        {
            int z = Random.Range(0, (spell_options.Count));
            while (z == random[0] || z == random[1] || z == random[2])
            {
                z = Random.Range(0, (spell_options.Count));
            }
            random[x] = z;
           
        }

        //Assign spells based on random
        Random_Spells = new GameObject[4];
        for (int y = 0; y < 4; y++)
        {
            Random_Spells[y] = spell_options[random[y]];
        }

        //Have to have this here after random_spells is populated so Level_Up can grab spells on awake
        Level_Up_Window.SetActive(true);

    }

    void Populate_Passive_Options()
    {
        Open_And_Pause();

        passive_random = new int[5] { 200, 200, 200, 200, 200};

        for (int x = 0; x < 5; x++)
        {
            int z = Random.Range(0, (Passive_Class_Option_List.Count));
            while (z == passive_random[0] || z == passive_random[1] || z == passive_random[2] || z == passive_random[3])
            {
                z = Random.Range(0, (Passive_Class_Option_List.Count));
            }
            passive_random[x] = z;

        }

        //Assign spells based on random
        Random_Passives = new string[5];
        for (int y = 0; y < 5; y++)
        {
            Random_Passives[y] = Passive_Class_Option_List[passive_random[y]];
        }


        Passive_Level_Up_Window.SetActive(true);
    }

    void Open_And_Pause()
    {
        Basics.instance.Action_UI.GetComponent<Animator>().Play("RollDownHotbar");
        Cursor.lockState = CursorLockMode.None;
        Basics.instance.Main_Camera.GetComponent<CameraController>().enabled = false;
        Time.timeScale = 0;
    }

    public void OnSpellCast()
    {
        //List usable by any passive to launch spell at near enemies
        //List<GameObject> near_enemies = Find_Near_Enemies();

        if (PlayerStats.instance.Rolling_Charge_Active)
        {
            //int rolling_random = Random.Range(0, 2);
            //if (rolling_random == 1)
            //{
                Vector3 new_post = new Vector3(Basics.instance.Spell_Spawn.transform.position.x, Basics.instance.Spell_Spawn.transform.position.y - 2, Basics.instance.Spell_Spawn.transform.position.z);
                GameObject rollingcharge_inst = Instantiate(rolling_charge_prefab, new_post, Quaternion.identity);
            //}
        }

        if (PlayerStats.instance.Warmth_Active)
        {
            int warmthrand = Random.Range(0, 8);
            if (warmthrand == 0)
            {
                StartCoroutine(Warmth_Regen());
            }
        }

        if (PlayerStats.instance.Sun_Call_Active)
        {
            int sunrandom = Random.Range(0, 6);
            if (sunrandom == 0)
            {
                Vector3 forwardpos = Basics.instance.Player.transform.position;
                forwardpos.y += 20;
                GameObject sun_call_inst = Instantiate(sun_call_prefab, forwardpos, Basics.instance.Spell_Spawn.transform.rotation);
            }
        }

        if (PlayerStats.instance.Fire_Sprite_Active)
        {
            int sprite_random = Random.Range(0, 5);
            if (sprite_random == 0)
            {
                GameObject sprite_inst = Instantiate(sprite_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
                if (PlayerStats.instance.Fire_Sprite_Rank == 1)
                {
                    //duration increases based on rank
                    Destroy(sprite_inst, 8);
                } else if (PlayerStats.instance.Fire_Sprite_Rank == 2)
                {
                    Destroy(sprite_inst, 13);
                }
                else if (PlayerStats.instance.Fire_Sprite_Rank == 3)
                {
                    Destroy(sprite_inst, 18);
                }
            }
        }

        if (PlayerStats.instance.Homing_Flares_Active)
        {
            StartCoroutine(Homing_Flares_Launch());
        }

        if (PlayerStats.instance.Icicles_Active)
        {
            StartCoroutine(Icicle_Launch());
        }

        if (PlayerStats.instance.Ice_Barrier_Active)
        {
            if (PlayerStats.instance.Ice_Barrier_Rank == 1 && ice_barrier_timer > 15)
            {
                PlayerStats.instance.Barrier_Total += PlayerStats.instance.player_max_shield * .1f;
                ice_barrier_timer = 0;
            }
            if (PlayerStats.instance.Ice_Barrier_Rank == 2 && ice_barrier_timer > 15)
            {
                PlayerStats.instance.Barrier_Total += PlayerStats.instance.player_max_shield * .15f;
                ice_barrier_timer = 0;
            }
            if (PlayerStats.instance.Ice_Barrier_Rank == 3 && ice_barrier_timer > 15)
            {
                PlayerStats.instance.Barrier_Total += PlayerStats.instance.player_max_shield * .2f;
                ice_barrier_timer = 0;
            }
        }
    }

    public void OnSpellHit(Vector3 position)
    {
        //Only runs spell hit no more than once per second
        if (On_Spell_Hit_Timer > 1)
        {

            if (PlayerStats.instance.Pressure_Vacuum_Active)
            {
                int PressureVRand = Random.Range(0, 7);
                if (PressureVRand == 1)
                {
                    GameObject pressure_vacuum = Instantiate(pressure_vacuum_prefab, position, Quaternion.identity);
                }
            }
            #region Arc
            int ArcRand = Random.Range(0, 2);
            List<GameObject> near_enemy_list = new List<GameObject>();
            List<float> distance = new List<float>();
            if (PlayerStats.instance.Arc_Active)
            {
                if (ArcRand == 1)
                {
                    Collider[] near_check = Physics.OverlapSphere(position, 15);
                    for (int i = 0; i < near_check.Length; i++)
                    {
                        if (near_check[i].transform.gameObject.tag == "Enemy")
                        {
                            float distance_check = Vector3.Distance(position, near_check[i].transform.position);
                            if (distance_check > 1)
                            {
                                near_enemy_list.Add(near_check[i].transform.gameObject);
                                distance.Add(Vector3.Distance(position, near_check[i].transform.position));
                            }
                            
                            
                        }
                    }
                    if (near_enemy_list.Count > 0)
                    {
                        Vector3 chain_spawn_adjust = new Vector3(position.x, (position.y + 2), position.z);
                        Vector3 chain_adjust = new Vector3(0, 1.2f, (distance[0]));
                        GameObject chain1 = Instantiate(arc_prefab, chain_spawn_adjust, Quaternion.identity);
                        Destroy(chain1, 1);
                        chain1.transform.LookAt(near_enemy_list[0].transform);
                        chain1.transform.GetChild(0).transform.gameObject.GetComponent<LineRenderer>().SetPosition(1, chain_adjust);

                        IDamageable<float> damageable2 = near_enemy_list[0].transform.GetComponent<IDamageable<float>>();
                        if (damageable2 != null)
                        {
                            damageable2.Damage(PlayerStats.instance.Arc_Damage());
                        }

                        chain1.GetComponent<AudioSource>().enabled = true;
                    }
                    if (near_enemy_list.Count > 1)
                    {
                        Vector3 chain_spawn_adjust = new Vector3(position.x, (position.y + 2), position.z);
                        Vector3 chain_adjust = new Vector3(0, 1.2f, (distance[1]));
                        GameObject chain2 = Instantiate(arc_prefab, chain_spawn_adjust, Quaternion.identity);
                        Destroy(chain2, 1);
                        chain2.transform.LookAt(near_enemy_list[1].transform);
                        chain2.transform.GetChild(0).transform.gameObject.GetComponent<LineRenderer>().SetPosition(1, chain_adjust);
                        IDamageable<float> damageable2 = near_enemy_list[1].transform.GetComponent<IDamageable<float>>();
                        if (damageable2 != null)
                        {
                            damageable2.Damage(PlayerStats.instance.Arc_Damage());
                        }
                    }
                    if (near_enemy_list.Count > 2)
                    {
                        Vector3 chain_spawn_adjust = new Vector3(position.x, (position.y + 2), position.z);
                        Vector3 chain_adjust = new Vector3(0, 1.2f, (distance[2]));
                        GameObject chain3 = Instantiate(arc_prefab, chain_spawn_adjust, Quaternion.identity);
                        Destroy(chain3, 1);
                        chain3.transform.LookAt(near_enemy_list[2].transform);
                        chain3.transform.GetChild(0).transform.gameObject.GetComponent<LineRenderer>().SetPosition(1, chain_adjust);
                        IDamageable<float> damageable2 = near_enemy_list[2].transform.GetComponent<IDamageable<float>>();
                        if (damageable2 != null)
                        {
                            damageable2.Damage(PlayerStats.instance.Arc_Damage());
                        }
                    }

                }
            }
            #endregion

            #region Hot Foot
            if (PlayerStats.instance.Hot_Foot_Active)
            {
                int HotFootRand = Random.Range(0, 6);
                switch (PlayerStats.instance.Hot_Foot_Rank)
                {
                    case 1: if (HotFootRand == 0 || HotFootRand == 1)
                        {
                            GameObject hot_foot_inst = Instantiate(Hot_foot_prefab, position, Quaternion.identity);
                            Destroy(hot_foot_inst, 6);
                        }
                        break;
                    case 2:
                        if (HotFootRand == 0 || HotFootRand == 1 || HotFootRand == 2)
                        {
                            GameObject hot_foot_inst = Instantiate(Hot_foot_prefab, position, Quaternion.identity);
                            Destroy(hot_foot_inst, 6);
                        }
                        break;
                    case 3:
                        if (HotFootRand == 0 || HotFootRand == 1 || HotFootRand == 2 || HotFootRand == 3)
                        {
                            GameObject hot_foot_inst = Instantiate(Hot_foot_prefab, position, Quaternion.identity);
                            Destroy(hot_foot_inst, 6);
                        }
                        break;
                }
            }
            #endregion

            if (PlayerStats.instance.Dust_Cloud_Active)
            {
                int dust_random = Random.Range(0, 4);
                if (dust_random == 1)
                {
                    GameObject dust_cloud_inst = Instantiate(dust_cloud_prefab, position, Quaternion.identity);
                }
            }

                On_Spell_Hit_Timer = 0;
        }
    }

    public List<GameObject> Find_Near_Enemies(int radius = 50)
    {
        List<GameObject> near_enemies = new List<GameObject>();
        Collider[] enemies = Physics.OverlapSphere(Basics.instance.Player.transform.position, radius);
        foreach (Collider hits in enemies)
        {
            if (hits.tag == "Enemy")
            {
                near_enemies.Add(hits.transform.gameObject);
            }
        }
        return near_enemies;
    }

    IEnumerator Icicle_Launch()
    {
        if (PlayerStats.instance.Icicles_Rank > 0)
        {
            GameObject icicle_inst1 = Instantiate(icicle_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
            Destroy(icicle_inst1, 4);
        }
        yield return new WaitForSeconds(.6f);
        if (PlayerStats.instance.Icicles_Rank > 1)
        {
            GameObject icicle_inst2 = Instantiate(icicle_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
            Destroy(icicle_inst2, 4);
        }
        yield return new WaitForSeconds(.6f);
        if (PlayerStats.instance.Icicles_Rank > 2)
        {
            GameObject icicle_inst3 = Instantiate(icicle_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
            Destroy(icicle_inst3, 4);
        }
        yield return null;
    }
    IEnumerator Homing_Flares_Launch()
    {
        switch (PlayerStats.instance.Homing_Flares_Rank)
        {
            case 1:
                {
                    GameObject flare1 = Instantiate(homing_flare_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
                    Destroy(flare1, 10);
                    yield return new WaitForSeconds(.6f);
                    GameObject flare2 = Instantiate(homing_flare_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
                    Destroy(flare2, 10);
                }
                break;
            case 2:
                {
                    GameObject flare3 = Instantiate(homing_flare_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
                    Destroy(flare3, 10);
                    yield return new WaitForSeconds(.6f);
                    GameObject flare4 = Instantiate(homing_flare_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
                    Destroy(flare4, 10);
                    yield return new WaitForSeconds(.6f);
                    GameObject flare5 = Instantiate(homing_flare_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
                    Destroy(flare5, 10);
                    yield return new WaitForSeconds(.6f);
                    GameObject flare6 = Instantiate(homing_flare_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
                    Destroy(flare6, 10);
                        }
                    break;
            case 3:
                GameObject flare11 = Instantiate(homing_flare_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
                Destroy(flare11, 10);
                yield return new WaitForSeconds(.6f);
                GameObject flare22 = Instantiate(homing_flare_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
                Destroy(flare22, 10);
                yield return new WaitForSeconds(.6f);
                GameObject flare33 = Instantiate(homing_flare_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
                Destroy(flare33, 10);
                yield return new WaitForSeconds(.6f);
                GameObject flare44 = Instantiate(homing_flare_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
                Destroy(flare44, 10);
                yield return new WaitForSeconds(.6f);
                GameObject flare55 = Instantiate(homing_flare_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
                Destroy(flare55, 10);
                yield return new WaitForSeconds(.6f);
                GameObject flare66 = Instantiate(homing_flare_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
                Destroy(flare66, 10);
                break;
            default: yield return null;
                break;
               
        }
    }
    IEnumerator Warmth_Regen()
    {
        switch (PlayerStats.instance.Warmth_Rank)
        {
            case 1:
                {
                    PlayerStats.instance.Shield_Regen += 2;
                    StartCoroutine(PlayerStats.instance.Heal_Text(2));
                    yield return new WaitForSeconds(3);
                    StartCoroutine(PlayerStats.instance.Heal_Text(2));
                    yield return new WaitForSeconds(3);
                    StartCoroutine(PlayerStats.instance.Heal_Text(2));
                    yield return new WaitForSeconds(3);
                    StartCoroutine(PlayerStats.instance.Heal_Text(2));
                    yield return new WaitForSeconds(1);
                    PlayerStats.instance.Shield_Regen -= 2;
                }
                break;
            case 2:
                {
                    PlayerStats.instance.Shield_Regen += 4;
                    StartCoroutine(PlayerStats.instance.Heal_Text(4));
                    yield return new WaitForSeconds(3);
                    StartCoroutine(PlayerStats.instance.Heal_Text(4));
                    yield return new WaitForSeconds(3);
                    StartCoroutine(PlayerStats.instance.Heal_Text(4));
                    yield return new WaitForSeconds(3);
                    StartCoroutine(PlayerStats.instance.Heal_Text(4));
                    yield return new WaitForSeconds(1);
                    PlayerStats.instance.Shield_Regen -= 4;
                }
                    break;
            case 3:
                {
                    PlayerStats.instance.Shield_Regen += 6;
                    StartCoroutine(PlayerStats.instance.Heal_Text(6));
                    yield return new WaitForSeconds(3);
                    StartCoroutine(PlayerStats.instance.Heal_Text(6));
                    yield return new WaitForSeconds(3);
                    StartCoroutine(PlayerStats.instance.Heal_Text(6));
                    yield return new WaitForSeconds(3);
                    StartCoroutine(PlayerStats.instance.Heal_Text(6));
                    yield return new WaitForSeconds(1);
                    PlayerStats.instance.Shield_Regen -= 6;
                }
                    break;
            default: yield return null;
                break;

        }
       
    }
}
