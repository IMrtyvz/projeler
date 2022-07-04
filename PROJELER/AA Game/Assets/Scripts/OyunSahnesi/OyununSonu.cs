using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyununSonu : MonoBehaviour
{

    #region Attribute
    public GameObject DonenBuyukCember;
    public GameObject SpawnLokasyonu;

   
    #endregion

    #region Unity Functions
  
    #endregion

    #region Mine Functions
    public void OyunuBitir()
     {
        DonenBuyukCember.GetComponent<DonenBuyukCember>().enabled = false;
        SpawnLokasyonu.GetComponent<KucukCubukSpawner>().enabled = false;
        
     }
    #endregion


    
}
