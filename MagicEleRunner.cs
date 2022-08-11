using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagicEleRunner : MonoBehaviour, IdamageableStatus<string, int>
{
    private Rigidbody rb;

    private float distance;
    public float attack_range;
    public float move_speed;
    public float current_health;
    public float max_health;
    private float timescale_multi;

    public int damage;
    private bool hit_check;
    public GameObject explode_prefab;

    private float fill_amount;

    public GameObject HP_Fill_bar;
    public GameObject HP_background_bar;
    public GameObject floating_damage;
    private GameObject float_damage_inst;
    public GameObject magic_ele_ragdoll;

    private AudioSource _as;

    private Animator animator;
    //public bool isAttacking;
    private bool Has_Attacked;
    private bool stop_moving;
    private bool side_move;
    private int random_direction;

    private int walk_threshold = 6;
    private int run_threshold = 15;

    private bool ground_check = true;

    private SkinnedMeshRenderer mesh;
    public Material[] base_material;
    GameObject exp_holder;
    public GameObject exp_prefab;

    void Start()
    {
        hit_check = true;
        stop_moving = false;
        _as = GetComponent<AudioSource>();
        exp_holder = GameObject.Find("Exp Holder");
        timescale_multi = 1.0f;
        rb = transform.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        current_health = max_health;
        mesh = transform.GetChild(1).transform.GetComponent<SkinnedMeshRenderer>();
        base_material = new Material[1] { mesh.material };

        if (Basics.instance.Main_Game_Timer < 600)
        {
            damage = (int)(damage * 1.5f);
        }
    }


    void FixedUpdate()
    {
        distance = Vector3.Distance(Basics.instance.Player.transform.position, transform.position);

        //Get in range
        if (distance >= attack_range)
        {
            Vector3 Targetposition = new Vector3(Basics.instance.Player.transform.position.x, transform.position.y, Basics.instance.Player.transform.position.z);
            transform.LookAt(Targetposition);

        } else
        {
            transform.LookAt(Basics.instance.Player.transform.position);
        }
        if (!stop_moving)
        {
            transform.Translate(Vector3.forward * move_speed * Time.deltaTime * timescale_multi);
        }

        //Death
        if (current_health <= 0.0f)
        {
            //StartCoroutine(Death());
            //PlayerStats.instance.Experience_Count++;
            Vector3 exp_spawn = transform.position;
            exp_spawn.y += 5;
            GameObject exp_inst = Instantiate(exp_prefab, exp_spawn, Quaternion.identity);
            exp_inst.transform.parent = exp_holder.transform;
            GameObject ragdoll_inst = Instantiate(magic_ele_ragdoll, transform.position, transform.rotation);
            //animator.SetBool("Death", true);
            Destroy(gameObject);
            Destroy(ragdoll_inst, 5);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !stop_moving)
        {
            stop_moving = true;
            StartCoroutine(Explode_Delay());
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "Player" && !stop_moving)
    //    {
    //        stop_moving = true;
    //        StartCoroutine(Explode_Delay());
    //    }
    //}

    IEnumerator Explode_Delay()
    {
        _as.Play();
        transform.GetChild(1).transform.GetComponent<Animator>().SetBool("Explode", true);
        animator.SetBool("Explode", true);
        animator.Play("ExplodePulse");
        yield return new WaitForSeconds(2);
        GameObject explode_inst = Instantiate(explode_prefab, transform.position, transform.rotation);
        Destroy(explode_inst, 2);
        if (hit_check)
        {
            Collider[] damaged_enemies = Physics.OverlapSphere(transform.position, 10);
            foreach (Collider col in damaged_enemies)
            {
                if (col.tag == "Player")
                {
                    IDamageable<float> damageable = col.GetComponent<IDamageable<float>>();
                    if (damageable != null)
                    {
                        damageable.Damage(damage);
                    }
                }
            }
            hit_check = false;

            Vector3 exp_spawn = transform.position;
            exp_spawn.y += 5;
            GameObject exp_inst = Instantiate(exp_prefab, exp_spawn, Quaternion.identity);
            exp_inst.transform.parent = exp_holder.transform;
            
        }
        Destroy(gameObject);
    }

    public void Damage(float Spell_Damage)
    {
        StartCoroutine(Allow_Physics());

        float damage_total;
        damage_total = Spell_Damage;
        current_health -= Spell_Damage;

        float_damage_inst = Instantiate(Basics.instance.Floating_Damage_Holder, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        float_damage_inst.transform.GetChild(0).GetComponent<TMP_Text>().text = damage_total.ToString();



        Destroy(float_damage_inst, 1);


        //Enemy health bar
        if (!this.HP_background_bar.activeSelf)
        {
            this.HP_background_bar.SetActive(true);
            this.HP_Fill_bar.SetActive(true);
        }

        fill_amount = (current_health / max_health);


        HP_Fill_bar.GetComponent<Image>().fillAmount = fill_amount;


    }


    //IEnumerator Attack()
    //{
    //    int attack_select = Random.Range(0, 10);
    //    switch (attack_select)
    //    {
    //        case int n when n < 9:
    //            {
    //                if (timescale_multi != 0)
    //                {
    //                    //Standard Bullet attack
    //                    //animator.Play("SpellReady");
    //                    stop_moving = true;
    //                    animator.SetBool("Attacking", true);

    //                    chargeup_instance = Instantiate(chargeup_prefab, attack_spawner.transform.position, attack_spawner.transform.rotation);
    //                    chargeup_instance.transform.SetParent(transform);
    //                    //chargeup_instace.transform.SetParent()
    //                    yield return new WaitForSeconds(1.5f);
    //                    //animator.Play("Attack01");
    //                    GameObject bullet_instance = Instantiate(bullet_prefab, attack_spawner.transform.position, attack_spawner.transform.rotation);

    //                    Destroy(bullet_instance, 2);
    //                    animator.SetBool("Attacking", false);
    //                    stop_moving = false;

    //                    attack_timer = 0;
    //                }
    //                else yield return null;
    //            }
    //            break;
    //        case 9:
    //            //Homing missile attack
    //            stop_moving = true;
    //            animator.SetBool("Attacking", true);
    //            chargeup_instance = Instantiate(chargeup_prefab, attack_spawner.transform.position, attack_spawner.transform.rotation);
    //            chargeup_instance.transform.SetParent(transform);
    //            //chargeup_instace.transform.SetParent()
    //            yield return new WaitForSeconds(1.5f);

    //            GameObject missile_instance = Instantiate(missile_prefab, attack_spawner.transform.position, attack_spawner.transform.rotation);

    //            Destroy(missile_instance, 6);
    //            animator.SetBool("Attacking", false);
    //            stop_moving = false;

    //            attack_timer = 0;
    //            break;
    //            //case 4:
    //            //    //Field aoe attack
    //            //    stop_moving = true;
    //            //    animator.SetBool("Attacking", true);
    //            //    chargeup_instance = Instantiate(chargeup_prefab, attack_spawner.transform.position, attack_spawner.transform.rotation);
    //            //    chargeup_instance.transform.SetParent(transform);
    //            //    //chargeup_instace.transform.SetParent()
    //            //    yield return new WaitForSeconds(1.5f);

    //            //    GameObject storm_instance = Instantiate(storm_prefab, Basics.instance.Player.transform.position, attack_spawner.transform.rotation);
    //            //    Destroy(storm_instance, 8);
    //            //    animator.SetBool("Attacking", false);
    //            //    stop_moving = false;

    //            //    attack_timer = 0;
    //            //    break;
    //    }

    //    Has_Attacked = false;
    //    //case int n when n == 5 || n == 6:
    //    //    //Random movement
    //    //    newpos = waypoints[Random.Range(0, 4)].position;
    //    //    combat_moving = true;
    //    //    yield return new WaitForSeconds(2);
    //    //    combat_moving = false;
    //    //    attack_timer = 0;
    //    //    break;
    //}



    IEnumerator Allow_Physics()
    {
        rb.drag = 1;
        ground_check = false;
        yield return new WaitForSeconds(4);
        rb.drag = 10;
        ground_check = true;
    }

    public IEnumerator Set_Status(string type, float duration)
    {
        switch (type)
        {
            case "frost":
                mesh.material = Basics.instance.Frost_Status_Mat;
                break;
            case "air":
                Material[] air_material = new Material[2] { base_material[0], Basics.instance.Air_Status_Mat };
                mesh.materials = air_material;
                break;
            case "earth":
                mesh.material = Basics.instance.Earth_Status_Mat;
                break;
        }
        timescale_multi = 0;
        animator.speed = 0;
        yield return new WaitForSeconds(duration);
        mesh.materials = base_material;
        timescale_multi = 1;
        animator.speed = 1;
    }

    public void Status(string Status_Effect, int duration)
    {
        StartCoroutine(Set_Status(Status_Effect, duration));
    }
}
