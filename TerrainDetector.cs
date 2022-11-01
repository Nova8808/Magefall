using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;
using UnityEngine.UIElements;

public class TerrainDetector: MonoBehaviour
{

    //private TerrainData terrainData;
    //private int alphamapWidth;
    //private int alphamapHeight;
    //private float[,,] splatmapData;
    //private int numTextures;
    //public Vector3 splatPosition;

    //public Transform player_position;



    //public void Start()
    //{
    //    //player_position = GameObject.FindGameObjectWithTag("Player").transform;
    //    terrainData = GetClosestCurrentTerrain(player_position.position).terrainData;
    //    alphamapWidth = terrainData.alphamapWidth;
    //    alphamapHeight = terrainData.alphamapHeight;

    //    splatmapData = terrainData.GetAlphamaps(0, 0, alphamapWidth, alphamapHeight);
    //    numTextures = splatmapData.Length / (alphamapWidth * alphamapHeight);


    //    Debug.Log(GetClosestCurrentTerrain(player_position.position));
    //}


    //private Vector3 ConvertToSplatMapCoordinate(Vector3 worldPosition)
    //{
    //    //Vector3 splatPosition = new Vector3();
    //    Terrain ter = GetClosestCurrentTerrain(player_position.position);
    //    Vector3 terPosition = ter.transform.position;
    //    splatPosition.x = ((worldPosition.x - terPosition.x) / ter.terrainData.size.x) * ter.terrainData.alphamapWidth;
    //    splatPosition.z = ((worldPosition.z - terPosition.z) / ter.terrainData.size.z) * ter.terrainData.alphamapHeight;
    //    return splatPosition;
    //}

    //public int GetActiveTerrainTextureIdx()
    //{
    //    Vector3 terrainCord = ConvertToSplatMapCoordinate(player_position.position);
    //    //Debug.Log(terrainCord);
    //    int activeTerrainIndex = 0;
    //    float largestOpacity = 0f;

    //    for (int i = 0; i < 4; i++)
    //    {
    //        if (largestOpacity < splatmapData[(int)terrainCord.z, (int)terrainCord.x, i])
    //        {
    //            activeTerrainIndex = i;
    //            largestOpacity = splatmapData[(int)terrainCord.z, (int)terrainCord.x, i];
    //        }
    //    }

    //    return activeTerrainIndex;
    //}

    public Transform playerTransform;
    public Terrain t;

    public int posX;
    public int posZ;
    public float[] textureValues;

    Terrain[] _terrains;
    public int current_terrain_index;
    public TerrainLayer[] terrainLayers;

    private AudioSource audio_source;
    private AudioClip[][] Footstep_Sounds_Array;
    public AudioClip[] layer_1;
    public AudioClip[] layer_2;
    public AudioClip[] layer_3;
    public AudioClip[] layer_4;
    public AudioClip[] layer_5;
    public AudioClip[] layer_6;
    public AudioClip[] layer_7;
    public AudioClip[] layer_8;
    public AudioClip[] swim_audio;

    private Collider player_collider;
    public bool in_water;
    public bool is_walking;
    public float walk_timer;
    public float step_interval;

    void Start()
    {
        // t = GetClosestCurrentTerrain(transform.position);
        playerTransform = transform;
        _terrains = Terrain.activeTerrains;
        current_terrain_index = GetClosestCurrentTerrain(playerTransform.position);
        t = _terrains[current_terrain_index];
        audio_source = GetComponent<AudioSource>();
        player_collider = GetComponent<SphereCollider>();
        in_water = false;
        is_walking = false;
        Footstep_Sounds_Array = new AudioClip[9][];

        //playerTransform = gameObject.transform;
        //Debug.Log(layer_1[1]);
        //Debug.Log(layer_1[2]);
        //Debug.Log(layer_1[3]);
    }

    public void Play_Footsteps()
    {
        //can check for t.tag for forest/desert/snow and say layer_1 = desert1[] 
        GetTerrainTexture();
        PlayAudio();


        //  Debug.Log(_terrains[wtf]);
        //if (textureValues[0] > 0)
        //{
        //    Debug.Log(textureValues[0]);
        //}
    }

    public void GetTerrainTexture()
    {
        // t = GetClosestCurrentTerrain(transform.position);
        current_terrain_index = GetClosestCurrentTerrain(playerTransform.position);
        t = _terrains[current_terrain_index];

        ConvertPosition(playerTransform.position);
        CheckTexture();
        //if (textureValues[0] > 0)
        //{
        //    Debug.Log(textureValues[1]);
        //}
        // Debug.Log(textureValues[2]);
    }

    void ConvertPosition(Vector3 playerPosition)
    {
        Vector3 terrainPosition = playerPosition - t.transform.position;

        Vector3 mapPosition = new Vector3
        (terrainPosition.x / t.terrainData.size.x, 0,
        terrainPosition.z / t.terrainData.size.z);

        float xCoord = mapPosition.x * t.terrainData.alphamapWidth;
        float zCoord = mapPosition.z * t.terrainData.alphamapHeight;

        posX = (int)xCoord;
        posZ = (int)zCoord;
    }

    void CheckTexture()
    {
        textureValues = new float[t.terrainData.terrainLayers.Length];
        float[,,] aMap = t.terrainData.GetAlphamaps(posX, posZ, 1, 1);
        for (int c = 0; c < t.terrainData.terrainLayers.Length; c++)
            {
            textureValues[c] = aMap[0, 0, c];
            }
        //textureValues[0] = aMap[0, 0, 0];
        //textureValues[1] = aMap[0, 0, 1];
        //textureValues[2] = aMap[0, 0, 2];
        //textureValues[3] = aMap[0, 0, 3];
        //textureValues[4] = aMap[0, 0, 4];
        //textureValues[5] = aMap[0, 0, 5];
    }


    //public Terrain GetClosestCurrentTerrain(Vector3 playerPos)
    //{
    //    //Get all terrain
    //    Terrain[] terrains = Terrain.activeTerrains;

    //    //Make sure that terrains length is ok
    //    if (terrains.Length == 0)
    //        return null;

    //    //If just one, return that one terrain
    //    if (terrains.Length == 1)
    //        return terrains[0];

    //    //Get the closest one to the player
    //    float lowDist = (terrains[0].GetPosition() - playerPos).sqrMagnitude;
    //    var terrainIndex = 0;

    //    for (int i = 1; i < terrains.Length; i++)
    //    {
    //        Terrain terrain = terrains[i];
    //        Vector3 terrainPos = terrain.GetPosition();

    //        //Find the distance and check if it is lower than the last one then store it
    //        var dist = (terrainPos - playerPos).sqrMagnitude;
    //        if (dist < lowDist)
    //        {
    //            lowDist = dist;
    //            terrainIndex = i;
    //        }
    //    }
       
    //    return terrains[terrainIndex];
    //}

    public int GetClosestCurrentTerrain(Vector3 playerPos)
    {

        
        //Get the closest one to the player
        var center = new Vector3(_terrains[0].transform.position.x + _terrains[0].terrainData.size.x / 2, playerPos.y, _terrains[0].transform.position.z + _terrains[0].terrainData.size.z / 2);
        float lowDist = (center - playerPos).sqrMagnitude;
        var terrainIndex = 0;

        for (int i = 0; i < _terrains.Length; i++)
        {
            center = new Vector3(_terrains[i].transform.position.x + _terrains[i].terrainData.size.x / 2, playerPos.y, _terrains[i].transform.position.z + _terrains[i].terrainData.size.z / 2);

            //Find the distance and check if it is lower than the last one then store it
            var dist = (center - playerPos).sqrMagnitude;
            if (dist < lowDist)
            {
                lowDist = dist;
                terrainIndex = i;
            }
        }
        return terrainIndex;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            in_water = true;
            audio_source.clip = swim_audio[0];
            audio_source.Play();
            
        }
        //else
        //{
        //    //audio_source.Stop();
        //    if (in_water)
        //    {
        //        audio_source.Stop();
        //        in_water = false;
        //    }
           
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            audio_source.Stop();
            in_water = false;
            is_walking = false;
            walk_timer = 0;
        }
    }


    private void PlayAudio()
    {
        //if (in_water == true)
        //{
        //    audio_source.clip = Footstep_Sounds_Array[8][0];
        //    audio_source.enabled = true;
        //   // audio_source.PlayOneShot(swim_audio[0], .8f);
        //}
        //if (in_water == false)
        //{
        //    audio_source.Stop();
        //}

        //for (int c = 0; c < t.terrainData.terrainLayers.Length; c++)
        //{
        //    if (textureValues[c] > 0)
        //    {
        //    if (Footstep_Sounds_Array[c][0] != null)
        //    {
        //        if (!is_walking)
        //        {
        //            Debug.Log(Footstep_Sounds_Array[c][0]);
        //            audio_source.PlayOneShot(Footstep_Sounds_Array[c][0], textureValues[c]);
        //            //audio_source.clip = Footstep_Sounds_Array[c][0];
        //           // audio_source.Play();
        //            is_walking = true;
        //        }
        //    }
        //    }
        //}

        walk_timer += Time.deltaTime;
        
       // Debug.Log(layer1_rand);
        if (walk_timer > step_interval)
        {
            if (textureValues[0] > 0)
            {
                
                audio_source.Stop();
                audio_source.PlayOneShot(layer_1[Random.Range(0, 8)], textureValues[0]);
                walk_timer = 0;
            }
            if (textureValues[1] > 0)
            {
                audio_source.Stop();
                audio_source.PlayOneShot(layer_2[Random.Range(0, 4)], textureValues[1]);
                walk_timer = 0;
            }
            if (textureValues[2] > 0)
            {
                audio_source.Stop();
                audio_source.PlayOneShot(layer_3[Random.Range(0, 4)], textureValues[2]);
                walk_timer = 0;
            }
        }
    }

}
