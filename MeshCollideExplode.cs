using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCollideExplode : MonoBehaviour
{
    public float minForce;
    public float maxForce;
    public float Radius;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Terrain" && collision.transform.tag != "Enemy")
        {
            Rigidbody rb = transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, Radius, 4);
            }

            Destroy(transform.gameObject, 4);

        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag != "Terrain" && other.tag != "Enemy")
    //    {
    //        Rigidbody rb = transform.GetComponent<Rigidbody>();
    //        if (rb != null)
    //            {
    //                rb.isKinematic = false;
    //                rb.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, Radius, 2);
    //            }
    //        foreach (Transform t in transform)
    //        {
    //            Rigidbody rbchild = transform.GetComponent<Rigidbody>();
    //            if (rbchild != null)
    //            {
    //                rbchild.isKinematic = false;
    //                rbchild.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, Radius, 2);
    //            }
    //        }

    //            Destroy(transform.gameObject, 4);
            
    //    }
    //}
}
