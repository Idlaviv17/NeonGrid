using System;
using UnityEngine;

public class NarratorStart : MonoBehaviour
{
    public AudioSource audioOutput;
    public AudioClip clip;
    public GameObject player;
    public GameObject door;
    private bool isClipPlaying;
    private float actualTime = 0;
    private float waitTime = 38;
    private bool doorIsOpening = false;
    private int openedCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isClipPlaying)
        {
            if (player.transform.position.x >= 4)
            {
                audioOutput.PlayOneShot(clip);
                isClipPlaying = true;
            }
        }

        if(isClipPlaying && actualTime <= waitTime) {
            actualTime += Time.deltaTime;
        } else if(isClipPlaying && actualTime > waitTime && openedCounter < 1)
        {
            doorIsOpening = true;
            openedCounter = 1;
        }

        if (doorIsOpening)
        {
            door.transform.position += new Vector3(0, -4 * Time.deltaTime, 0);
        }

        if (door.transform.position.y < -4f)
        {
            doorIsOpening = false;
        }
    }
}
