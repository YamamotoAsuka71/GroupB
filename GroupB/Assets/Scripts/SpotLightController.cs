using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{
    const float defaultLength = 5f;   //  ライトの当たり判定の最大(最初)の大きさ
    float distance; //  オブジェクトからライトの持ちてに当たる部分までの距離
    float percentage;   //  ライトの当たり判定を可変するための比率
    private bool isColliding = false;   //  ライトが他のオブジェクトに当たっているかのフラグ
    public bool GetIsColliding() { return isColliding; }
    public void SetIsColliding(bool collision) { isColliding = collision; }
    private GameObject obj; //  当たっているオブジェクトを参照するために格納する変数
    public void SetObj(GameObject obj) { this.obj = obj; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (obj == null)    //  オブジェクトが格納されていないなら(ライトになにも当たっていなければ)
        {
            isColliding = false;    //  当たっていないとする
        }
        if (isColliding == true)    //  何かが当たっているならば
        {
            Debug.Log("a");
            distance = (obj.transform.position - transform.position).magnitude; //  ライトの持ちてに当たる部分から他のオブジェクトまでの距離を計算
            percentage = distance / defaultLength;  //  距離ともともとの長さから当たり判定の比率を計算
            transform.localScale = new Vector3(1.0f * percentage, 1.0f * percentage, 1.0f * percentage);    //  当たり判定の大きさを変える
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);   //  当たり判定の大きさを元に戻す
        }
        if (distance > defaultLength)   //  距離が基本の長さより上回ったら
        {
            isColliding = false;    //  当たっていないとする
        }
        if (transform.localScale.x > 1.0f || transform.localScale.y > 1.0f || transform.localScale.z > 1.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);   //  当たり判定の大きさを元に戻す
        }
    }
}
