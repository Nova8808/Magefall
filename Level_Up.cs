using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Up : MonoBehaviour
{
    private int Get_Spot;
    public GameObject NoEmpty_Popup;
    private GameObject Spell_Option_inst;
    public GameObject Spell_At_Max_Popup;
    

    private void OnEnable()
    {
        if (transform.childCount > 3)
        {
            Destroy(transform.GetChild(3).gameObject);
        }
        //Populate Options
        //Get what button and assign random selected spell gamelogic/instance/random_spells
        switch (transform.name)
        {
            case "Spell_Choice_1":
                Get_Spot = 0;              
                break;
            case "Spell_Choice_2":
                Get_Spot = 1;
                break;
            case "Spell_Choice_3":
                Get_Spot = 2;
                break;
            case "Spell_Choice_4":
                Get_Spot = 3;
                break;
        }

        Spell_Option_inst = Instantiate(Game_Logic.instance.Random_Spells[Get_Spot], transform.GetChild(2).transform.GetChild(0).transform);
        Spell_Option_inst.name = Game_Logic.instance.Random_Spells[Get_Spot].name;
        //Spell_Option_inst.GetComponent<RectTransform>().anchoredPosition = new Vector3(-145, 30, 0);
        Spell_Option_inst.GetComponent<RectTransform>().localScale = new Vector3(.81f, .81f, .81f);
        Spell_Option_inst.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        //Check if on bar and if so make a bool flag so that it doesnt say new spell
        GameObject[] check_hotbar = new GameObject[8];
        bool spell_on_bar = false;
        //Gets current hotbar
        for (int x = 0; x < 7; x++)
        {
            if (Basics.instance.Fire_Hotbar.transform.GetChild(x).transform.childCount > 1)
            {
                check_hotbar[x] = Basics.instance.Fire_Hotbar.transform.GetChild(x).transform.GetChild(1).transform.gameObject;
            }
            else check_hotbar[x] = Game_Logic.instance.Level_Up_Window;
        }

        for (int x = 0; x < 7; x++)
        {
            if (Spell_Option_inst.transform.name == check_hotbar[x].transform.name)
            {
                spell_on_bar = true;
            }
        }

            //************************************************************\\
            //Giant switch/case for populating text Update for each new spell!
            #region Population Options Text (Update for each new spell)
            switch (Spell_Option_inst.transform.name)
        {
            case "Meteor_UI":
                //Within this probably need if statement which checks spell level to decide what text to say
                if (PlayerStats.instance.Meteor_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Meteor";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A giant meteor crashes down from the sky for " + PlayerStats.instance.Meteor_Damage().ToString() + " damage. Cooldown: " 
                        + CooldownManager.instance.Meteor_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Meteor";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Meteor damage and area of effect is increased";
                }
                break;
            case "Chain_Lightning_UI":
                if (PlayerStats.instance.Chain_Lightning_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Chain Lightning";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A bolt of lightning that chains between foes for " + PlayerStats.instance.ChainLightning_Damage().ToString() + " damage. Cooldown: " +
                        CooldownManager.instance.Chain_Lightning_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Chain Lightning";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Number of chains and damage increases";
                }
                break;
            case "Solar_Sphere_UI":
                if (PlayerStats.instance.Solar_Sphere_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Solar Sphere";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "An enormous sphere of solar energy hitting for " + PlayerStats.instance.SolarSphere_Damage().ToString() + " damage. Cooldown: " +
                        CooldownManager.instance.Solar_Sphere_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Solar Sphere";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Solar Sphere damage and area of effect is increased";
                }
                break;
            case "Blizzard_UI":
                if (PlayerStats.instance.Blizzard_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Blizzard";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Rain shards of ice from the sky dealing " + PlayerStats.instance.Blizzard_Damage().ToString() + " damage per second and a 20% chance to freeze. Cooldown: " +
                        CooldownManager.instance.Blizzard_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Blizzard";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Blizzard damage and duration is increased";
                }
                break;
            case "Ice_Claymore_UI":
                if (PlayerStats.instance.Ice_Claymore_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Ice Claymore";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Swing a giant sword of ice for " + PlayerStats.instance.Ice_Claymore_Damage().ToString() + " damage and healing for 10 HP. Cooldown: " +
                        CooldownManager.instance.Ice_Claymore_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Ice Claymore";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Ice Claymore damage and range is increased";
                }
                break;
            case "Frozen_Orb_UI":
                if (PlayerStats.instance.Frozen_Orb_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Frozen Orb";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Swirling frozen orb dealing " + PlayerStats.instance.FrozenOrb_Damage().ToString() + " damage per second and a 20% chance to freeze. Cooldown: "
                        + CooldownManager.instance.Frozen_Orb_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Frozen Orb";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Frozen Orb damage and area of effect is increased";
                }
                break;
            case "Scorching_Ray_UI":
                if (PlayerStats.instance.Scorching_Ray_Spell_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Scorching Ray";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Hold to channel a beam of scorching heat dealing " + PlayerStats.instance.Scorching_Ray_Damage().ToString() + " damage per .5 seconds. Cooldown: " +
                        CooldownManager.instance.Scorching_Ray_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Scorching Ray";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Scorching Ray damage and size is increased";
                }
                break;
            case "Earthquake_UI":
                if (PlayerStats.instance.Earthquake_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Earthquake";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Summons an earthquake to churn the earth dealing " + PlayerStats.instance.Earthquake_Damage().ToString() + " damage. Cooldown: "
            + CooldownManager.instance.Earth_Spike_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Earthquake";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Earthquake area effect and damage is increased";
                }
                break;
            case "Magma_Orb_UI":
                if (PlayerStats.instance.Magma_Spell_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Magma Orb";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A bouncing ball of magma dealing " + PlayerStats.instance.Magma_Damage().ToString() + " damage per bounce. Cooldown: " +
                        CooldownManager.instance.Magma_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Magma Orb";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Magma Orb damage and number of bounces increases";
                }
                break;
            case "Static_UI":
                if (PlayerStats.instance.Static_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Static";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Hold to channel electricity dealing " + PlayerStats.instance.Static_Damage().ToString() + " damage per second. Cooldown: " +
                        CooldownManager.instance.Static_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Static";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Static duration and damage increases";
                }
                break;
            case "Rock_Barrage_UI":
                if (PlayerStats.instance.Stone_Sling_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Rock Barrage";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Hold to channel a barrage of rocks for " + PlayerStats.instance.Stone_Sling_Damage().ToString() + " damage per rock";
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Rock Barrage";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Increases damage for each rock";
                }
                break;
            case "Sunbeam_UI":
                if (PlayerStats.instance.Sunbeam_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Sunbeam";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "After a delay, a giant pillar of fire scorches enemies for " + PlayerStats.instance.Sunbeam_Damage().ToString() + " damage in a line. Cooldown: " +
                        CooldownManager.instance.Sunbeam_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Sunbeam";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Sunbeam damage and area of effect increased";
                }
                break;
            case "Plasma_Ray_UI":
                if (PlayerStats.instance.Plasma_Ray_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Plasma Ray";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "An intense but short beam of plasma dealing " + PlayerStats.instance.Plasma_Ray_Damage().ToString() + " damage per .15 seconds and drags enemies. Cooldown: "
            + CooldownManager.instance.Plasma_Ray_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Plasma Ray";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Plasma Ray duration and damage increases";
                }
                break;
            case "Loose_Boulder_UI":
                if (PlayerStats.instance.Loose_Boulder_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Loose Boulder";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Let loose a massive boulder that crashes into enemies for " + PlayerStats.instance.LooseBoulder_Damage().ToString() + " damage. Cooldown: "
            + CooldownManager.instance.Loose_Boulder_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Loose Boulder";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Loose Boulder size and damage increases";
                }
                break;
            case "Terra_Dive_UI":
                if (PlayerStats.instance.Terra_Dive_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Terra Dive";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Rise into the air and then crash down forawrd, cratering for " + PlayerStats.instance.TerraDive_Damage().ToString() + " damage. Cooldown: "
            + CooldownManager.instance.Terra_Dive_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Terra Dive";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Terra Dive area effect and damage increases";
                }
                break;
            case "Flare_Barrage_UI":
                if (PlayerStats.instance.FlareBarrage_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Flare Barrage";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A barrage of flares seek out enemies dealing " + PlayerStats.instance.FlareBarrage_Damage().ToString() + " damage each. Cooldown: " +
                        CooldownManager.instance.FlareBarrage_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Flare Barrage";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Number of flares increases";
                }
                break;
            case "Sky_Piercer_UI":
                if (PlayerStats.instance.Sky_Piercer_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Sky Piercer";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Massive earthen spears crash down for " + PlayerStats.instance.Sky_Piercer_Damage().ToString() + " damage, and after a delay explode again for "
            + (PlayerStats.instance.Sky_Piercer_Damage() / 3).ToString() + " Cooldown: " + CooldownManager.instance.Sky_Piercer_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Sky Piercer";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Sky Piercer size and chance of overlaping damage increases";
                }
                break;
            case "Seismic_Shockwave_UI":
                if (PlayerStats.instance.Seismic_Shockwave_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Seismic Shockwave";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Lob a dense chunk of earth which hits the earth and creates a shockwave dealing " + PlayerStats.instance.Seismic_Shockwave_Damage().ToString() + " damage. Cooldown: "
            + CooldownManager.instance.Seismic_Shockwave_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Seismic Shockwave";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Seismic Shockwave area effect and damage increases";
                }
                break;
            case "Vortex_UI":
                if (PlayerStats.instance.Vortex_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Vortex";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A swirling column of air that pulls in enemies and damages them for " + PlayerStats.instance.Vortex_Damage().ToString() + " damage. Cooldown: "
                        + CooldownManager.instance.Vortex_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Vortex";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Vortex area effect and damage increases";
                }
                break;
            case "Thunderstorm_UI":
                if (PlayerStats.instance.Storm_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Thunderstorm";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A storm rages over a large area with lightning strikes for " + PlayerStats.instance.Storm_Damage().ToString() + " damage per strike. Cooldown: " +
                        CooldownManager.instance.Storm_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Thunderstorm";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Thunderstorm duration, number of strikes and damage increases";
                }
                break;
            case "Spark_Step_UI":
                if (PlayerStats.instance.Lightning_Dash_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Spark Step";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Charge up to dash forward, knocking enemies out of your way and shocking them for " + PlayerStats.instance.LightningDash_Damage().ToString() + " damage. Overcharge" +
                        " for increase dash distance. Cooldown: "
                        + CooldownManager.instance.Lightning_Dash_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Spark Step";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Spark Step damage increases and charge time decreases";
                }
                break;
            case "Cluster_Bomb_UI":
                if (PlayerStats.instance.Seeker_Bomb_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Inferno Bomb";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A firey bomb seeks out enemies before exploding dealing " + PlayerStats.instance.SeekerBomb_Damage().ToString() + " damage and releasing smaller bombs. Cooldown: "
                        + CooldownManager.instance.Seeker_Bomb_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Inferno Bomb";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Number of smaller clusters increases";
                }
                break;
            case "Microburst_UI":
                if (PlayerStats.instance.Microburst_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Microburst";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Hold cast to guide a concentrated ball of air, pushing back and damaing enemies. Release cast to explode for " + PlayerStats.instance.Microburst_Damage().ToString() + " damage. Cooldown: "
                        + CooldownManager.instance.Microburst_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Microburst";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Microburst area of effect and damage increases";
                }
                break;
            case "Ball_Lightning_UI":
                if (PlayerStats.instance.Ball_Lightning_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Ball Lightning";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A magnetic ball of lightning flies forward, pulling in enemies and dealing " + PlayerStats.instance.Ball_Lightning_Damage().ToString() + " damage. Cooldown: "
                        + CooldownManager.instance.Ball_Lightning_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Ball Lightning";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Ball Lightning area of effect and damage increases";
                }
                break;
            case "Tornado_UI":
                if (PlayerStats.instance.Tornado_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Tornado";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A tornado rages dealing " + PlayerStats.instance.Tornado_Damage().ToString() + " damage and throws enemies into the air. Cooldown: "
                        + CooldownManager.instance.Tornado_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Tornado";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Tornado area of effect and damage increases";
                }
                break;
            case "Rock_Wall_UI":
                if (PlayerStats.instance.Rock_Wall_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Rock Wall";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A defensive wall of rock forms (moveable with mouse scroll) eventually exploding for " + PlayerStats.instance.Rock_Wall_Damage().ToString() + " damage. Cooldown: "
                        + CooldownManager.instance.Rock_Wall_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Rock Wall";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Rock Wall size and damage increases";
                }
                break;
            case "Rock_Hammer_UI":
                if (PlayerStats.instance.Rock_Hammer_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Rock Hammer";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Form a boulder overhead and smash it down in front of you for " + PlayerStats.instance.RockHammer_Damage().ToString() + " damage. Cooldown: "
                        + CooldownManager.instance.Rock_Hammer_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Rock Hammer";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Rock Hammer size and damage increases";
                }
                break;
            case "Earthen_Aegis_UI":
                if (PlayerStats.instance.Earthen_Aegis_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Earthen Aegis";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A protective hammer spirals around you hitting enemies for " + PlayerStats.instance.Earthen_Aegis_Damage().ToString() + " damage. Cooldown: "
                        + CooldownManager.instance.Earthen_Aegis_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Earthen Aegis";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Number of hammers increases";
                }
                break;
            case "Fireball_UI":
                if (PlayerStats.instance.Fireball_Spell_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Fireball";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A burning ball of fire strikes foes for " + PlayerStats.instance.Fireball_Damage().ToString() + " damage. Cooldown: "
                        + CooldownManager.instance.Fireball_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Fireball";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Fireball area of effect and damage increases";
                }
                break;
            case "Meteor_Shower_UI":
                if (PlayerStats.instance.Meteor_Shower_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Meteor Shower";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Meteors rain down from the sky exploding for " + PlayerStats.instance.Meteor_Shower_Damage().ToString() + " damage. Cooldown: "
                        + CooldownManager.instance.Meteor_Shower_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Meteor Shower";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Meteor Shower duration and damage increases";
                }
                break;
            case "Glacial_Spike_UI":
                if (PlayerStats.instance.Glacial_Spike_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Glacial Spikes";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Form icy spikes over nearby enemies before dropping, shattering for " + PlayerStats.instance.GlacialSpike_Damage().ToString() + " damage. Cooldown: "
                        + CooldownManager.instance.Glacial_Spike_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Glacial Spikes";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Glacial Spikes damage and number of spikes increases";
                }
                break;
            case "Ice_Mines_UI":
                if (PlayerStats.instance.Ice_Mines_Rank == 0 && !spell_on_bar) 
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Ice Mines";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Drop frozen mines that detonate near enemies dealing " + PlayerStats.instance.IceMines_Damage().ToString() + " damage. Cooldown: "
                        + CooldownManager.instance.Ice_Mines_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Ice Mines";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Ice Mine's damage and number of mines increases";
                }
                break;
            case "Whirlpool_UI":
                if (PlayerStats.instance.Whirlpool_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Whirlpool";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Form a massive whirlpool that draws in enemies before exploding for " + PlayerStats.instance.Whirlpool_Damage().ToString() + " damage. Cooldown: "
                        + CooldownManager.instance.Whirlpool_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Whirlpool";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Whirlpool size and damage increases";
                }
                break;
            case "Wave_Cannon_UI":
                if (PlayerStats.instance.Wave_Cannon_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Wave Cannon";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Hold cast to rapidly shoot a water cannon, hitting for " + PlayerStats.instance.Wave_Cannon_Damage().ToString() + " damage.";
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Wave Cannon";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Wave Cannon rate of fire increases";
                }
                break;
            case "Frost_Blades_UI":
                if (PlayerStats.instance.Icey_Slash_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Frost Blades";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Hold cast to unleash a barrage of slashes dealing " + PlayerStats.instance.IcySlash_Damage().ToString() + " damage and healing on hit. Cooldown: "
                        + CooldownManager.instance.Icey_Slash_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Frost Blades";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Frost Blades damage and healing";
                }
                break;
            case "Shattering_Ice_UI":
                if (PlayerStats.instance.Shattered_Ice_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Shattering Ice";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Frozen shard of ice shoot out a short range before exploding for " + PlayerStats.instance.Shattered_Ice_Damage().ToString() + " damage. Cooldown: "
                        + CooldownManager.instance.Shattered_Ice_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Shattering Ice";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Shattering Ice repeats for each rank";
                }
                break;
            case "Earth_Bend_UI":
                if (PlayerStats.instance.Earth_Bend_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Earth Bend";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A stone spike bursts from the ground, impaling enemies for " + PlayerStats.instance.Earth_Bend_Damage().ToString() + " damage. Cooldown: "
            + CooldownManager.instance.Earth_Bend_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Earth Bend";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Earth Bend damage and spike count increases";
                }
                break;
            case "Solar_Flare_UI":
                if (PlayerStats.instance.Solar_Flare_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Solar Flare";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "After a delay, an explosion occures dealing " + PlayerStats.instance.SolarFlare_Damage().ToString() + " damage. Cooldown: " +
                        CooldownManager.instance.Solar_Flare_Cooldown;
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Solar Flare";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Solar Flare area of effect and damage increases";
                }
                break;
            case "IceRay_UI":
                if (PlayerStats.instance.IceRay_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Ice Ray";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "A freezing ray of ice dealing " + PlayerStats.instance.IceRay_Damage().ToString() + " damage per .5 seconds";
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Ice Ray";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Ice Ray damage increases";
                }
                break;
            case "MoltenSmash_UI":
                if (PlayerStats.instance.Molten_Smash_Rank == 0 && !spell_on_bar)
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "New Spell: Molten Smash";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Hold to swing a molten mace, smashing down for " + PlayerStats.instance.MoltenSmash_Damage().ToString() + " damage and scorching the area. Heals on hit.";
                }
                else
                {
                    transform.GetChild(0).transform.GetComponent<Text>().text = "Upgrade: Molten Smash";
                    transform.GetChild(1).transform.GetComponent<Text>().text = "Molten smash area of effect and damage increases";
                }
                break;

        }
        #endregion


    }

    public void Select_Spell_Button()
    {
        int empty_slot_number = 100;
        GameObject[] get_hotbar = new GameObject[8];
        
        //Gets current hotbar
        for (int x = 0; x < 7; x++)
        {
            if (Basics.instance.Fire_Hotbar.transform.GetChild(x).transform.childCount > 1)
            {
                get_hotbar[x] = Basics.instance.Fire_Hotbar.transform.GetChild(x).transform.GetChild(1).transform.gameObject;
            }
            else get_hotbar[x] = Game_Logic.instance.Level_Up_Window;

            //************************************************************\\
            //Check for duplicate for rank upgrade. Add to for each new spell.
            #region Check for duplicate to upgrade spell and end method. Update for each new spell!
            if (Spell_Option_inst.name == get_hotbar[x].name)
            {
                switch (Spell_Option_inst.name)
                {
                    case "Meteor_UI":
                        if (PlayerStats.instance.Meteor_Rank < 2)
                        {
                            PlayerStats.instance.Meteor_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Chain_Lightning_UI":
                        if (PlayerStats.instance.Chain_Lightning_Rank < 2)
                        {
                            PlayerStats.instance.Chain_Lightning_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Solar_Sphere_UI":
                        if (PlayerStats.instance.Solar_Sphere_Rank < 2)
                        {
                            PlayerStats.instance.Solar_Sphere_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Blizzard_UI":
                        if (PlayerStats.instance.Blizzard_Rank < 2)
                        {
                            PlayerStats.instance.Blizzard_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Ice_Claymore_UI":
                        if (PlayerStats.instance.Ice_Claymore_Rank < 2)
                        {
                            PlayerStats.instance.Ice_Claymore_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Frozen_Orb_UI":
                        if (PlayerStats.instance.Frozen_Orb_Rank < 2)
                        {
                            PlayerStats.instance.Frozen_Orb_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Scorching_Ray_UI":
                        if (PlayerStats.instance.Scorching_Ray_Spell_Rank < 2)
                        {
                            PlayerStats.instance.Scorching_Ray_Spell_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Earthquake_UI":
                        if (PlayerStats.instance.Earthquake_Rank < 2)
                        {
                            PlayerStats.instance.Earthquake_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Magma_Orb_UI":
                        if (PlayerStats.instance.Magma_Spell_Rank < 2)
                        {
                            PlayerStats.instance.Magma_Spell_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Static_UI":
                        if (PlayerStats.instance.Static_Rank < 2)
                        {
                            PlayerStats.instance.Static_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Rock_Barrage_UI":
                        if (PlayerStats.instance.Stone_Sling_Rank < 2)
                        {
                            PlayerStats.instance.Stone_Sling_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Skybeam_UI":
                        if (PlayerStats.instance.Sunbeam_Rank < 2)
                        {
                            PlayerStats.instance.Sunbeam_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Flare_Barrage_UI":
                        if (PlayerStats.instance.FlareBarrage_Rank < 2)
                        {
                            PlayerStats.instance.FlareBarrage_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Plasma_Ray_UI":
                        if (PlayerStats.instance.Plasma_Ray_Rank < 2)
                        {
                            PlayerStats.instance.Plasma_Ray_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Loose_Boulder_UI":
                        if (PlayerStats.instance.Loose_Boulder_Rank < 2)
                        {
                            PlayerStats.instance.Loose_Boulder_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Terra_Dive_UI":
                        if (PlayerStats.instance.Terra_Dive_Rank < 2)
                        {
                            PlayerStats.instance.Terra_Dive_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Sky_Piercer_UI":
                        if (PlayerStats.instance.Sky_Piercer_Rank < 2)
                        {
                            PlayerStats.instance.Sky_Piercer_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Seismic_Shockwave_UI":
                        if (PlayerStats.instance.Seismic_Shockwave_Rank < 2)
                        {
                            PlayerStats.instance.Seismic_Shockwave_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Vortex_UI":
                        if (PlayerStats.instance.Vortex_Rank < 2)
                        {
                            PlayerStats.instance.Vortex_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Thunderstorm_UI":
                        if (PlayerStats.instance.Storm_Rank < 2)
                        {
                            PlayerStats.instance.Storm_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Spark_Step_UI":
                        if (PlayerStats.instance.Lightning_Dash_Rank < 2)
                        {
                            PlayerStats.instance.Lightning_Dash_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Cluster_Bomb_UI":
                        if (PlayerStats.instance.Seeker_Bomb_Rank < 2)
                        {
                            PlayerStats.instance.Seeker_Bomb_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Microburst_UI":
                        if (PlayerStats.instance.Microburst_Rank < 2)
                        {
                            PlayerStats.instance.Microburst_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Ball_Lightning_UI":
                        if (PlayerStats.instance.Ball_Lightning_Rank < 2)
                        {
                            PlayerStats.instance.Ball_Lightning_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Tornado_UI":
                        if (PlayerStats.instance.Tornado_Rank < 2)
                        {
                            PlayerStats.instance.Tornado_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Rock_Wall_UI":
                        if (PlayerStats.instance.Rock_Wall_Rank < 2)
                        {
                            PlayerStats.instance.Rock_Wall_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Rock_Hammer_UI":
                        if (PlayerStats.instance.Rock_Hammer_Rank < 2)
                        {
                            PlayerStats.instance.Rock_Hammer_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Earthen_Aegis_UI":
                        if (PlayerStats.instance.Earthen_Aegis_Rank < 2)
                        {
                            PlayerStats.instance.Earthen_Aegis_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Fireball_UI":
                        if (PlayerStats.instance.Fireball_Spell_Rank < 2)
                        {
                            PlayerStats.instance.Fireball_Spell_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Meteor_Shower_UI":
                        if (PlayerStats.instance.Meteor_Shower_Rank < 2)
                        {
                            PlayerStats.instance.Meteor_Shower_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Glacial_Spike_UI":
                        if (PlayerStats.instance.Glacial_Spike_Rank < 2)
                        {
                            PlayerStats.instance.Glacial_Spike_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Ice_Mines_UI":
                        if (PlayerStats.instance.Ice_Mines_Rank < 2)
                        {
                            PlayerStats.instance.Ice_Mines_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Whirlpool_UI":
                        if (PlayerStats.instance.Whirlpool_Rank < 2)
                        {
                            PlayerStats.instance.Whirlpool_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Wave_Cannon_UI":
                        if (PlayerStats.instance.Wave_Cannon_Rank < 2)
                        {
                            PlayerStats.instance.Wave_Cannon_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Frost_Blades_UI":
                        if (PlayerStats.instance.Icey_Slash_Rank < 2)
                        {
                            PlayerStats.instance.Icey_Slash_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Shattering_Ice_UI":
                        if (PlayerStats.instance.Shattered_Ice_Rank < 2)
                        {
                            PlayerStats.instance.Shattered_Ice_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Earth_Bend_UI":
                        if (PlayerStats.instance.Earth_Bend_Rank < 2)
                        {
                            PlayerStats.instance.Earth_Bend_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "Solar_Flare_UI":
                        if (PlayerStats.instance.Solar_Flare_Rank < 2)
                        {
                            PlayerStats.instance.Solar_Flare_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "IceRay_UI":
                        if (PlayerStats.instance.IceRay_Rank < 2)
                        {
                            PlayerStats.instance.IceRay_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                    case "MoltenSmash_UI":
                        if (PlayerStats.instance.Molten_Smash_Rank < 2)
                        {
                            PlayerStats.instance.Molten_Smash_Rank++;
                            Close_and_Exit();
                            return;
                        }
                        else
                        {
                            Spell_At_Max_Popup.SetActive(true);
                            return;
                        }
                }
                
            }
            #endregion

        }


        //search for empty hotbar
        for (int x = 6; x>=0; x--)
        {
            if (Basics.instance.Fire_Hotbar.transform.GetChild(x).transform.childCount == 1)
            {
                empty_slot_number = x;
            }
        }



        //if no empty display popup and do nothing or place spell at fist open spot
        if (empty_slot_number == 100)
        {
            NoEmpty_Popup.SetActive(true);
        } else
        {
            GameObject New_Spell = Instantiate(Game_Logic.instance.Random_Spells[Get_Spot], Basics.instance.Fire_Hotbar.transform.GetChild(empty_slot_number).transform);
            New_Spell.name = Game_Logic.instance.Random_Spells[Get_Spot].name;
            New_Spell.transform.position = Basics.instance.Fire_Hotbar.transform.GetChild(empty_slot_number).transform.position;
            New_Spell.transform.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            Close_and_Exit();
        }
    }

    public void Close_and_Exit()
    {
        //Basics.instance.Action_UI.SetActive(true);
        Basics.instance.Action_UI.GetComponent<Animator>().Play("RollUpHotbar");
        Cursor.lockState = CursorLockMode.Locked;
        Basics.instance.Main_Camera.GetComponent<CameraController>().enabled = true;
        Time.timeScale = 1;
        Game_Logic.instance.Level_Up_Window.SetActive(false);
    }


}
