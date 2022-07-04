using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminSpawner : MonoBehaviour
{
    /* 
    zemin spawnlarken son zeminimizin sonuna olusturup eklememiz gerekmektedir bunun icinde son zemini bilmemiz gerekmektedir.
    */
    public GameObject son_zemin;


    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            zemin_oluþtur();
        }
    }
    void Update()
    {
        
    }
    /// <summary>
    /// bulundugumuz zeminden ayrildigimiz zaman yeni bir zemin veya surekli olarak zemin olusturmasini isteyebilecegimiz fonksiyonumuz
    /// </summary>
    int sayi = 1;
    public void zemin_oluþtur()
    {   /* 
         olusturulacak zemini son zeminin ilerisine mi yoksa soluna mi olacaginin randomlugunu belirlemeliyiz. 
         */
        Vector3 yön;
        if (Random.Range(0,2)==0)// 0 ile 2 arasind yani 0 ve 1 seceneklerinden secilen deger 0 ise 
        {
            yön = Vector3.left;
        }
        else
        {
            yön = Vector3.forward;
        }

        // obje spawnlamak icin Instantiate komutu kullanilmaktadir.
        son_zemin=Instantiate(son_zemin, son_zemin.transform.position + yön , son_zemin.transform.rotation);
        // olusan bu yeni zemin artik bizlerin son zemin objesi haline gelmektedir.
        son_zemin.transform.name = "Zemin" + sayi;
        sayi++;
    }
}
