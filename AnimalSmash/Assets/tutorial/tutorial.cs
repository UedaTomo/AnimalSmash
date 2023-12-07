using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorial : MonoBehaviour
{
    public bool CountDownStart;
    public TextMeshProUGUI UpText;
    public TextMeshProUGUI RightText;
    public GameObject firstEx;
    public GameObject moveEx;

    private float TIME;//始まってからの時間

    // Start is called before the first frame update
    void Start()
    {
        TIME = 0f;

        UpText.text = "";
        RightText.text = "";
        firstEx.SetActive(false);
        moveEx.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TIME += Time.deltaTime;

        //最初の4秒はアニメーション

        if (TIME <= 4 && TIME <= 6)//プレイヤーの説明
        {
            firstEx.SetActive(true);
        }
        if (TIME <= 7 && TIME <= 8)//移動説明
        {
            firstEx.SetActive(false);
            UpText.text = "いどうしてみよう";
            RightText.text = "いどうほうほう";
            moveEx.SetActive(true);
        }

    }
}
