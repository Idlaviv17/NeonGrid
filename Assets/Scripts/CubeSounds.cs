using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSounds : MonoBehaviour
{
    public AudioSource impactSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Player")
        {
            if (collision.relativeVelocity.magnitude > 3)
            {
                impactSound.Play();
            }
        }
    }
}
