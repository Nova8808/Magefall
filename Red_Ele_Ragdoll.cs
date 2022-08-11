using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Ele_Ragdoll : MonoBehaviour, IdamageableStatus<string, int>
{
    private SkinnedMeshRenderer mesh;
    private Material[] base_material;
    // Start is called before the first frame update
    void Start()
    {
        mesh = transform.GetChild(0).transform.GetComponent<SkinnedMeshRenderer>();
        base_material = new Material[1] { mesh.material };
    }

    // Update is called once per frame
    void Update()
    {
        
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
        yield return new WaitForSeconds(duration);
        mesh.materials = base_material;
    }

    public void Status(string Status_Effect, int duration)
    {
        StartCoroutine(Set_Status(Status_Effect, duration));
    }

    public void Damage(float Spell_Damage)
    {
        
    }
}
