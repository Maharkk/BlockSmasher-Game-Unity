using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelScript : MonoBehaviour
{
    [SerializeField] int noOfBlocks;
    SceneLoader scenes;
    public void CountNumberofBlocks()
    {
        noOfBlocks++;
    }
    public void Destroyed()
    {
        noOfBlocks--;
    }
    private void Update()
    {
        if(noOfBlocks == 0 )
        {
            SceneManager.LoadScene("Level Completed");
        }
    }
}
