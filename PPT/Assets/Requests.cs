using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;


public class Requests : MonoBehaviour
{
    public UrlManager UrlManager;
    public bool isGet=false;
    public float numeroRespuesta;

    public string choose;
    public string url = "http://172.16.48.37:5000/serv/tobias/get/tiro"; // Reemplaza esto con la URL de tu API

    private void Update()
    {
        url = UrlManager.url+"Tiro/";
    }


    public void SetNew(string choo)
    {
        StartCoroutine(HacerPeticion(url+choo));
        Debug.Log(url+choo);
      
    }


    public void SetPlayerID()
    {
    
        StartCoroutine(HacerPeticion(UrlManager.readyUrl));
        Debug.Log(UrlManager.readyUrl); 
        
    }
    
    public IEnumerator HacerPeticion(string newUrl)
    {
        while (true)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(newUrl))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.LogError("Error en la solicitud: " + www.error);
                }
                else
                {
                    // La respuesta de la API está en www.downloadHandler.text
                    string respuesta = www.downloadHandler.text;

                    // Convierte la respuesta a número (puedes usar int.Parse o float.Parse según el tipo de dato esperado)
                    //   float numeroRespuesta;
                    if (float.TryParse(respuesta, out numeroRespuesta))
                    {
                        // Imprime el número en la consola
                        Debug.Log("Número recibido: " + numeroRespuesta);

                    }
                    else
                    {
                        Debug.LogError("La respuesta no es un número válido: " + respuesta);
                    }
                }
            }
            yield return new WaitForSecondsRealtime(1f);
            StopCoroutine(HacerPeticion(null));
        }
    }


}
