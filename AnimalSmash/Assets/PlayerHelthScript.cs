using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerHelthScript : MonoBehaviour
{
    public int playerCount; // écã@êî
    public TextMeshProUGUI PlayerHelth;
    public TextMeshProUGUI GameOver;
    // Start is called before the first frame update
    void Start()
    {
        playerCount = 5;
        PlayerHelth.text = "" + playerCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IsFailed()
    {
        playerCount -= 1;
        PlayerHelth.text = "" + playerCount;

        if (playerCount <= 0)
        {

            GameOver.text = "ë∫ÇéÁÇÍÇ»Ç©Ç¡ÇΩ...";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            IsFailed();

        }
    }
}