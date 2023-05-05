using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CubesOrder : MonoBehaviour
{
    private GameObject correctCube;
    [SerializeField] private GameObject Door;
    [SerializeField] private GameObject wallLight;
    [SerializeField] private Material neutralLight;
    [SerializeField] private Material correctLight;
    [SerializeField] private Material wrongLight;
    [SerializeField] private static int cubeCounter = 0;
    [SerializeField] private static int cubeStarter;
    [SerializeField] private static int cubeActual;
    [SerializeField] private static int requiredPositionsCount = 5;
    public static int correctPositionsCount;
    private static List<int> assignedCubes = new List<int>();
    private static List<int> sequence;
    private static int lastAssignedCube = 0;
    private bool doorIsOpening = false;
    private bool correctCubeisPositioned = false;
    private bool impulse = false;
    private static bool globalImpulse = false;
    private Vector3 doorInitialPosition;

    private void Start()
    {
        correctPositionsCount = 0;
        doorInitialPosition = Door.transform.position;
        wallLight.GetComponent<Renderer>().material = neutralLight;
        asignSequence();
        //Debug.Log(correctCube.name);
    }

    private void Update()
    {
        if (globalImpulse)
        {
            wallLight.GetComponent<Renderer>().material = wrongLight;
        }
        else if (correctCubeisPositioned && !globalImpulse)
        {
            wallLight.GetComponent<Renderer>().material = correctLight;
        }
        else if (!correctCubeisPositioned && !globalImpulse)
        {
            wallLight.GetComponent<Renderer>().material = neutralLight;
        }

        if (impulse && correctCubeisPositioned)
        {
            Rigidbody rb = correctCube.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 upwardForce = Vector3.up * 500000f;
                Vector3 randomDirection = UnityEngine.Random.insideUnitSphere;
                randomDirection.y = Mathf.Abs(randomDirection.y);
                float randomMagnitude = UnityEngine.Random.Range(50000f, 100000f);
                Vector3 impulseForce = upwardForce + randomDirection * randomMagnitude;
                rb.AddForce(impulseForce, ForceMode.Impulse);
            }
        }

        if (correctPositionsCount == 0)
        {
            globalImpulse = false;
        }

        impulse = globalImpulse;

        if (correctPositionsCount == requiredPositionsCount)
        {
            doorIsOpening = true;
        }
        else
        {
            doorIsOpening = false;
        }

        if (doorIsOpening)
        {
            if (Door.transform.position.y > doorInitialPosition.y - 4f)
            {
                Door.transform.position += new Vector3(0, -1 * Time.deltaTime, 0);
                // Sets the door opening limit
            }
        }
        else
        {
            Door.transform.position += new Vector3(0, 1 * Time.deltaTime, 0);

            // Sets the door closing limit
            if (Door.transform.position.y > doorInitialPosition.y)
            {
                Door.transform.position = new Vector3(Door.transform.position.x, doorInitialPosition.y, Door.transform.position.z);
                doorIsOpening = true;
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickableCube"))
        {
            if (collision.gameObject != correctCube)
            {
                Debug.Log("Wrong Cube");
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 upwardForce = Vector3.up * 500000f;
                    Vector3 randomDirection = UnityEngine.Random.insideUnitSphere;
                    randomDirection.y = Mathf.Abs(randomDirection.y);
                    float randomMagnitude = UnityEngine.Random.Range(50000f, 100000f);
                    Vector3 impulseForce = upwardForce + randomDirection * randomMagnitude;
                    rb.AddForce(impulseForce, ForceMode.Impulse);
                    globalImpulse = true;
                }
            }
            else if (collision.gameObject == correctCube)
            {
                correctCubeisPositioned = true;
                correctPositionsCount++;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == correctCube && correctCubeisPositioned == true)
        {
            correctCubeisPositioned = false;
        }

        if (correctPositionsCount > 0)
        {
            if (collision.gameObject.name == correctCube.name)
            {
                correctPositionsCount--;
            }
        }
    }

    private void asignSequence()
    {
        int randomCube = -1;
        if (cubeCounter < 5)
        {
            if (cubeCounter == 0)
            {
                // Si es el primer cubo, elegir aleatoriamente
                lastAssignedCube = UnityEngine.Random.Range(1, 6);
                randomCube = lastAssignedCube;
                switch (lastAssignedCube)
                {
                    case 1:
                        sequence = new List<int> { 1, 2, 3, 4, 5 };
                        break;
                    case 2:
                        sequence = new List<int> { 2, 3, 4, 5, 1 };
                        break;
                    case 3:
                        sequence = new List<int> { 3, 4, 5, 1, 2 };
                        break;
                    case 4:
                        sequence = new List<int> { 4, 5, 1, 2, 3 };
                        break;
                    case 5:
                        sequence = new List<int> { 5, 1, 2, 3, 4 };
                        break;
                }
                assignedCubes.Add(randomCube);
                sequence.RemoveAt(0);
            }
            else
            {
                randomCube = sequence[0];
                sequence.RemoveAt(0);
                assignedCubes.Add(randomCube);
            }
            correctCube = GameObject.Find("Cube" + randomCube);
            Debug.Log(string.Join(",", sequence));
            cubeCounter++;
        }
    }
}