using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraAnimasyon : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim=GetComponent<Animator>();
    }
    private void Update()
    {
        if (KucukCubuk.oyunBitti == true)
        {
            anim.SetBool("OyunBitti", true);
        }
    }
}
