using UnityEngine;

public class FloorController : MonoBehaviour
{
    public float visibilityDuration = 5f; // Duración de la visibilidad del piso
    public float visibilityInterval = 10f; // Intervalo de tiempo entre cada visibilidad
    private float visibilityTimer = 0f; // Temporizador de visibilidad
    private bool isFloorVisible = false; // Variable que indica si el piso está visible o no

    void Update()
    {
        visibilityTimer += Time.deltaTime; // Incrementa el temporizador de visibilidad

        if (visibilityTimer >= visibilityInterval) // Si ha pasado el intervalo de visibilidad
        {
            visibilityTimer = 0f; // Reinicia el temporizador de visibilidad
            ToggleFloor(); // Alterna la visibilidad del piso
        }

        if (isFloorVisible) // Si el piso está visible
        {
            visibilityDuration -= Time.deltaTime; // Resta el tiempo desde el último cuadro
            if (visibilityDuration <= 0f) // Si se ha agotado el tiempo de visibilidad
            {
                ToggleFloor(); // Alterna la visibilidad del piso
            }
        }
    }

    void ToggleFloor()
    {
        isFloorVisible = !isFloorVisible; // Alterna la visibilidad del piso
        GetComponent<MeshRenderer>().enabled = isFloorVisible; // Muestra u oculta el objeto del piso según la visibilidad
        visibilityDuration = isFloorVisible ? 5f : 0f; // Reinicia o desactiva el temporizador de visibilidad
    }
}