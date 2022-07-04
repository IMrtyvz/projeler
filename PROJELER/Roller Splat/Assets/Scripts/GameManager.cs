using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject[] grounds;

    //neden int yapmadik
    public float grounNumber;
    private int currentLevel;
  
    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        Debug.Log("Parca Sayisi " + grounds.Length);
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    
    }

 
    void Update()
    {
        grounNumber = grounds.Length;          
    }
    public void LevelUpdate()
    {
        SceneManager.LoadScene(currentLevel+1);
    }
}
