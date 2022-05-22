using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource footstepSound;
    public AudioSource landingSound;

    public void Running()
    {
        footstepSound.Play();
    }

    public void Landing()
    {
        landingSound.Play();
    }
}