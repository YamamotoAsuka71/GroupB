using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{

    private GameObject mainCamera;              //メインカメラ格納用
    public float rotateSpeed = 2.0f;


    float x;
    float z;
    float moveSpeed = 2.0f;
    Rigidbody rb;
    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとプレイヤーをそれぞれ取得
        mainCamera = Camera.main.gameObject;
       
    }


    //単位時間ごとに実行される関数
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //rotateCameraの呼び出し
            rotateCamera();
        }
        MoveCamera();
    }

    //カメラを回転させる関数
    private void rotateCamera()
    {
        //Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        //transform.RotateAround()をしようしてメインカメラを回転させる
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
