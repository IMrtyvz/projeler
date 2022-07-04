using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucukCubuk : MonoBehaviour
{
    #region Attribute
    Rigidbody2D rb;
    // yukari gidis hizini denetlemek icin 
    public float hiz;

    public bool hareketKisitliMi;

    //
    public GameObject yönetici;

    public static bool oyunBitti;
    #endregion

    #region Unity Functions
    void Start()
    {
        yönetici = GameObject.FindGameObjectWithTag("Yonetici");
        rb = GetComponent<Rigidbody2D>(); //rigidbody2d'mizi kod içinden almýþ olduk
    }


    void Update()
    {
        if (hareketKisitliMi==false)
        {
            rb.MovePosition(rb.position + Vector2.up * hiz * Time.deltaTime);
        }
        
    }

    #endregion

    #region Mine Functions
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DonenBuyukCember")
        {
            transform.SetParent(col.transform); // donenBuyukCember etiketli bir objeye temas ettigin zaman artik sen onun childisin dedik.
            hareketKisitliMi = true;
        }
        if (col.gameObject.tag == "KucukCember")
        {
            oyunBitti = true;
            yönetici.GetComponent<OyununSonu>().OyunuBitir();
        }
    }
    #endregion

}
/* 
  #region Attribute


   #endregion

   #region Unity Functions
   void Start()
   {

   }


   void Update()
   {

   }

   #endregion

   #region Mine Functions

   #endregion


 */