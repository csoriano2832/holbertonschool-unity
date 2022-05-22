using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle checkbox;
    public Slider BGMSlider, SFXSlider;
    public AudioMixer mixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Inverted"))
            checkbox.isOn = (PlayerPrefs.GetInt("Inverted") == 1 ? true : false);
        if (PlayerPrefs.HasKey("BGMVolume"))
            BGMSlider.value = DecibelToLinear(PlayerPrefs.GetFloat("BGMVolume"));
        if (PlayerPrefs.HasKey("SFXVolume"))
            SFXSlider.value = DecibelToLinear(PlayerPrefs.GetFloat("SFXVolume"));
    }

    private void Update()
    {
        mixer.SetFloat("BGMVolume", LinearToDecibel(BGMSlider.value));
        mixer.SetFloat("SFXVolume", LinearToDecibel(SFXSlider.value));
    }

    // Goes to the previous scene
    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Previous"));
    }

    // Saves changes made in the options menu. 
    // Changes persist even on game exit and restart.
    public void Apply()
    {
        PlayerPrefs.SetInt("Inverted", checkbox.isOn ? 1 : 0);
        PlayerPrefs.SetFloat("BGMVolume", LinearToDecibel(BGMSlider.value));
        PlayerPrefs.SetFloat("SFXVolume", LinearToDecibel(SFXSlider.value));
        PlayerPrefs.Save();
        Debug.Log("Changes Applied!");
        Back();
    }

    private float LinearToDecibel(float linear)
    {
        if (linear != 0)
            return 20.0f * Mathf.Log10(linear);
        return -144.0f;
    }

    private float DecibelToLinear(float dB)
    {
        return Mathf.Pow(10.0f, dB / 20.0f);
    }
}
