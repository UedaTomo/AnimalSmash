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

    private float TIME;//�n�܂��Ă���̎���

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

        //�ŏ���4�b�̓A�j���[�V����

        if (TIME <= 4 && TIME <= 6)//�v���C���[�̐���
        {
            firstEx.SetActive(true);
        }
        if (TIME <= 7 && TIME <= 8)//�ړ�����
        {
            firstEx.SetActive(false);
            UpText.text = "���ǂ����Ă݂悤";
            RightText.text = "���ǂ��ق��ق�";
            moveEx.SetActive(true);
        }

    }
}
