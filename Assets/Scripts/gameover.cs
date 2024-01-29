using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
