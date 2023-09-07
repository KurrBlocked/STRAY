using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public PlayerController player;//Change to whatever gameobject is keeping track of points and contact with ghost
    public GameObject pauseScreen;
    public GameObject gameUI;
    private bool paused = false;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
        if (SceneManager.GetActiveScene().name == "LoseScreen") {
            audio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && player.win) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayWinScreen();
        }
        if (player != null && player.lose)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayLoseScreen();
        }
        if (pauseScreen != null && player.quit.triggered)//add player input conditional
        {
            paused = !paused;

            if (!paused)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                pauseScreen.SetActive(false);
                gameUI.SetActive(true);
                Time.timeScale = 1;
                //pauseScreen.interactable = false;
                //pauseScreen.blocksRaycasts = false;
                //pauseScreen.alpha = 0f;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pauseScreen.SetActive(true);
                gameUI.SetActive(false);
                Time.timeScale = 0;
                
                //pauseScreen.interactable = true;
                //pauseScreen.blocksRaycasts = true;
                //pauseScreen.alpha = 1f;
            }
        }
        if (paused && player.menu.triggered)
        {
            //audio.Play();
            Application.Quit();
            Debug.Log("Quitting");
        }
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MazeSkelly");//insert Main game scene here
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void PlayIntro()
    {
        SceneManager.LoadScene("IntroductionScreen");
    }

    public void PlayWinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }
    public void PlayLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }
}
