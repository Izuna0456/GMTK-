using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour
{
    public int sceneIndex = 1; // Index of the scene to switch to

    public AudioClip musicClip; // Assign the music clip in the Inspector

    private void Start()
    {
        play_sfx.Instance.PlayMusic(musicClip);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
