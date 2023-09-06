using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{

    private GameObject mainCamera;              //���C���J�����i�[�p
    public float rotateSpeed = 2.0f;


    float x;
    float z;
    float moveSpeed = 2.0f;
    Rigidbody rb;
    //�Ăяo�����Ɏ��s�����֐�
    void Start()
    {
        //���C���J�����ƃv���C���[�����ꂼ��擾
        mainCamera = Camera.main.gameObject;
       
    }


    //�P�ʎ��Ԃ��ƂɎ��s�����֐�
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //rotateCamera�̌Ăяo��
            rotateCamera();
        }
        MoveCamera();
    }

    //�J��������]������֐�
    private void rotateCamera()
    {
        //Vector3��X,Y�����̉�]�̓x�������`
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        //transform.RotateAround()�����悤���ă��C���J��������]������
        mainCamera.transform.RotateAround(mainCamera.transform.position, Vector3.up, angle.x);
        mainCamera.transform.RotateAround(mainCamera.transform.position, Vector3.right, -angle.y);
        mainCamera.transform.localEulerAngles = new Vector3(mainCamera.transform.localEulerAngles.x, mainCamera.transform.localEulerAngles.y, 0.0f);
    }

    void MoveCamera()
    {
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
        {
            var direction = Quaternion.Euler(mainCamera.transform.eulerAngles) * Vector3.forward;
            transform.position += new Vector3(direction.x, 0, direction.z) * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            var direction = Quaternion.Euler(mainCamera.transform.eulerAngles) * Vector3.back;
            transform.localPosition += new Vector3(direction.x, 0, direction.z) * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            var direction = Quaternion.Euler(mainCamera.transform.eulerAngles) * Vector3.left;
            transform.localPosition += new Vector3(direction.x, 0, direction.z) * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            var direction = Quaternion.Euler(mainCamera.transform.eulerAngles) * Vector3.right;
            transform.localPosition += new Vector3(direction.x, 0, direction.z) * moveSpeed * Time.deltaTime;
        }
    }
}
