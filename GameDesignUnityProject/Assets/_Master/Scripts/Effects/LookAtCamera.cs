using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        // Encuentra la c�mara principal en la escena
        mainCamera = Camera.main;

        // Verifica si se encontr� una c�mara
        if (mainCamera == null)
        {
            Debug.LogError("No se encontr� una c�mara principal en la escena.");
            enabled = false; // Deshabilita el script para evitar errores.
        }
    }

    private void LateUpdate()
    {
        // Obtiene la posici�n de la c�mara
        Vector3 cameraPosition = mainCamera.transform.position;

        // Itera a trav�s de los objetos hijos y hace que miren hacia la c�mara
        foreach (Transform child in transform)
        {
            child.LookAt(cameraPosition);
        }
    }
}
  

