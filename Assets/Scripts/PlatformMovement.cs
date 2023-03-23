using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class PlatformMovement : MonoBehaviour
{
    public GameObject Platform;
    private bool platformIsDescending = false;

    // Update is called once per frame
    void Update()
    {
        if (platformIsDescending)
        {
            Debug.Log("Metodo");
            Platform.transform.position += new Vector3(0, -4 * Time.deltaTime, 0);
        }

        if (Platform.transform.position.y < -8f)
        {
            platformIsDescending = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickableCube"))
        {
            platformIsDescending = true;
            Debug.Log("True");
        }
    }
}
