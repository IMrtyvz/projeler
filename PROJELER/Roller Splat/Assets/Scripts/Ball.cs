using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{   private GameManager gm;
    public Image levelBar;
    public Image tryBar;
    public Rigidbody rb;
    private Vector2 firstPos;
    private Vector2 secondPos;
    private Vector2 currentPos;

    public float moveSpeed;

    public float currentGroundNumber;
    public float howManyTimes;
    public float maxTry;

    void Start()
    {
        gm=GameManager.FindObjectOfType<GameManager>();
    }


    void Update()
    {
        Swipe();
        levelBar.fillAmount = currentGroundNumber / gm.grounNumber;
        tryBar.fillAmount =  howManyTimes / maxTry;
        if (tryBar.fillAmount == 1)
        {
            Debug.Log("Level Basarisiz ");
            // tekrar leveli baslatma
        }
        if (levelBar.fillAmount == 1)
        {
            gm.LevelUpdate();
        }
    
    }

    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            secondPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
            currentPos= new Vector2(
                secondPos.x - firstPos.x,
                secondPos.y - firstPos.y
                );
        }
        currentPos.Normalize();

        if (currentPos.y < 0 && currentPos.x > -0.5f && currentPos.x < 0.5f)
        {
            // back 
            rb.velocity = Vector3.back * moveSpeed;
        }
        else if (currentPos.y > 0 && currentPos.x > -0.5f && currentPos.x < 0.5f)
        {
            //forward
            rb.velocity = Vector3.forward * moveSpeed;
        }
        else if (currentPos.x<0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            //left
            rb.velocity = Vector3.left * moveSpeed;
        }
        else if (currentPos.x>0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            //right
            rb.velocity = Vector3.right * moveSpeed;
        }
    }
    private void OnCollisionEnter(Collision other)
    {   /*
         Eger bizim carptigimiz objenin rengi kirmizidan farkli ise
         */
        if (other.gameObject.GetComponent<MeshRenderer>().material.color != Color.red)
        {
            if (other.gameObject.tag == "Ground")
            {
                /* 
                 Carptigimiz objenin etiketi Ground ise 
                 üzerinden gecmisizdir ve biz bu zeminin rengini degistirmeliyiz. 
                */
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                Constraints();
                currentGroundNumber++;
            }
        }
        if (other.gameObject.tag == "Ground")
        {
            /*kac kez groun uzerinden gectigimizi hesaplamak icin parametre */
            howManyTimes++;
        }

    }


    private void Constraints()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;    
    }
}
