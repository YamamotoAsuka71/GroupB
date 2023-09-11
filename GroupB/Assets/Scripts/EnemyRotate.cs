using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    public GameObject redEnemy, greenEnemy, blueEnemy;
    GameObject obj, enemy;
    const float POS_Z = -0.3f, POS_X_1 = 0.75f, POS_X_2 = -0.75f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            int randomNum = Random.Range(0, 3);
            switch (randomNum)
            {
                case 0:
                    enemy = redEnemy;
                    break;
                case 1:
                    enemy = greenEnemy;
                    break;
                case 2:
                    enemy = blueEnemy;
                    break;
            }
            if (i == 0)
            {
                obj = Instantiate(enemy, new Vector3(transform.position.x + POS_X_1, transform.position.y, transform.position.z + POS_Z), Quaternion.identity);
                obj.transform.parent = transform;
            }
            else
            {
                obj = Instantiate(enemy, new Vector3(transform.position.x + POS_X_2, transform.position.y, transform.position.z + POS_Z), Quaternion.identity);
                obj.transform.parent = transform;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        int ObjCount = transform.childCount;
        if (ObjCount == 0)
        {
            Destroy(gameObject);
        }
        transform.Rotate(0.0f, 1.0f, 0.0f);
    }
}
