using UnityEngine;
using System.Collections;
using System;

public class Delete : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
