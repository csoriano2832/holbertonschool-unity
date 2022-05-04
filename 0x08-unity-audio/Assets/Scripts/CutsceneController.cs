using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;
    public GameObject timerCanvas;
    public Animator anim;
    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Level01") {
            anim.SetTrigger("Lvl1");
        }
        else if (scene.name == "Level02") {
            anim.SetTrigger("Lvl2");
        }
        else {
            anim.SetTrigger("Lvl3");
        }
    }

    public void CutsceneCameraEvent()
    {
        mainCamera.SetActive(true);
        timerCanvas.SetActive(true);
        player.GetComponent<PlayerController>().enabled = true;
        this.gameObject.SetActive(false);
    }
}
