using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float actualTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actualTime += Time.deltaTime;
        updateTimeText();
    }

    void updateTimeText()
    {
        int minutes = Mathf.FloorToInt(actualTime / 60f);
        int seconds = Mathf.FloorToInt(actualTime % 60f);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeText.text = formattedTime;
    }
}
