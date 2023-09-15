using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyFactory1 : MonoBehaviour//BOSS“™ŽG‹›ˆÈŠO‚Ì¶¬ƒXƒNƒŠƒvƒg
{
    public GameObject red;//ÔF‚Ì“G
    public GameObject blue;//ÂF‚Ì“G
    public GameObject green;//—ÎF‚Ì“G
    public GameObject yellow;//‰©F‚Ì“G
    public GameObject purple; //Ž‡F‚Ì“G
    public GameObject Variant;//‹óF‚Ì“G
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
        //5‰ñŽG‹›‚ð¶¬‚µ‚½‚ç‹­‚¢“G‚ð¶¬
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
        //ƒ‰ƒ“ƒ_ƒ€‚Å”Žš‚ðŒˆ‚ß‚éA‚»‚µ‚Ä‚»‚Ì”Žš‚Å“G‚ðŒˆ‚ß‚Ä¶¬‚µ‚Ä‚¢‚é
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
        //ƒ‰ƒ“ƒ_ƒ€‚Å”Žš‚ðŒˆ‚ß‚éA‚»‚µ‚Ä‚»‚Ì”Žš‚Å“G‚ðŒˆ‚ß‚Ä¶¬‚µ‚Ä‚¢‚é
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
