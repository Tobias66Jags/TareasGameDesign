using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class PokRequest : MonoBehaviour
{
    string SetReadyPlayer;

    public float numeroRespuesta;
  
    public void SetP(string a)
    {
        StartCoroutine(HacerPeticion(a));
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
                    // La respuesta de la API est� en www.downloadHandler.text
                    string respuesta = www.downloadHandler.text;

                    // Convierte la respuesta a n�mero (puedes usar int.Parse o float.Parse seg�n el tipo de dato esperado)
                    //   float numeroRespuesta;
                    if (float.TryParse(respuesta, out numeroRespuesta))
                    {
                        // Imprime el n�mero en la consola
                        Debug.Log("N�mero recibido: " + numeroRespuesta);

                    }
                    else
                    {
                        Debug.LogError("La respuesta no es un n�mero v�lido: " + respuesta);
                    }
                }
            }
            yield return new WaitForSecondsRealtime(10f);
            StopAllCoroutines();
        }
    }
}
