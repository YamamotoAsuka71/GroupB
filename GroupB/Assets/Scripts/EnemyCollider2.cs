using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollider2 : MonoBehaviour
{
    bool isInvincible = true, isDestroy = false;
    int timerCount = 0;
    public GameObject Rotate;
    bool isGreen = false, isBlue = false, isRed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rotate != null)
        {
            isInvincible = true;
        }
        else
        {
            isInvincible = false;
        }
        if (gameObject.tag == "Cyan")
        {
            if (isGreen == true && isBlue == true && isRed == false)
            {
                isDestroy = true;
            }
        }
        if (gameObject.tag == "Yellow")
        {
            if (isGreen == true && isRed == true && isBlue == false)
            {
                isDestroy = true;
            }
        }
        if (gameObject.tag == "Magenta")
        {
            if (isGreen == false && isRed == true && isBlue == true)
            {
                isDestroy = true;
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (isInvincible == false)
        {
            if (other.tag == "Red")
            {
                isRed = true;
            }
            else if (other.tag == "Green")
            {
                isGreen = true;
            }
            else if (other.tag == "Blue")
            {
                isBlue = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Green")
        {
            isGreen = false;
        }
        if (other.tag == "Red")
        {
            isRed = false;
        }
        if (other.tag == "Blue")
        {
            isBlue = false;
        }
    }

    private void FixedUpdate()
    {
        if (isDestroy == true)
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
