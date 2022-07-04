#region Library
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion
#region Class
public class Ball_Controller : MonoBehaviour
{
    #region Attribute
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float mouseClickDelay;
    [SerializeField] private GameManager gameManager;
    private BoxCollider x;
    private bool canJump =true;
    #endregion


    #region Unity Func
    void Start()
    {
        
    }
    void Update()
    {
        // varsayilan olarak serbest halde saga sola gitmesi icin
        idleMove();
        //bir kez mouse'un sol tikina basildiginda yukari ziplamasi icin
        
        //
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            rb.velocity = Vector3.up * jumpPower;
            canJump = false;
            Invoke("Lck", mouseClickDelay);
            // bir defa true'ya donecek degisken baska yerde yazilabilir mi
            gameManager.isStart = true;
        }
        
    }
    #endregion

    #region My Func
    void Lck() => canJump = true; 
    /// <summary>
    /// varsayilan olarak serbest halde saga sola gitmesine izin veren fonksiyon
    /// Z ekseninde hareket ettirmeye karr verilirse ona gore editlenmeli
    /// </summary>
    void idleMove()
    {
        if (gameManager.isComplete == false)
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
        }
        
    }
    private void OnCollisionEnter(Collision coll)
    {
        /* carpilan objenin etiketi Short Edge ise */
        if(coll.gameObject.CompareTag("Short Edge"))
        {
            moveSpeed *= -1; //yonu zit degistir
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Long Edge"))
        {
            other.GetComponent<BoxCollider>().isTrigger = false;
            //other.gameObject.GetComponent<Transform>().tag = "Long Edge 2";
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {   // puan verecek objemize carptigimizda obje yok olacak
        if (other.gameObject.CompareTag("Point"))
        {
            gameManager.point++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            gameManager.LevelUpdatePanel();
            gameManager.isComplete = true;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            gameManager.GameOver();

        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Mizraga top giriyor");
            gameManager.GameOver();

        }
    }
    #endregion

}
#endregion