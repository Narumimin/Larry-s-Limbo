using System.Diagnostics;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource ambientMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ambientMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            ambientMusic.Pause();
        }
    }
}
