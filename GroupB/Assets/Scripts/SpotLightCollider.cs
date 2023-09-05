using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightCollider : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OK");
        }
    }
}
