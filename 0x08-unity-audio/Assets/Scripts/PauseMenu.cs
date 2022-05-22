using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject mainCamera;
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeInHierarchy)
                Pause();
            else if (pauseMenu.activeInHierarchy)
                Resume();

        }
        
        if (Time.timeScale == 1)
            unpaused.TransitionTo(0f);
        else
            paused.TransitionTo(0f);
    }

    // Pauses the game
    public void Pause()
    {
        Time.timeScale = 0;
        mainCamera.GetComponent<CameraController>().enabled = false;
        pauseMenu.SetActive(true);
    }

    // Resumes the currently running game
    public void Resume()
    {
        Time.timeScale = 1;
        mainCamera.GetComponent<CameraController>().enabled = true;
        pauseMenu.SetActive(false);
    }

    // Restarts the current level the player is on
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    //
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Resume();
    }

    //
    public void Options()
    {
        PlayerPrefs.SetInt("Previous", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Options");
        Resume();
    }
}
