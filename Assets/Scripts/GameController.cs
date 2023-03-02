using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject StartGameUI;
    public GameObject Pause;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        Time.timeScale = 1;
        StartGameUI.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        Pause.SetActive(true);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        Pause.SetActive(false);
    }
    public void ExitGame()
    {     
         Application.Quit();   
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
