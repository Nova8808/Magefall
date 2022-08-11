using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
//using UnityEngine.InputSystem.DualShock;
using UnityEngine.UI;

public class CooldownManager : MonoBehaviour
{
    #region Dash
    [HideInInspector] public bool Dash_Offcooldown = true;
    public float Dash_Cooldown;

    public IEnumerator Dash_Countdown()
    {
        Dash_Offcooldown = false;
        yield return new WaitForSeconds(Dash_Cooldown);
        Dash_Offcooldown = true;
    }

    public void Dash_Timer()
    {
        StartCoroutine(Dash_Countdown());
    }
    #endregion

    #region Fire Variables
    [HideInInspector] public bool Fireball_Offcooldown = true;
    public int Fireball_Cooldown;

    [HideInInspector] public bool Magma_Offcooldown = true;
    public int Magma_Cooldown;

    [HideInInspector] public bool Scorching_Ray_Offcooldown = true;
    public int Scorching_Ray_Cooldown;

    [HideInInspector] public bool Homing_Flares_Offcooldown = true;
    public int Homing_Flares_Cooldown;

    [HideInInspector] public bool Dragons_Breath_Offcooldown = true;
    public int Dragons_Breath_Cooldown;

    [HideInInspector] public bool Solar_Flare_Offcooldown = true;
    public int Solar_Flare_Cooldown;

    [HideInInspector] public bool Meteor_Shower_Offcooldown = true;
    public int Meteor_Shower_Cooldown;

    [HideInInspector] public bool Flare_Beam_Burst_Offcooldown = true;
    public int Flare_Beam_Burst_Cooldown;

    [HideInInspector] public bool Meteor_Offcooldown = true;
    public int Meteor_Cooldown = 3;

    [HideInInspector] public bool Seeker_Bomb_Offcooldown = true;
    public int Seeker_Bomb_Cooldown;

    [HideInInspector] public bool FlareBarrage_Offcooldown = true;
    public int FlareBarrage_Cooldown;

    [HideInInspector] public bool Sunbeam_Offcooldown = true;
    public int Sunbeam_Cooldown;

    [HideInInspector] public bool Solar_Sphere_Offcooldown = true;
    public int Solar_Sphere_Cooldown;
    #endregion

    #region Frost Variables

    [HideInInspector] public bool Ice_Claymore_Offcooldown = true;
    public int Ice_Claymore_Cooldown;

    [HideInInspector] public bool Wave_Cannon_Offcooldown = true;
    public int Wave_Cannon_Cooldown;

    [HideInInspector] public bool Ice_Lances_Offcooldown = true;
    public int Ice_Lances_Cooldown;

    [HideInInspector] public bool IceRay_Offcooldown = true;
    public int IceRay_Cooldown;

    [HideInInspector] public bool Icey_Slash_Offcooldown = true;
    public int Icey_Slash_Cooldown;

    [HideInInspector] public bool Frozen_Orb_Offcooldown = true;
    public int Frozen_Orb_Cooldown;

    [HideInInspector] public bool Ice_Spear_Offcooldown = true;
    public int Ice_Spear_Cooldown;

    [HideInInspector] public bool Whirlpool_Offcooldown = true;
    public int Whirlpool_Cooldown;

    [HideInInspector] public bool Glacial_Spike_Offcooldown = true;
    public int Glacial_Spike_Cooldown;

    [HideInInspector] public bool Blizzard_Offcooldown = true;
    public int Blizzard_Cooldown;

    [HideInInspector] public bool Ice_Mines_Offcooldown = true;
    public int Ice_Mines_Cooldown;

    [HideInInspector] public bool Shattered_Ice_Offcooldown = true;
    public int Shattered_Ice_Cooldown;

    #endregion

    #region Air Variables
    [HideInInspector] public bool Explosive_Charge_Offcooldown = true;
    public int Explosive_Charge_Cooldown;

    [HideInInspector] public bool Shock_Nova_Offcooldown = true;
    public int Shock_Nova_Cooldown;

    [HideInInspector] public bool Wind_Assault_Offcooldown = true;
    public int Wind_Assault_Cooldown;

    [HideInInspector] public bool Lightning_Dash_Offcooldown = true;
    public int Lightning_Dash_Cooldown;

    [HideInInspector] public bool Ball_Lightning_Offcooldown = true;
    public int Ball_Lightning_Cooldown;

    [HideInInspector] public bool Tornado_Offcooldown = true;
    public int Tornado_Cooldown;

    [HideInInspector] public bool Plasma_Ray_Offcooldown = true;
    public int Plasma_Ray_Cooldown;

    [HideInInspector] public bool Vortex_Offcooldown = true;
    public int Vortex_Cooldown;

    [HideInInspector] public bool Chain_Lightning_Offcooldown = true;
    public int Chain_Lightning_Cooldown;

    [HideInInspector] public bool Volatile_Charge_Offcooldown = true;
    public int Volatile_Charge_Cooldown;

    [HideInInspector] public bool Storm_Offcooldown = true;
    public int Storm_Cooldown;

    [HideInInspector] public bool Microburst_Offcooldown = true;
    public int Microburst_Cooldown;

    [HideInInspector] public bool Static_Offcooldown = true;
    public int Static_Cooldown;

    #endregion

    #region Earth Variables
    [HideInInspector] public bool Earth_Bend_Offcooldown = true;
    public int Earth_Bend_Cooldown;

    [HideInInspector] public bool Stone_Sling_Offcooldown = true;
    public int Stone_Sling_Cooldown;

    [HideInInspector] public bool Loose_Boulder_Offcooldown = true;
    public int Loose_Boulder_Cooldown;

    [HideInInspector] public bool Rock_Hammer_Offcooldown = true;
    public int Rock_Hammer_Cooldown;

    [HideInInspector] public bool Stone_Spray_Offcooldown = true;
    public int Stone_Spray_Cooldown;

    [HideInInspector] public bool Earth_Spike_Offcooldown = true;
    public int Earth_Spike_Cooldown;

    [HideInInspector] public bool Sky_Piercer_Offcooldown = true;
    public int Sky_Piercer_Cooldown;

    [HideInInspector] public bool Earthen_Aegis_Offcooldown = true;
    public int Earthen_Aegis_Cooldown;

    [HideInInspector] public bool Seismic_Shockwave_Offcooldown = true;
    public int Seismic_Shockwave_Cooldown;

    [HideInInspector] public bool Dust_Devil_Offcooldown = true;
    public int Dust_Devil_Cooldown;

    [HideInInspector] public bool Terra_Dive_Offcooldown = true;
    public int Terra_Dive_Cooldown;

    [HideInInspector] public bool Rock_Wall_Offcooldown = true;
    public int Rock_Wall_Cooldown;
    #endregion

    #region SINGLETON PATTERN
    public static CooldownManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning: Multiple inventory instance");
        }
        instance = this;

        Magma_Offcooldown = true;

    }
    #endregion


    #region Fire Cooldown Timers
    public IEnumerator Fireball_Countdown()
    {
        Fireball_Offcooldown = false;
        yield return new WaitForSeconds(Fireball_Cooldown);
        Fireball_Offcooldown = true;
    }

    public void Fireball_Timer()
    {

        StartCoroutine(Fireball_Countdown());
    }
    public IEnumerator Scorching_Ray_Countdown()
    {
        Scorching_Ray_Offcooldown = false;
        yield return new WaitForSeconds(Scorching_Ray_Cooldown);
        Scorching_Ray_Offcooldown = true;
    }

    public void Scorching_Ray_Timer()
    {

        StartCoroutine(Scorching_Ray_Countdown());
    }
    public IEnumerator Magma_Orb_Countdown()
    {
        Magma_Offcooldown = false;
        yield return new WaitForSeconds(Magma_Cooldown);
        Magma_Offcooldown = true;
    }

    public void Magma_Timer()
    {

        StartCoroutine(Magma_Orb_Countdown());
    }

    public IEnumerator Homing_Flares_Countdown()
    {
        Homing_Flares_Offcooldown = false;
        yield return new WaitForSeconds(Homing_Flares_Cooldown);
        Homing_Flares_Offcooldown = true;
    }

    public void Homing_Flares_Timer()
    {

        StartCoroutine(Homing_Flares_Countdown());
    }

    public IEnumerator Dragons_Breath_Countdown()
    {
        Dragons_Breath_Offcooldown = false;
        yield return new WaitForSeconds(Dragons_Breath_Cooldown);
        Dragons_Breath_Offcooldown = true;
    }

    public void Dragons_Breath_Timer()
    {

        StartCoroutine(Dragons_Breath_Countdown());
    }

    public IEnumerator Solar_Flare_Countdown()
    {
        Solar_Flare_Offcooldown = false;
        yield return new WaitForSeconds(Solar_Flare_Cooldown);
        Solar_Flare_Offcooldown = true;
    }

    public void Solar_Flare_Timer()
    {

        StartCoroutine(Solar_Flare_Countdown());
    }

    public IEnumerator Meteor_Shower_Countdown()
    {
        Meteor_Shower_Offcooldown = false;
        yield return new WaitForSeconds(Meteor_Shower_Cooldown);
        Meteor_Shower_Offcooldown = true;
    }

    public void Meteor_Shower_Timer()
    {

        StartCoroutine(Meteor_Shower_Countdown());
    }

    public IEnumerator Flare_Beam_Burst_Countdown()
    {
        Flare_Beam_Burst_Offcooldown = false;
        yield return new WaitForSeconds(Flare_Beam_Burst_Cooldown);
        Flare_Beam_Burst_Offcooldown = true;
    }

    public void Flare_Beam_Burst_Timer()
    {

        StartCoroutine(Flare_Beam_Burst_Countdown());
    }

    public IEnumerator Meteor_Countdown()
    {
        Meteor_Offcooldown = false;
        yield return new WaitForSeconds(Meteor_Cooldown);
        Meteor_Offcooldown = true;
    }

    public void Meteor_Timer()
    {

        StartCoroutine(Meteor_Countdown());
    }

    public IEnumerator Seeker_Bomb_Countdown()
    {
        Seeker_Bomb_Offcooldown = false;
        yield return new WaitForSeconds(Seeker_Bomb_Cooldown);
        Seeker_Bomb_Offcooldown = true;
    }

    public void Seeker_Bomb_Timer()
    {

        StartCoroutine(Seeker_Bomb_Countdown());
    }

    public IEnumerator FlareBarrage_Countdown()
    {
        FlareBarrage_Offcooldown = false;
        yield return new WaitForSeconds(FlareBarrage_Cooldown);
        FlareBarrage_Offcooldown = true;
    }

    public void FlareBarrage_Timer()
    {

        StartCoroutine(FlareBarrage_Countdown());
    }

    public IEnumerator Sunbeam_Countdown()
    {
        Sunbeam_Offcooldown = false;
        yield return new WaitForSeconds(Sunbeam_Cooldown);
        Sunbeam_Offcooldown = true;
    }

    public void Sunbeam_Timer()
    {

        StartCoroutine(Sunbeam_Countdown());
    }

    public IEnumerator Solar_Sphere_Countdown()
    {
        Solar_Sphere_Offcooldown = false;
        yield return new WaitForSeconds(Solar_Sphere_Cooldown);
        Solar_Sphere_Offcooldown = true;
    }

    public void Solar_Sphere_Timer()
    {

        StartCoroutine(Solar_Sphere_Countdown());
    }
    #endregion

    #region Frost Cooldown Timers

    public IEnumerator Ice_Claymore_Countdown()
    {
        Ice_Claymore_Offcooldown = false;
        yield return new WaitForSeconds(Ice_Claymore_Cooldown);
        Ice_Claymore_Offcooldown = true;
    }

    public void Ice_Claymore_Timer()
    {

        StartCoroutine(Ice_Claymore_Countdown());
    }
    public IEnumerator Wave_Cannon_Countdown()
    {
        Wave_Cannon_Offcooldown = false;
        yield return new WaitForSeconds(Wave_Cannon_Cooldown);
        Wave_Cannon_Offcooldown = true;
    }

    public void Wave_Cannon_Timer()
    {
        StartCoroutine(Wave_Cannon_Countdown());
    }

    public IEnumerator Ice_Lance_Countdown()
    {
        Ice_Lances_Offcooldown = false;
        yield return new WaitForSeconds(Ice_Lances_Cooldown);
        Ice_Lances_Offcooldown = true;
    }

    public void Ice_Lance_Timer()
    {
        StartCoroutine(Ice_Lance_Countdown());
    }

    public IEnumerator IceRay_Countdown()
    {
        IceRay_Offcooldown = false;
        yield return new WaitForSeconds(IceRay_Cooldown);
        IceRay_Offcooldown = true;
    }

    public void IceRay_Timer()
    {
        StartCoroutine(IceRay_Countdown());
    }

    public IEnumerator Icey_Slash_Countdown()
    {
        Icey_Slash_Offcooldown = false;
        yield return new WaitForSeconds(Icey_Slash_Cooldown);
        Icey_Slash_Offcooldown = true;
    }

    public void Icey_Slash_Timer()
    {
        StartCoroutine(Icey_Slash_Countdown());
    }

    public IEnumerator Frozen_Orb_Countdown()
    {
        Frozen_Orb_Offcooldown = false;
        yield return new WaitForSeconds(Frozen_Orb_Cooldown);
        Frozen_Orb_Offcooldown = true;
    }

    public void Frozen_Orb_Timer()
    {
        StartCoroutine(Frozen_Orb_Countdown());
    }

    public IEnumerator Ice_Spear_Countdown()
    {
        Ice_Spear_Offcooldown = false;
        yield return new WaitForSeconds(Ice_Spear_Cooldown);
        Ice_Spear_Offcooldown = true;
    }

    public void Ice_Spear_Timer()
    {
        StartCoroutine(Ice_Spear_Countdown());
    }

    public IEnumerator Whirlpool_Countdown()
    {
        Whirlpool_Offcooldown = false;
        yield return new WaitForSeconds(Whirlpool_Cooldown);
        Whirlpool_Offcooldown = true;
    }

    public void Whirlpool_Timer()
    {
        StartCoroutine(Whirlpool_Countdown());
    }

    public IEnumerator Glacial_Spike_Countdown()
    {
        Glacial_Spike_Offcooldown = false;
        yield return new WaitForSeconds(Glacial_Spike_Cooldown);
        Glacial_Spike_Offcooldown = true;
    }

    public void Glacial_Spike_Timer()
    {
        StartCoroutine(Glacial_Spike_Countdown());
    }

    public IEnumerator Blizzard_Countdown()
    {
        Blizzard_Offcooldown = false;
        yield return new WaitForSeconds(Blizzard_Cooldown);
        Blizzard_Offcooldown = true;
    }

    public void Blizzard_Timer()
    {
        StartCoroutine(Blizzard_Countdown());
    }

    public IEnumerator Ice_Mine_Countdown()
    {
        Ice_Mines_Offcooldown = false;
        yield return new WaitForSeconds(Ice_Mines_Cooldown);
        Ice_Mines_Offcooldown = true;
    }

    public void Ice_Mines_Timer()
    {
        StartCoroutine(Ice_Mine_Countdown());
    }

    public IEnumerator Shattered_Ice_Countdown()
    {
        Shattered_Ice_Offcooldown = false;
        yield return new WaitForSeconds(Shattered_Ice_Cooldown);
        Shattered_Ice_Offcooldown = true;
    }

    public void Shattered_Ice_Timer()
    {
        StartCoroutine(Shattered_Ice_Countdown());
    }
    #endregion

    #region Air Cooldown Timers
    public IEnumerator Static_Countdown()
    {
        Static_Offcooldown = false;
        yield return new WaitForSeconds(Static_Cooldown);
        Static_Offcooldown = true;
    }

    public void Static_Timer()
    {
        StartCoroutine(Static_Countdown());
    }
    public IEnumerator Explosive_Charge_Countdown()
    {
        Explosive_Charge_Offcooldown = false;
        yield return new WaitForSeconds(Explosive_Charge_Cooldown);
        Explosive_Charge_Offcooldown = true;
    }

    public void Explosive_Charge_Timer()
    {
        StartCoroutine(Explosive_Charge_Countdown());
    }

    public IEnumerator Shock_Nova_Countdown()
    {
        Shock_Nova_Offcooldown = false;
        yield return new WaitForSeconds(Shock_Nova_Cooldown);
        Shock_Nova_Offcooldown = true;
    }

    public void Shock_Nova_Timer()
    {
        StartCoroutine(Shock_Nova_Countdown());
    }

    public IEnumerator Wind_Assault_Countdown()
    {
        Wind_Assault_Offcooldown = false;
        yield return new WaitForSeconds(Wind_Assault_Cooldown);
        Wind_Assault_Offcooldown = true;
    }

    public void Wind_Assault_Timer()
    {
        StartCoroutine(Wind_Assault_Countdown());
    }

    public IEnumerator Lightning_Dash_Countdown()
    {
        Lightning_Dash_Offcooldown = false;
        yield return new WaitForSeconds(Lightning_Dash_Cooldown);
        Lightning_Dash_Offcooldown = true;
    }

    public void Lightning_Dash_Timer()
    {
        StartCoroutine(Lightning_Dash_Countdown());
    }

    public IEnumerator Ball_Lightning_Countdown()
    {
        Ball_Lightning_Offcooldown = false;
        yield return new WaitForSeconds(Ball_Lightning_Cooldown);
        Ball_Lightning_Offcooldown = true;
    }

    public void Ball_Lightning_Timer()
    {
        StartCoroutine(Ball_Lightning_Countdown());
    }
    public IEnumerator Tornado_Countdown()
    {
        Tornado_Offcooldown = false;
        yield return new WaitForSeconds(Tornado_Cooldown);
        Tornado_Offcooldown = true;
    }

    public void Tornado_Timer()
    {
        StartCoroutine(Tornado_Countdown());
    }

    public IEnumerator Plasma_Ray_Countdown()
    {
        Plasma_Ray_Offcooldown = false;
        yield return new WaitForSeconds(Plasma_Ray_Cooldown);
        Plasma_Ray_Offcooldown = true;
    }

    public void Plasma_Ray_Timer()
    {
        StartCoroutine(Plasma_Ray_Countdown());
    }

    public IEnumerator Vortex_Countdown()
    {
        Vortex_Offcooldown = false;
        yield return new WaitForSeconds(Vortex_Cooldown);
        Vortex_Offcooldown = true;
    }

    public void Vortex_Timer()
    {
        StartCoroutine(Vortex_Countdown());
    }

    public IEnumerator Chain_Lightning_Countdown()
    {
        Chain_Lightning_Offcooldown = false;
        yield return new WaitForSeconds(Chain_Lightning_Cooldown);
        Chain_Lightning_Offcooldown = true;
    }

    public void Chain_Lightning_Timer()
    {

        StartCoroutine(Chain_Lightning_Countdown());
    }

    public IEnumerator Volatile_Charge_Countdown()
    {
        Volatile_Charge_Offcooldown = false;
        yield return new WaitForSeconds(Volatile_Charge_Cooldown);
        Volatile_Charge_Offcooldown = true;
    }

    public void Volatile_Charge_Timer()
    {

        StartCoroutine(Volatile_Charge_Countdown());
    }

    public IEnumerator Storm_Countdown()
    {
        Storm_Offcooldown = false;
        yield return new WaitForSeconds(Storm_Cooldown);
        Storm_Offcooldown = true;
    }

    public void Storm_Timer()
    {

        StartCoroutine(Storm_Countdown());
    }

    public IEnumerator Microburst_Countdown()
    {
        Microburst_Offcooldown = false;
        yield return new WaitForSeconds(Microburst_Cooldown);
        Microburst_Offcooldown = true;
    }

    public void Microburst_Timer()
    {

        StartCoroutine(Microburst_Countdown());
    }
    #endregion

    #region Earth Cooldown Timers
    public IEnumerator Earth_Bend_Countdown()
    {
        Earth_Bend_Offcooldown = false;
        yield return new WaitForSeconds(Earth_Bend_Cooldown);
        Earth_Bend_Offcooldown = true;
    }

    public void Earth_Bend_Timer()
    {
        StartCoroutine(Earth_Bend_Countdown());
    }
    public IEnumerator Stone_Sling_Countdown()
    {
        Stone_Sling_Offcooldown = false;
        yield return new WaitForSeconds(Stone_Sling_Cooldown);
        Stone_Sling_Offcooldown = true;
    }

    public void Stone_Sling_Timer()
    {
        StartCoroutine(Stone_Sling_Countdown());
    }

    public IEnumerator Loose_Boulder_Countdown()
    {
        Loose_Boulder_Offcooldown = false;
        yield return new WaitForSeconds(Loose_Boulder_Cooldown);
        Loose_Boulder_Offcooldown = true;
    }

    public void Loose_Boulder_Timer()
    {
        StartCoroutine(Loose_Boulder_Countdown());
    }

    public IEnumerator Rock_Hammer_Countdown()
    {
        Rock_Hammer_Offcooldown = false;
        yield return new WaitForSeconds(Rock_Hammer_Cooldown);
        Rock_Hammer_Offcooldown = true;
    }

    public void Rock_Hammer_Timer()
    {
        StartCoroutine(Rock_Hammer_Countdown());
    }

    public IEnumerator Stone_Spray_Countdown()
    {
        Stone_Spray_Offcooldown = false;
        yield return new WaitForSeconds(Stone_Spray_Cooldown);
        Stone_Spray_Offcooldown = true;
    }

    public void Stone_Spray_Timer()
    {
        StartCoroutine(Stone_Spray_Countdown());
    }

    public IEnumerator Earth_Spike_Countdown()
    {
        Earth_Spike_Offcooldown = false;
        yield return new WaitForSeconds(Earth_Spike_Cooldown);
        Earth_Spike_Offcooldown = true;
    }

    public void Earth_Spike_Timer()
    {
        StartCoroutine(Earth_Spike_Countdown());
    }

    public IEnumerator Sky_Piercer_Countdown()
    {
        Sky_Piercer_Offcooldown = false;
        yield return new WaitForSeconds(Sky_Piercer_Cooldown);
        Sky_Piercer_Offcooldown = true;
    }

    public void Sky_Piercer_Timer()
    {
        StartCoroutine(Sky_Piercer_Countdown());
    }

    public IEnumerator Earthen_Aegis_Countdown()
    {
        Earthen_Aegis_Offcooldown = false;
        yield return new WaitForSeconds(Earthen_Aegis_Cooldown);
        Earthen_Aegis_Offcooldown = true;
    }

    public void Earthen_Aegis_Timer()
    {
        StartCoroutine(Earthen_Aegis_Countdown());
    }

    public IEnumerator Seismic_Shockwave_Countdown()
    {
        Seismic_Shockwave_Offcooldown = false;
        yield return new WaitForSeconds(Seismic_Shockwave_Cooldown);
        Seismic_Shockwave_Offcooldown = true;
    }

    public void Seismic_Shockwave_Timer()
    {
        StartCoroutine(Seismic_Shockwave_Countdown());
    }

    public IEnumerator Dust_Devil_Countdown()
    {
        Dust_Devil_Offcooldown = false;
        yield return new WaitForSeconds(Dust_Devil_Cooldown);
        Dust_Devil_Offcooldown = true;
    }

    public void Dust_Devil_Timer()
    {
        StartCoroutine(Dust_Devil_Countdown());
    }

    public IEnumerator Terra_Dive_Countdown()
    {
        Terra_Dive_Offcooldown = false;
        yield return new WaitForSeconds(Terra_Dive_Cooldown);
        Terra_Dive_Offcooldown = true;
    }

    public void Terra_Dive_Timer()
    {
        StartCoroutine(Terra_Dive_Countdown());
    }

    public IEnumerator Rock_Wall_Countdown()
    {
        Rock_Wall_Offcooldown = false;
        yield return new WaitForSeconds(Rock_Wall_Cooldown);
        Rock_Wall_Offcooldown = true;
    }

    public void Rock_Wall_Timer()
    {
        StartCoroutine(Rock_Wall_Countdown());
    }
    #endregion
}
