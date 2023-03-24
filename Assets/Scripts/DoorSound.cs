using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public GameObject door;
    public AudioSource doorSound;
    private float position;
    private bool doorIsOpening = false;
    private bool doorIsClosing = false;

    // Update is called once per frame
    void Update()
    {
        position = door.transform.position.y;

        if(position < door.transform.position.y)
        {
            doorIsOpening = true;
            doorIsClosing = false;
        } else if(position > door.transform.position.y)
        {
            doorIsOpening = false;
            doorIsClosing = true;
        }

        if (doorIsOpening && !doorIsClosing)
        {
            doorSound.Play();
            Debug.Log("Door sound");
        }
        
    }
}
