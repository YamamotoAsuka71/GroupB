using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{
    const float defaultLength = 9.5f;
    const float defaultDiameter = 4f;
    float distance;
    float percentage;
    private bool isColliding = false;
    public bool GetIsColliding() { return isColliding; }
    public void SetIsColliding(bool collision) { isColliding = collision; }
    private GameObject obj;
    //public bool GetObj() { return obj; }
    public void SetObj(GameObject obj) { this.obj = obj; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding == true)
        {
            distance = (obj.transform.position - transform.position).magnitude;
            percentage = distance / defaultLength;
            transform.localScale = new Vector3(1.0f * percentage, 1.0f * percentage, 1.0f * percentage);
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if (distance > defaultLength)
        {
            isColliding = false;
        }

    }
}
