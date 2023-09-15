using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyFactory1 : MonoBehaviour//BOSS���G���ȊO�̐����X�N���v�g
{
    public GameObject red;//�ԐF�̓G
    public GameObject blue;//�F�̓G
    public GameObject green;//�ΐF�̓G
    public GameObject yellow;//���F�̓G
    public GameObject purple; //���F�̓G
    public GameObject Variant;//��F�̓G
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
        //5��G���𐶐������狭���G�𐶐�
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
        //�����_���Ő��������߂�A�����Ă��̐����œG�����߂Đ������Ă���
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
        //�����_���Ő��������߂�A�����Ă��̐����œG�����߂Đ������Ă���
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
