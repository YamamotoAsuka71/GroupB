using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hidden : MonoBehaviour
{
    public GameObject Pauze;
    public GameObject Title;
    // Start is called before the first frame update
    void Start()
    {
        Pauze.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Title.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                Pauze.SetActive(true);
            }
        }
    }

    public void OnClick()
    {
        Time.timeScale = 1;
        Pauze.SetActive(false);
    }
    public void OnClick2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
