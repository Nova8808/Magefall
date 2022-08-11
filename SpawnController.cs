using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Mobs
{
    public class SpawnController : MonoBehaviour
    {
        private int total_spawn_points;
        GameObject[] spawn_point_array;
        public int spawn_interval;
        private float timer;
        private int total_spawns_at_a_time;
        private int[] random_selections;

        private GameObject[] total_enemies_in_map;
        private int current_total_enemies;
        private int total_enemies_allowed;

        int game_time;

        bool update_spawns_at_a_time;
        void Start()
        {
            game_time = 0;
            current_total_enemies = 0;
            total_spawns_at_a_time = 2;
            update_spawns_at_a_time = false;
            //Populate array of all spawn points based on children to holder object
            total_spawn_points = transform.childCount;
            spawn_point_array = new GameObject[total_spawn_points];
            random_selections = new int[total_spawns_at_a_time];

            for (int x = 0; x < total_spawn_points; x++)
            {
                spawn_point_array[x] = transform.GetChild(x).gameObject;
            }

        }

        private void Update()
        {
            timer += Time.deltaTime;
            // Initial spawn which picks 2 spawn points randomly and spawns every interval. expanding on this can add if statements to change based on player level,
            // longer/shorter interval and more random numbers picked to spawn from more points at once
            if (Basics.instance.Main_Game_Timer > -1 && Basics.instance.Main_Game_Timer < 200)
            {
                total_enemies_allowed = 30;
            }
            else if (Basics.instance.Main_Game_Timer >= 200 && Basics.instance.Main_Game_Timer < 400)
            {
                total_enemies_allowed = 40;
                total_spawns_at_a_time = 3;
                if (!update_spawns_at_a_time)
                {
                    random_selections = new int[total_spawns_at_a_time];
                    update_spawns_at_a_time = true;
                }
            }
            else if (Basics.instance.Main_Game_Timer >= 400 && Basics.instance.Main_Game_Timer < 800)
            {
                game_time = 1;
                total_enemies_allowed = 50;
            }
            else if (Basics.instance.Main_Game_Timer >= 800 && Basics.instance.Main_Game_Timer < 12100)
            {
                game_time = 2;
                total_enemies_allowed = 60;
            }

            if (timer > spawn_interval)
            {
                //int randm_spawn_selector;
                //randm_spawn_selector = Random.Range(0, total_spawn_points);
                //total_enemies_in_map = new GameObject[1];
                current_total_enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

                if (current_total_enemies < total_enemies_allowed)
                {
                    for (int i = 0; i < total_spawns_at_a_time; i++)
                    {
                        random_selections[i] = Random.Range(0, total_spawn_points);
                        spawn_point_array[random_selections[i]].transform.GetChild(0).transform.GetComponent<SpawnScript1>().Mob_Spawn(game_time);
                        // transform.GetChild(randm_spawn_selector).transform.GetChild(0).transform.GetComponent<SpawnScript1>().Mob_Spawn();
                    }
                }

                timer = 0;
            }
        }


    }
}