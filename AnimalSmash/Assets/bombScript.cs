using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    public GameObject RedZone;
    public Transform[] BossAttackPoint;
    public Transform BossPoint;
    public float speed = 1.0f;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        Throw();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Throw()
    {
        int randomIndex = Random.Range(0, BossAttackPoint.Length);
        Transform ThrowBomb = BossAttackPoint[randomIndex];//爆弾を落とす位置をランダムに選択
        distance = Vector3.Distance(BossPoint.position, ThrowBomb.position);
        float interpolatedValue = (Time.time * speed) / distance;                     //二点の距離
        transform.position = Vector3.Slerp(BossPoint.position, ThrowBomb.position, interpolatedValue);  //
    }
}
