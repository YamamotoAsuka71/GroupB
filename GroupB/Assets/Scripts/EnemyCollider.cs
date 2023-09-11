using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    bool isDestroy = false;
    bool isRed = false, isGreen = false, isBlue = false;
    int timerCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Red")
        {
            if (isRed == true && isGreen == false && isBlue == false)
            {
                isDestroy = true;
            }
        }
        if (gameObject.tag == "Green")
        {
            if (isRed == false && isGreen == true && isBlue == false)
            {
                isDestroy = true;
            }
        }
        if (gameObject.tag == "Blue")
        {
            if (isRed == false && isGreen == false && isBlue == true)
            {
                isDestroy = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Red")
        {
            isRed = true;
        }
        if (other.tag == "Green")
        {
            isGreen = true;
        }
        if (other.tag == "Blue")
        {
            isBlue = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Red")
        {
            isRed = false;
        }
        if (other.tag == "Green")
        {
            isGreen = false;
        }
        if (other.tag == "Blue")
        {
            isBlue = false;
        }
    }
    private void FixedUpdate()
    {
        if(isDestroy == true)
        {
            timerCount++;
            if (timerCount == 20)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            timerCount = 0;
        }
    }
}
