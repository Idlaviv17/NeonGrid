using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLevitation : MonoBehaviour
{
    public GameObject cube;
    public float limitPosition;
    public AudioSource destructionSound;
    private float actualPosition;
    private Material ogMaterial;
    private Material actualMaterial;
    public Material newMaterial;
    private Vector3 initialPosition;
    private bool hasRespawned;

    private void Start()
    {
        initialPosition = cube.transform.position;
        Material[] materials = cube.GetComponent<Renderer>().materials;
        ogMaterial = materials[2];
        actualMaterial = ogMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (cube == null && !hasRespawned)
        {
            InstantiateCube();
            hasRespawned = true;
        }

        if (cube != null)
        {
            actualPosition = cube.transform.position.y;
            if (actualPosition >= limitPosition)
            {
                Material[] materials = cube.GetComponent<Renderer>().materials;
                materials[2] = newMaterial;
                cube.GetComponent<Renderer>().materials = materials;
                actualMaterial = newMaterial;
            }
            else if (actualPosition < limitPosition && actualMaterial != ogMaterial)
            {
                Material[] materials = cube.GetComponent<Renderer>().materials;
                materials[2] = ogMaterial;
                cube.GetComponent<Renderer>().materials = materials;
                actualMaterial = ogMaterial;
            }

            if (actualPosition >= limitPosition + 5)
            {
                Destroy(cube);
            }
        }
    }

    private void InstantiateCube()
    {
        cube = Instantiate(cube, initialPosition, Quaternion.identity);
    }
}