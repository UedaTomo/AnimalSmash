using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float move = 0.01f;
    public float Up = -6.0f;
    public float Down = 0f;
    public float UpDown = 0.1f;
    public GameObject obj;
    public GameObject result;

    public ParticleSystem particle;

    PauseScript pausescript;
    ResultScript resultscript;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Player");
        pausescript = obj.GetComponent<PauseScript>();

        result = GameObject.Find("Result");
        resultscript = result.GetComponent<ResultScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pausescript.enemy_pause)
        {
            Vector3 position = new Vector3(0, Down, move);
            transform.Translate(position);
        }

        if(resultscript.FIN)
        {
            // �p�[�e�B�N���V�X�e���̃C���X�^���X�𐶐�����B
            ParticleSystem newParticle = Instantiate(particle);
            // �p�[�e�B�N���̔����ꏊ�����̃X�N���v�g���A�^�b�`���Ă���GameObject�̏ꏊ�ɂ���B
            newParticle.transform.position = this.transform.position;
            // �p�[�e�B�N���𔭐�������B
            newParticle.Play();
            // �C���X�^���X�������p�[�e�B�N���V�X�e����GameObject��5�b��ɍ폜����B(�C��)
            // ����������newParticle�����ɂ���ƃR���|�[�l���g�����폜����Ȃ��B
            Destroy(newParticle.gameObject, 0.5f);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destroy"))
        {
            Destroy(gameObject);
        }
    }
}

