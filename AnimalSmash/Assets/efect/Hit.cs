using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    float _hitTime = 0.0f;
    public float _destroy = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _hitTime += Time.deltaTime;
        if (_hitTime > _destroy)
            Destroy(gameObject);
    }
}
