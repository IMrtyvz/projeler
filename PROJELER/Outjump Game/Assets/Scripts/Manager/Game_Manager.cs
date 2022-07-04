#region Library
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#endregion

public class Game_Manager : MonoBehaviour
{
    #region Attribute
    [SerializeField] private GameObject levelUpdatePanel;
    [SerializeField] private Image[] stars;
    public bool isStart;
    // yildiz sayisini tutmak icin degisken
    public int starCount=1;
    // sahne gecisleri icin anlikLevel degiskeni
    private int currentLevelIndex;
    #endregion

    #region Unity Functions

    void Start()
    {
        isStart = false;
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentLevelIndex);
    }
    void Update()
    {
         Debug.Log(kacYildizKazandi().ToString());
        for (int i = 0; i < kacYildizKazandi(); i++)
        {
            stars[i].enabled=true;
        }
    }
    #endregion

    public int kacYildizKazandi()
    {
        switch (starCount)
        {
            case 0:
                return 0;
                break;
            case 1: 
                return 1;
                break;
            case 2:
                return 2;
                break;
            case 3:
                return 3;
                break;
            default:
                return -1;
                break;
        }

    }
    #region Functions   
    public void LevelUpdatePanel()
    {   //level gecisleri arasinda panelimizi gostermek icin aktif hale getirdik
        levelUpdatePanel.SetActive(true);   

    }
    public void LevelUpdate()
    {
        SceneManager.LoadScene(currentLevelIndex + 1);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(currentLevelIndex);
        isStart = false;
    }
    #endregion
}
