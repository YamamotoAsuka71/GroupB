using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    //生成するゲームオブジェクト
    public GameObject red;
    public GameObject blue;
    public GameObject green;
    public GameObject yellowllow;
    public GameObject purple; 
    public GameObject Variant;
    void Start()
    {
        //FunctionTestを3秒毎に呼び出します。
        InvokeRepeating("Generation", 0f, 3f);
    }

    void Generation()
    {
        float target = Random.Range(0, 975);
        if (target == 0||target<225)
        {
            Instantiate(red, transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
        }
        else if(target<=225||target<450)
        {
            Instantiate(blue, transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
        }
        else if(target<=450||target<675)
        {
            Instantiate(green, transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
        }
        else if (target<=675||target<775)
        {
            Instantiate(yellowllow, transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
        }
        else if(target<=775||target<875)
        {
            Instantiate(purple, transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
        }
        else if (target<=875||target<975)
        {
            Instantiate(Variant, transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
        }
        else
        {

        }
    }
}
