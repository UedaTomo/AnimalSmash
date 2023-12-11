using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI countdown;
    public GameObject advice;
    public bool start;

    private float CountDownTime;
    private float TIME;

    // Start is called before the first frame update
    void Start()
    {
        CountDownTime = 4.0f;
        start = false;

        advice.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        TIME += Time.deltaTime;

        if (TIME >= 8 || Input.GetKey(KeyCode.S))
        {
            TIME = 8.0f;
            advice.SetActive(false);

            CountDownTime -= Time.deltaTime;
            countdown.text = "" + (int)CountDownTime;

            if (CountDownTime < 1)
            {
                countdown.text = "Go!";
                start = true;
            }
            if (CountDownTime < 0)
            {
                countdown.text = "";
            }
        }
    }
}