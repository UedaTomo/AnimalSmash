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
            // パーティクルシステムのインスタンスを生成する。
            ParticleSystem newParticle = Instantiate(particle);
            // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
            newParticle.transform.position = this.transform.position;
            // パーティクルを発生させる。
            newParticle.Play();
            // インスタンス化したパーティクルシステムのGameObjectを5秒後に削除する。(任意)
            // ※第一引数をnewParticleだけにするとコンポーネントしか削除されない。
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

