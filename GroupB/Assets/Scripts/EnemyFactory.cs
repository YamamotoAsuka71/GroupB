using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    //生成するゲームオブジェクト
    public GameObject red;//赤色の敵
    public GameObject blue;//青色の敵
    public GameObject green;//緑色の敵
    void Start()
    {
        //FunctionTestを3秒毎に呼び出します。
        InvokeRepeating("Generation", 0f, 3f);
    }

    void Generation()
    {
        //ランダムで数字を決める、そしてその数字で敵を決めて生成している
        float target = Random.Range(0, 3);
        if (target == 0)
        {
            Instantiate(red, transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
            PlayerPrefs.SetInt("smallfry", PlayerPrefs.GetInt("smallfry", 0) + 1);
            PlayerPrefs.Save();
        }
        else if (target == 1)
        {
            Instantiate(blue, transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
            PlayerPrefs.SetInt("smallfry", PlayerPrefs.GetInt("smallfry", 0) + 1);
            PlayerPrefs.Save();
        }
        else
        {
            Instantiate(green, transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
            PlayerPrefs.SetInt("smallfry", PlayerPrefs.GetInt("smallfry", 0) + 1);
            PlayerPrefs.Save();
        }
    }
}
