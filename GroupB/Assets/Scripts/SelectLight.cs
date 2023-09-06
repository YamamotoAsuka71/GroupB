using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SelectLight : MonoBehaviour
{
    bool allSelect = false;
    int selectNum = 0;
    public GameObject[] Lights = new GameObject[4];
    public GameObject setColor;
    TextMeshProUGUI colorText;
    float rotateSpeed = 2.0f;
    new GameObject light = null;

    private void Start()
    {
        allSelect = false;
        colorText = setColor.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (allSelect == false)
        {
            WheelCount();
        }
        SelectedNum();
        SwitchingLight();
        if (Input.GetMouseButton(1))
        {
            //rotateCamera‚ÌŒÄ‚Ño‚µ
            rotateCamera();
        }
    }

    void WheelCount()
    {
        //‰ñ“]‚ÌŽæ“¾
        float wh = Input.GetAxis("Mouse ScrollWheel");
        if (wh > 0)
        {
            selectNum++;
        }
        else if (wh < 0)
        {
            selectNum--;
        }
        if (selectNum > 1)
        {
            selectNum = 1;
        }
        if (selectNum < -1)
        {
            selectNum = -1;
        }
    }
    void SelectedNum()
    {
        if (allSelect == false)
        {
            switch (selectNum)
            {
                case 0:
                    colorText.text = "<color=#FF0000>Red";
                    light = Lights[1];
                    break;
                case 1:
                    colorText.text = "<color=#4169E1>Blue";
                    light = Lights[3];
                    break;
                case -1:
                    colorText.text = "<color=#00FF7F>Green";
                    light = Lights[2];
                    break;
            }
        }  
    }
    void SwitchingLight()
    {
        if (Input.GetMouseButtonDown(2))
        {
            if (allSelect == false)
            {
                for (int i = 1; i < 4; i++)
                {
                    Lights[i].transform.localEulerAngles = new Vector3(-90.0f, 0.0f, 0.0f);
                }
            }
            allSelect = !allSelect;
        }
        if (allSelect == true)
        {
            light = Lights[0];
            colorText.text = "AllColor";
        }
    }
    void rotateCamera()
    {
        //Vector3‚ÅX,Y•ûŒü‚Ì‰ñ“]‚Ì“x‡‚¢‚ð’è‹`
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        //transform.RotateAround()‚ð‚µ‚æ‚¤‚µ‚Ä‘I‘ð‚µ‚Ä‚¢‚éƒ‰ƒCƒg‚ð‰ñ“]‚³‚¹‚é
        light.transform.RotateAround(transform.position, Vector3.up, angle.x);
        light.transform.RotateAround(transform.position, transform.right, -angle.y);
    }
}
