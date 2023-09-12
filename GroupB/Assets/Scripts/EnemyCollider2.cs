using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollider2 : MonoBehaviour
{
    bool isInvincible = true, isDestroy = false;    //  ���G��Ԕ��ʗp�Ɣj��\�����ʂ���ϐ�
    int timerCount = 0; //  �t���[���v���p
    public GameObject Rotate;   //  ��]����I�u�W�F�N�g
    bool isGreen = false, isBlue = false, isRed = false;    //  �e�F�̏Փ˔���
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rotate != null) //  ��]����I�u�W�F�N�g�������
        {
            isInvincible = true;    //  ���G�ɂ���
        }
        else
        {
            isInvincible = false;   //  ���G��Ԃ�����
        }
        if (gameObject.tag == "Cyan")   //  ���̃v���O�������A�^�b�`����Ă���I�u�W�F�N�g�̃^�O��Cyan�Ȃ�
        {
            if (isGreen == true && isBlue == true && isRed == false)    //  �΂Ɛ̃��C�g�������������Ă���ꍇ
            {
                isDestroy = true;   //  �j��\�ɂ���
            }
        }
        if (gameObject.tag == "Yellow") //  ���̃v���O�������A�^�b�`����Ă���I�u�W�F�N�g�̃^�O��Yellow�Ȃ�
        {
            if (isGreen == true && isRed == true && isBlue == false)    //  �΂ƐԂ̃��C�g�������������Ă���ꍇ
            {
                isDestroy = true;   //  �j��\�ɂ���
            }
        }
        if (gameObject.tag == "Magenta")    //  ���̃v���O�������A�^�b�`����Ă���I�u�W�F�N�g�̃^�O��Magenta�Ȃ�
        {
            if (isGreen == false && isRed == true && isBlue == true)    //  �ԂƐ̃��C�g�������������Ă���ꍇ
            {
                isDestroy = true;   //  �j��\�ɂ���
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (isInvincible == false)  //  ���G��ԂłȂ��Ȃ�
        {
            if (other.tag == "Red") //  �������Ă���I�u�W�F�N�g�̃^�O��Red�̏ꍇ
            {
                isRed = true;   //  �ԐF�̃��C�g���������Ă���Ƃ���
            }
            else if (other.tag == "Green")  //  �������Ă���I�u�W�F�N�g�̃^�O��Green�̏ꍇ
            {
                isGreen = true; //  �ΐF�̃��C�g���������Ă���Ƃ���
            }
            else if (other.tag == "Blue")   //  �������Ă���I�u�W�F�N�g�̃^�O��Blue�̏ꍇ
            {
                isBlue = true;  //  �F�̃��C�g���������Ă���Ƃ���
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Green")   //  ���ꂽ�I�u�W�F�N�g�̃^�O��Green�Ȃ�
        {
            isGreen = false;    //  �ΐF�̃��C�g���������Ă��Ȃ��Ƃ���
        }
        if (other.tag == "Red") //  ���ꂽ�I�u�W�F�N�g�̃^�O��Red�Ȃ�
        {
            isRed = false;  //  �ԐF�̃��C�g���������Ă��Ȃ��Ƃ���
        }
        if (other.tag == "Blue")    //  ���ꂽ�I�u�W�F�N�g�̃^�O��Blue�Ȃ�
        {
            isBlue = false; //  �F�̃��C�g���������Ă��Ȃ��Ƃ���
        }
    }

    private void FixedUpdate()
    {
        if (isDestroy == true)  //  �j��\�Ȃ�
        {
            timerCount++;   //  �t���[�����v������
            if (timerCount == 20)   //  �t���[����20�̎�
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
