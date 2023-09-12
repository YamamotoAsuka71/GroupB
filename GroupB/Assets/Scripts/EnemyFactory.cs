using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    //生成するゲームオブジェクト
    public GameObject red;//赤色の敵
    public GameObject blue;//青色の敵
    public GameObject green;//緑色の敵
    public GameObject yellowllow;//黄色の敵
    public GameObject purple; //紫色の敵
    public GameObject Variant;//空色の敵
    void Start()
    {
        //FunctionTestを3秒毎に呼び出します。
        InvokeRepeating("Generation", 0f, 3f);
    }

    void Generation()
    {
        //ランダムで数字を決める、そしてその数字で敵を決めて生成している
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
