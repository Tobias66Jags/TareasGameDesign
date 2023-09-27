using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFade : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje

    void Update()
    {
        // Obtener la entrada del jugador en el eje horizontal y vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular la dirección de movimiento
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Mover el personaje en la dirección calculada
        transform.Translate(movement);

      
    }
}
