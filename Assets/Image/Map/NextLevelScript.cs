using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{

    GameObject meme;
    private void Start()
    {
        meme = GameObject.Find("meme");
        meme.transform.position = new Vector2 (0, 0);   
        meme.SetActive(false);
    }
    public void NextLevel()
    {
        meme.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadScene("StartMenu");    
    }
}
