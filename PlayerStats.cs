using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour, IDamageable<float>
{

    public int Experience_Count;
    public int player_level;

    public float player_current_shield;
    public float player_max_shield;
    public Image Shield_Fill_Bar;
    public float Shield_Regen;

    public float Barrier_Total;
    public GameObject Barrier_Bar;
    private float Barrier_Max;

    public bool Ward_Active;
    public float Ward_Total;
    public float Ward_Current;
    public bool Ward_Waiting;
    private float Ward_Countdown;
    public float Ward_Regen_Rate;

    public GameObject Ward_Fill;
    public GameObject Ward_Background;
    public GameObject Ward_Effect;

    private AudioSource Hit_AudioSource;
    public AudioClip Normal_Hit_Sound;
    public AudioClip Ward_Hit_Sound;
    private float Ward_regen_rune_multi;

    public GameObject DeathPopup;
    private GameObject HitCameraEffect;
    public AudioClip DeathSound1;

    [HideInInspector] public float Fire_Damage_Multi;
    [HideInInspector] public float Frost_Damage_Multi;
    [HideInInspector] public float Air_Damage_Multi;
    [HideInInspector] public float Earth_Damage_Multi;
    [HideInInspector] public float Fire_Speed_Multi;
    [HideInInspector] public float Frost_Speed_Multi;
    [HideInInspector] public float Air_Speed_Multi;
    [HideInInspector] public float Earth_Speed_Multi;

    #region SINGLETON PATTERN
    public static PlayerStats instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning: Multiple player stats instance");
        }
        instance = this;
    }
    #endregion


    #region Fire Spell Progression Variables and Damage Method
    #region Fire Variables
    //public float Fire_School_Level;


    [HideInInspector] public float Fireball_Spell_Rank;
    private int Fireball_Base_Damage;

    [HideInInspector] public float Molten_Smash_Rank;

    [HideInInspector] public float Magma_Spell_Rank;
    private int Magma_Base_Damage;

    [HideInInspector] public float Scorching_Ray_Spell_Rank;
    private int Scorching_Ray_Base_Damage;

    [HideInInspector] public float Dragons_Breath_Rank;

    private int Dragons_Breath_BaseDmg;

    [HideInInspector] public float Solar_Flare_Rank;

    private int Solar_Flare_BaseDmg;

    [HideInInspector] public float Meteor_Shower_Rank;

    private int Meteor_Shower_BaseDmg;

    [HideInInspector] public float Meteor_Rank;

    private int Meteor_BaseDmg;

    [HideInInspector] public float Seeker_Bomb_Rank;

    private int Seeker_Bomb_BaseDmg;

    [HideInInspector] public float FlareBarrage_Rank;

    private int FlareBarrage_BaseDmg;

    [HideInInspector] public float Sunbeam_Rank;

    private int Sunbeam_BaseDmg;

    [HideInInspector] public float Solar_Sphere_Rank;

    private int Solar_Sphere_BaseDmg;
    #endregion
    //Base damage set based on rank. Also adds 20% of spell level. 
    public int Fireball_Damage()
    {
        switch (Fireball_Spell_Rank)
        {
            case 0:
                Fireball_Base_Damage = 70;
                break;
            case 1:
                Fireball_Base_Damage = 140;
                break;
            case 2:
                Fireball_Base_Damage = 210;
                break;
        }
        float damage = Fireball_Base_Damage;
        damage *= Fire_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int MoltenSmash_Damage()
    {
        float damagefloat = 100;
        switch (Molten_Smash_Rank)
        {
            case 0:
                damagefloat = 100;
                break;
            case 1:
                damagefloat = 150;
                break;
            case 2:
                damagefloat = 200;
                break;
        }
        damagefloat *= (Frozen_Armor_Multi() + (1 - Fire_Damage_Multi));
        int damage = (int)damagefloat;
        return damage;
    }

    public int Magma_Damage()
    {
        switch (Magma_Spell_Rank)
        {
            case 0:
                Magma_Base_Damage = 70;
                break;
            case 1:
                Magma_Base_Damage = 100;
                break;
            case 2:
                Magma_Base_Damage = 130;
                break;
        }
        float damage = Magma_Base_Damage;
        damage *= Fire_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int Scorching_Ray_Damage()
    {
        switch (Scorching_Ray_Spell_Rank)
        {
            case 0:
                Scorching_Ray_Base_Damage = 50;
                break;
            case 1:
                Scorching_Ray_Base_Damage = 75;
                break;
            case 2:
                Scorching_Ray_Base_Damage = 100;
                break;
        }
        float damage = Scorching_Ray_Base_Damage;
        damage *= Fire_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int DragonsBreath_Damage()
    {
        switch (Dragons_Breath_Rank)
        {
            case 0:
                Dragons_Breath_BaseDmg = 100;
                break;
            case 1:
                Dragons_Breath_BaseDmg = 200;
                break;
            case 2:
                Dragons_Breath_BaseDmg = 300;
                break;
            case 3:
                Dragons_Breath_BaseDmg = 400;
                break;
        }
        int damage = Dragons_Breath_BaseDmg;
        //ADD any modifiers here
        return damage;
    }

    public int SolarFlare_Damage()
    {
        switch (Solar_Flare_Rank)
        {
            case 0:
                Solar_Flare_BaseDmg = 100;
                break;
            case 1:
                Solar_Flare_BaseDmg = 200;
                break;
            case 2:
                Solar_Flare_BaseDmg = 300;
                break;
            case 3:
                Solar_Flare_BaseDmg = 400;
                break;
        }
        float damage = Solar_Flare_BaseDmg;
        damage *= Fire_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int Meteor_Shower_Damage()
    {
        switch (Meteor_Shower_Rank)
        {
            case 0:
                Meteor_Shower_BaseDmg = 60;
                break;
            case 1:
                Meteor_Shower_BaseDmg = 80;
                break;
            case 2:
                Meteor_Shower_BaseDmg = 100;
                break;
            case 3:
                Meteor_Shower_BaseDmg = 100;
                break;
        }
        float damage = Meteor_Shower_BaseDmg;
        damage *= Fire_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int Meteor_Damage()
    {
        switch (Meteor_Rank)
        {
            case 0:
                Meteor_BaseDmg = 100;
                break;
            case 1:
                Meteor_BaseDmg = 200;
                break;
            case 2:
                Meteor_BaseDmg = 300;
                break;
            case 3:
                Meteor_BaseDmg = 400;
                break;

        }

        float damage = Meteor_BaseDmg;
        damage *= Fire_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    public int SeekerBomb_Damage()
    {
        switch (Seeker_Bomb_Rank)
        {
            case 0:
                Seeker_Bomb_BaseDmg = 60;
                break;
            case 1:
                Seeker_Bomb_BaseDmg = 60;
                break;
            case 2:
                Seeker_Bomb_BaseDmg = 60;
                break;

        }

        float damage = Seeker_Bomb_BaseDmg;
        damage *= Fire_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    public int FlareBarrage_Damage()
    {
        switch (FlareBarrage_Rank)
        {
            case 0:
                FlareBarrage_BaseDmg = 75;
                break;
            case 1:
                FlareBarrage_BaseDmg = 75;
                break;
            case 2:
                FlareBarrage_BaseDmg = 75;
                break;
        }

        float damage = FlareBarrage_BaseDmg;
        damage *= Fire_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    public int Sunbeam_Damage()
    {
        switch (Sunbeam_Rank)
        {
            case 0:
                Sunbeam_BaseDmg = 100;
                break;
            case 1:
                Sunbeam_BaseDmg = 200;
                break;
            case 2:
                Sunbeam_BaseDmg = 300;
                break;
            case 3:
                Sunbeam_BaseDmg = 400;
                break;

        }

        float damage = Sunbeam_BaseDmg;
        damage *= Fire_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    public int SolarSphere_Damage()
    {
        switch (Solar_Sphere_Rank)
        {
            case 0:
                Solar_Sphere_BaseDmg = 100;
                break;
            case 1:
                Solar_Sphere_BaseDmg = 200;
                break;
            case 2:
                Solar_Sphere_BaseDmg = 300;
                break;
            case 3:
                Solar_Sphere_BaseDmg = 400;
                break;

        }

        float damage = Solar_Sphere_BaseDmg;
        damage *= Fire_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    #endregion

    #region Frost Spells Progression Variables and Damage Methods
    #region Frost Variables
    //public float Frost_School_Level;

    [HideInInspector] public float Ice_Claymore_Rank;
    private int Ice_Claymore_BaseDmg;

    [HideInInspector] public float Wave_Cannon_Rank;
    private int Wave_Cannon_BaseDmg;

    [HideInInspector] public float Ice_Lance_Rank;

    private int Ice_Lance_BaseDmg;

    [HideInInspector] public float IceRay_Rank;

    [HideInInspector] public float Icey_Slash_Rank;

    private int Icey_Slash_BaseDmg;

    [HideInInspector] public float Frozen_Orb_Rank;

    private int Frozen_Orb_BaseDmg;

    [HideInInspector] public float Ice_Spear_Rank;

    private int Ice_Spear_BaseDmg;

    [HideInInspector] public float Whirlpool_Rank;

    private int Whirlpool_Base;

    [HideInInspector] public float Glacial_Spike_Rank;

    private int Glacial_Spike_BaseDmg;

    [HideInInspector] public float Blizzard_Rank;

    private int Blizzard_BaseDmg;

    [HideInInspector] public float Ice_Mines_Rank;

    private int Ice_Mines_BaseDmg;

    [HideInInspector] public float Shattered_Ice_Rank;

    private int Shattered_Ice_BaseDmg;
    #endregion

    public int Ice_Claymore_Damage()
    {

        switch (Ice_Claymore_Rank)
        {
            case 0:
                Ice_Claymore_BaseDmg = 100;
                break;
            case 1:
                Ice_Claymore_BaseDmg = 150;
                break;
            case 2:
                Ice_Claymore_BaseDmg = 200;
                break;
            case 3:
                Ice_Claymore_BaseDmg = 180;
                break;
        }
        float damagefloat = Ice_Claymore_BaseDmg;
        damagefloat *= (Frozen_Armor_Multi() + (1-Frost_Damage_Multi));
        int damage = (int)damagefloat;
        return damage;
    }
    public int Wave_Cannon_Damage()
    {

        switch (Wave_Cannon_Rank)
        {
            case 0:
                Wave_Cannon_BaseDmg = 50;
                break;
            case 1:
                Wave_Cannon_BaseDmg = 50;
                break;
            case 2:
                Wave_Cannon_BaseDmg = 50;
                break;
            case 3:
                Wave_Cannon_BaseDmg = 60;
                break;
        }
        float damage = Wave_Cannon_BaseDmg;
        damage *= Frost_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int IceLance_Damage()
    {
        switch (Ice_Lance_Rank)
        {
            case 0:
                Ice_Lance_BaseDmg = 100;
                break;
            case 1:
                Ice_Lance_BaseDmg = 200;
                break;
            case 2:
                Ice_Lance_BaseDmg = 300;
                break;
            case 3:
                Ice_Lance_BaseDmg = 400;
                break;

        }

        int damage = Ice_Lance_BaseDmg;
        //ADD any modifiers here
        return damage;
    }

    public int IceRay_Damage()
    {
        float damage = 25;
        switch (IceRay_Rank)
        {
            case 0:
                damage = 25;
                break;
            case 1:
                damage = 50;
                break;
            case 2:
                damage = 75;
                break;
        }
        damage *= Frost_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int IcySlash_Damage()
    {
        switch (Icey_Slash_Rank)
        {
            case 0:
                Icey_Slash_BaseDmg = 50;
                break;
            case 1:
                Icey_Slash_BaseDmg = 100;
                break;
            case 2:
                Icey_Slash_BaseDmg = 150;
                break;
            case 3:
                Icey_Slash_BaseDmg = 90;
                break;

        }
        float damagefloat = Icey_Slash_BaseDmg;
        damagefloat *= (Frozen_Armor_Multi() + (1 - Frost_Damage_Multi));
        int damage = (int)damagefloat;
        return damage;
    }

    public int FrozenOrb_Damage()
    {
        switch (Frozen_Orb_Rank)
        {
            case 0:
                Frozen_Orb_BaseDmg = 25;
                break;
            case 1:
                Frozen_Orb_BaseDmg = 50;
                break;
            case 2:
                Frozen_Orb_BaseDmg = 75;
                break;
            case 3:
                Frozen_Orb_BaseDmg = 60;
                break;

        }

        float damage = Frozen_Orb_BaseDmg;
        damage *= Frost_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int IceSpear_Damage()
    {
        switch (Ice_Spear_Rank)
        {
            case 0:
                Ice_Spear_BaseDmg = 100;
                break;
            case 1:
                Ice_Spear_BaseDmg = 200;
                break;
            case 2:
                Ice_Spear_BaseDmg = 300;
                break;
            case 3:
                Ice_Spear_BaseDmg = 400;
                break;

        }

        float damage = Ice_Spear_BaseDmg;
        damage *= Frost_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int Whirlpool_Damage()
    {
        switch (Whirlpool_Rank)
        {
            case 0:
                Whirlpool_Base = 100;
                break;
            case 1:
                Whirlpool_Base = 200;
                break;
            case 2:
                Whirlpool_Base = 300;
                break;
            case 3:
                Whirlpool_Base = 400;
                break;

        }
        float damage = Whirlpool_Base;
        damage *= Frost_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int GlacialSpike_Damage()
    {
        switch (Glacial_Spike_Rank)
        {
            case 0:
                Glacial_Spike_BaseDmg = 70;
                break;
            case 1:
                Glacial_Spike_BaseDmg = 140;
                break;
            case 2:
                Glacial_Spike_BaseDmg = 210;
                break;
            case 3:
                Glacial_Spike_BaseDmg = 200;
                break;
        }
        float damage = Glacial_Spike_BaseDmg;
        damage *= Frost_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int Blizzard_Damage()
    {
        switch (Blizzard_Rank)
        {
            case 0:
                Blizzard_BaseDmg = 35;
                break;
            case 1:
                Blizzard_BaseDmg = 70;
                break;
            case 2:
                Blizzard_BaseDmg = 105;
                break;
            case 3:
                Blizzard_BaseDmg = 40;
                break;
        }
        float damage = Blizzard_BaseDmg;
        damage *= Frost_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int IceMines_Damage()
    {
        switch (Ice_Mines_Rank)
        {
            case 0:
                Ice_Mines_BaseDmg = 70;
                break;
            case 1:
                Ice_Mines_BaseDmg = 140;
                break;
            case 2:
                Ice_Mines_BaseDmg = 210;
                break;
            case 3:
                Ice_Mines_BaseDmg = 120;
                break;
        }
        float damage = Ice_Mines_BaseDmg;
        damage *= Frost_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int Shattered_Ice_Damage()
    {
        switch (Shattered_Ice_Rank)
        {
            case 0:
                Shattered_Ice_BaseDmg = 70;
                break;
            case 1:
                Shattered_Ice_BaseDmg = 70;
                break;
            case 2:
                Shattered_Ice_BaseDmg = 70;
                break;
        }
        float damage = Shattered_Ice_BaseDmg;
        damage *= Frost_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    #endregion

    #region Air Spells Progression Variables and Damage Methods
    #region Air Variables
    //public float Air_School_Level;

    [HideInInspector] public float Static_Rank;
    private int Static_BaseDmg;

    [HideInInspector] public float Explosive_Charge_Rank;
    private int Explosive_Charge_BaseDmg;

    [HideInInspector] public float Shock_Nova_Rank;
    private int Shock_Nova_BaseDmg;

    [HideInInspector] public float Wind_Assault_Rank;
    private int Wind_Assault_BaseDmg;

    [HideInInspector] public float Lightning_Dash_Rank;
    private int Lightning_Dash_BaseDmg;

    [HideInInspector] public float Ball_Lightning_Rank;
    private int Ball_Lightning_BaseDmg;

    [HideInInspector] public float Tornado_Rank;
    private int Tornado_BaseDmg;

    [HideInInspector] public float Plasma_Ray_Rank;
    private int Plasma_Ray_BaseDmg;

    [HideInInspector] public float Vortex_Rank;
    private int Vortex_BaseDmg;

    [HideInInspector] public float Chain_Lightning_Rank;
    private int Chain_Lightning_BaseDmg;

    [HideInInspector] public float Volatile_Charge_Rank;
    private int Volatile_Charge_BaseDmg;

    [HideInInspector] public float Storm_Rank;
    private int Storm_BaseDmg;

    [HideInInspector] public float Microburst_Rank;
    private int Microburst_BaseDmg;
    #endregion

    public int Static_Damage()
    {
        switch (Static_Rank)
        {
            case 0:
                Static_BaseDmg = 25;
                break;
            case 1:
                Static_BaseDmg = 50;
                break;
            case 2:
                Static_BaseDmg = 75;
                break;
            case 3:
                Static_BaseDmg = 60;
                break;
        }
        float damage = Static_BaseDmg;
        damage *= Air_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    public int Explosive_Charge_Damage()
    {
        switch (Explosive_Charge_Rank)
        {
            case 0:
                Explosive_Charge_BaseDmg = 100;
                break;
            case 1:
                Explosive_Charge_BaseDmg = 200;
                break;
            case 2:
                Explosive_Charge_BaseDmg = 300;
                break;
            case 3:
                Explosive_Charge_BaseDmg = 400;
                break;
        }
        int damage = Explosive_Charge_BaseDmg;
        //ADD any modifiers here
        return damage;
    }
    public int ShockNova_Damage()
    {
        switch (Shock_Nova_Rank)
        {
            case 0:
                Shock_Nova_BaseDmg = 100;
                break;
            case 1:
                Shock_Nova_BaseDmg = 200;
                break;
            case 2:
                Shock_Nova_BaseDmg = 300;
                break;
            case 3:
                Shock_Nova_BaseDmg = 400;
                break;
        }
        int damage = Shock_Nova_BaseDmg;
        //ADD any modifiers here
        return damage;
    }
    public int WindAssault_Damage()
    {
        switch (Wind_Assault_Rank)
        {
            case 0:
                Wind_Assault_BaseDmg = 100;
                break;
            case 1:
                Wind_Assault_BaseDmg = 200;
                break;
            case 2:
                Wind_Assault_BaseDmg = 300;
                break;
            case 3:
                Wind_Assault_BaseDmg = 400;
                break;
        }
        int damage = Wind_Assault_BaseDmg;
        //ADD any modifiers here
        return damage;
    }

    public int LightningDash_Damage()
    {
        switch (Lightning_Dash_Rank)
        {
            case 0:
                Lightning_Dash_BaseDmg = 70;
                break;
            case 1:
                Lightning_Dash_BaseDmg = 140;
                break;
            case 2:
                Lightning_Dash_BaseDmg = 210;
                break;
            case 3:
                Lightning_Dash_BaseDmg = 150;
                break;
        }
        float damagefloat = Lightning_Dash_BaseDmg;
        damagefloat *= (Frozen_Armor_Multi() + (1- Air_Damage_Multi));
        int damage = (int)damagefloat;
        return damage;
    }

    public int Ball_Lightning_Damage()
    {
        switch (Ball_Lightning_Rank)
        {
            case 0:
                Ball_Lightning_BaseDmg = 20;
                break;
            case 1:
                Ball_Lightning_BaseDmg = 40;
                break;
            case 2:
                Ball_Lightning_BaseDmg = 60;
                break;
            case 3:
                Ball_Lightning_BaseDmg = 30;
                break;
        }
        float damage = Ball_Lightning_BaseDmg;
        damage *= Air_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int Tornado_Damage()
    {
        switch (Tornado_Rank)
        {
            case 0:
                Tornado_BaseDmg = 70;
                break;
            case 1:
                Tornado_BaseDmg = 140;
                break;
            case 2:
                Tornado_BaseDmg = 210;
                break;
            case 3:
                Tornado_BaseDmg = 400;
                break;
        }
        float damage = Tornado_BaseDmg;
        damage *= Air_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    public int Plasma_Ray_Damage()
    {
        switch (Plasma_Ray_Rank)
        {
            case 0:
                Plasma_Ray_BaseDmg = 25;
                break;
            case 1:
                Plasma_Ray_BaseDmg = 30;
                break;
            case 2:
                Plasma_Ray_BaseDmg = 35;
                break;
        }
        float damage = Plasma_Ray_BaseDmg;
        damage *= Air_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int Vortex_Damage()
    {
        switch (Vortex_Rank)
        {
            case 0:
                Vortex_BaseDmg = 15;
                break;
            case 1:
                Vortex_BaseDmg = 30;
                break;
            case 2:
                Vortex_BaseDmg = 45;
                break;
            case 3:
                Vortex_BaseDmg = 45;
                break;
        }
        float damage = Vortex_BaseDmg;
        damage *= Air_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    public int ChainLightning_Damage()
    {
        switch (Chain_Lightning_Rank)
        {
            case 0:
                Chain_Lightning_BaseDmg = 60;
                break;
            case 1:
                Chain_Lightning_BaseDmg = 120;
                break;
            case 2:
                Chain_Lightning_BaseDmg = 180;
                break;


        }
        float damage = Chain_Lightning_BaseDmg;
        damage *= Air_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int VolatileCharge_Damage()
    {
        switch (Volatile_Charge_Rank)
        {
            case 0:
                Volatile_Charge_BaseDmg = 100;
                break;
            case 1:
                Volatile_Charge_BaseDmg = 200;
                break;
            case 2:
                Volatile_Charge_BaseDmg = 300;
                break;
            case 3:
                Volatile_Charge_BaseDmg = 400;
                break;
        }
        float damage = Volatile_Charge_BaseDmg;
        damage *= Air_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    public int Storm_Damage()
    {
        switch (Storm_Rank)
        {
            case 0:
                Storm_BaseDmg = 50;
                break;
            case 1:
                Storm_BaseDmg = 60;
                break;
            case 2:
                Storm_BaseDmg = 70;
                break;
        }
        float damage = Storm_BaseDmg;
        damage *= Air_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int Microburst_Damage()
    {
        switch (Microburst_Rank)
        {
            case 0:
                Microburst_BaseDmg = 35;
                break;
            case 1:
                Microburst_BaseDmg = 70;
                break;
            case 2:
                Microburst_BaseDmg = 105;
                break;
            case 3:
                Microburst_BaseDmg = 60;
                break;
        }
        float damage = Microburst_BaseDmg;
        damage *= Air_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    #endregion

    #region Earth Spell Progression Variables and Damage Method
    #region Earth Variables
    //public float Earth_School_Level;

    [HideInInspector] public float Stone_Sling_Rank;
    private int Stone_Sling_BaseDmg;

    [HideInInspector] public float Loose_Boulder_Rank;
    private int Loose_Boulder_BaseDmg;

    [HideInInspector] public float Rock_Hammer_Rank;
    private int Rock_Hammner_BaseDmg;

    [HideInInspector] public float Stone_Spray_Rank;
    private int Stone_Spray_BaseDmg;

    [HideInInspector] public float Earth_Spike_Rank;
    private int Earth_Spike_BaseDmg;

    [HideInInspector] public float Earthquake_Rank;

    [HideInInspector] public float Sky_Piercer_Rank;
    private int Sky_Piercer_Base;

    [HideInInspector] public float Earthen_Aegis_Rank;
    private int Earthen_Aegis_BaseDmg;

    [HideInInspector] public float Seismic_Shockwave_Rank;
    private int Seismic_Shockwave_BaseDmg;

    [HideInInspector] public float Dust_Devil_Rank;
    private int Dust_Devil_BaseDmg;

    [HideInInspector] public float Terra_Dive_Rank;
    private int Terra_Dive_BaseDmg;

    [HideInInspector] public float Rock_Wall_Rank;
    private int Rock_Wall_BaseDmg;

    [HideInInspector] public float Earth_Bend_Rank;
    private int Earth_Bend_BaseDmg;

    #endregion
    public int Earth_Bend_Damage() //Actually rock barrage
    {
        switch (Earth_Bend_Rank)
        {
            case 0:
                Earth_Bend_BaseDmg = 100;
                break;
            case 1:
                Earth_Bend_BaseDmg = 150;
                break;
            case 2:
                Earth_Bend_BaseDmg = 200;
                break;
        }
        float damagefloat = Earth_Bend_BaseDmg;
        damagefloat *= Earth_Damage_Multi;
        int total_damage = (int)damagefloat;
        return total_damage;
    }
    public int Rock_Wall_Damage()
    {
        switch (Rock_Wall_Rank)
        {
            case 0:
                Rock_Wall_BaseDmg = 100;
                break;
            case 1:
                Rock_Wall_BaseDmg = 150;
                break;
            case 2:
                Rock_Wall_BaseDmg = 200;
                break;
        }
        float damagefloat = Rock_Wall_BaseDmg;
        damagefloat *= Earth_Damage_Multi;
        int total_damage = (int)damagefloat;
        return total_damage;
    }
    public int Stone_Sling_Damage()
    {
        switch (Stone_Sling_Rank)
        {
            case 0:
                Stone_Sling_BaseDmg = 40;
                break;
            case 1:
                Stone_Sling_BaseDmg = 80;
                break;
            case 2:
                Stone_Sling_BaseDmg = 120;
                break;
            case 3:
                Stone_Sling_BaseDmg = 90;
                break;
        }
        float damagefloat = Stone_Sling_BaseDmg;
        damagefloat *= Earth_Damage_Multi;
        int total_damage = (int)damagefloat;
        return total_damage;
    }

    public int LooseBoulder_Damage()
    {
        switch (Loose_Boulder_Rank)
        {
            case 0:
                Loose_Boulder_BaseDmg = 100;
                break;
            case 1:
                Loose_Boulder_BaseDmg = 150;
                break;
            case 2:
                Loose_Boulder_BaseDmg = 200;
                break;
            case 3:
                Loose_Boulder_BaseDmg = 400;
                break;
        }
        float damagefloat = Loose_Boulder_BaseDmg;
        damagefloat *= Earth_Damage_Multi;
        int total_damage = (int)damagefloat;
        return total_damage;
    }
    public int RockHammer_Damage()
    {
        switch (Rock_Hammer_Rank)
        {
            case 0:
                Rock_Hammner_BaseDmg = 100;
                break;
            case 1:
                Rock_Hammner_BaseDmg = 150;
                break;
            case 2:
                Rock_Hammner_BaseDmg = 200;
                break;
            case 3:
                Rock_Hammner_BaseDmg = 400;
                break;
        }
        float damagefloat = Rock_Hammner_BaseDmg;
        damagefloat *= (Frozen_Armor_Multi() + (1-Earth_Damage_Multi));
        int damage = (int)damagefloat;
        return damage;
    }
    public int StoneSpray_Damage()
    {
        switch (Stone_Spray_Rank)
        {
            case 0:
                Stone_Spray_BaseDmg = 100;
                break;
            case 1:
                Stone_Spray_BaseDmg = 200;
                break;
            case 2:
                Stone_Spray_BaseDmg = 300;
                break;
            case 3:
                Stone_Spray_BaseDmg = 400;
                break;
        }
        int damage = Stone_Spray_BaseDmg;
        //ADD any modifiers here
        return damage;
    }
    public int EarthSpike_Damage() //actually earth bend
    {
        switch (Earth_Spike_Rank)
        {
            case 0:
                Earth_Spike_BaseDmg = 70;
                break;
            case 1:
                Earth_Spike_BaseDmg = 140;
                break;
            case 2:
                Earth_Spike_BaseDmg = 210;
                break;
            case 3:
                Earth_Spike_BaseDmg = 210;
                break;
        }
        float damage = Earth_Spike_BaseDmg;
        damage *= Earth_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    public int Earthquake_Damage() 
    {
        float damage = 50;
        switch (Earthquake_Rank)
        {
            case 0:
                damage = 50;
                break;
            case 1:
                damage = 100;
                break;
            case 2:
                damage = 150;
                break;
            case 3:
                damage = 200;
                break;
        }
        damage *= Earth_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }

    public int Sky_Piercer_Damage()
    {
        switch (Sky_Piercer_Rank)
        {
            case 0:
                Sky_Piercer_Base = 75;
                break;
            case 1:
                Sky_Piercer_Base = 105;
                break;
            case 2:
                Sky_Piercer_Base = 135;
                break;
        }
        float damage = Sky_Piercer_Base;
        damage *= Earth_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    public int Earthen_Aegis_Damage()
    {
        switch (Earthen_Aegis_Rank)
        {
            case 0:
                Earthen_Aegis_BaseDmg = 70;
                break;
            case 1:
                Earthen_Aegis_BaseDmg = 70;
                break;
            case 2:
                Earthen_Aegis_BaseDmg = 70;
                break;
        }
        float damage = Earthen_Aegis_BaseDmg;
        damage *= Earth_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    public int Seismic_Shockwave_Damage()
    {
        switch (Seismic_Shockwave_Rank)
        {
            case 0:
                Seismic_Shockwave_BaseDmg = 100;
                break;
            case 1:
                Seismic_Shockwave_BaseDmg = 150;
                break;
            case 2:
                Seismic_Shockwave_BaseDmg = 200;
                break;
        }
        float damage = Seismic_Shockwave_BaseDmg;
        damage *= Earth_Damage_Multi;
        int total_damage = (int)damage;
        return total_damage;
    }
    public int DustDevil_Damage()
    {
        switch (Dust_Devil_Rank)
        {
            case 0:
                Dust_Devil_BaseDmg = 10;
                break;
            case 1:
                Dust_Devil_BaseDmg = 20;
                break;
            case 2:
                Dust_Devil_BaseDmg = 30;
                break;
        }
        int damage = Dust_Devil_BaseDmg;
        //ADD any modifiers here
        return damage;
    }
    public int TerraDive_Damage()
    {
        switch (Terra_Dive_Rank)
        {
            case 0:
                Terra_Dive_BaseDmg = 100;
                break;
            case 1:
                Terra_Dive_BaseDmg = 150;
                break;
            case 2:
                Terra_Dive_BaseDmg = 200;
                break;
        }
        float damagefloat = Terra_Dive_BaseDmg;
        damagefloat *= (Frozen_Armor_Multi() + (1-Earth_Damage_Multi));
        int damage = (int)damagefloat;
        return damage;
    }

    #endregion

    #region Passives Variables, Activate Method And Damages
    #region Air
    [HideInInspector] public int Thunder_Aura_Rank;
    [HideInInspector] public bool Thunder_Aura_Active;
    public void Thunder_Aura_Activator()
    {
        Thunder_Aura_Rank++;
        Thunder_Aura_Active = true;
    }
    public int Thunder_Aura_Damage()
    {
        int damage = 40;
        switch (Thunder_Aura_Rank)
        {
            case 1:
                damage = 100;
                break;
            case 2:
                damage = 150; ;
                break;
            case 3:
                damage = 200; ;
                break;
        }
        return damage;
    }
    [HideInInspector] public int Tail_Wind_Rank;
    [HideInInspector] public bool Tail_Wind_Active;
    public void Tail_Wind_activator()
    {
        Tail_Wind_Rank++;
        Tail_Wind_Active = true;
    }

    [HideInInspector] public int Wind_Step_Rank;
    [HideInInspector] public bool Wind_Step_Active;
    public void Wind_Step_activator()
    {
        Wind_Step_Rank++;
        Wind_Step_Active = true;
        switch (Wind_Step_Rank)
        {
            case 1: CooldownManager.instance.Dash_Cooldown = 3;
                break;
            case 2:
                CooldownManager.instance.Dash_Cooldown = 2f;
                break;
            case 3: CooldownManager.instance.Dash_Cooldown = 1f;
                break;
        }
    }

    [HideInInspector] public int Aero_Momentum_Rank;
    [HideInInspector] public bool Aero_Momentum_Active;
    public void Aero_Momentum_activator()
    {
        Aero_Momentum_Rank++;
        Aero_Momentum_Active = true;
    }

    public int Aero_Momentum_Damage()
    {
        int damage = 40;
        switch (Aero_Momentum_Rank)
        {
            case 1:
                damage = 100;
                break;
            case 2:
                damage = 150; ;
                break;
            case 3:
                damage = 200;
                break;
        }
        //ADD any modifiers here
        return damage;
    }

    [HideInInspector] public int Pressure_Vacuum_Rank;
    [HideInInspector] public bool Pressure_Vacuum_Active;
    public void Pressure_Vacuum_activator()
    {
        Pressure_Vacuum_Rank++;
        Pressure_Vacuum_Active = true;
    }
    public int Pressure_Vacuum_Damage()
    {
        int damage = 40;
        switch (Pressure_Vacuum_Rank)
        {
            case 1:
                damage = 10;
                break;
            case 2:
                damage = 20;
                break;
            case 3:
                damage = 30;
                break;
        }
        //ADD any modifiers here
        return damage;
    }
    [HideInInspector] public int Arc_Rank;
    [HideInInspector] public bool Arc_Active;
    public void Arc_activator()
    {
        Arc_Rank++;
        Arc_Active = true;
    }
    public int Arc_Damage()
    {
        int damage = 40;
        switch (Arc_Rank)
        {
            case 1:
                damage = 50;
                break;
            case 2:
                damage = 100;
                break;
            case 3:
                damage = 150;
                break;
        }
        //ADD any modifiers here
        return damage;
    }

    [HideInInspector] public int Rolling_Charge_Rank;
    [HideInInspector] public bool Rolling_Charge_Active;
    public void Rolling_Charge_activator()
    {
        Rolling_Charge_Rank++;
        Rolling_Charge_Active = true;
    }
    public int Rolling_Charge_Damage()
    {
        int damage = 40;
        switch (Rolling_Charge_Rank)
        {
            case 1:
                damage = 100;
                break;
            case 2:
                damage = 150;
                break;
            case 3:
                damage = 200;
                break;
        }
        //ADD any modifiers here
        return damage;
    }

    [HideInInspector] public int Siphon_Ward_Rank;
    [HideInInspector] public bool Siphon_Ward_Active;
    public void Siphon_Ward_activator()
    {
        Siphon_Ward_Rank++;
        Siphon_Ward_Active = true;
    }

    [HideInInspector] public int Supercharge_Ward_Rank;
    [HideInInspector] public bool Supercharge_Ward_Active;
    private float Supercharge_Multi()
    {
        float value = 1;
        switch (Supercharge_Ward_Rank)
        {
            case 1: value = 1.5f;
                break;
            case 2: value = 2.0f;
                break;
            case 3: value = 2.5f;
                break;
        }
        return value;
    }
    public void Supercharge_Ward_activator()
    {
        Supercharge_Ward_Rank++;
        Supercharge_Ward_Active = true;
    }
    #endregion
    #region Fire
    [HideInInspector] public int Flare_Beam_Rank;
    [HideInInspector] public bool Flare_Beam_Active;
    public void Flare_Beam_Activator()
    {
        Flare_Beam_Rank++;
        Flare_Beam_Active = true;
    }
    public int FlareBeam_Damage()
    {
        int damage = 15;
        switch (Flare_Beam_Rank)
        {
            case 1:
                damage = 70;
        break;
            case 2:
                damage = 140;
        break;
            case 3:
                damage = 210;
        break;

        }
        //ADD any modifiers here
        return damage;
    }


[HideInInspector] public int Hot_Foot_Rank;
    [HideInInspector] public bool Hot_Foot_Active;
    public void Hot_Foot_Activator()
    {
        Hot_Foot_Rank++;
        Hot_Foot_Active = true;
    }
    public int Hot_Foot_Damage()
    {
        int damage = 15;
        switch (Hot_Foot_Rank)
        {
            case 1:
                damage = 10;
                break;
            case 2:
                damage = 15;
                break;
            case 3:
                damage = 20;
                break;

        }
        //ADD any modifiers here
        return damage;
    }

    [HideInInspector] public int Cauterize_Rank;
    [HideInInspector] public bool Cauterize_Active;
    public void Cauterize_Activator()
    {
        Cauterize_Rank++;
        Cauterize_Active = true;
    }
    public int Cauterize_Heal()
    {
        int heal = 10;
        switch (Cauterize_Rank)
        {
            case 1:
                heal = 20;
                break;
            case 2:
                heal = 40;
                break;
            case 3:
                heal = 60;
                break;
        }
        return heal;
    }
    [HideInInspector] public int Starfall_Rank;
    [HideInInspector] public bool Starfall_Active;
    public void Starfall_Activator()
    {
        Starfall_Rank++;
        Starfall_Active = true;
    }
    public int Starfall_Damage()
    {
        int damage = 20;
        switch (Starfall_Rank)
        {
            case 1:
                damage = 50;
                break;
            case 2:
                damage = 50;
                break;
            case 3:
                damage = 50;
                break;
        }
        //ADD any modifiers here
        return damage;
    }

    [HideInInspector] public int Fire_Sprite_Rank;
    [HideInInspector] public bool Fire_Sprite_Active;
    public void Fire_Sprite_Activator()
    {
        Fire_Sprite_Rank++;
        Fire_Sprite_Active = true;
    }
    public int Fire_Sprite_Damage()
    {
        int damage = 20;
        switch (Fire_Sprite_Rank)
        {
            case 1:
                damage = 40;
                break;
            case 2:
                damage = 40;
                break;
            case 3:
                damage = 40;
                break;
        }
        //ADD any modifiers here
        return damage;
    }

    [HideInInspector] public int Homing_Flares_Rank;
    [HideInInspector] public bool Homing_Flares_Active;
    public void Homing_Flares_Activator()
    {
        Homing_Flares_Rank++;
        Homing_Flares_Active = true;
    }
    public int Homing_Flares_Damage()
    {
        int damage = 20;
        switch (Homing_Flares_Rank)
        {
            case 1:
                damage = 40;
                break;
            case 2:
                damage = 40;
                break;
            case 3:
                damage = 40;
                break;

        }
        //ADD any modifiers here
        return damage;
    }

    [HideInInspector] public int Sun_Call_Rank;
    [HideInInspector] public bool Sun_Call_Active;
    public void Sun_Call_Activator()
    {
        Sun_Call_Rank++;
        Sun_Call_Active = true;
    }
    public int Sun_Call_Damage()
    {
        int damage = 20;
        switch (Sun_Call_Rank)
        {
            case 1:
                damage = 100;
                break;
            case 2:
                damage = 150;
                break;
            case 3:
                damage = 200;
                break;
        }
        //ADD any modifiers here
        return damage;
    }
    [HideInInspector] public int Warmth_Rank;
    [HideInInspector] public bool Warmth_Active;
    public void Warmth_Activator()
    {
        Warmth_Rank++;
        Warmth_Active = true;
    }

    [HideInInspector] public int Flame_Dash_Rank;
    [HideInInspector] public bool Flame_Dash_Active;
    public void Flame_Dash_Activator()
    {
        Flame_Dash_Rank++;
        Flame_Dash_Active = true;
    }
    public int Flame_Dash_Damage()
    {
        int damage = 20;
        switch (Flame_Dash_Rank)
        {
            case 1:
                damage = 15;
                break;
            case 2:
                damage = 30;
                break;
            case 3:
                damage = 45;
                break;
        }
        //ADD any modifiers here
        return damage;
    }
    #endregion
    #region Ice
    [HideInInspector] public int Icicles_Rank;
    [HideInInspector] public bool Icicles_Active;
    public void Icicles_Activator()
    {
        Icicles_Rank++;
        Icicles_Active = true;
    }
    public int Icicles_Damage()
    {
        int damage = 20;
        switch (Icicles_Rank)
        {
            case 1:
                damage = 80;
                break;
            case 2:
                damage = 160;
                break;
            case 3:
                damage = 240;
                break;
        }
        //ADD any modifiers here
        return damage;
    }
    [HideInInspector] public int Ice_Barrier_Rank;
    [HideInInspector] public bool Ice_Barrier_Active;
    public void Ice_Barrier_Activator()
    {
        Ice_Barrier_Rank++;
        Game_Logic.instance.ice_barrier_timer = 15;
        Ice_Barrier_Active = true;
    }
    [HideInInspector] public int Frozen_Armor_Rank;
    [HideInInspector] public bool Frozen_Armor_Active;
    public void Frozen_Armor_Activator()
    {
        Frozen_Armor_Rank++;
        Frozen_Armor_Active = true;
    }
    public float Frozen_Armor_Multi()
    {
        float multi = 1;
        switch (Frozen_Armor_Rank)
        {
            case 1:
                multi = 1.33f;
                break;
            case 2:
                multi = 1.66f;
                break;
            case 3:
                multi = 2f;
                break;
        }
        return multi;
    }
    [HideInInspector] public int Frost_Nova_Rank;
    [HideInInspector] public bool Frost_Nova_Active;
    public void Frost_Nova_Activator()
    {
        Frost_Nova_Rank++;
        Frost_Nova_Active = true;
    }
    public int Frost_Nova_Damage()
    {
        int damage = 20;
        switch (Frost_Nova_Rank)
        {
            case 1:
                damage = 70;
                break;
            case 2:
                damage = 140;
                break;
            case 3:
                damage = 210;
                break;
        }
        return damage;
    }
    [HideInInspector] public int Ice_Block_Rank;
    [HideInInspector] public bool Ice_Block_Active;
    [HideInInspector] public int Ice_Block_Charges;
    public void Ice_Block_Activator()
    {
        Ice_Block_Rank++;
        Ice_Block_Charges++;
        Ice_Block_Active = true;
    }
    [HideInInspector] public int Healing_Rain_Rank;
    [HideInInspector] public bool Healing_Rain_Active;
    public void Healing_Rain_Activator()
    {
        Healing_Rain_Rank++;
        Healing_Rain_Active = true;
    }
    public int Healing_Rain_Heal()
    {
        int heal = 4;
        switch (Healing_Rain_Rank)
        {
            case 1:
                heal = 8;
                break;
            case 2:
                heal = 12;
                break;
            case 3:
                heal = 16;
                break;
        }
        return heal;
    }
    [HideInInspector] public int Frozen_Ward_Rank;
    [HideInInspector] public bool Frozen_Ward_Active;
    public void Frozen_Ward_Activator()
    {
        Frozen_Ward_Rank++;
        Frozen_Ward_Active = true;
        Ward_Total *= 1.15f;
    }
    [HideInInspector] public int Icy_Impale_Rank;
    [HideInInspector] public bool Icy_Impale_Active;
    public void Icy_Impale_Activator()
    {
        Icy_Impale_Rank++;
        Icy_Impale_Active = true;
    }
    public int Icy_Impale_Damage()
    {
        int damage = 20;
        switch (Icy_Impale_Rank)
        {
            case 1:
                damage = 80;
                break;
            case 2:
                damage = 160;
                break;
            case 3:
                damage = 240;
                break;
        }
        return damage;
    }
    #endregion
    #region Earth
    [HideInInspector] public int Stone_Throw_Rank;
    [HideInInspector] public bool Stone_Throw_Active;
    public void Stone_Throw_Activator()
    {
        Stone_Throw_Rank++;
        Stone_Throw_Active = true;
    }
    public int Stone_Throw_Damage()
    {
        int damage = 20;
        switch (Stone_Throw_Rank)
        {
            case 1:
                damage = 60;
                break;
            case 2:
                damage = 70;
                break;
            case 3:
                damage = 80;
                break;
        }
        //ADD any modifiers here
        return damage;
    }

    [HideInInspector] public int Stone_Skin_Rank;
    [HideInInspector] public bool Stone_Skin_Active;
    public void Stone_Skin_Activator()
    {
        Stone_Skin_Rank++;
        Stone_Skin_Active = true;
        player_max_shield *= 1.1f;
        HealShield(player_max_shield * .1f);
        StartCoroutine(Heal_Text((int)(player_max_shield * .1f)));
    }
    [HideInInspector] public int Rejuvination_Rank;
    [HideInInspector] public bool Rejuvination_Active;
    public void Rejuvination_Activator()
    {
        Rejuvination_Rank++;
        Rejuvination_Active = true;
        Shield_Regen += .5f;
    }
    [HideInInspector] public int Spike_Armor_Rank;
    [HideInInspector] public bool Spike_Armor_Active;
    public void Spike_Armor_Activator()
    {
        Spike_Armor_Rank++;
        Spike_Armor_Active = true;
    }
    public int Spike_Armor_Damage()
    {
        int damage = 20;
        switch (Spike_Armor_Rank)
        {
            case 1:
                damage = 50;
                break;
            case 2:
                damage = 75;
                break;
            case 3:
                damage = 100;
                break;
        }
        //ADD any modifiers here
        return damage;
    }
    [HideInInspector] public int Dust_Cloud_Rank;
    [HideInInspector] public bool Dust_Cloud_Active;
    public void Dust_Cloud_Activator()
    {
        Dust_Cloud_Rank++;
        Dust_Cloud_Active = true;
    }
    public int Dust_Cloud_Damage()
    {
        int damage = 20;
        switch (Dust_Cloud_Rank)
        {
            case 1:
                damage = 20;
                break;
            case 2:
                damage = 30;
                break;
            case 3:
                damage = 40;
                break;
        }
        //ADD any modifiers here
        return damage;
    }
    [HideInInspector] public int Harden_Rank;
    [HideInInspector] public bool Harden__Active;
    public void Harden_Activator()
    {
        Harden_Rank++;
        Harden__Active = true;
    }
    [HideInInspector] public int Rock_Drill_Rank;
    [HideInInspector] public bool Rock_Drill_Active;
    public void Rock_Drill_Activator()
    {
        Rock_Drill_Rank++;
        Rock_Drill_Active = true;
    }
    public int Rock_Drill_Damage()
    {
        int damage = 20;
        switch (Rock_Drill_Rank)
        {
            case 1:
                damage = 70;
                break;
            case 2:
                damage = 140;
                break;
            case 3:
                damage = 210;
                break;
        }
        //ADD any modifiers here
        return damage;
    }
    [HideInInspector] public int Earth_Elemental_Rank;
    [HideInInspector] public bool Earth_Elemental_Active;
    private GameObject Earth_Elemental_Inst;
    public void Earth_Elemental_Activator()
    {
        Earth_Elemental_Rank++;
        Earth_Elemental_Active = true;
        if (Earth_Elemental_Inst == null)
        {
            Vector3 summon_pos = Basics.instance.Player.transform.position;
            summon_pos.z += 10;
            Earth_Elemental_Inst = Instantiate(Game_Logic.instance.earth_elemental_prefab, summon_pos, Quaternion.identity);
            Earth_Elemental_Inst.transform.localScale = new Vector3(.8f, .8f, .8f);
        }
        else if (Earth_Elemental_Rank == 2)
        {
            Earth_Elemental_Inst.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        } else if (Earth_Elemental_Rank == 3)
        {
            Earth_Elemental_Inst.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
        }     
    }
    public int Earth_Ele_Damage()
    {
        int damage = 20;
        switch (Earth_Elemental_Rank)
        {
            case 1:
                damage = 100;
                break;
            case 2:
                damage = 150;
                break;
            case 3:
                damage = 200;
                break;
        }
        //ADD any modifiers here
        return damage;
    }
    #endregion
    #endregion


    private void Start()
    {
        //starting shield
        AudioSource[] audio_get = Basics.instance.Player.GetComponents<AudioSource>();
        Hit_AudioSource = audio_get[2];
        HitCameraEffect = transform.GetChild(0).transform.GetChild(0).transform.gameObject;

        Fire_Damage_Multi = 1 + (PlayerPrefs.GetInt("Fire Damage") * .05f);
        Frost_Damage_Multi = 1 + (PlayerPrefs.GetInt("Frost Damage") * .05f);
        Air_Damage_Multi = 1 + (PlayerPrefs.GetInt("Air Damage") * .05f);
        Earth_Damage_Multi = 1 + (PlayerPrefs.GetInt("Earth Damage") * .05f);
        Fire_Speed_Multi = (PlayerPrefs.GetInt("Fire Speed") * .05f);
        Frost_Speed_Multi = (PlayerPrefs.GetInt("Frost Speed") * .05f);
        Air_Speed_Multi = (PlayerPrefs.GetInt("Air Speed") * .05f);
        Earth_Speed_Multi = (PlayerPrefs.GetInt("Earth Speed") * .05f);

        player_max_shield *= 1 + (PlayerPrefs.GetInt("Health Total") * .05f);
        Ward_Total *= 1 + (PlayerPrefs.GetInt("Ward Total") * .05f);

        player_current_shield = player_max_shield;
        Ward_Current = Ward_Total;
        Barrier_Total = 0;
        Barrier_Max = 1000;

        Shield_Regen *= 1 + (PlayerPrefs.GetInt("Health Regen") * .05f);
        Ward_regen_rune_multi = (float)PlayerPrefs.GetInt("Ward Regen") * .05f;

        //Debug passives - DELETE
    }

    private void Update()
    {

        //Regen
        if (player_current_shield < player_max_shield)
        {
            player_current_shield += Shield_Regen * Time.deltaTime;
            //if (shield_regen_interval > 2)
            //{
            //    player_current_shield += Shield_Regen;
            //    shield_regen_interval = 0;
            //}
        }



        Shield_Fill_Bar.fillAmount = player_current_shield / player_max_shield;
        Shield_Fill_Bar.transform.GetChild(0).GetComponent<TMP_Text>().text = ((int)player_current_shield).ToString();

        //Ward wait and regen
        if (Ward_Current < Ward_Total && !Ward_Waiting)
        {
            float ward_regen_multi = Supercharge_Multi() + Ward_regen_rune_multi;
            Ward_Current += Ward_Regen_Rate * Supercharge_Multi() * Time.deltaTime;
        }

        //Ward_Background.SetActive(Ward_Active);
        Ward_Fill.SetActive(Ward_Active);
        Ward_Effect.SetActive(Ward_Active);

        if (Ward_Fill.activeSelf)
        {
            Ward_Current -= 8 * Time.deltaTime;
            Ward_Fill.transform.GetComponent<Image>().fillAmount = Ward_Current / Ward_Total;
        }

        if (Ward_Waiting)
        {
            Ward_Countdown += Time.deltaTime;
            if (Ward_Countdown > 5)
            {
                Ward_Waiting = false;
            }
        }

        //DECAY BARRIERS
        #region Decay Barriers
        if (Barrier_Total > 0)
        {
            Barrier_Total -= Time.deltaTime *10;
            Barrier_Bar.SetActive(true);
            Barrier_Bar.transform.GetComponent<Image>().fillAmount = (Barrier_Total / Barrier_Max) *5;
        }
        else Barrier_Bar.SetActive(false);
        #endregion
    }


    public void HealShield(float heal_amount)
    {
        if ((player_current_shield + heal_amount) > player_max_shield)
        {
            player_current_shield = player_max_shield;
        }
        else
        player_current_shield += heal_amount;
    }


    public void Damage(float Spell_Damage)
    {
        float ward_remainder = 0;
        if (Ward_Active)
        {
            if ((Ward_Current - Spell_Damage) < 0)
            {
                ward_remainder = Ward_Current - Spell_Damage;
                Ward_Current = 0;
                Ward_Active = false;
                Ward_Waiting = true;
                Ward_Countdown = 0;
                Hit_AudioSource.PlayOneShot(Ward_Hit_Sound);

                if (Siphon_Ward_Active)
                {
                    switch (Siphon_Ward_Rank)
                    {
                        case 1:
                            HealShield(Ward_Current * .1f);
                            StartCoroutine(Heal_Text((int)(Ward_Current * .1f)));
                            break;
                        case 2:
                            HealShield(Ward_Current * .2f);
                            StartCoroutine(Heal_Text((int)(Ward_Current * .2f)));
                            break;
                        case 3:
                            HealShield(Ward_Current * .3f);
                            StartCoroutine(Heal_Text((int)(Ward_Current * .3f)));
                            break;
                    }
                }
            }
            else
                Ward_Current -= Spell_Damage;
            Hit_AudioSource.PlayOneShot(Ward_Hit_Sound);
            if (Siphon_Ward_Active)
            {
                switch (Siphon_Ward_Rank)
                {
                    case 1:
                        HealShield(Ward_Current * .1f);
                        StartCoroutine(Heal_Text((int)(Ward_Current * .1f)));
                        break;
                    case 2:
                        HealShield(Ward_Current * .2f);
                        StartCoroutine(Heal_Text((int)(Ward_Current * .2f)));
                        break;
                    case 3:
                        HealShield(Ward_Current * .3f);
                        StartCoroutine(Heal_Text((int)(Ward_Current * .3f)));
                        break;
                }
            }
        }
        else
        {
            //Barrier buffer
            if (Barrier_Total > 0)
            {
                if (Barrier_Total - Spell_Damage > 0)
                {
                    Barrier_Total -= Spell_Damage;
                    Hit_AudioSource.PlayOneShot(Ward_Hit_Sound);
                }
                else
                {
                    float barrier_remainder = Barrier_Total - Spell_Damage;
                    player_current_shield += barrier_remainder;
                    Barrier_Total = 0;
                    Hit_AudioSource.PlayOneShot(Ward_Hit_Sound);
                }
            }
            else
            {
                //Normal Damage
                player_current_shield -= Spell_Damage;
                StartCoroutine(Damage_Camera_Effect());
                Hit_AudioSource.PlayOneShot(Normal_Hit_Sound, .75f);
            }
        }

        if (ward_remainder != 0)
        {
            //add because remainder is negative
            player_current_shield += ward_remainder;
        }

        if (Cauterize_Active)
        {
            int caut_rand = Random.Range(0, 10);
            if (caut_rand == 1)
            {
                HealShield(Cauterize_Heal());
                StartCoroutine(Heal_Text(Cauterize_Heal()));
            }
        }

        if (player_current_shield <= 0)
        {
                if (Ice_Block_Charges > 0)
                {
                    HealShield((player_max_shield * .2f));
                StartCoroutine(Heal_Text((int)(player_max_shield * .2f)));
                    GameObject frost_nova = Instantiate(Game_Logic.instance.Frost_nova_prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Player.transform.rotation);
                    Destroy(frost_nova, 3);
                Ice_Block_Charges--;
                }
            else
            {
               StartCoroutine(PlayerDie());
            }
        }
    }

    IEnumerator PlayerDie()
    {
        Hit_AudioSource.PlayOneShot(DeathSound1);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Basics.instance.Main_Camera.transform.GetComponent<CameraController>().enabled = false;
        Basics.instance.EndGamePanel.SetActive(true);
        Basics.instance.Action_UI.GetComponent<Animator>().Play("EndGameFade");
        yield return new WaitForSecondsRealtime(3.5f);
        DeathPopup.SetActive(true);
        //Basics.instance.Action_UI.GetComponent<Animator>().Play("Died");
    }

    IEnumerator Damage_Camera_Effect()
    {
        HitCameraEffect.SetActive(true);
        yield return new WaitForSeconds(.25f);
        HitCameraEffect.SetActive(false);
    }

    public IEnumerator Heal_Text(int heal)
    {
        Shield_Fill_Bar.transform.GetChild(1).GetComponent<TMP_Text>().text = "+ " + heal;
        yield return new WaitForSeconds(2);
        Shield_Fill_Bar.transform.GetChild(1).GetComponent<TMP_Text>().text = "";
    }

    #region Save/Load
    //public void SavePlayer()
    //{
    //   // Save_Data.SavePlayer(this);
    //}

    //public void LoadPlayer()
    //{
    //    //player_data data = Save_Data.LoadPlayer();
    //    Save_Data.player_data data = Save_Data.LoadPlayer();
    //    Fireball_Spell_Level = data.Fire_skills[0];
    //    Fire_School_Level = data.Fire_skills[1];

        
    //    position.x = data.player_position[0];
    //    position.y = data.player_position[1];
    //    position.z = data.player_position[2];

    //    #region Inventory Load

    //    Inventory.instance.PlayerItems.Clear();

    //    for (int x = 0; x < Inventory.instance.inventoryUI.inv_slot_total; x++)
    //        {
    //        Inventory.instance.inventoryUI.UpdateSlot(x, null);
    //        }

    //    for (int x = 0; x < data.player_inventory_name_save.Length; x++)
    //    {
    //        //if (data.player_inventory_name_save[x] != null)
    //        //{
    //        //    Item load_item = new Item(data.player_inventory_name_save[x], data.player_inventory_quantity_save[x]);
    //        //    Inventory.instance.inventoryUI.UpdateSlot(x, load_item);
    //        //}
    //        //else Inventory.instance.inventoryUI.UpdateSlot(x, null);


    //        Inventory.instance.Add_Item(data.player_inventory_name_save[x], data.player_inventory_quantity_save[x]);
    //        //Debug.Log(data.player_inventory_name_save[x] + " " + data.player_inventory_quantity_save[x]);
    //    }
    //    #endregion

    //    #region Hotbar Load
    //    _firebar.SetActive(true);
    //        _firemenu.SetActive(true);
          
    //    for (int i = 0; i < 8; i++)
    //    {
    //        if (data.firehotbarSave[i] != null)
    //        {
    //            Icon_Load = Instantiate(GameObject.Find(data.firehotbarSave[i]), _firebar.gameObject.transform);
    //            //Icon_Load = Instantiate(FindObjectsOfTypeAll(data.firehotbarSave[i]), _firebar.gameObject.transform);
    //            Icon_Load.transform.SetParent(_firebar.transform.GetChild(i));
    //            Icon_Load.transform.position = Icon_Load.transform.parent.position;
    //         }
            
    //    }
    //    _firebar.SetActive(false);
    //    _firemenu.SetActive(false);
    //    _frostbar.SetActive(true);
    //    _frostmenu.SetActive(true);
    //    for (int i = 0; i < 8; i++)
    //    {
            
    //        if (data.frosthotbarSave[i] != null)
    //        {
    //            Icon_Load = Instantiate(GameObject.Find(data.frosthotbarSave[i]), _frostbar.gameObject.transform);
    //            Icon_Load.transform.SetParent(_frostbar.transform.GetChild(i));
    //            Icon_Load.transform.position = Icon_Load.transform.parent.position;
                
    //        }

    //    }
    //    _frostbar.SetActive(false);
    //    _frostmenu.SetActive(false);
    //    _airmenu.SetActive(true);
    //    _airbar.SetActive(true);
    //    for (int i = 0; i < 8; i++)
    //    {
            
    //        if (data.airhotbarSave[i] != null)
    //        {
    //            Icon_Load = Instantiate(GameObject.Find(data.airhotbarSave[i]), _airbar.gameObject.transform);
    //            Icon_Load.transform.SetParent(_airbar.transform.GetChild(i));
    //            Icon_Load.transform.position = Icon_Load.transform.parent.position;
    //        }

    //    }
    //    _airbar.SetActive(false);
    //    _airmenu.SetActive(false);
    //    _earthbar.SetActive(true);
    //    _earthmenu.SetActive(true);
    //    for (int i = 0; i < 8; i++)
    //    {
           
    //        if (data.earthhotbarSave[i] != null)
    //        {
    //            Icon_Load = Instantiate(GameObject.Find(data.earthhotbarSave[i]), _earthbar.gameObject.transform);
    //            Icon_Load.transform.SetParent(_earthbar.transform.GetChild(i));
    //            Icon_Load.transform.position = Icon_Load.transform.parent.position;
    //        }

    //    }
    //    _earthbar.SetActive(false);
    //    _earthmenu.SetActive(false);
    //    _firemenu.SetActive(true);
    //    _firebar.SetActive(true);
    //    _frostbar.SetActive(false);
    //    _airbar.SetActive(false);


    //    #endregion


    //    Player_GO.GetComponent<CharacterController>().enabled = false;
    //    Player_GO.transform.position = position;
    //    Player_GO.GetComponent<CharacterController>().enabled = true;
    //}

    #endregion
}
