using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI countdown;
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