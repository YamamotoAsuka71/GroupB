using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightCollider : MonoBehaviour
{
    public GameObject spotLight;    //  スポットライトの当たり判定可変プログラム格納用
    SpotLightController spot;
    private void Start()
    {
        spot = spotLight.GetComponent<SpotLightController>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (spot.GetIsColliding() == false) //  当たっていないと判別していたら
        {
            spot.SetObj(other.gameObject);  //  当たっているオブジェクトを格納
            spot.SetIsColliding(true);  //  当たっているとする
        }
    }
    private void OnTriggerExit(Collider other)
    {
        spot.SetIsColliding(false); //  当たっていないとする
    }
}
