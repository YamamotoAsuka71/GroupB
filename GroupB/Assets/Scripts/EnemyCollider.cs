using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    bool isDestroy = false; //  破壊するかどうか判別する
    bool isRed = false, isGreen = false, isBlue = false;    //  各ライトの衝突判定を行うフラグ
    int timerCount = 0; //  フレーム計測用変数
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Red")    //  このプログラムがアタッチされているオブジェクトのタグがRedだったら
        {
            if (isRed == true && isGreen == false && isBlue == false)   //  赤色のライトだけが当たっている場合
            {
                isDestroy = true;   //  破壊可能にする
            }
        }
        if (gameObject.tag == "Green")  //  このプログラムがアタッチされているオブジェクトのタグがGreenだったら
        {
            if (isRed == false && isGreen == true && isBlue == false)   //  緑色のライトだけが当たっている場合
            {
                isDestroy = true;   //  破壊可能にする
            }
        }
        if (gameObject.tag == "Blue")   //  このプログラムがアタッチされているオブジェクトのタグがBlueだったら
        {
            if (isRed == false && isGreen == false && isBlue == true)   //  青色のライトだけが当たっている場合
            {
                isDestroy = true;   //  破壊可能にする
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Red") //  当たっているオブジェクトのタグがRedだった場合
        {
            isRed = true;   //  赤色のライトが当たっているとする
        }
        if (other.tag == "Green")   //  当たっているオブジェクトのタグがGreenだった場合
        {
            isGreen = true; //  緑色のライトが当たっているとする
        }
        if (other.tag == "Blue")    //  当たっているオブジェクトのタグがBlueだった場合
        {
            isBlue = true;  //  青色のライトが当たっているとする
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Red") //  離れたオブジェクトのタグがRedだった場合
        {
            isRed = false;  //  赤色のライトが当たっていないとする
        }
        if (other.tag == "Green")   //  離れたオブジェクトのタグがGreenだった場合
        {
            isGreen = false;    //  緑色のライトが当たっていないとする
        }
        if (other.tag == "Blue")    //  離れたオブジェクトのタグがBlueだった場合
        {
            isBlue = false; //  青色のライトが当たっていないとする
        }
    }
    private void FixedUpdate()
    {
        if(isDestroy == true)   //  破壊可能な状態にあるとき
        {
            timerCount++;   //  フレーム計測開始
            if (timerCount == 20)   //  フレーム数が20の時
            {
                Destroy(gameObject);    //  このオブジェクトを破壊する
            }
        }
        else
        {
            timerCount = 0; //  計測リセット
        }
    }
}
