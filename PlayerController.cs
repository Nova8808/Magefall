using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;


public class PlayerController : MonoBehaviour

{
    public float speed = 8f;
    public float jumpSpeed = .5F;
    public float gravity = -.1F;
    private Vector3 moveDirection = Vector3.zero;
    public float timer;
    //private float Lerp_Increase;
    //Rigidbody Player_RB;
    private CharacterController controller;
    private float vertical_velocity;
    private float x_velocity;
    private float z_velocity;
    //private Vector3 Standing_Direction;
    //public int flight_time = 8;
    public Camera main_camera;
    private float max_height;
    //private float teleport_cooldown = 2;
    //private float teleport_timer;
    public float dash_time;
    //public float dash_cooldown = 3f;
    public float dash_speed;
    //private Rigidbody rb;
    public GameObject Aero_Passive_Prefab;
    public GameObject Rock_Drill_prefab;
    public AudioClip dash_sound;
    

    private AudioSource Audio_Source_1;
    private AudioSource Audio_Source_2;
    public AudioSource Audio_Source_3;
    public AudioClip flying_wind;
    public AudioClip takeoff_sound;
    public AudioClip landing_sound;
    private bool wind_isplaying;
    private bool takeoff_soundplayed;
    private bool fast_flight_sound;
    public AudioClip[] footsteps;

    private float footstep_timer;

    bool play_audio_once = true;
    // private TerrainDetector footsteps;
    bool ward_open_once;
    bool ward_close_once;
    Animator ward_animator;

    RaycastHit ground_ray;
    float ground_distance;
    bool height_okay;


    private void Start()
    {
       // Player_RB = this.GetComponentInParent<Rigidbody>();
        timer = 0;
        controller = GetComponent<CharacterController>();
        // Standing_Direction = new Vector3(0, vertical_velocity, 0);
        AudioSource[] Audio_Sources = GetComponents<AudioSource>();
        Audio_Source_1 = Audio_Sources[0]; // Movement audio
        Audio_Source_2 = Audio_Sources[1]; // Cast loop audio
        Audio_Source_3 = Audio_Sources[2]; // hit sounds
        // footsteps = GetComponent<TerrainDetector>();
        wind_isplaying = false;
        ward_animator = transform.GetChild(2).transform.GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
        //rb.isKinematic = true;

        //   loot_window = GameObject.Find("Loot");
        //   loot_panel = loot_window.transform.GetChild(0).gameObject;
        //  inv_UI = Inventory.instance.inventoryUI;
        //detector.InitializeTerrain();
        Cursor.lockState = CursorLockMode.Locked;


    }

    void Update()
    {
        
        footstep_timer += Time.deltaTime;
        //  Debug.Log(detector.GetActiveTerrainTextureIdx());
        //Feed moveDirection with input.
        //if (Input.GetKey(Forward_Button))
        //{
        //    Z_axis = Mathf.Lerp(0, 1, .5f);
        //}
        //else if (Input.GetKey(Backwards_button))
        //{
        //    Z_axis = Mathf.Lerp(0, -1, .5f);
        //}
        //else Z_axis = Mathf.Lerp(controller.velocity.z, 0, .5f);
        //if (Input.GetKey(Right_Button))
        //{
        //    X_axis = Mathf.Lerp(0, 1, .5f);
        //}
        //else if (Input.GetKey(Left_Button))
        //{
        //    X_axis = Mathf.Lerp(0, -1, .5f);
        //}
        //else X_axis = 0;
        
        //moveDirection = new Vector3(X_axis, vertical_velocity, Z_axis);
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), vertical_velocity, Input.GetAxis("Vertical"));

        //moveDirection = new Vector3(x_velocity, vertical_velocity, z_velocity);


        moveDirection = transform.TransformDirection(moveDirection);

        //Multiply it by speed.
        if (PlayerStats.instance.Tail_Wind_Rank == 1)
        {
            moveDirection *= speed * 1.15f;
        }
        else if (PlayerStats.instance.Tail_Wind_Rank == 2)
        {
            moveDirection *= speed * 1.3f;
        }
        else if (PlayerStats.instance.Tail_Wind_Rank == 3)
        {
            moveDirection *= speed * 1.45f;
        } 
        else moveDirection *= speed;

        controller.Move(moveDirection * Time.deltaTime);

        //Hover
        if (Physics.Raycast(transform.position, Vector3.down, out ground_ray, 200, 3))
        {
            if (ground_ray.transform.tag == "Terrain")
            {
                ground_distance = Vector3.Distance(transform.position, ground_ray.point);
            }
        }
        if (ground_distance > 20)
        {
            height_okay = false;
        }
        else height_okay = true;
        //if (controller.isGrounded)
        //{
        //    max_height = Basics.instance.Player.transform.localPosition.y + 20;

        //}

        if (Input.GetButton("Jump"))
        {

            // Debug.Log("Jump");
            //Lerp_Increase += .25f * Time.deltaTime;
            //if (Basics.instance.Player.transform.localPosition.y < max_height)
            if (height_okay)
            {
                vertical_velocity = Mathf.SmoothStep(vertical_velocity, jumpSpeed * 2, 5 * Time.deltaTime);
            } else vertical_velocity = Mathf.SmoothStep(vertical_velocity, gravity, 5 * Time.deltaTime);

            speed = 12;
            //  vertical_velocity = jumpSpeed;
            //controller.Move(moveDirection * Time.deltaTime);
            //controller.Move(moveDirection * Mathf.Lerp(.01f, .1f, Lerp_Increase));
        }
        else if (Input.GetButton("Sink"))
        {
            //Lerp_Increase = 3 * Time.deltaTime;
            // vertical_velocity += Mathf.Lerp(gravity * Lerp_Increase, gravity / 4, gravity);
            // vertical_velocity += gravity * Lerp_Increase;
            if (controller.isGrounded == false)
            {
                vertical_velocity = Mathf.SmoothStep(vertical_velocity, gravity * 10, 5 * Time.deltaTime);
                //controller.Move(moveDirection * Time.deltaTime);
                // Debug.Log(gravity * Lerp_Increase);
                //footsteps.step_interval = .25f;
            }
            //else
            //{
            //  //  footsteps.step_interval = .25f;
            //    speed = 12;
            //}
        }
        else
        {
            vertical_velocity = Mathf.SmoothStep(vertical_velocity, gravity, 5 * Time.deltaTime);
        }

        //dash_timer -= Time.deltaTime;
        if (Input.GetButtonDown("Dash"))
        {
            //controller.Move(moveDirection * Time.deltaTime * 20);
            //if (dash_timer < 0)
            //{
            //    rb.isKinematic = false;
            //    rb.velocity = moveDirection * 20f;
            //    dash_timer = 1;
            //}
            if (CooldownManager.instance.Dash_Offcooldown)
            {
                Audio_Source_1.PlayOneShot(dash_sound);
                StartCoroutine(Dash());
                CooldownManager.instance.Dash_Timer();
            }
        }

        if (Input.GetMouseButton(1) && !PlayerStats.instance.Ward_Waiting)
        {
            PlayerStats.instance.Ward_Active = true;
        }
        else
        {
            PlayerStats.instance.Ward_Active = false;
        }

        //if (ward_close_once)
        //{
        //    StartCoroutine(Ward_Close());
        //    ward_close_once = false;
        //}

        //if (ward_open_once)
        //{
        //    StartCoroutine(Ward_Open());
        //    ward_open_once = false;
        //}

        #region CleanUp2
        //else controller.Move(moveDirection * Time.deltaTime);
        //else
        //{
        //    x_velocity = Input.GetAxis("Horizontal");
        //    z_velocity = Input.GetAxis("Vertical");
        //}




        //if (controller.velocity.magnitude > 0 && footsteps.in_water == false && controller.isGrounded == true)
        //{
        //    // Debug.Log("Moving not in air or water");
        //    //call terraindetector update and audio
        //    //if not colliding with water do footstep, otherwise play water
        //    footsteps.Play_Footsteps();
        //}
        //if (controller.velocity.magnitude == 0 && !footsteps.in_water)
        //{
        //    Audio_Source.Stop();
        //    footsteps.is_walking = false;
        //}


        //if (Input.GetButton("Sink"))
        //{
        //    Lerp_Increase += .05f * Time.deltaTime;
        //    vertical_velocity += Mathf.Lerp(gravity * Lerp_Increase, gravity /2 , gravity);
        //   // vertical_velocity += gravity * Lerp_Increase; 
        //    controller.Move(moveDirection * Time.deltaTime);
        //}

        //    }
        //Applying gravity to the controller
        #endregion
        //Char controller y is enver 0 so isgrounded doesnt work. Checking for above 0 velocity to check if obj is grounded

        if (controller.velocity.y > 1 || timer > .1) 
        {
            timer += Time.deltaTime;
            //   moveDirection.y -= vertical_velocity;
            //  controller.Move(moveDirection * Time.deltaTime);

            //moveDirection.y -= gravity / 10 * Time.deltaTime;
        }
        //if (footsteps.in_water == true)
        //{
        //    vertical_velocity += 1.8f * Time.deltaTime;
        //    timer = 0;
        //}
            // controller.enabled = false;
            // controller.Move(moveDirection * Time.deltaTime);
            // Player_RB.velocity = new Vector3(transform.forward.x * speed, Player_RB.velocity.y, transform.forward.z * speed);
            // Player_RB.velocity = new Vector3((transform.forward * Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime);
        if (timer > .5f)
        {
            if (!takeoff_soundplayed) 
            {
                Audio_Source_1.PlayOneShot(takeoff_sound, .8f);
                takeoff_soundplayed = true;
            }
               
        }
        if (timer > 1)
        {
            if (!wind_isplaying)
            {

                Audio_Source_1.clip = flying_wind;
                Audio_Source_1.Play();
                wind_isplaying = true;
            }
        }

        //Cast Sounds
        if (Basics.instance.Fire_Castfill.gameObject.activeSelf && play_audio_once)
        {
            Audio_Source_2.clip =Basics.instance.Cast_Audio_Loop_Fire;
            Audio_Source_2.Play();
            play_audio_once = false;
        }
        else if (Basics.instance.Frost_Castfill.gameObject.activeSelf && play_audio_once)
        {
            Audio_Source_2.clip =Basics.instance.Cast_Audio_Loop_Frost;
            Audio_Source_2.Play();
            play_audio_once = false;
        }
        else if (Basics.instance.Air_Castfill.gameObject.activeSelf && play_audio_once)
        {
            Audio_Source_2.clip =Basics.instance.Cast_Audio_Loop_Air;
            Audio_Source_2.Play();
            play_audio_once = false;
        }
        else if (Basics.instance.Earth_Castfill.gameObject.activeSelf && play_audio_once)
        {
            Audio_Source_2.clip =Basics.instance.Cast_Audio_Loop_Earth;
            Audio_Source_2.Play();
            play_audio_once = false;
        }
        else if (!Basics.instance.Fire_Castfill.gameObject.activeSelf && !Basics.instance.Frost_Castfill.gameObject.activeSelf && !Basics.instance.Air_Castfill.gameObject.activeSelf && !Basics.instance.Earth_Castfill.gameObject.activeSelf)
        {
            Audio_Source_2.Stop();
            play_audio_once = true;
        }


        if (controller.isGrounded == true)
        {

            //controller.Move(moveDirection * Time.deltaTime);
            timer = 0;
            if (wind_isplaying)
            {
                Audio_Source_1.Stop();
                Audio_Source_1.PlayOneShot(landing_sound, .6f);
                wind_isplaying = false;
                takeoff_soundplayed = false;
               // footsteps.is_walking = false;
               // footsteps.walk_timer = 0;
            }
            //velcity.z? or use controler velocity magnitude
            if (footstep_timer > .33f && controller.velocity.z != 0)
            {
                Audio_Source_1.PlayOneShot(footsteps[0]);
                footstep_timer = 0;
            }
            // wind_isplaying = false;
            //  Audio_Source.Stop();
            // Lerp_Increase = 0f;

            //controller.enabled = true;
        }



        }
    //IEnumerator Ward_Open()
    //{
    //    ward_animator.SetBool("ward_open", true);
    //    yield return new WaitForSeconds(.25f);
    //    PlayerStats.instance.Ward_Active = true;
    //    ward_animator.SetBool("ward_open", false);
    //}
    //IEnumerator Ward_Close()
    //{
    //    ward_animator.SetBool("ward_close", true);
    //    yield return new WaitForSeconds(.25f);
    //    PlayerStats.instance.Ward_Active = false;
    //    ward_animator.SetBool("ward_close", false);
    //}

    IEnumerator Dash()
    {
        //    //rb.isKinematic = false;
        //    // rb.velocity = moveDirection * 50f;
        //    //x_velocity = Mathf.SmoothStep(x_velocity, jumpSpeed * 5, 10 * Time.deltaTime);
        //    //z_velocity = Mathf.SmoothStep(z_velocity, jumpSpeed * 5, 10 * Time.deltaTime);

        //increase dash length by increasing dash_time
        float start_time = Time.time;
       // PlayerStats.instance.Aero_Momentum_Active = true;
        if (PlayerStats.instance.Harden__Active)
        {
            if (PlayerStats.instance.Harden_Rank == 1)
            {
                PlayerStats.instance.Barrier_Total = PlayerStats.instance.player_max_shield * .05f;
            }
            if (PlayerStats.instance.Harden_Rank == 2)
            {
                PlayerStats.instance.Barrier_Total = PlayerStats.instance.player_max_shield * .075f;
            }
            if (PlayerStats.instance.Harden_Rank == 3)
            {
                PlayerStats.instance.Barrier_Total = PlayerStats.instance.player_max_shield * .1f;
            }
        }

        if (PlayerStats.instance.Rock_Drill_Active)
        {
            GameObject Rock_drill_inst = Instantiate(Rock_Drill_prefab, Basics.instance.Player.transform);
            Destroy(Rock_drill_inst, .5f);
        }

        //Dash
        while (Time.time < start_time + dash_time)
        {
            controller.Move(moveDirection * dash_speed * Time.deltaTime);
            yield return null;
        }

        if (PlayerStats.instance.Rock_Drill_Active)
        {
            Rigidbody _rb;
            Collider[] ragdoll = Physics.OverlapSphere(Basics.instance.Player.transform.position, 10);
            foreach (Collider hits in ragdoll)
            {
                if (hits.tag == "Enemy" || hits.tag == "Ragdoll")
                {
                    _rb = hits.transform.gameObject.GetComponent<Rigidbody>();
                    //_rb.angularDrag = 1;
                    _rb.AddExplosionForce(Basics.instance.Low_Force, Basics.instance.Player.transform.position, 10);
                }
                if (hits.tag == "Enemy")
                {
                    IDamageable<float> damageable = hits.transform.GetComponent<IDamageable<float>>();
                    if (damageable != null)
                    {
                        damageable.Damage(PlayerStats.instance.Rock_Drill_Damage());
                    }
                }

            }
        }

        if (PlayerStats.instance.Flame_Dash_Active)
        {
            RaycastHit ground_ray;
            if (Physics.Raycast(Basics.instance.Player.transform.position, Vector3.down, out ground_ray, 100, 3))
            {
                if (ground_ray.collider.tag == "Terrain")
                {
                }
            }

            GameObject flame_dash_inst = Instantiate(Game_Logic.instance.Hot_foot_prefab, ground_ray.point, Quaternion.identity);
            Destroy(flame_dash_inst, 8);
        }
        if (PlayerStats.instance.Aero_Momentum_Active)
        {
            yield return new WaitForSeconds(.25f);
            GameObject aero_inst = Instantiate(Aero_Passive_Prefab, Basics.instance.Spell_Spawn.transform.position, Basics.instance.Spell_Spawn.transform.rotation);
        }
        //    //rb.isKinematic = true;   
        //}
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    Basics.instance.Player.transform.position += new Vector3(Input.GetAxis("Horizontal") * 60, 0, Input.GetAxis("Vertical") * 60);
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.transform.tag == "Exp")
    //    {
    //        Rigidbody rb = other.transform.GetComponent<Rigidbody>();
    //        float distance = Vector3.Distance(transform.position, other.transform.position);
    //        rb.AddForce((transform.position - other.transform.position) * distance);
    //        if (distance < 5)
    //        {
    //            Audio_Source_3.PlayOneShot(exp_sound, .5f);
    //            PlayerStats.instance.Experience_Count++;
    //            Destroy(other.transform.gameObject);
    //        }
    //    }
    //}

}


