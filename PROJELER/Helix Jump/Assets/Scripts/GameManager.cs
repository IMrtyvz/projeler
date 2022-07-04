using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //canvaslar� textleri kullanacagimiz icin dahil ediyoruz
using UnityEngine.SceneManagement; //sahneleme olacagi icin dahil ettik
public class GameManager : MonoBehaviour
{
    private int score;
    public Text scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameScore(int ringScore)
    {   /*
         her ring ge�ildi�inde 25 puan alacak 
         bunun i�inde her ringin transformuna ihtiyacimiz vardir.
         
         */
        score += ringScore;
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
