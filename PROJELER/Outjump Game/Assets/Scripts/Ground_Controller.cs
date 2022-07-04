#region Library
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class Ground_Controller : MonoBehaviour
{
    #region Attribute
    [SerializeField] private float moveSpeed;
    [SerializeField] private Game_Manager game_Manager;

    #endregion

    #region Unity Functions


    void Update()
    {
        if (game_Manager.isStart == true)
        {
            transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);
        }
    }
    #endregion

    #region Functions   
    #endregion
}
