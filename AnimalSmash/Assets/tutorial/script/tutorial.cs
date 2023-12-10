using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class tutorial : MonoBehaviour
{
    public bool CountDownStart;
    public bool AblePlay;
    public bool AbleSpawn;
    public TextMeshProUGUI UpText;
    public TextMeshProUGUI RightText;
    public TextMeshProUGUI Esc;
    public GameObject moveEx;
    public GameObject AimEx;
    public GameObject Player;

    private float TIME;//�n�܂��Ă���̎���
    private float time;
    private float ablemove;
    private bool ableaim;
    private bool aimFrag;

    public GameObject obj;
    tutorialBoss Tutorialboss;


    // Start is called before the first frame update
    void Start()
    {
        TIME = 0f;
        time = 0f;
        ablemove = 0f;
        CountDownStart = false;
        AblePlay = false;
        AbleSpawn = false;

        ableaim = false;
        aimFrag = true;

        UpText.text = "";
        RightText.text = "";
        Player.SetActive(false);
        moveEx.SetActive(false);
        AimEx.SetActive(false);

       obj = GameObject.Find("Boss_koya");
       Tutorialboss = obj.GetComponent<tutorialBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }

        Transform moveex = moveEx.transform;

        TIME += Time.deltaTime;

        //�ŏ���6�b�̓A�j���[�V����

        if (!ableaim && TIME <= 6 && TIME <= 7)//�v���C���[�̐���
        {
            Player.SetActive(true);
            UpText.text = "���ꂪ���Ȃ��ł�";
        }
        if (!ableaim && TIME >= 8 && TIME <= 9)//�ړ�����
        {
            Player.SetActive(false);
            UpText.text = "�ړ����Ă݂悤";
            moveEx.SetActive(true);
            AblePlay = true;
        }
        if (!ableaim && TIME >= 10)
        {
            if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0 || //�ړ�����������
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
            aimFrag = false;
        }
        if (!aimFrag && TIME >= 2)
        {
            AbleSpawn = true;
            moveex.localPosition = new Vector3(-471, 171, 0);
            moveex.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            UpText.text = "�����X�^�[�����܂����I\n�ł��Ԃ��Ă݂܂��傤�I";
            AimEx.SetActive(true);
        }
        if (Tutorialboss.HitNum >= 3.0f)
        {
            time += Time.deltaTime;
            UpText.text = "good!\n";
        }

        if (time >= 2)
        {
            Esc.text = "";
            UpText.text = "�ł͂ނ�����ɂ����܂��傤�I\n���j���[�ɂ��ǂ�ɂ�Esc�������Ă�������";
        }

    }
}
