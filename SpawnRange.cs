using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRange : MonoBehaviour
{
    private bool inside;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.GetChild(0).transform.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !inside)
        {
            transform.GetChild(0).transform.gameObject.SetActive(true);
            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.GetChild(0).transform.gameObject.SetActive(false);
            inside = false;
        }
    }
}
