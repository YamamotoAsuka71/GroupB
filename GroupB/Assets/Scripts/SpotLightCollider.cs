using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightCollider : MonoBehaviour
{
    public GameObject spotLight;    //  �X�|�b�g���C�g�̓����蔻��σv���O�����i�[�p
    SpotLightController spot;
    private void Start()
    {
        spot = spotLight.GetComponent<SpotLightController>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (spot.GetIsColliding() == false) //  �������Ă��Ȃ��Ɣ��ʂ��Ă�����
        {
            spot.SetObj(other.gameObject);  //  �������Ă���I�u�W�F�N�g���i�[
            spot.SetIsColliding(true);  //  �������Ă���Ƃ���
        }
    }
    private void OnTriggerExit(Collider other)
    {
        spot.SetIsColliding(false); //  �������Ă��Ȃ��Ƃ���
    }
}
