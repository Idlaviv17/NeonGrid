using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;

public class PlatformMovement : MonoBehaviour
{
    public GameObject platform;
    public GameObject player;
    public LayerMask playerLayer;
    public string nombreNivel;
    private bool platformIsDescending = false;
    private float platformInitialPosition;

    private void Start()
    {
        platformInitialPosition = platform.transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        
        if (platformIsDescending)
        {
            platform.transform.position += new Vector3(0, -1 * Time.deltaTime, 0);

            if (platform.transform.position.y <= platformInitialPosition - 6)
            {
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
}
