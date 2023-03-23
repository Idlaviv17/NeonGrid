using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
  public GameObject Button;
  public GameObject Door;
  private bool doorIsOpening = false;
  private bool doorIsClosing = false;

    private void Update()
  {
    if (doorIsOpening && !doorIsClosing)
    {
    //Button.transform.Translate(Vector3.back * Time.deltaTime * 2);
    Button.transform.position += new Vector3(0, -0.1f * Time.deltaTime, 0);
    //Door.transform.Translate(Vector3.down * Time.deltaTime * 4);
    Door.transform.position += new Vector3(0, -4 * Time.deltaTime, 0);
    Debug.Log("Door Opens");
    }
    if (doorIsClosing && !doorIsOpening)
    {
      //Button.transform.Translate(Vector3.forward * Time.deltaTime * 2);
      Button.transform.position += new Vector3(0, .1f * Time.deltaTime, 0);
      //Door.transform.Translate(Vector3.up * Time.deltaTime * 4);
      Door.transform.position += new Vector3(0, 4 * Time.deltaTime, 0);
      Debug.Log("Door Closes");
    }

    // Sets the door opening and closing limits
    //if (Door.transform.position.y < -2.1f)
    if (Door.transform.position.y < -4f)
    {
      doorIsOpening = false;
    }
    //if (Door.transform.position.y > 1.94f)
    if (Door.transform.position.y > 0)
    {
      doorIsClosing = false;
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("PickableCube"))
    {
      doorIsOpening = true;
      doorIsClosing = false;
    }
  }

  private void OnCollisionExit(Collision collision)
  {
    if (collision.gameObject.CompareTag("PickableCube"))
    {
      doorIsClosing = true;
      doorIsOpening = false;
    }
  }
}
