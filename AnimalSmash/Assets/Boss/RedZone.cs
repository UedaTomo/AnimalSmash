using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    public GameObject effectPrefab;

    void Start()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        // ‚P‚O‰ñ“_–Å
        for (int i = 0; i < 12; i++)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
        Destroy(gameObject);
    }
}
