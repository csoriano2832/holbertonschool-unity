using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("escape"))
        {
            Pause();
        }
    }

    // Pauses the game
    public void Pause()
    {
        SetActive(true);
    }

    // Resumes the currently running game
    public void Resume()
    {

    }
}
