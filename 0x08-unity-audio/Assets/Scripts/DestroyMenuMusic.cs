using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyMenuMusic : MonoBehaviour
{
    private string level;

    private void Awake()
    {
        level = SceneManager.GetActiveScene().name;
        if (level == "Level01" | level == "Level02" | level == "Level03")
        {
            Destroy(GameObject.FindGameObjectWithTag("GameMusic"));
        }
    }
}
