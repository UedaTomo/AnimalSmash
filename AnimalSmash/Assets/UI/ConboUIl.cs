using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConboUIl : MonoBehaviour
{
    public TextMeshProUGUI gameing;

    void Start()
    {

    }

    void Update()
    {
        gameing.color = Color.HSVToRGB(Time.time % 1, 1, 1);
    }
}
