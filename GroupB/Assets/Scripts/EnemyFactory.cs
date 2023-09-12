using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    //��������Q�[���I�u�W�F�N�g
    public GameObject red;//�ԐF�̓G
    public GameObject blue;//�F�̓G
    public GameObject green;//�ΐF�̓G
    void Start()
    {
        //FunctionTest��3�b���ɌĂяo���܂��B
        InvokeRepeating("Generation", 0f, 3f);
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
}
