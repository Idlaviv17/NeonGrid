using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLevel : MonoBehaviour
{
    public string levelName;
    public GameObject player;
    public GameObject activationArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            LoadLevel(levelName);
        }
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}