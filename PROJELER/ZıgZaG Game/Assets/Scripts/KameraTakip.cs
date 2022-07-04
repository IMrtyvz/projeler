using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform topKonumu;
    Vector3 fark;
    void Start()
    {
        fark= transform.position - topKonumu.position;
    }
    void Update()
    {
        if (TopHareketi.topDustuMu == false)
        {
            transform.position = topKonumu.position + fark;
        }
    }
}
