using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonenBuyukCember : MonoBehaviour
{
    #region Attribute
    public float hiz;

    #endregion

    #region Unity Functions
    void Start()
    {

    }


    void Update()
    {
        transform.Rotate(0,0,hiz*Time.deltaTime);
    }

    #endregion

    #region Mine Functions

    #endregion
}
