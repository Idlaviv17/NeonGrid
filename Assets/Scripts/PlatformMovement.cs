using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class PlatformMovement : MonoBehaviour
{
    public GameObject platform;
    public GameObject player;
    public LayerMask playerLayer;
    private bool platformIsDescending = false;

    // Update is called once per frame
    void Update()
    {
        
        if (platformIsDescending)
        {
            Debug.Log("Metodo");
            platform.transform.position += new Vector3(0, -1 * Time.deltaTime, 0);
        }

        if (platform.transform.position.y < -8f)
        {
            platformIsDescending = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        platformIsDescending = true;
    }
}
