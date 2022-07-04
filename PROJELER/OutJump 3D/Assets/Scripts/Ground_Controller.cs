#region Library
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class Ground_Controller : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] GameManager gameManager;

    void Update()
    {
        if (gameManager.isStart == true && gameManager.isComplete ==false)
        {
           GroundMove();
        }
    }
    void GroundMove()
    {
        transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);
    }
}
