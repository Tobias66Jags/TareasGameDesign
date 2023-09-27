using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        // Encuentra la cámara principal en la escena
        mainCamera = Camera.main;

        // Verifica si se encontró una cámara
        if (mainCamera == null)
        {
            Debug.LogError("No se encontró una cámara principal en la escena.");
            enabled = false; // Deshabilita el script para evitar errores.
        }
    }

    private void LateUpdate()
    {
        // Obtiene la posición de la cámara
        Vector3 cameraPosition = mainCamera.transform.position;

        // Itera a través de los objetos hijos y hace que miren hacia la cámara
        foreach (Transform child in transform)
        {
            child.LookAt(cameraPosition);
        }
    }
}
  

