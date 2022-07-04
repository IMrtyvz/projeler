using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject levelUpdatePanel;
    [SerializeField] private Image[] stars;
    [SerializeField] private GameObject points;
    public int totalPointCount;
    public bool isStart;
    public bool isComplete;
    public int point;
    private int currentLevelIndex;
    void Start()
    {
        isStart = false;
        isComplete = false;
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentLevelIndex);
        totalPointCount = points.gameObject.GetComponent<Transform>().childCount;
    }

    void Update()
    {
        for (int i = 0; i < successRate() ; i++)
        {
            stars[i].enabled = true;
        }
    }
    public int successRate()
    {    int a;
        a = (100 * point) / totalPointCount;
        if (a >= 80)
            return 5;
        else if (a >= 60 && a < 80)
            return 4;
        else if (a >= 40 && a < 60)
            return 3;
        else if (a >= 20 && a < 40)
            return 2;
        else if (a >= 1 && a < 20)
            return 1;
        else
            return 0;

    }
    public void LevelUpdatePanel()
    {
        levelUpdatePanel.SetActive(true);
    }

    public void LevelUpdate()
    {
        SceneManager.LoadScene(currentLevelIndex+1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(currentLevelIndex);
    }
}
