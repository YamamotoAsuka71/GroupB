using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    //��������Q�[���I�u�W�F�N�g
    public GameObject target;
    void Start()
    {
        //FunctionTest��3�b���ɌĂяo���܂��B
        InvokeRepeating("Generation", 0f, 3f);
    }

    void Generation()
    {
        Instantiate(target, new Vector3(-8.0f, 0.0f, 5.0f), Quaternion.identity);
    }
}
