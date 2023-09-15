using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SelectLight : MonoBehaviour
{
    bool allSelect = false; //  ライト全選択のフラグ
    int selectNum = 0;  //  ライト識別番号
    public GameObject[] Lights = new GameObject[4]; //  ライト格納
    public GameObject setColor; // 現在のカラー表示テキスト格納用 
    TextMeshProUGUI colorText;
    float rotateSpeed = 2.0f;   //  ライト回転スピード
    new GameObject light = null;    //  現在のライト格納用
    float rotateSpeedY = 2.0f;

    private void Start()
    {
        allSelect = false;
        colorText = setColor.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (allSelect == false) //  現在のライトが全選択でないなら
        {
            WheelCount();   //  色の選択を行う
        }
        SelectedNum();  //  番号によるライト選択
        SwitchingLight();   //  ライトの全選択と個別選択切り替え
        if (Input.GetMouseButton(1))    // マウスが右クリックされている間
        {
            //RotateLightの呼び出し
            RotateLight();
        }
    }

    void WheelCount()
    {
        //回転の取得
        float wh = Input.GetAxis("Mouse ScrollWheel");  //  マウスホイールの回転取得
        if (wh > 0) //  回転情報が０より大きければ
        {
            selectNum++;    //  色識別番号をプラスする
        }
        else if (wh < 0)    //  回転情報が０より小さければ
        {
            selectNum--;    //  色識別番号をマイナスする
        }
        if (selectNum > 1)  //  色識別番号が１を超えたら
        {
            selectNum = -1; //  -１にする
        }
        if (selectNum < -1) //  色識別番号が-１を下回ったら
        {
            selectNum = 1;  //  １にする
        }
    }
    void SelectedNum()
    {
        if (allSelect == false) //  ライトが個別選択状態だったら
        {
            switch (selectNum)
            {
                case 0: //  色識別番号が０の時
                    colorText.text = "<color=#FF0000>Red";  //  現在の色を表示するテキストを赤に設定
                    light = Lights[1];  //  赤色のライト格納
                    break;
                case 1: //  色識別番号が１の時
                    colorText.text = "<color=#4169E1>Blue"; //  現在の色を表示するテキストを青に設定
                    light = Lights[3];  //  青色のライトを格納
                    break;
                case -1:    //  色識別番号が-１の時
                    colorText.text = "<color=#00FF7F>Green";    //  現在の色を表示するテキストを緑に設定
                    light = Lights[2];  //  緑色のライトを格納
                    break;
            }
        }  
    }
    void SwitchingLight()
    {
        if (Input.GetMouseButtonDown(2))    //  マウスホイールがクリックされたら
        {
            if (allSelect == false) //  ライトが個別選択の場合
            {
                for (int i = 1; i < 4; i++) //  全てのライトを回す
                {
                    Lights[i].transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f); //  初期値に戻す
                }
            }
            allSelect = !allSelect; //  ライトの選択状態を反転
        }
        if (allSelect == true)  //  ライトが全選択の場合
        {
            light = Lights[0];  //  全部のライトを動かすライトを選択
            colorText.text = "AllColor";    //  現在の色を表示するテキストを全ての色に設定
        }
    }
    void RotateLight()
    {
        //Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeedY, 0);

        float currentYAngle = transform.eulerAngles.y;
        // 現在の角度が180より大きい場合
        if (currentYAngle % 360 >= 90 && currentYAngle % 360 <= 270 || currentYAngle % 360 <= -90 && currentYAngle % 360 >= -270)
        {
            rotateSpeedY = -2.0f;
        }
        else
        {
            rotateSpeedY = 2.0f;
        }
        //transform.RotateAround()をしようして選択しているライトを回転させる
        light.transform.RotateAround(transform.position, Vector3.up, angle.x);
        light.transform.RotateAround(transform.position, Vector3.right, -angle.y);
        light.transform.localEulerAngles = new Vector3(light.transform.localEulerAngles.x, light.transform.localEulerAngles.y, 0.0f);
    }
}
