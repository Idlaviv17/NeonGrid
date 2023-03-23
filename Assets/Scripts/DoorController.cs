using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
  public GameObject Door;
  private bool doorIsOpening = false;
  private bool doorIsClosing = false;

  private void Update()
  {
    if (doorIsOpening && !doorIsClosing)
    {
      Door.transform.Translate(Vector3.down * Time.deltaTime * 4);
      Debug.Log("Door Opens");
    }
    if (doorIsClosing && !doorIsOpening)
    {
      Door.transform.Translate(Vector3.up * Time.deltaTime * 4);
      Debug.Log("Door Closes");
    }

    // Sets the door opening and closing limits
    if (Door.transform.position.y < -2.1f)
    {
      doorIsOpening = false;
    }
    if (Door.transform.position.y > 1.94f)
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
