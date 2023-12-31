using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyFactory1 : MonoBehaviour//BOSS等雑魚以外の生成スクリプト
{
    public GameObject red;//赤色の敵
    public GameObject blue;//青色の敵
    public GameObject green;//緑色の敵
    public GameObject yellow;//黄色の敵
    public GameObject purple; //紫色の敵
    public GameObject Variant;//空色の敵
    bool flag = false;
    int timerCount = 50;
    float timer = 0.0f;

    void Start()
    {
        PlayerPrefs.SetInt("smallfry", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        //5回雑魚を生成したら強い敵を生成
        if (PlayerPrefs.GetInt("smallfry", 0) >= 5)
        {
            flag = true;
        }
        else
        {
            flag = false;
        }
        if (flag == true)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5f)
            {
                BossGeneration();
            }
        }
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

    void BossGeneration()
    {
        //ランダムで数字を決める、そしてその数字で敵を決めて生成している
        int target = Random.Range(0, 3);

        if (target == 0)
        {
            Instantiate(yellow, transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
        }
        else if (target == 1)
        {
            Instantiate(purple, transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
        }
        else if (target == 2)
        {
            Instantiate(Variant, transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));
        }
        else
        {

        }
        PlayerPrefs.SetInt("smallfry", 0);
        PlayerPrefs.Save();
        flag = false;
    }
    private void FixedUpdate()
    {
        if (flag == false)
        {
            timer = 0.0f;
            if (timerCount >= 50)
            {
                Generation();
                timerCount = 0;
            }
            timerCount++;
        }
    }
}
