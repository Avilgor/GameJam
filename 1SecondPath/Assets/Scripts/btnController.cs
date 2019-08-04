using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnController : MonoBehaviour
{
    public void playJump()
    {
        SceneManager.LoadScene(2);
    }

    public void playJump()
    {
        SceneManager.LoadScene(3);
    }

    public void playMaze()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
