using System.Collections;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject prefab; // El Prefab que quieres reutilizar.
    public float spawnRate = 2f; // Frecuencia de aparición de objetos.
    public float despawnTime = 5f; // Tiempo antes de que los objetos desaparezcan.

    public float xRange = 20;
    public float yRange = 10;

    private Camera mainCamera;
    private float cameraWidth;
    private float cameraHeight;

    private void Start()
    {
        mainCamera = Camera.main;
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;

        StartCoroutine(SpawnObject());
        StartCoroutine(Difficult());
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject obj = GetPooledObject();
            if (obj != null)
            {
                // Configura la posición aleatoria dentro de la vista de la cámara.
                float xPosition = Random.Range(-xRange, xRange);
                float yPosition = Random.Range(-yRange, yRange);
                Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0f);

                // Convierte la posición de la pantalla en posición del mundo.
             //   spawnPosition = mainCamera.ScreenToWorldPoint(spawnPosition);
                spawnPosition.z = 0f;

                obj.transform.position = spawnPosition;
                obj.SetActive(true);

                // Después de un tiempo, desactiva el objeto.
                StartCoroutine(DeactivateObject(obj));
            }
        }
    }

    private GameObject GetPooledObject()
    {
        // Aquí deberías tener una lista de objetos en tu pool.
        // Si no existe un objeto inactivo en el pool, puedes instanciar uno nuevo.
        // Asegúrate de desactivar el objeto cuando lo devuelvas al pool.

        // Por ejemplo:
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        return obj;
    }

    private IEnumerator DeactivateObject(GameObject obj)
    {
        yield return new WaitForSeconds(despawnTime);

        if (despawnTime<=0.8)
        {
            despawnTime = 0.8f;
        }else
        {
            despawnTime -= 0.2f;
        }
        obj.SetActive(false);
    }

    private IEnumerator Difficult()
    {
        while (true)
        {
            yield return new WaitForSeconds(8f);

           
            spawnRate -= 0.1f;
        }
    }
}

