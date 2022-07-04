using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_Manager : MonoBehaviour
{
    public int levelNum = 1;
    public void StartGame()
    {
        SceneManager.LoadScene(levelNum);
    }
}
