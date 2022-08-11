using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Passive_Level_Up : MonoBehaviour
{
    private int Get_Spot;
    public GameObject Max_Passive_Popup;
    private GameObject Passives_Display;

    private void Start()
    {
        Passives_Display = Basics.instance.display_passives_canvas.transform.GetChild(0).transform.gameObject;
    }
    private void OnEnable()
        {
            //Populate Options
            //Get what button and assign random selected spell gamelogic/instance/random_spells
            switch (transform.name)
            {
                case "Passive_Choice_1":
                    Get_Spot = 0;
                    break;
                case "Passive_Choice_2":
                    Get_Spot = 1;
                    break;
                case "Passive_Choice_3":
                    Get_Spot = 2;
                    break;
                case "Passive_Choice_4":
                    Get_Spot = 3;
                    break;
                case "Passive_Choice_5":
                    Get_Spot = 4;
                    break;
            }

        //***************************************\\
        //Populate info based on random chosen passives
        #region Populate Options
        switch (Game_Logic.instance.Random_Passives[Get_Spot].ToString())
        {
            #region Air
            case "Thunder Aura":
                if (PlayerStats.instance.Thunder_Aura_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Thunder Aura";
                } else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Thunder Aura";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Strikes a random enemy with a lightning bolt every 12/8/4 seconds for 100 damage";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Thunder_Aura_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.air_sprite;
                break;
                case "Tail Wind":
                if (PlayerStats.instance.Tail_Wind_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Tail Wind";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Tail Wind";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Increases movement and flight speed by 15/30/40%";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Tail_Wind_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.air_sprite;
                break;
                case "Wind Step":
                if (PlayerStats.instance.Wind_Step_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Wind Step";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Wind Step";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Dash cooldown reduced  1/2/3 seconds";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Wind_Step_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.air_sprite;
                break;
                case "Aero Momentum":
                if (PlayerStats.instance.Aero_Momentum_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Aero Momentum";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Aero Momentum";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Dashing shoots a wind orb dealing 100/150/200 damage";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Aero_Momentum_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.air_sprite;
                break;
                case "Pressure Vacuum":
                if (PlayerStats.instance.Pressure_Vacuum_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Pressure Vacuum";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Pressure Vacuum";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Spell hits have a 14% chance to create a vortex pulling in enemies and dealing 10/20/30 damage per second";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Pressure_Vacuum_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.air_sprite;
                break;
            case "Arc":
                if (PlayerStats.instance.Arc_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Arc";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Arc";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Spells hits have 50% chance to arc lightning to 3 nearby enemies dealing 50/100/150";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Arc_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.air_sprite;
                break;
            case "Rolling Charge":
                if (PlayerStats.instance.Rolling_Charge_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Rolling Charge";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Rolling Charge";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Spell casts create a rolling charge for 100/150/200 and shocking the enemy";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Rolling_Charge_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.air_sprite;
                break;
            case "Siphon Ward":
                if (PlayerStats.instance.Siphon_Ward_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Siphon Ward";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Siphon Ward";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Attacks that hit your ward will heal you for 10/20/30% of the damage warded";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Siphon_Ward_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.air_sprite;
                break;
            case "Supercharge Ward":
                if (PlayerStats.instance.Supercharge_Ward_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Supercharge Ward";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Supercharge Ward";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Ward regenerates 50/100/150% faster";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Supercharge_Ward_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.air_sprite;
                break;
            #endregion
            #region Fire
            case "Hot Foot":
                if (PlayerStats.instance.Hot_Foot_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Hot Foot";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Hot Foot";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Spell hits have a 33/50/66% chance to leave floor lava for 6 seconds dealing 10/15/20 damage per second";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Hot_Foot_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.fire_sprite;
                break;
            case "Cauterize":
                if (PlayerStats.instance.Cauterize_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Cauterize";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Cauterize";
                transform.GetChild(1).transform.GetComponent<Text>().text = "10% chance to heal 20/40/60 health when damaged";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Cauterize_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.fire_sprite;
                break;
            case "Starfall":
                if (PlayerStats.instance.Starfall_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Starfall";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Starfall";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Every 5 seconds call down 2/4/6 blue fire meteors dealing 50 damage";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Starfall_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.fire_sprite;
                break;
            case "Fire Sprite":
                if (PlayerStats.instance.Fire_Sprite_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Fire Sprite";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Fire Sprite";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Spell casts have a 20% chance to summon a fire sprite that shoots 40 damage fireballs at nearby enemies for 8/13/18 seconds";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Fire_Sprite_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.fire_sprite;
                break;
            case "Homing Flares":
                if (PlayerStats.instance.Homing_Flares_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Homing Flares";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Homing Flares";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Spell casts launch 2/4/6 homing flares for 40 damage each";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Homing_Flares_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.fire_sprite;
                break;
            case "Sun Call":
                if (PlayerStats.instance.Sun_Call_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Sun Call";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Sun Call";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Spell casts have a 15% chance to drop a massive sun orb for 100/150/200 damage";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Sun_Call_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.fire_sprite;
                break;
            case "Warmth":
                if (PlayerStats.instance.Warmth_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Warmth";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Warmth";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Casting a spell has a 12% chance to increases passive healing per second by 2/4/6 for 10 seconds";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Warmth_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.fire_sprite;
                break;
            case "Flame Dash":
                if (PlayerStats.instance.Flame_Dash_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Flame Dash";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Flame Dash";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Dashing leaves behind a firey area dealing 15/30/45 damage per second for 8 seconds";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Flame_Dash_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.fire_sprite;
                break;
            case "Flare Beam":
                if (PlayerStats.instance.Flare_Beam_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Flare Beam";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Flare Beam";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Every 10 seconds a firey beam hits a nearby enemy for 70/140/210 damage";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Flare_Beam_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.fire_sprite;
                break;
            #endregion
            #region Ice
            case "Icicles":
                if (PlayerStats.instance.Hot_Foot_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Icicles";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Icicles";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Spell casts launch 1/2/3 icicles for 80 damage each";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Icicles_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.water_sprite;
                break;
            case "Ice Barrier":
                if (PlayerStats.instance.Ice_Barrier_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Ice Barrier";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Ice Barrier";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Every 15 seconds, spell casts give you a 10/15/20% max health decaying barrier";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Ice_Barrier_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.water_sprite;
                break;
            case "Frozen Armor":
                if (PlayerStats.instance.Frozen_Armor_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Frozen Armor";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Frozen Armor";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Increase melee and close range spell damage by 33/66/100%";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Frozen_Armor_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.water_sprite;
                break;
            case "Frost Nova":
                if (PlayerStats.instance.Frost_Nova_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Frost Nova";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Frost Nova";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Every 10 seconds release a frost nova for 70/140/210 damage and freezing enemies";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Frost_Nova_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.water_sprite;
                break;
            case "Ice Block":
                if (PlayerStats.instance.Ice_Block_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Ice Block";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Ice Block";
                transform.GetChild(1).transform.GetComponent<Text>().text = "When reaching 1 health, heal 20% of max health. 1/2/3 charges.";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Ice_Block_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.water_sprite;
                break;
            case "Healing Rain":
                if (PlayerStats.instance.Healing_Rain_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Healing Rain";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Healilng Rain";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Every 30 seconds spawn a rain storm. Standing inside the rain heals you for 8/12/16 health per second";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Healing_Rain_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.water_sprite;
                break;
            case "Frozen Ward":
                if (PlayerStats.instance.Frozen_Ward_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Frozen Ward";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Frozen Ward";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Increase max ward by 15/30/45%";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Frozen_Ward_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.water_sprite;
                break;
            case "Icy Impale":
                if (PlayerStats.instance.Icy_Impale_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Icy Impale";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Icy Impale";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Every 6/4/2 seconds cast an ice spike at a nearby enemy for 80 damage";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Icy_Impale_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.water_sprite;
                break;
            #endregion
            #region Earth
            case "Stone Throw":
                if (PlayerStats.instance.Hot_Foot_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Stone Throw";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Stone Throw";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Every 6/4/2 seconds throw a stone dealing 60/70/80 damage";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Stone_Throw_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.earth_sprite;
                break;
            case "Stone Skin":
                if (PlayerStats.instance.Stone_Skin_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Stone Skin";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Stone Skin";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Increases max health by 10/20/30%";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Stone_Skin_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.earth_sprite;
                break;
            case "Rejuvenation":
                if (PlayerStats.instance.Rejuvination_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Rejuvenation";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Rejuvenation";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Increase passive healing per second by 100%/150%/200%";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Rejuvination_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.earth_sprite;
                break;
            case "Spike Armor":
                if (PlayerStats.instance.Spike_Armor_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Earth Stomp";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Earth Stomp";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Every 5 seconds deals 50/75/100 damage to nearby enemies";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Spike_Armor_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.earth_sprite;
                break;
            case "Dust Cloud":
                if (PlayerStats.instance.Dust_Cloud_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Dust Cloud";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Dust Cloud";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Spell hits have a 25% chance to leave behind a dust cloud dealing 20/30/40 damager per second and petrifying for 4/5/6 seconds";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Dust_Cloud_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.earth_sprite;
                break;
            case "Harden":
                if (PlayerStats.instance.Harden_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Harden";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Harden";
                transform.GetChild(1).transform.GetComponent<Text>().text = "On dash gain a decaying barrier for 5/7.5/10% of max health";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Harden_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.earth_sprite;
                break;
            case "Rock Drill":
                if (PlayerStats.instance.Rock_Drill_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Rock Drill";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Rock Drill";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Dashing into enemy deals 70/140/210 damage";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Rock_Drill_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.earth_sprite;
                break;
            case "Earth Elemental":
                if (PlayerStats.instance.Earth_Elemental_Rank == 0)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Passive: Earth Elemental";
                }
                else transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Earth Elemental";
                transform.GetChild(1).transform.GetComponent<Text>().text = "Summons an earth elemental who attacks nearby foes for 100/150/200 damage";
                transform.GetChild(2).transform.GetComponent<Text>().text = PlayerStats.instance.Earth_Elemental_Rank.ToString();
                transform.GetChild(3).transform.GetComponent<Image>().sprite = Game_Logic.instance.earth_sprite;
                break;
                #endregion
        }
        #endregion
    }

    public void Passive_Selected_Button()
    {
        //***************************************\\
        //Run activate/rank up when button pressed
        #region Passive Options for Button

        int new_rank;
        switch (Game_Logic.instance.Random_Passives[Get_Spot].ToString())
        {
            #region Air
            case "Thunder Aura":
                if (PlayerStats.instance.Thunder_Aura_Rank < 3)
                {
                    PlayerStats.instance.Thunder_Aura_Activator();
                    new_rank = PlayerStats.instance.Thunder_Aura_Rank;
                    CopyToPassivesDisplay("air", new_rank);
                    Close_and_Exit();
                } else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Tail Wind":
                //Logic is in player controller
                if (PlayerStats.instance.Tail_Wind_Rank < 3)
                {
                    PlayerStats.instance.Tail_Wind_activator();
                new_rank = PlayerStats.instance.Tail_Wind_Rank;
                CopyToPassivesDisplay("air", new_rank);
                Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Wind Step":
                if (PlayerStats.instance.Wind_Step_Rank < 3)
                {
                    PlayerStats.instance.Wind_Step_activator();
                new_rank = PlayerStats.instance.Wind_Step_Rank;
                CopyToPassivesDisplay("air", new_rank);
                Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Aero Momentum":
                if (PlayerStats.instance.Aero_Momentum_Rank < 3)
                {
                    PlayerStats.instance.Aero_Momentum_activator();
                new_rank = PlayerStats.instance.Aero_Momentum_Rank;
                CopyToPassivesDisplay("air", new_rank);
                Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Pressure Vacuum":
                if (PlayerStats.instance.Pressure_Vacuum_Rank < 3)
                {
                    PlayerStats.instance.Pressure_Vacuum_activator();
                new_rank = PlayerStats.instance.Pressure_Vacuum_Rank;
                CopyToPassivesDisplay("air", new_rank);
                Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Arc":
                if (PlayerStats.instance.Arc_Rank < 3)
                {
                    PlayerStats.instance.Arc_activator();
                new_rank = PlayerStats.instance.Arc_Rank;
                CopyToPassivesDisplay("air", new_rank);
                Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Rolling Charge":
                if (PlayerStats.instance.Rolling_Charge_Rank < 3)
                {
                    PlayerStats.instance.Rolling_Charge_activator();
                new_rank = PlayerStats.instance.Rolling_Charge_Rank;
                CopyToPassivesDisplay("air", new_rank);
                Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Siphon Ward":
                if (PlayerStats.instance.Siphon_Ward_Rank < 3)
                {
                    PlayerStats.instance.Siphon_Ward_activator();
                new_rank = PlayerStats.instance.Siphon_Ward_Rank;
                CopyToPassivesDisplay("air", new_rank);
                Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Supercharge Ward":
                if (PlayerStats.instance.Supercharge_Ward_Rank < 3)
                {
                    PlayerStats.instance.Supercharge_Ward_activator();
                    new_rank = PlayerStats.instance.Supercharge_Ward_Rank;
                    CopyToPassivesDisplay("air", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            #endregion
            #region Fire
            case "Hot Foot":
                if (PlayerStats.instance.Hot_Foot_Rank < 3)
                {
                    PlayerStats.instance.Hot_Foot_Activator();
                    new_rank = PlayerStats.instance.Hot_Foot_Rank;
                    CopyToPassivesDisplay("fire", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Cauterize":
                if (PlayerStats.instance.Cauterize_Rank < 3)
                {
                    PlayerStats.instance.Cauterize_Activator();
                    new_rank = PlayerStats.instance.Cauterize_Rank;
                    CopyToPassivesDisplay("fire", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Starfall":
                if (PlayerStats.instance.Starfall_Rank < 3)
                {
                    PlayerStats.instance.Starfall_Activator();
                    new_rank = PlayerStats.instance.Starfall_Rank;
                    CopyToPassivesDisplay("fire", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Fire Sprite":
                if (PlayerStats.instance.Fire_Sprite_Rank < 3)
                {
                    PlayerStats.instance.Fire_Sprite_Activator();
                    new_rank = PlayerStats.instance.Fire_Sprite_Rank;
                    CopyToPassivesDisplay("fire", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Homing Flares":
                if (PlayerStats.instance.Homing_Flares_Rank < 3)
                {
                    PlayerStats.instance.Homing_Flares_Activator();
                    new_rank = PlayerStats.instance.Homing_Flares_Rank;
                    CopyToPassivesDisplay("fire", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Sun Call":
                if (PlayerStats.instance.Sun_Call_Rank < 3)
                {
                    PlayerStats.instance.Sun_Call_Activator();
                    new_rank = PlayerStats.instance.Sun_Call_Rank;
                    CopyToPassivesDisplay("fire", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Warmth":
                if (PlayerStats.instance.Warmth_Rank < 3)
                {
                    PlayerStats.instance.Warmth_Activator();
                    new_rank = PlayerStats.instance.Warmth_Rank;
                    CopyToPassivesDisplay("fire", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Flame Dash":
                if (PlayerStats.instance.Flame_Dash_Rank < 3)
                {
                    PlayerStats.instance.Flame_Dash_Activator();
                    new_rank = PlayerStats.instance.Flame_Dash_Rank;
                    CopyToPassivesDisplay("fire", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Flare Beam":
                if (PlayerStats.instance.Flare_Beam_Rank < 3)
                {
                    PlayerStats.instance.Flare_Beam_Activator();
                    new_rank = PlayerStats.instance.Flare_Beam_Rank;
                    CopyToPassivesDisplay("fire", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            #endregion
            #region Ice
            case "Icicles":
                if (PlayerStats.instance.Icicles_Rank < 3)
                {
                    PlayerStats.instance.Icicles_Activator();
                    new_rank = PlayerStats.instance.Icicles_Rank;
                    CopyToPassivesDisplay("ice", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Ice Barrier":
                if (PlayerStats.instance.Ice_Barrier_Rank < 3)
                {
                    PlayerStats.instance.Ice_Barrier_Activator();
                    new_rank = PlayerStats.instance.Ice_Barrier_Rank;
                    CopyToPassivesDisplay("ice", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Frozen Armor":
                if (PlayerStats.instance.Frozen_Armor_Rank < 3)
                {
                    PlayerStats.instance.Frozen_Armor_Activator();
                    new_rank = PlayerStats.instance.Frozen_Armor_Rank;
                    CopyToPassivesDisplay("ice", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Frost Nova":
                if (PlayerStats.instance.Frost_Nova_Rank < 3)
                {
                    PlayerStats.instance.Frost_Nova_Activator();
                    new_rank = PlayerStats.instance.Frost_Nova_Rank;
                    CopyToPassivesDisplay("ice", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Ice Block":
                if (PlayerStats.instance.Ice_Block_Rank < 3)
                {
                    PlayerStats.instance.Ice_Block_Activator();
                    new_rank = PlayerStats.instance.Ice_Block_Rank;
                    CopyToPassivesDisplay("ice", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Healing Rain":
                if (PlayerStats.instance.Healing_Rain_Rank < 3)
                {
                    PlayerStats.instance.Healing_Rain_Activator();
                    new_rank = PlayerStats.instance.Healing_Rain_Rank;
                    CopyToPassivesDisplay("ice", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Frozen Ward":
                if (PlayerStats.instance.Frozen_Ward_Rank < 3)
                {
                    PlayerStats.instance.Frozen_Ward_Activator();
                    new_rank = PlayerStats.instance.Frozen_Ward_Rank;
                    CopyToPassivesDisplay("ice", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Icy Impale":
                if (PlayerStats.instance.Icy_Impale_Rank < 3)
                {
                    PlayerStats.instance.Icy_Impale_Activator();
                    new_rank = PlayerStats.instance.Icy_Impale_Rank;
                    CopyToPassivesDisplay("ice", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            #endregion
            #region Earth
            case "Stone Throw":
                if (PlayerStats.instance.Stone_Throw_Rank < 3)
                {
                    PlayerStats.instance.Stone_Throw_Activator();
                    new_rank = PlayerStats.instance.Stone_Throw_Rank;
                    CopyToPassivesDisplay("earth", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Stone Skin":
                if (PlayerStats.instance.Stone_Skin_Rank < 3)
                {
                    PlayerStats.instance.Stone_Skin_Activator();
                    new_rank = PlayerStats.instance.Stone_Skin_Rank;
                    CopyToPassivesDisplay("earth", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Rejuvenation":
                if (PlayerStats.instance.Rejuvination_Rank < 3)
                {
                    PlayerStats.instance.Rejuvination_Activator();
                    new_rank = PlayerStats.instance.Rejuvination_Rank;
                    CopyToPassivesDisplay("earth", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Spike Armor":
                if (PlayerStats.instance.Spike_Armor_Rank < 3)
                {
                    PlayerStats.instance.Spike_Armor_Activator();
                    new_rank = PlayerStats.instance.Spike_Armor_Rank;
                    CopyToPassivesDisplay("earth", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Dust Cloud":
                if (PlayerStats.instance.Dust_Cloud_Rank < 3)
                {
                    PlayerStats.instance.Dust_Cloud_Activator();
                    new_rank = PlayerStats.instance.Dust_Cloud_Rank;
                    CopyToPassivesDisplay("earth", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Harden":
                if (PlayerStats.instance.Harden_Rank < 3)
                {
                    PlayerStats.instance.Harden_Activator();
                    new_rank = PlayerStats.instance.Harden_Rank;
                    CopyToPassivesDisplay("earth", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Rock Drill":
                if (PlayerStats.instance.Rock_Drill_Rank < 3)
                {
                    PlayerStats.instance.Rock_Drill_Activator();
                    new_rank = PlayerStats.instance.Rock_Drill_Rank;
                    CopyToPassivesDisplay("earth", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
            case "Earth Elemental":
                if (PlayerStats.instance.Earth_Elemental_Rank < 3)
                {
                    PlayerStats.instance.Earth_Elemental_Activator();
                    new_rank = PlayerStats.instance.Earth_Elemental_Rank;
                    CopyToPassivesDisplay("earth", new_rank);
                    Close_and_Exit();
                }
                else
                {
                    Max_Passive_Popup.SetActive(true);
                    return;
                }
                break;
                #endregion
        }
        #endregion
    }

    private void CopyToPassivesDisplay(string Element, int updated_rank)
    {
        GameObject display_inst;

        //search all and delete old version with lower rank
        if (Passives_Display.transform.childCount > 0)
        {
            for (int i = 0; i < Passives_Display.transform.childCount; i++)
            {
                if (Passives_Display.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text == Game_Logic.instance.Random_Passives[Get_Spot].ToString())
                {
                    Destroy(Passives_Display.transform.GetChild(i).gameObject);
                }
            }
        }
        //add to UI display list search for dupe
        switch (Element)
        {
            case "air":
                display_inst = Instantiate(Basics.instance.air_display_prefab, Passives_Display.transform);
                display_inst.transform.GetChild(0).GetComponent<Text>().text = Game_Logic.instance.Random_Passives[Get_Spot].ToString();
                display_inst.transform.GetChild(1).GetComponent<Text>().text = transform.GetChild(1).transform.GetComponent<Text>().text;
                display_inst.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = updated_rank.ToString();
                break;
            case "fire":
                display_inst = Instantiate(Basics.instance.fire_display_prefab, Passives_Display.transform);
                display_inst.transform.GetChild(0).GetComponent<Text>().text = Game_Logic.instance.Random_Passives[Get_Spot].ToString();
                display_inst.transform.GetChild(1).GetComponent<Text>().text = transform.GetChild(1).transform.GetComponent<Text>().text;
                display_inst.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = updated_rank.ToString();
                break;
            case "ice":
                display_inst = Instantiate(Basics.instance.ice_display_prefab, Passives_Display.transform);
                display_inst.transform.GetChild(0).GetComponent<Text>().text = Game_Logic.instance.Random_Passives[Get_Spot].ToString();
                display_inst.transform.GetChild(1).GetComponent<Text>().text = transform.GetChild(1).transform.GetComponent<Text>().text;
                display_inst.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = updated_rank.ToString();
                break;
            case "earth":
                display_inst = Instantiate(Basics.instance.earth_display_prefab, Passives_Display.transform);
                display_inst.transform.GetChild(0).GetComponent<Text>().text = Game_Logic.instance.Random_Passives[Get_Spot].ToString();
                display_inst.transform.GetChild(1).GetComponent<Text>().text = transform.GetChild(1).transform.GetComponent<Text>().text;
                display_inst.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = updated_rank.ToString();
                break;
        }

    }

    public void Close_and_Exit()
    {
        //Basics.instance.Action_UI.SetActive(true);
        Basics.instance.Action_UI.GetComponent<Animator>().Play("RollUpHotbar");
        Cursor.lockState = CursorLockMode.Locked;
        Basics.instance.Main_Camera.GetComponent<CameraController>().enabled = true;
        Time.timeScale = 1;
        Game_Logic.instance.Passive_Level_Up_Window.SetActive(false);
    }

}
