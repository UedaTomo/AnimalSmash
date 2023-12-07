using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownScript : MonoBehaviour
{
    public TextMeshProUGUI CountDown;
    public bool start;

    private float CountDownTime;

    // Start is called before the first frame update
    void Start()
    {
        CountDownTime = 4.0f;
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        CountDownTime -= Time.deltaTime;
        CountDown.text = "" + (int)CountDownTime;

        if (CountDownTime < 1)
        {
            CountDown.text = "Go!";
            start = true;
        }
        if (CountDownTime < 0)
        {
            CountDown.text = "";
        }
    }
}