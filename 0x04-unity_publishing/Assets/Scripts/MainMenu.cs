using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    void Start()
     {
         Button playBtn = playButton.GetComponent<Button>();
         Button quitBtn = quitButton.GetComponent<Button>();

         playBtn.onClick.AddListener(PlayMaze);
         quitBtn.onClick.AddListener(QuitMaze);
     }

    public void PlayMaze()
    {
        if (colorblindMode.isOn == true)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        
        SceneManager.LoadScene("maze");
    }

    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
