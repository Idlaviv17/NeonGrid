using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsController : MonoBehaviour
{
  public GameObject Button;
  public GameObject Stairs;
  private bool stairsAppear = false;
  private bool stairsDisappear = false;

  private void Update()
  {
    if (stairsAppear && !stairsDisappear)
    {
      //Button.transform.Translate(Vector3.back * Time.deltaTime * 2);
      Button.transform.position += new Vector3(0, -0.1f * Time.deltaTime, 0);
      //Door.transform.Translate(Vector3.down * Time.deltaTime * 4);
      Stairs.transform.position += new Vector3(0, 0, 10 * Time.deltaTime);
      Debug.Log("Stairs Appear");
    }
    if (stairsDisappear && !stairsAppear)
    {
      //Button.transform.Translate(Vector3.forward * Time.deltaTime * 2);
      Button.transform.position += new Vector3(0, .1f * Time.deltaTime, 0);
      //Door.transform.Translate(Vector3.up * Time.deltaTime * 4);
      Stairs.transform.position += new Vector3(0, 0, -10 * Time.deltaTime);
      Debug.Log("Stairs Disappear");
    }

    // Sets the door opening and closing limits
    //if (Door.transform.position.y < -2.1f)

    if (Stairs.transform.position.z > -13.2f)
    {
      stairsAppear = false;
    }
    //if (Door.transform.position.y > 1.94f)
    if (Stairs.transform.position.z < -19.22)
    {
      stairsDisappear = false;
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("PickableCube"))
    {
      stairsAppear = true;
      stairsDisappear = false;
    }
  }

  private void OnCollisionExit(Collision collision)
  {
    if (collision.gameObject.CompareTag("PickableCube"))
    {
      stairsDisappear = true;
      stairsAppear = false;
    }
  }
}
