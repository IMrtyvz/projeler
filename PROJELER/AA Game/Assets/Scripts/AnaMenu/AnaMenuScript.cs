using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnaMenuScript : MonoBehaviour
{
    /*
     sahneden sahneye ge�i� kodlarini kullanacagimiz paket unity scriptleri icerisinde
    farkli bir pakette yer almaktadir. bu paket SceneManagement paketidir.
     */

    #region Attribute


    #endregion

    #region Unity Functions
  

    #endregion

    #region Mine Functions
    public void oynaButonu()
    {
        // y�klemek istedigimiz sahnenein numarasini giriyoruz
        SceneManager.LoadScene(1); //1 numarali sahne oyunEkrani sahnesi
    }
    #endregion
}
