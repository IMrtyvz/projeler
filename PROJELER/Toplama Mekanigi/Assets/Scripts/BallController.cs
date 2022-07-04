using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefabs;
    [SerializeField] private TMP_Text ballCountText;
    [SerializeField] private List<GameObject> balls =new List<GameObject> ();
    // yatayda hareket edebilmesi icin gerekli hiz parametresi
    [SerializeField] private float horizontalSpeed;

    // yatayda hareket sinirlandirmasi icin gerekli parametreler
    [SerializeField] private float _horizontalLimit;

    [SerializeField] private float _moveSpeed;

    private float horizontal;
    private int gateNumber;
    private int targetCount; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalBallMove();
        ForwardBallMove();
        UpdateBallCountText();
    
    }
    private void HorizontalBallMove()
    {
        float newX;
        if (Input.GetMouseButton(0))
        {
            horizontal = Input.GetAxisRaw("Mouse X");
        }
        else
        {
            //elimizi mouse'dan cektigimiz andan itibaren horizontal degeri 0 olsun
            horizontal = 0;
        }
        newX = transform.position.x + horizontal * horizontalSpeed * Time.deltaTime;
        newX = Mathf.Clamp(newX, - _horizontalLimit, _horizontalLimit);
        transform.position = new Vector3(
            newX,
            transform.position.y,
            transform.position.z
            );
    }
    private void UpdateBallCountText()
    {
        ballCountText.text=balls.Count.ToString();
    }
    private void ForwardBallMove()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallStack"))
        {
            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.transform.localPosition = new Vector3(0f,0f,balls[balls.Count-1].transform.localPosition.z - 1f);
            balls.Add(other.gameObject);
        }
        if (other.gameObject.CompareTag("Gate"))
        {
            gateNumber = other.gameObject.GetComponent<GateController>().GetGateNumber();
            targetCount = balls.Count + gateNumber;
            if (gateNumber > 0)
            {
                IncreseBallCount();
            }
            else if (gateNumber <0)
            {
                DecreaseBallCount();
            }
            
        }
    }
    private void IncreseBallCount()
    {
        for (int i = 0; i < gateNumber; i++)
        {
            GameObject newBall = Instantiate(ballPrefabs);
            newBall.transform.SetParent(transform);
            newBall.GetComponent<SphereCollider>().enabled = false;
            newBall.gameObject.transform.localPosition = new Vector3(0f, 0f, balls[balls.Count - 1].transform.localPosition.z - 1f);
            balls.Add(newBall);
        }
    }
    private void DecreaseBallCount()
    {
        for (int i = balls.Count - 1 ; i >= targetCount; i--)
        {
            balls.RemoveAt(i);
        }
    }
}
