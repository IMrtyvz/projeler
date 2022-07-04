using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucukCubukSpawner : MonoBehaviour
{
    /* bir objeyi spawnlayacaksak o objenin prefab olmasi gerekiyor  */

    #region Attribute
    // prefab objemize ulasmak adina
    public GameObject kucukCubuk;
    private bool lck;
    public float gecikmeSuresi=0.5f;
   #endregion

    #region Unity Functions

    void Update()
   {
        if (Input.GetMouseButtonDown(0)) //sol tik basilirsa
        {
            KucukCubukSpawn();
        }
   }

   #endregion

   #region Mine Functions
    void KucukCubukSpawn()
    {
        // kodun sahibi objenin (spwanlokasyonu) transform position ve rotationlarini verdik.
        //spwanlanacak obje, spawnlanacagi pozisyon, spwanlanacagi rotasyon
        if (!lck)
        {
            Instantiate(kucukCubuk, transform.position, transform.rotation);
            lck = true;
            Invoke("AntiLocker", gecikmeSuresi);
        }
       
    }
   #endregion
    void AntiLocker() => lck = false;
    
}
