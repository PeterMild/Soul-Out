using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // เรียกใช้เพื่อให้ทำการ load scene ได้
using UnityEngine.UI; // เรียกใช้เพื่อให้สามารถเรียก UI


public class PauseMenu : MonoBehaviour
{
    public static  bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    
    


    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }

       



    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

       
        
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("PrepareMenu");
        
    }

    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);



    }

}
