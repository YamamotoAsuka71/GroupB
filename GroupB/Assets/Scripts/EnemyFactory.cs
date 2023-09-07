using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    //生成するゲームオブジェクト
    public GameObject target;
    void Start()
    {
        //FunctionTestを3秒毎に呼び出します。
        InvokeRepeating("Generation", 0f, 3f);
    }

    void Generation()
    {
        Instantiate(target, new Vector3(-8.0f, 0.0f, 5.0f), Quaternion.identity);
    }
}
