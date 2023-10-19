using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class Manager : MonoBehaviour
{
   public TextMeshProUGUI counter;
   public TextMeshProUGUI globalCounter;
   public TextMeshProUGUI globalName;

    public float globalTimer;
   public float timer=100;


  public  float numeroRespuesta=5;


    public string user = "a";
    void Start()
    {
        StartCoroutine(HacerPeticion(url));
        StartCoroutine(HacerPeticionUsuario(url));
        
    }

    private void Update()
    {
        timer = Player.newC;
        counter.text = timer.ToString()+" s";
        globalCounter.text = numeroRespuesta.ToString();

       /* if (timer<numeroRespuesta)
        {
            Debug.Log("Se pudo");
            StartCoroutine(HacerPeticion("http://172.16.48.37:5000/serv/tobias/tiro/"+timer.ToString()));

        }
        else
        {
            return;
        }*/
    }


    private string url = "http://172.16.48.37:5000/serv/tobias/get/tiro"; // Reemplaza esto con la URL de tu API

  

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
        }
    }
    public IEnumerator HacerPeticionUsuario(string newUrl)
    {
        while (true)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(url))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.LogError("Error en la solicitud: " + www.error);
                }
                else
                {
                    // La respuesta de la API está en www.downloadHandler.text
                    user = www.downloadHandler.text;

                    // Imprime el string en la consola
                    Debug.Log("Respuesta recibida: " + user);
                }
            }
            yield return new WaitForSecondsRealtime(1f);
        }
    }

}
