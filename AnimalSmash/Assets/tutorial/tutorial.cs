using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorial : MonoBehaviour
{
    public bool CountDownStart;
    public bool AblePlay;
    public TextMeshProUGUI UpText;
    public TextMeshProUGUI RightText;
    public TextMeshProUGUI Player;
    public GameObject moveEx;
    public GameObject AimEx;

    private float TIME;//�n�܂��Ă���̎���
    private float ablemove;
    private bool ableaim;
    private bool aimFrag;

    // Start is called before the first frame update
    void Start()
    {
        TIME = 0f;
        ablemove = 0f;
        CountDownStart = false;
        AblePlay = false;
        ableaim = false;
        aimFrag = true;

        UpText.text = "";
        RightText.text = "";
        Player.text="";
        moveEx.SetActive(false);
        AimEx.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Transform moveex = moveEx.transform;

        TIME += Time.deltaTime;

        //�ŏ���6�b�̓A�j���[�V����

        if (TIME <= 6 && TIME <= 7)//�v���C���[�̐���
        {
            Player.text="�v���C���[";
        }
        if (TIME >= 8 && TIME <= 9)//�ړ�����
        {
            Player.enabled = false;
            UpText.text = "�ړ����Ă݂悤";
            //RightText.text = "�ړ����@";
            moveEx.SetActive(true);
            AblePlay = true;
        }
        if (TIME >= 10)
        {
            if (Input.GetAxis("Horizontal")>0 || Input.GetAxis("Vertical") >0|| //�ړ�����������
                Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                ablemove++;
            }
        }
        if (ablemove > 10)
        {
            UpText.text = "nice!";
            ableaim = true;
        }
        if (ableaim == aimFrag)
        {
            TIME = 0f;
            aimFrag= false;
        }
        if (!aimFrag && TIME >= 2)
        {
            moveex.localPosition = new Vector3(-471, 171, 0);
            moveex.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            UpText.text = "�����X�^�[�����܂����I�ł��Ԃ��Ă݂܂��傤�I";
            AimEx.SetActive(true);
        }

    }
}
