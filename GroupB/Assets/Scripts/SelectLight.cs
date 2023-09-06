using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectLight : MonoBehaviour
{
    bool allSelect = false;
    int selectNum = 0;
    void Update()
    {
        WheelCount();
        SelectedNum();
    }

    void WheelCount()
    {
        //‰ñ“]‚ÌŽæ“¾
        float wh = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(selectNum);
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
        switch(selectNum)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
}
