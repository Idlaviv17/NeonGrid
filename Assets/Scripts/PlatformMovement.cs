using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;

public class PlatformMovement : MonoBehaviour
{
    public GameObject platform;
    public GameObject player;
    public LayerMask playerLayer;
    public string nombreNivel;
    public TextMeshProUGUI timeText;
    private bool platformIsDescending = false;
    private float platformInitialPosition;
    private float actualTime = 0f;
    private string levelKey;

    private void Start()
    {
        PlayerPrefs.SetFloat(levelKey, 0F);
        platformInitialPosition = platform.transform.position.y;
        levelKey = "LevelTime_" + SceneManager.GetActiveScene().buildIndex;
        platformInitialPosition = platform.transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        actualTime += Time.deltaTime;
        updateTimeText();

        if (platformIsDescending)
        {
            platform.transform.position += new Vector3(0, -1 * Time.deltaTime, 0);

            if (platform.transform.position.y <= platformInitialPosition - 6)
            {
                PlayerPrefs.SetFloat(levelKey, actualTime);
                SceneManager.LoadScene(nombreNivel);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        platformIsDescending = true;
    }

    public void CargarNivel(string nombreNivels)
    {
        SceneManager.LoadScene(nombreNivels);
    }

    void updateTimeText()
    {
        int minutes = Mathf.FloorToInt(actualTime / 60f);
        int seconds = Mathf.FloorToInt(actualTime % 60f);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeText.text = formattedTime;
    }
}
