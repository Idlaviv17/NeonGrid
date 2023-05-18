using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Narrator : MonoBehaviour
{
    public AudioSource audioOutput;
    public AudioClip clip;
    public GameObject player;
    public string activationAxis;
    public float activationNumber;
    private bool isClipPlaying;
    private Scene currentScene;
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

// Update is called once per frame
void Update()
    {
        if (!isClipPlaying)
        {
            if (activationAxis.Equals("X"))
            {
                if (player.transform.position.x >= activationNumber)
                {
                    audioOutput.PlayOneShot(clip);
                    isClipPlaying = true;
                }
            }
            else if (activationAxis.Equals("Y"))
            {
                if (player.transform.position.y >= activationNumber)
                {
                    audioOutput.PlayOneShot(clip);
                    isClipPlaying = true;
                }
            }
            else if (activationAxis.Equals("Z"))
            {
                if (sceneName == "level4")
                {
                    if (player.transform.position.z <= activationNumber)
                    {
                        audioOutput.PlayOneShot(clip);
                        isClipPlaying = true;
                    }
                }
                else
                {
                    if (player.transform.position.z >= activationNumber)
                    {
                        audioOutput.PlayOneShot(clip);
                        isClipPlaying = true;
                    }
                }
            }
        }

    }
}
