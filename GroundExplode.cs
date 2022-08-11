using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundExplode : MonoBehaviour
{
    public float minForce;
    public float maxForce;
    public float Radius;



    
    private void Start()
    {
        Explode();
        Destroy(gameObject, 5);
    }
    private void OnEnable()
    {
        Explode();
        Destroy(gameObject, 5);
            
    }


    void Explode()
    {
        foreach (Transform t in transform)
        {
            var rb = t.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, Radius);
            }

            Destroy(t.gameObject, 4);
        }

    }


    


}
