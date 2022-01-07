using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public GameObject winLoseObject;
    private Image winLoseBG;

    // Start is called before the first frame update
    void Update()
    {
        if (health == 0)
        {
            SetLoseText();
            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);        
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Trap")
        {
            health--;
            SetHealthText();
        }
        else if (other.tag == "Goal")
        {
            SetWinText();
            StartCoroutine(LoadScene(3));
        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }

    void SetWinText()
    {
        winLoseBG = winLoseObject.GetComponent<Image>();
        winLoseText.text = "You win!";
        winLoseText.color = Color.black;
        winLoseBG.color = Color.green;
        winLoseObject.SetActive(true);
    }

    void SetLoseText()
    {
        winLoseBG = winLoseObject.GetComponent<Image>();
        winLoseText.text = "Game Over!";
        winLoseText.color = Color.white;
        winLoseBG.color = Color.red;
        winLoseObject.SetActive(true);
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
