using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public int sceneIndex = 1; // Index of the scene to switch to
    public float elapsedTime = 0f;
    void Update()
    {
        if (elapsedTime <= 0)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}