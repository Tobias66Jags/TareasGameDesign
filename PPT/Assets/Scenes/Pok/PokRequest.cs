using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class PokRequest : MonoBehaviour
{
    string SetReadyPlayer;

    public float numeroRespuesta;

    private void Start()
    {
        StartCoroutine(HacerPeticion("34.139.173.148/serv/tobias/Player1/0"));
        StartCoroutine(HacerPeticion("34.139.173.148/serv/tobias/Player2/0"));
        StartCoroutine(HacerPeticion("34.139.173.148/serv/tobias/Player3/0"));
        StartCoroutine(HacerPeticion("34.139.173.148/serv/tobias/Player4/0"));
        StartCoroutine(HacerPeticion("34.139.173.148/serv/tobias/Player5/0"));



        StartCoroutine(HacerPeticion("34.139.173.148/serv/tobias/Player1Card/0"));
        StartCoroutine(HacerPeticion("34.139.173.148/serv/tobias/Player2Card/0"));
        StartCoroutine(HacerPeticion("34.139.173.148/serv/tobias/Player3Card/0"));
        StartCoroutine(HacerPeticion("34.139.173.148/serv/tobias/Player4Card/0"));
        StartCoroutine(HacerPeticion("34.139.173.148/serv/tobias/Player5Card/0"));
    }
    public void SetP(string a)
    {
        StartCoroutine(HacerPeticion(a));
    }

    private void Update()
    {
      /*  StartCoroutine(HacerPeticion("34.139.173.148/serv/carla/Jugador1/listo"));
        StartCoroutine(HacerPeticion("34.139.173.148/serv/carla/Jugador2/listo"));
        StartCoroutine(HacerPeticion("34.139.173.148/serv/carla/Jugador3/listo"));*/
      
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
            yield return new WaitForSecondsRealtime(10f);
            StopAllCoroutines();
        }
    }
}
