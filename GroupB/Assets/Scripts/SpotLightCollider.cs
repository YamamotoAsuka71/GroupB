using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightCollider : MonoBehaviour
{
    public GameObject spotLight;
    SpotLightController spot;
    private void Start()
    {
        spot = spotLight.GetComponent<SpotLightController>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (spot.GetIsColliding() == false)
        {
            spot.SetObj(other.gameObject);
            spot.SetIsColliding(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        spot.SetIsColliding(false);
    }
}
