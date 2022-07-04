using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    /* 
    Ilk olarak topumuzun rigidbody'sini almamiz gerekmektedir.
    çünkü topumuzun ziplamasini saglamamiz gerekmektedir.
     
     */
    #region Attribute
    public Rigidbody rb;

    public GameObject splashPrefab;
    private GameManager gm;

    /// <summary>
    /// ziplama kuvveti
    /// </summary>
    public float jumpForce; //ziplama kuvveti
    
    #endregion

    void Start()
    {
        gm=GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*topumuz carpistigi anda tetiklenmesini istedigimiz icin sekme ziplama fonksiyonu, onun icin OnCollision */
    private void OnCollisionEnter(Collision collision)
    {  
        rb.AddForce(Vector3.up * jumpForce);
        GameObject splash=Instantiate(splashPrefab,transform.position+new Vector3(0f,-0.2f,0f),transform.rotation);
        splash.transform.SetParent(collision.gameObject.transform);
        /* 
         çarpýlan objenin materyal ismini her seferinde alacagiz 
                     
         */
        string materialName=collision.gameObject.GetComponent<MeshRenderer>().material.name;
        Debug.Log("Materyal Adi: "+materialName);
        if (materialName== "Unsafe Color (Instance)")
        {
            // bolum yeniden baslayacak
            gm.RestartGame();
        }
        else if (materialName== "Last Ring (Instance)")
        {
            // Bir sonraki levele gecilecek
            Debug.Log("Next Level");
        }
    }
}
