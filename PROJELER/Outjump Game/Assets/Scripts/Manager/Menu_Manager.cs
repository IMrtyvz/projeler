#region Library
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// sahne islemleri yapmak icin eklememiz gereken kutuphane
using UnityEngine.SceneManagement;
#endregion

public class Menu_Manager : MonoBehaviour
{
    #region Attribute

    #endregion

    #region Unity Functions 
    #endregion

    #region Functions 
    /// <summary>
    /// Oyunu baslatma icin gerekli fonksiyon
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    #endregion

    /* 
    #region Library
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    #endregion
   
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

    #region Functions   
    #endregion

    */

}
