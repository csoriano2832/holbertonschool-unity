using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject winCanvas;
    public AudioSource BGM;
    public GameObject sting;

    void OnTriggerEnter(Collider other)
    {
        Camera.main.GetComponent<CameraController>().enabled = false;
        BGM.Stop();
        winCanvas.SetActive(true);
        sting.SetActive(true);
        //timerText.color = Color.green;
        //timerText.fontSize = 60;
    }
}
