using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    
    public void LoadNextScene()
    {
        int indexNumber = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexNumber + 1);
    }

    public void LoadMainScreen()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStats>().gameReset();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadLevelScreen()
    {
        SceneManager.LoadScene("Level Screen");
    }
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LoadLevelThree()
    {
        SceneManager.LoadScene("Level 3");
    }
}
