using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    bool isDestroy = false; //  �j�󂷂邩�ǂ������ʂ���
    bool isRed = false, isGreen = false, isBlue = false;    //  �e���C�g�̏Փ˔�����s���t���O
    int timerCount = 0; //  �t���[���v���p�ϐ�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Red")    //  ���̃v���O�������A�^�b�`����Ă���I�u�W�F�N�g�̃^�O��Red��������
        {
            if (isRed == true && isGreen == false && isBlue == false)   //  �ԐF�̃��C�g�������������Ă���ꍇ
            {
                isDestroy = true;   //  �j��\�ɂ���
            }
        }
        if (gameObject.tag == "Green")  //  ���̃v���O�������A�^�b�`����Ă���I�u�W�F�N�g�̃^�O��Green��������
        {
            if (isRed == false && isGreen == true && isBlue == false)   //  �ΐF�̃��C�g�������������Ă���ꍇ
            {
                isDestroy = true;   //  �j��\�ɂ���
            }
        }
        if (gameObject.tag == "Blue")   //  ���̃v���O�������A�^�b�`����Ă���I�u�W�F�N�g�̃^�O��Blue��������
        {
            if (isRed == false && isGreen == false && isBlue == true)   //  �F�̃��C�g�������������Ă���ꍇ
            {
                isDestroy = true;   //  �j��\�ɂ���
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Red") //  �������Ă���I�u�W�F�N�g�̃^�O��Red�������ꍇ
        {
            isRed = true;   //  �ԐF�̃��C�g���������Ă���Ƃ���
        }
        if (other.tag == "Green")   //  �������Ă���I�u�W�F�N�g�̃^�O��Green�������ꍇ
        {
            isGreen = true; //  �ΐF�̃��C�g���������Ă���Ƃ���
        }
        if (other.tag == "Blue")    //  �������Ă���I�u�W�F�N�g�̃^�O��Blue�������ꍇ
        {
            isBlue = true;  //  �F�̃��C�g���������Ă���Ƃ���
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Red") //  ���ꂽ�I�u�W�F�N�g�̃^�O��Red�������ꍇ
        {
            isRed = false;  //  �ԐF�̃��C�g���������Ă��Ȃ��Ƃ���
        }
        if (other.tag == "Green")   //  ���ꂽ�I�u�W�F�N�g�̃^�O��Green�������ꍇ
        {
            isGreen = false;    //  �ΐF�̃��C�g���������Ă��Ȃ��Ƃ���
        }
        if (other.tag == "Blue")    //  ���ꂽ�I�u�W�F�N�g�̃^�O��Blue�������ꍇ
        {
            isBlue = false; //  �F�̃��C�g���������Ă��Ȃ��Ƃ���
        }
    }
    private void FixedUpdate()
    {
        if(isDestroy == true)   //  �j��\�ȏ�Ԃɂ���Ƃ�
        {
            timerCount++;   //  �t���[���v���J�n
            if (timerCount == 20)   //  �t���[������20�̎�
            {
                Destroy(gameObject);    //  ���̃I�u�W�F�N�g��j�󂷂�
            }
        }
        else
        {
            timerCount = 0; //  �v�����Z�b�g
        }
    }
}
