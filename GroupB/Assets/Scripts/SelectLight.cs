using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SelectLight : MonoBehaviour
{
    bool allSelect = false; //  ���C�g�S�I���̃t���O
    int selectNum = 0;  //  ���C�g���ʔԍ�
    public GameObject[] Lights = new GameObject[4]; //  ���C�g�i�[
    public GameObject setColor; // ���݂̃J���[�\���e�L�X�g�i�[�p 
    TextMeshProUGUI colorText;
    float rotateSpeed = 2.0f;   //  ���C�g��]�X�s�[�h
    new GameObject light = null;    //  ���݂̃��C�g�i�[�p
    float rotateSpeedY = 2.0f;

    private void Start()
    {
        allSelect = false;
        colorText = setColor.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (allSelect == false) //  ���݂̃��C�g���S�I���łȂ��Ȃ�
        {
            WheelCount();   //  �F�̑I�����s��
        }
        SelectedNum();  //  �ԍ��ɂ�郉�C�g�I��
        SwitchingLight();   //  ���C�g�̑S�I���ƌʑI��؂�ւ�
        if (Input.GetMouseButton(1))    // �}�E�X���E�N���b�N����Ă����
        {
            //RotateLight�̌Ăяo��
            RotateLight();
        }
    }

    void WheelCount()
    {
        //��]�̎擾
        float wh = Input.GetAxis("Mouse ScrollWheel");  //  �}�E�X�z�C�[���̉�]�擾
        if (wh > 0) //  ��]��񂪂O���傫�����
        {
            selectNum++;    //  �F���ʔԍ����v���X����
        }
        else if (wh < 0)    //  ��]��񂪂O��菬�������
        {
            selectNum--;    //  �F���ʔԍ����}�C�i�X����
        }
        if (selectNum > 1)  //  �F���ʔԍ����P�𒴂�����
        {
            selectNum = -1; //  -�P�ɂ���
        }
        if (selectNum < -1) //  �F���ʔԍ���-�P�����������
        {
            selectNum = 1;  //  �P�ɂ���
        }
    }
    void SelectedNum()
    {
        if (allSelect == false) //  ���C�g���ʑI����Ԃ�������
        {
            switch (selectNum)
            {
                case 0: //  �F���ʔԍ����O�̎�
                    colorText.text = "<color=#FF0000>Red";  //  ���݂̐F��\������e�L�X�g��Ԃɐݒ�
                    light = Lights[1];  //  �ԐF�̃��C�g�i�[
                    break;
                case 1: //  �F���ʔԍ����P�̎�
                    colorText.text = "<color=#4169E1>Blue"; //  ���݂̐F��\������e�L�X�g��ɐݒ�
                    light = Lights[3];  //  �F�̃��C�g���i�[
                    break;
                case -1:    //  �F���ʔԍ���-�P�̎�
                    colorText.text = "<color=#00FF7F>Green";    //  ���݂̐F��\������e�L�X�g��΂ɐݒ�
                    light = Lights[2];  //  �ΐF�̃��C�g���i�[
                    break;
            }
        }  
    }
    void SwitchingLight()
    {
        if (Input.GetMouseButtonDown(2))    //  �}�E�X�z�C�[�����N���b�N���ꂽ��
        {
            if (allSelect == false) //  ���C�g���ʑI���̏ꍇ
            {
                for (int i = 1; i < 4; i++) //  �S�Ẵ��C�g����
                {
                    Lights[i].transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f); //  �����l�ɖ߂�
                }
            }
            allSelect = !allSelect; //  ���C�g�̑I����Ԃ𔽓]
        }
        if (allSelect == true)  //  ���C�g���S�I���̏ꍇ
        {
            light = Lights[0];  //  �S���̃��C�g�𓮂������C�g��I��
            colorText.text = "AllColor";    //  ���݂̐F��\������e�L�X�g��S�Ă̐F�ɐݒ�
        }
    }
    void RotateLight()
    {
        //Vector3��X,Y�����̉�]�̓x�������`
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeedY, 0);

        float currentYAngle = transform.eulerAngles.y;
        // ���݂̊p�x��180���傫���ꍇ
        if (currentYAngle % 360 >= 90 && currentYAngle % 360 <= 270 || currentYAngle % 360 <= -90 && currentYAngle % 360 >= -270)
        {
            rotateSpeedY = -2.0f;
        }
        else
        {
            rotateSpeedY = 2.0f;
        }
        //transform.RotateAround()�����悤���đI�����Ă��郉�C�g����]������
        light.transform.RotateAround(transform.position, Vector3.up, angle.x);
        light.transform.RotateAround(transform.position, Vector3.right, -angle.y);
        light.transform.localEulerAngles = new Vector3(light.transform.localEulerAngles.x, light.transform.localEulerAngles.y, 0.0f);
    }
}
