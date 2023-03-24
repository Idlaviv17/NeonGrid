using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource Sonido;
    public AudioClip hover;
    public AudioClip click;

    public void HoverSound(){
        Sonido.PlayOneShot(hover);
    }

    public void ClickSound(){
        Sonido.PlayOneShot(click);
    }

}
