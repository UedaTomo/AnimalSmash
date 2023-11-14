using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class HelthScript : MonoBehaviour
{

    public int playerCount; // 
    public int nowHP;
    public int BossHP = BossScript.currentHp;
    public TextMeshProUGUI HP;
    public TextMeshProUGUI WaitKey;
    public Image VictoryImage;
    public Image LoseImage;
    public GameObject _playerObj;
    public bool result;


    // Start is called before the first frame update
    void Start()
    {
        result = false;
        playerCount = 5;
        HP.text = " x " + playerCount;
        //VictoryImage = GetComponent<Image>();
        //LoseImage = GetComponent<Image>();
        //GameObject VImage = GameObject.Find("VictoryImage");
        //GameObject LImage = GameObject.Find("LoseImage");
    }

    // Update is called once per frame
    void Update()
    {
        nowHP = playerCount;
        if (BossHP <= 0)
        {
            // Debug.Log(VictoryImage);
            //Color newColor = VictoryImage.color;
            //newColor.a = 1.0f;
            playerCount = nowHP;
            //VictoryImage.color = newColor;

            if (Input.GetKey("joystick button 1")||Input.GetKey("joystick button 2")||Input.GetKey("joystick button 3")||Input.GetKey("joystick button 4")||(Input.GetKeyDown(KeyCode.Space)))
            {
                SceneManager.LoadScene("title");
            }
            //VictoryImage.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
        }
        //if(playerCount > 0)
        //{
        //    Time.timeScale = 0f;
        //}

    }

    public void IsGameover()
    {
        //Color newColor = LoseImage.color;
        //newColor.a = 1.0f;
        //LoseImage.color = newColor;
        Debug.Log("ok");
        //LoseImage.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
        WaitKey.text = "<Push B to Title>";

        if (Input.GetKey("joystick button 1")||Input.GetKey("joystick button 2")|| Input.GetKey("joystick button 3")||Input.GetKey("joystick button 4")||(Input.GetKeyDown(KeyCode.Space)))
        {
            SceneManager.LoadScene("title");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            if (playerCount > 0)
            {

                playerCount -= 1;
                HP.text = " x " + playerCount;

            }
        }

        if (playerCount <= 0)
        {
            SceneManager.LoadScene("LoseResult");
            //IsGameover();
            //_playerObj.GetComponent<PlayerScript>().GameClear();
        }
    }
}