using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollider2 : MonoBehaviour
{
    bool isInvincible = true, isDestroy = false;    //  無敵状態判別用と破壊可能か判別する変数
    int timerCount = 0; //  フレーム計測用
    public GameObject Rotate;   //  回転するオブジェクト
    bool isGreen = false, isBlue = false, isRed = false;    //  各色の衝突判定
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rotate != null) //  回転するオブジェクトがあれば
        {
            isInvincible = true;    //  無敵にする
        }
        else
        {
            isInvincible = false;   //  無敵状態を解除
        }
        if (gameObject.tag == "Cyan")   //  このプログラムがアタッチされているオブジェクトのタグがCyanなら
        {
            if (isGreen == true && isBlue == true && isRed == false)    //  緑と青のライトだけが当たっている場合
            {
                isDestroy = true;   //  破壊可能にする
            }
        }
        if (gameObject.tag == "Yellow") //  このプログラムがアタッチされているオブジェクトのタグがYellowなら
        {
            if (isGreen == true && isRed == true && isBlue == false)    //  緑と赤のライトだけが当たっている場合
            {
                isDestroy = true;   //  破壊可能にする
            }
        }
        if (gameObject.tag == "Magenta")    //  このプログラムがアタッチされているオブジェクトのタグがMagentaなら
        {
            if (isGreen == false && isRed == true && isBlue == true)    //  赤と青のライトだけが当たっている場合
            {
                isDestroy = true;   //  破壊可能にする
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (isInvincible == false)  //  無敵状態でないなら
        {
            if (other.tag == "Red") //  当たっているオブジェクトのタグがRedの場合
            {
                isRed = true;   //  赤色のライトが当たっているとする
            }
            else if (other.tag == "Green")  //  当たっているオブジェクトのタグがGreenの場合
            {
                isGreen = true; //  緑色のライトが当たっているとする
            }
            else if (other.tag == "Blue")   //  当たっているオブジェクトのタグがBlueの場合
            {
                isBlue = true;  //  青色のライトが当たっているとする
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Green")   //  離れたオブジェクトのタグがGreenなら
        {
            isGreen = false;    //  緑色のライトが当たっていないとする
        }
        if (other.tag == "Red") //  離れたオブジェクトのタグがRedなら
        {
            isRed = false;  //  赤色のライトが当たっていないとする
        }
        if (other.tag == "Blue")    //  離れたオブジェクトのタグがBlueなら
        {
            isBlue = false; //  青色のライトが当たっていないとする
        }
    }

    private void FixedUpdate()
    {
        if (isDestroy == true)  //  破壊可能なら
        {
            timerCount++;   //  フレームを計測する
            if (timerCount == 20)   //  フレームが20の時
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
