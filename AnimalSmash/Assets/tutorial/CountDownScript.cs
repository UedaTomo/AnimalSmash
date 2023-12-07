using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownScript : MonoBehaviour
{
    public TextMeshProUGUI CountDown;
    public bool start;
    public GameObject obj;
    tutorial Tutorial;

    private float CountDownTime;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("tutorial");
        Tutorial = obj.GetComponent<tutorial>();

        CountDownTime = 4.0f;
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Tutorial.CountDownStart)
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
}