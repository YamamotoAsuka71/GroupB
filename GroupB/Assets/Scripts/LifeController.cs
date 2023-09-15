using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeController : MonoBehaviour
{
    int life = 3;
    public GameObject[] Lifes = new GameObject[3];
    public GameObject text;
    TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("life", life);
        PlayerPrefs.Save();
        Text = text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        life = PlayerPrefs.GetInt("life", 0);
        if (life == 2)
        {
            Lifes[2].SetActive(false);
        }
        if (life == 1)
        {
            Lifes[1].SetActive(false);
        }
        if (life <= 0)
        {
            Debug.Log("END");
            Time.timeScale = 0;
            Text.text = "<color=#0000ff>GAME OVER";
        }
    }
}
