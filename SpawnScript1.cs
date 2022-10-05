using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnScript1 : MonoBehaviour
{
    public GameObject[] mob_types;
    private GameObject[] spawner_array;
    private GameObject[] currently_spawned;

    public GameObject[] FireEle_Mobs;
    public GameObject[] SnowEle_Mobs;
    public GameObject[] DesertEle_Mobs;
    private GameObject mob_to_spawn;
    private bool empty_check;
    private float timer;
    int scene;
    private void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        spawner_array = new GameObject[transform.childCount];

        for (int x = 0; x < spawner_array.Length; x++)
        {
            spawner_array[x] = transform.GetChild(x).gameObject;
        }


    }



    public void Mob_Spawn(int time)
    {
        this.currently_spawned = new GameObject[spawner_array.Length];
        //spawn at each spawn point, update instantiate mob type 0 to be random number from availible mob types
        if (scene == 1 || scene == 4)
        {
            mob_types = FireEle_Mobs;
        }
        else if (scene == 2)
        {
            mob_types = DesertEle_Mobs;
        }
        else if (scene == 3)
        {
            mob_types = SnowEle_Mobs;
        }

        for (int x = 0; x < spawner_array.Length; x++)
        {
            int random_mob_type = Random.Range(0, 5);


            if (random_mob_type < 4) //regular fire ele spawns
            {
                if (time == 0)
                {
                    mob_to_spawn = mob_types[0];
                }
                else if (time == 1)
                {
                    mob_to_spawn = mob_types[1];
                }
                else if (time == 2)
                {
                    mob_to_spawn = mob_types[2];
                }
            }
            else if (random_mob_type == 4) //magic ele runner
            {
                mob_to_spawn = mob_types[3];
            }

            currently_spawned[x] = (Instantiate(mob_to_spawn, spawner_array[x].transform.position, Quaternion.identity));
        }
    }

    
}
