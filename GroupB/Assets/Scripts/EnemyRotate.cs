using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    public GameObject redEnemy, greenEnemy, blueEnemy;  //  �G���G�Ƃ���ԁA�΁A�̃G�l�~�[���i�[
    GameObject obj, enemy;  //  �q�Ƃ��Đ������邽�߂̕ϐ��Ƃǂ̃G�l�~�[�����ʂ��邽�߂̊i�[�p�ϐ�
    const float POS_Z = -0.3f, POS_X_1 = 0.75f, POS_X_2 = -0.75f;   //  �G�l�~�[�����|�W�V����
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            int randomNum = Random.Range(0, 3); //  �J���[�I��p�̐����������_�����o
            switch (randomNum)
            {
                case 0: //  �O�̎�
                    enemy = redEnemy;   //  ��������G�l�~�[�͐Ԃɂ���
                    break;
                case 1: //  �P�̎�
                    enemy = greenEnemy; //  ��������G�l�~�[�͗΂ɂ���
                    break;
                case 2: //  �Q�̎�
                    enemy = blueEnemy;  //  ��������G�l�~�[�͐ɂ���
                    break;
            }
            if (i == 0) //  ���ڂ̐����̎�
            {
                obj = Instantiate(enemy, new Vector3(transform.position.x + POS_X_1, transform.position.y, transform.position.z + POS_Z), Quaternion.identity); //  �G�l�~�[�̉E���ɐ���
                obj.transform.parent = transform;   //  ���̃v���O�������A�^�b�`����Ă���I�u�W�F�N�g�̎q�Ƃ���
            }
            else
            {
                obj = Instantiate(enemy, new Vector3(transform.position.x + POS_X_2, transform.position.y, transform.position.z + POS_Z), Quaternion.identity); //  �G�l�~�[�̍����ɐ���
                obj.transform.parent = transform;   //  ���̃v���O�������A�^�b�`����Ă���I�u�W�F�N�g�̎q�Ƃ���
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        int ObjCount = transform.childCount;    //  �q�̃I�u�W�F�N�g�̐��𐔂���
        if (ObjCount == 0)  //  ����q�̃I�u�W�F�N�g���Ȃ��ꍇ
        {
            Destroy(gameObject);    //  ���̃I�u�W�F�N�g��j�󂷂�
        }
        transform.Rotate(0.0f, 1.0f, 0.0f); //  ���̃I�u�W�F�N�g����]������
    }
}
