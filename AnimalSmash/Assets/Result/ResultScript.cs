using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class ResultScript : MonoBehaviour
{
    BossScript bossscript;
    HelthScript helthscript;

    public GameObject obj;
    public GameObject obj1;
    public Animator Boss_koya;
    public Animator camera;
    public Animator monster;
    //public Animator win_image;
    public bool FIN;
    public bool win;
    public bool lose;
    public bool finish;
    public bool clear;
    public bool camera_move;
    public bool LOSE;
    public AudioClip breaksound;
    public AudioClip shotsound;
    public GameObject clear_image;
    //public TextMeshProUGUI Text;
    AudioSource AS;
    AudioSource AS_1;

    private float clear_TIME;
    private bool finish_Frag;
    private bool win_Frag;

    // Start is called before the first frame update
    void Start()
    {
        finish_Frag = true;
        win_Frag = true;

        FIN = false;
        win = false;
        lose = false;
        finish = false;
        clear = false;
        camera_move = false;
        LOSE = false;

        clear_TIME = 0f;

        obj = GameObject.Find("Boss_koya");
        bossscript = obj.GetComponent<BossScript>();
        obj1 = GameObject.Find("destroyCanvas");
        helthscript = obj1.GetComponent<HelthScript>();

        AS = GetComponent<AudioSource>();
        AS_1 = GetComponent<AudioSource>();

        //clear_image.SetActive(false);
        //Text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        camera.SetBool("finish", camera_move);
        Boss_koya.SetBool("win", win);
        Boss_koya.SetBool("lose", lose);
        Boss_koya.SetBool("finish", finish);
        monster.SetBool("finish", LOSE);
        //win_image.SetBool("clear", clear);

        if (bossscript.Clear)
        {
            FIN = true;
            clear_TIME += Time.deltaTime;
            finish = true;
            camera_move = true;
            
            if(finish==finish_Frag)
            {
                AS.PlayOneShot(breaksound);
                finish_Frag = false;
            }
            if(clear_TIME>1.0f)
            {
                //AS.Pause();
                finish = false;
                win = true;
            }
            if (clear_TIME > 1.5f)
            {
                if (win == win_Frag)
                {
                    AS_1.PlayOneShot(shotsound);
                    win_Frag = false;
                }
            }
            if(clear_TIME>2.5f)
            {
                AS.Pause();
                //win = false;
                //clear_image.SetActive(true);
                clear = true;
            }
            if(clear_TIME>4.0f)
            {
                //Text.text = "Aをおしてスコアをみる";
                //clear_image.SetActive(true);
                SceneManager.LoadScene("WinResult");

            }
        }
        if(helthscript.Lose)
        {
            LOSE = true;
            clear_TIME += Time.deltaTime;

            if (clear_TIME > 2.0f)
            {
                SceneManager.LoadScene("LoseResult");
            }
        }

        /*if (clear && Input.GetKey(KeyCode.A))
        {
            SceneManager.LoadScene("WinResult");
        }*/
    }
}
