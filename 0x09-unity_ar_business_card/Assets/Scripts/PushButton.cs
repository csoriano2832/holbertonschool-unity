using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/SorianoFSSE");
    }

    public void Linkedin()
    {
        Application.OpenURL("https://www.linkedin.com/in/csoriano2832/");
    }

    public void Github()
    {
        Application.OpenURL("https://github.com/csoriano2832");
    }
}
