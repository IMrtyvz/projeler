#region Library
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class Ball_Controller : MonoBehaviour
{
    #region Attribute
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Game_Manager game_Manager;
    #endregion
    #region Unity Functions
    void Start()
    {

    }


    void Update()
    {   /*
         Sadece x ekseninde yonlendirme yapiyorum y ve z eksenlerinde 0f ile hareket ettirmiyorum 
         */
        transform.Translate(moveSpeed * Time.deltaTime, 0f ,0f);
        /* 
         Her mouse'un sol tikina (0)'a tiklanmasinin ardindan 
        yukari ziplama islemini gerceklestiriyoruz        
         */
        if (Input.GetMouseButtonDown(0) && rb.velocity.y == 0) //mouse'un sol tikina basildiginda (bir defa)
        {
            rb.velocity = Vector2.up * jumpPower;
            game_Manager.isStart = true;
        }
       
    }
    #endregion
    #region Functions   
    private void OnCollisionEnter2D(Collision2D other)
    {   /*
         Carpilan objenin tag'i Short Edge ise yon degistirmesi icin hiz degiskenini -1 ile carpiyoruz 
         */
        if (other.gameObject.CompareTag("Short Edge"))
        {
            moveSpeed *= -1; //yonunu degistirdik
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        Trigger'lanan objenin etiketi Star ise destroy et  
        */
        if (collision.gameObject.CompareTag("Star"))
        {
            game_Manager.starCount++;
            Destroy(collision.gameObject);
        }
        /*
        Trigger'lanan objenin etiketi Flag ise level gec  
        */
        if (collision.gameObject.CompareTag("Flag"))
        {
            game_Manager.LevelUpdatePanel();
            Debug.Log("Level Complete");
        }
        /*
        Trigger'lanan objenin etiketi Ground ise oyun sonu  
        */
        if (collision.gameObject.CompareTag("Ground"))
        {   // Basarisiz level icin GameOver fonksiyonu
            game_Manager.GameOver();
        }
    }

    #endregion

}
