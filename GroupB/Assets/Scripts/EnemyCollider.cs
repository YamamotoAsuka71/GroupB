using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    bool isDestroy = false;
    int timerCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "Red")
        {
            if (other.tag == "Green" || other.tag == "Blue")
            {
                isDestroy = false;
            }
            else if (other.tag == "Red")
            {
                isDestroy = true;
            }
        }
        if (gameObject.tag == "Green")
        {
            if (other.tag == "Red" || other.tag == "Blue")
            {
                isDestroy = false;
            }
            else if (other.tag == "Green")
            {
                isDestroy = true;
            }
        }
        if (gameObject.tag == "Blue")
        {
            if (other.tag == "Green" || other.tag == "Red")
            {
                isDestroy = false;
            }
            else if (other.tag == "Blue")
            {
                isDestroy = true;
            }
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
