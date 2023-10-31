using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    [SerializeField] private GameObject _redZone;
    [SerializeField] private Transform _redPoint;
    [SerializeField] private Transform _bossAttackPoint;
    [SerializeField] private Transform _center;
    [SerializeField] private Transform _bossPoint;
    public float speed = 6.0f;
    private float distance;
    [Range(0.0f, 180.0f)] public float arcAngle = 60.0f;
    public float baseHeight = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        _redZone = Instantiate(_redZone, _redPoint.position, _redPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        var frompoint = _bossPoint.position;
        frompoint.y = baseHeight;

        //‰~‚Ì‹O“¹Šp“x‚Ì”¼•ª‚Ìƒ^ƒ“ƒWƒFƒ“ƒg
        var tangentOfHalfAngle = Mathf.Tan(Mathf.Deg2Rad * arcAngle * 0.5f);
        
        distance = Vector3.Distance(_bossPoint.position, _bossAttackPoint.position);
        //float interpolatedValue = (Time.time * speed) / distance;
        float interpolatedValue = speed * Time.deltaTime;
        transform.position = Vector3.Slerp(_bossPoint.position, _bossAttackPoint.position, interpolatedValue);
    }
}
