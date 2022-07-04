using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHareketi : MonoBehaviour
{
    /// <summary>
    ///    ileri ya da sola gitmesini belirledigimiz degiskenimiz
    /// </summary>
    Vector3 y�n;
    // karakterimizin hiz degiskenini unity icerisinden g�z karari secebilmek icin 
    // hiz adinda bir parametre olusturduk
    public float speed;
    public ZeminSpawner zeminspwanerScripti;
    /* KameraTakip Scriptinden bu bool'a erisebilmek adina 
     statik tanimlama gerceklestirdik. ve topun d�s�p d�smedigini g�recegiz */
    public static bool topDustuMu;
    /* Her sol tik basildiginda topun hizini cok cok az miktarda artirmak icin*/
    public float eklenecekHiz;

    void Start()
    {
        // topumuzun z ekseninde pozitif hareket etmesini sagladik (varsayilan olarak ileri olarak baslattik)
        y�n = Vector3.forward; 
    }

   public bool TopDustuMu()
    {
        if(gameObject.transform.position.y <= 0.5f)
        {
            Debug.Log("Top Dustu");
            topDustuMu = true;
            return true;
        }
        return false;
    }
    void Update()
    {
        
        if (TopDustuMu())
        {
            return;
            /* 
             Eger top dustu ise 
             bu bosa dondurme ile Update fonksiyonundan cikmayi saglayarak 
             asagidaki kodlarin calismamasini saglamaktayiz   
             */
        }
        if (Input.GetMouseButtonDown(0)) //  mousumuzun 0 yani sol tiki algilandiginda ama down hali ile yani bir kere i�leme sokacagiz
        {
            if (y�n.x==0)
            {
                // y�n�m�z�n x degeri 0 yani z degeri artiyorsa 
                y�n = Vector3.left;
            }
            else
            {
                // y�n�m�z�n x degeri 0 degil ise yani sola gidiyorsa ileri dogru devam etmeli
                y�n = Vector3.forward;
            }
            speed += eklenecekHiz * Time.deltaTime;
            Debug.Log("Yeni Hiz"+speed);
        }
    }
    private void FixedUpdate()
    {
        Vector3 hareket=y�n*Time.deltaTime*speed;
        transform.position += hareket;
    }

    /// <summary>
    /// Temastan ayrilindiginda yani topumuz 
    /// </summary> 
      
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag=="zemin")
        {
            Skor.skor++;
            /* temastan cikilan zemin objemizin dusmesini saglamak icin
                bir rigidbody ekleyelim.             
             */
            collision.gameObject.AddComponent<Rigidbody>();
            // gameObjemiz yani topumuz zemin etiketine ait bir objeden ayrilirsa 
            zeminspwanerScripti.zemin_olu�tur();
            StartCoroutine(ZemininSil(collision.gameObject));
        }

    }

    

    /// <summary>
    /// Bir zeminden temasi kestikten sonra hemen silmek yerine belli bir s�re bekledikten 
    /// sonra silme gerceklestirmek icin kullanilacak fonksiyon.
    /// </summary>
    IEnumerator ZemininSil(GameObject SilinecekZemin)
    {
        yield return new WaitForSeconds(3f);
        // zaman kodu iceren kodlarimiz.
        Destroy(SilinecekZemin);
    }


}
