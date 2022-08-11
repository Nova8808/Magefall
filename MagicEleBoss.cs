using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagicEleBoss : MonoBehaviour, IdamageableStatus<string, int>
{
    private Rigidbody rb;

    private float distance;
    public float attack_range;
    public float move_speed;
    public float current_health;
    public float max_health;
    private float timescale_multi;

    private float fill_amount;

    public GameObject HP_Fill_bar;
    public GameObject HP_background_bar;
    public GameObject floating_damage;
    private GameObject float_damage_inst;
    public GameObject red_ele_ragdoll;

    public GameObject attack_spawner;
    private GameObject chargeup_instance;
    public GameObject chargeup_prefab;
    public GameObject Lob1_Prefab;
    public GameObject Barrage_prefab;
    public GameObject GiantLob_Prefab;


    private float attack_timer;
    private float attack_delay = 5f;

    private Animator animator;
    //public bool isAttacking;
    private bool Has_Attacked;
    private bool stop_moving;
    private bool side_move;
    private int random_direction;

    private bool spawning;
    private int walk_threshold = 6;
    private int run_threshold = 15;

    RaycastHit ground_ray;
    float ground_distance;
    private bool ground_check = true;
    Vector3 Targetposition;

    private SkinnedMeshRenderer mesh;
    private Material[] base_material;
    GameObject exp_holder;
    public GameObject exp_prefab;
    public GameObject spawn_smoke_prefab;
    private bool dying;

    void Start()
    {
        spawning = true;
        dying = false;
        StartCoroutine(Spawn());
        //exp_holder = GameObject.Find("Exp Holder");
        timescale_multi = 1.0f;
        rb = transform.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        current_health = max_health;
        mesh = transform.GetChild(1).transform.GetComponent<SkinnedMeshRenderer>();
        base_material = new Material[1] { mesh.material };
        //base_material[0] = mesh.materials[0];

    }


    void FixedUpdate()
    {
        Targetposition = new Vector3(Basics.instance.Player.transform.position.x, transform.position.y, Basics.instance.Player.transform.position.z);
        distance = Vector3.Distance(Targetposition, transform.position);


        if (Physics.Raycast(transform.position, Vector3.down, out ground_ray, 200, 3))
        {
            if (ground_ray.transform.tag == "Terrain")
            {
                ground_distance = Vector3.Distance(transform.position, ground_ray.point);
            }
        }
        if (ground_distance > 2)
        {
            transform.Translate(Vector3.down * 5 * Time.deltaTime);
        }

        //Get in range
        if (distance >= attack_range)
        {
            if (!stop_moving && !spawning && !dying)
            {
                transform.LookAt(Targetposition);
                transform.Translate(Vector3.forward * move_speed * Time.deltaTime * timescale_multi);

            }

        }

        if (Has_Attacked && !stop_moving && timescale_multi != 0 && !dying)
        {
            switch (random_direction)
            {
                case 1:
                    transform.Translate(Vector3.left * (move_speed / 2 * Time.deltaTime));
                    break;
                case 2:
                    transform.Translate(Vector3.right * (move_speed / 2 * Time.deltaTime));
                    break;
                case 3:
                    transform.Translate(Vector3.back * (move_speed / 2 * Time.deltaTime));
                    break;
                case 4:
                    transform.Translate(Vector3.forward * (move_speed / 2 * Time.deltaTime));
                    break;
            }
        }


        if (distance < attack_range && !dying)
        {
            animator.SetBool("Movement", false);
        }
        else
        {
            animator.SetBool("Movement", true);
        }
        //else if (distance > (attack_range + walk_threshold) && distance < (attack_range + run_threshold))
        //{
        //    animator.SetFloat("Movement", Mathf.SmoothStep(0, .5f, 1));
        //}
        //else animator.SetFloat("Movement", Mathf.SmoothStep(0, 1, 1));

        //animator.SetFloat("Movement", Mathf.Abs(rb.velocity.magnitude));

        //Set animator based on speed, rb velocity?
        //animator.SetFloat("Speed", golem_speed);

        //Attack
        attack_timer += Time.deltaTime;

        if ((attack_range > distance) && (attack_timer > attack_delay) && !spawning && !dying)
        {
            if (!Has_Attacked)
            {
                StartCoroutine(Attack());
                // Destroy(chargeup_instance.gameObject, 2);
                //attack_timer = 0;
                random_direction = Random.Range(1, 5);
                Has_Attacked = true;
            }

            //isAttacking = true;
        }
        //TRANSLATE THIS TO c# its to check line of sight
        //var hit : RaycastHit;
        //var rayDirection = player.position - transform.position;
        //if (Physics.Raycast(transform.position, rayDirection, hit))
        //{
        //    if (hit.transform == player)
        //    {
        //        // enemy can see the player!
        //    }
        //    else
        //    {
        //        // there is something obstructing the view
        //    }
        //}



        //Death
        if (current_health <= 0.0f)
        {
            //StartCoroutine(Death());
            //PlayerStats.instance.Experience_Count++;

            //Vector3 exp_spawn = transform.position;
            //exp_spawn.y += 5;
            //GameObject exp_inst = Instantiate(exp_prefab, exp_spawn, Quaternion.identity);
            //exp_inst.transform.parent = exp_holder.transform;
            //GameObject ragdoll_inst = Instantiate(red_ele_ragdoll, transform.position, transform.rotation);
            animator.SetBool("Death", true);
            Basics.instance.GuardianBoss_Dead = true;
            dying = true;
            Destroy(gameObject, 8);
            //Destroy(ragdoll_inst, 5);
        }
        else
        {
            //Vector3 Targetposition = new Vector3(Basics.instance.Player.transform.position.x, transform.position.y, Basics.instance.Player.transform.position.z);
            //transform.LookAt(Targetposition);]
            if (!spawning)
            {
                transform.LookAt(Targetposition);
            }
        }

        //if (float_damage_inst != null)
        //{
        //    //float_damage_inst.transform.LookAt(Basics.instance.Main_Camera.transform);
        //    float_damage_inst.transform.rotation = Quaternion.LookRotation(float_damage_inst.transform.position - Basics.instance.Main_Camera.transform.position);
        //}

        //if (chargeup_instance != null)
        //{
        //    Destroy(chargeup_instance.gameObject, 5);
        //}

    }


    public void Damage(float Spell_Damage)
    {
        //StartCoroutine(Allow_Physics());

        float damage_total;
        damage_total = Spell_Damage;
        current_health -= Spell_Damage;

        float_damage_inst = Instantiate(Basics.instance.Floating_Damage_Holder, transform);
        float_damage_inst.transform.position = new Vector3(float_damage_inst.transform.position.x, float_damage_inst.transform.position.y - 4, float_damage_inst.transform.position.z);
        //float_damage_inst.transform.localScale = new Vector3(2, 2, 2);
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
    

    IEnumerator Pause_Movement()
    {
        stop_moving = true;
        yield return new WaitForSeconds(2);
        stop_moving = false;
    }

    //IEnumerator Death()
    //{
    //    GameObject ragdoll_inst = Instantiate(red_ele_ragdoll, transform);
    //    Destroy(gameObject);

    //    //animator.SetBool("Death", true);
    //    yield return new WaitForSeconds(4);
    //    //Debug.Log("Shit golem down");


    //    Destroy(gameObject);
    //    //Destroy(hp_bar_inst);
    //}

    IEnumerator Attack()
    {
        int attack_select = Random.Range(0, 9);
        switch (attack_select)
        {
            case int n when n < 8:
                {
                    if (timescale_multi != 0)
                    {
                        //Standard Bullet attack
                        //animator.Play("SpellReady");
                        stop_moving = true;
                        animator.SetBool("Lob", true);

                        chargeup_instance = Instantiate(chargeup_prefab, attack_spawner.transform);
                        yield return new WaitForSeconds(1.6f);
                        //animator.Play("Attack01");
                        GameObject bullet_instance = Instantiate(Lob1_Prefab, attack_spawner.transform.position, Quaternion.identity);
                        Destroy(bullet_instance, 6);
                        yield return new WaitForSeconds(1);
                        animator.SetBool("Lob", false);
                        stop_moving = false;
                        Destroy(chargeup_instance, 1);
                        attack_timer = 0;
                    }
                    else yield return null;
                }
                break;
            case 8:
                //Channel attack, add enum cooldown w bool like spell
                if (timescale_multi != 0)
                {
                    stop_moving = true;
                    animator.SetBool("Channel", true);
                    chargeup_instance = Instantiate(chargeup_prefab, attack_spawner.transform);

                    yield return new WaitForSeconds(2);
                    GameObject missile_instance = Instantiate(Barrage_prefab, attack_spawner.transform.position, attack_spawner.transform.rotation);
                    Destroy(missile_instance, 12);
                    yield return new WaitForSeconds(2);
                    GameObject missile_instance2 = Instantiate(Barrage_prefab, attack_spawner.transform.position, attack_spawner.transform.rotation);
                    Destroy(missile_instance2, 12);
                    yield return new WaitForSeconds(2);
                    GameObject missile_instance3 = Instantiate(Barrage_prefab, attack_spawner.transform.position, attack_spawner.transform.rotation);
                    Destroy(missile_instance3, 12);
                    animator.SetBool("Channel", false);
                    Destroy(chargeup_instance, 1);
                    stop_moving = false;

                    attack_timer = 0;
                }
                else yield return null;
                break;
                //CAN have some random numbers to a movement instead of attack like a roar
                //case 4: //ADD giant overhead lob w custom animation
                //    //Field aoe attack
                //    stop_moving = true;
                //    animator.SetBool("Attacking", true);
                //    chargeup_instance = Instantiate(chargeup_prefab, attack_spawner.transform.position, attack_spawner.transform.rotation);
                //    chargeup_instance.transform.SetParent(transform);
                //    //chargeup_instace.transform.SetParent()
                //    yield return new WaitForSeconds(1.5f);

                //    GameObject storm_instance = Instantiate(storm_prefab, Basics.instance.Player.transform.position, attack_spawner.transform.rotation);
                //    Destroy(storm_instance, 8);
                //    animator.SetBool("Attacking", false);
                //    stop_moving = false;

                //    attack_timer = 0;
                //    break;
        }

        Has_Attacked = false;
    }

    IEnumerator Spawn()
    {
        GameObject spawnsmoke_inst = Instantiate(spawn_smoke_prefab, transform);
        transform.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(8);
        transform.GetComponent<BoxCollider>().enabled = true;
        Destroy(spawnsmoke_inst);
        spawning = false;
        rb.isKinematic = false;
    }

    //IEnumerator Allow_Physics()
    //{
    //    rb.drag = 1;
    //    ground_check = false;
    //    yield return new WaitForSeconds(4);
    //    rb.drag = 10;
    //    ground_check = true;
    //}

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
        duration = duration / 4;
        yield return new WaitForSeconds(duration);
        mesh.materials = base_material;
        timescale_multi = 1;
        animator.speed = 1;
    }

    public void Status(string Status_Effect, int duration)
    {
        StartCoroutine(Set_Status(Status_Effect, duration));
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.transform.tag == "Player") 
    //    {
    //        IDamageable<float> damageable = collision.transform.GetComponent<IDamageable<float>>();
    //        if (damageable != null)
    //        {
    //            damageable.Damage(1);
    //        }
    //    }
    //}
}