using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    public GameObject redEnemy, greenEnemy, blueEnemy;  //  雑魚敵とする赤、緑、青のエネミーを格納
    GameObject obj, enemy;  //  子として生成するための変数とどのエネミーか判別するための格納用変数
    const float POS_Z = -0.3f, POS_X_1 = 0.75f, POS_X_2 = -0.75f;   //  エネミー生成ポジション
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            int randomNum = Random.Range(0, 3); //  カラー選択用の数字をランダム抽出
            switch (randomNum)
            {
                case 0: //  ０の時
                    enemy = redEnemy;   //  生成するエネミーは赤にする
                    break;
                case 1: //  １の時
                    enemy = greenEnemy; //  生成するエネミーは緑にする
                    break;
                case 2: //  ２の時
                    enemy = blueEnemy;  //  生成するエネミーは青にする
                    break;
            }
            if (i == 0) //  一回目の生成の時
            {
                obj = Instantiate(enemy, new Vector3(transform.position.x + POS_X_1, transform.position.y, transform.position.z + POS_Z), Quaternion.identity); //  エネミーの右側に生成
                obj.transform.parent = transform;   //  このプログラムがアタッチされているオブジェクトの子とする
            }
            else
            {
                obj = Instantiate(enemy, new Vector3(transform.position.x + POS_X_2, transform.position.y, transform.position.z + POS_Z), Quaternion.identity); //  エネミーの左側に生成
                obj.transform.parent = transform;   //  このプログラムがアタッチされているオブジェクトの子とする
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        int ObjCount = transform.childCount;    //  子のオブジェクトの数を数える
        if (ObjCount == 0)  //  一つも子のオブジェクトがない場合
        {
            Destroy(gameObject);    //  このオブジェクトを破壊する
        }
        transform.Rotate(0.0f, 1.0f, 0.0f); //  このオブジェクトを回転させる
    }
}
