using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{
    const float defaultLength = 5f;   //  ���C�g�̓����蔻��̍ő�(�ŏ�)�̑傫��
    float distance; //  �I�u�W�F�N�g���烉�C�g�̎����Ăɓ����镔���܂ł̋���
    float percentage;   //  ���C�g�̓����蔻����ς��邽�߂̔䗦
    private bool isColliding = false;   //  ���C�g�����̃I�u�W�F�N�g�ɓ������Ă��邩�̃t���O
    public bool GetIsColliding() { return isColliding; }
    public void SetIsColliding(bool collision) { isColliding = collision; }
    private GameObject obj; //  �������Ă���I�u�W�F�N�g���Q�Ƃ��邽�߂Ɋi�[����ϐ�
    public void SetObj(GameObject obj) { this.obj = obj; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (obj == null)    //  �I�u�W�F�N�g���i�[����Ă��Ȃ��Ȃ�(���C�g�ɂȂɂ��������Ă��Ȃ����)
        {
            isColliding = false;    //  �������Ă��Ȃ��Ƃ���
        }
        if (isColliding == true)    //  �������������Ă���Ȃ��
        {
            Debug.Log("a");
            distance = (obj.transform.position - transform.position).magnitude; //  ���C�g�̎����Ăɓ����镔�����瑼�̃I�u�W�F�N�g�܂ł̋������v�Z
            percentage = distance / defaultLength;  //  �����Ƃ��Ƃ��Ƃ̒������瓖���蔻��̔䗦���v�Z
            transform.localScale = new Vector3(1.0f * percentage, 1.0f * percentage, 1.0f * percentage);    //  �����蔻��̑傫����ς���
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);   //  �����蔻��̑傫�������ɖ߂�
        }
        if (distance > defaultLength)   //  ��������{�̒�������������
        {
            isColliding = false;    //  �������Ă��Ȃ��Ƃ���
        }
        if (transform.localScale.x > 1.0f || transform.localScale.y > 1.0f || transform.localScale.z > 1.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);   //  �����蔻��̑傫�������ɖ߂�
        }
    }
}
