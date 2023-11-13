using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class HelthScript : MonoBehaviour
{
    public int playerCount; // écã@êî
    public TextMeshProUGUI HP;
    public TextMeshProUGUI GameOver;
    public TextMeshProUGUI GameOverComment;
    public TextMeshProUGUI WaitKey;
    public GameObject _playerObj;
    // Start is called before the first frame update
    void Start()
    {
        playerCount = 5;
        HP.text = "Å~ " + playerCount;
    }

    // Update is called once per frame
    void Update()
    {
        //if(playerCount > 0)
        //{
        //    Time.timeScale = 0f;
        //}
    }

    public void IsGameover()
    {
        GameOver.text = "Game Over";
        GameOverComment.text = "you couldn't protect the village ...";
        WaitKey.text = "<Push B to Title>";

        if (Input.GetKey("joystick button 1") || Input.GetKey("joystick button 2") || Input.GetKey("joystick button 3") || Input.GetKey("joystick button 4"))
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
                    HP.text = "Å~ " + playerCount;

            }
        }

        if (playerCount <= 0)
        {
            IsGameover();
            _playerObj.GetComponent<PlayerScript>().GameClear();
        }
    }
}
