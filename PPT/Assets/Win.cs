using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Win : MonoBehaviour
{
 public string P1, P2;

    public void setChooseP1(string p)
    {
        StartCoroutine(HacerPeticion(p));
    }
    public void setChooseP2(string p)
    {
        StartCoroutine(HacerPeticion2(p));
    }

    private void Update()
    {
        
    }
    public void winner()
    {
        int v = DeterminarGanador(int.Parse(P1), int.Parse(P2));
        if (v== 0)
        {
            Debug.Log("Nadie Ganó");
        }
        else if (v == 1)
        {
            Debug.Log("Player 1 Ganó");
        }
           else if (v == 2)
        {
            Debug.Log("Player 2 Ganó");
        }

    }

    public int DeterminarGanador(int decisionJugador1, int decisionJugador2)
    {
        if (decisionJugador1 == decisionJugador2)
        {
            return 0; // Empate
        }
        else if ((decisionJugador1 == 1 && decisionJugador2 == 3) ||
                 (decisionJugador1 == 2 && decisionJugador2 == 1) ||
                 (decisionJugador1 == 3 && decisionJugador2 == 2))
        {
            return 1; // Jugador 1 gana
        }
        else if ((decisionJugador1 == 3 && decisionJugador2 == 1) ||
                 (decisionJugador1 == 1 && decisionJugador2 == 2) ||
                 (decisionJugador1 == 2 && decisionJugador2 == 3))
        {
            return 2; // Jugador 2 gana
        }
        else if (decisionJugador1 == 0 && (decisionJugador2 == 1 || decisionJugador2 == 2 || decisionJugador2 == 3))
        {
            return 2; // Jugador 2 gana si jugador 1 no elige nada
        }
        else if (decisionJugador2 == 0 && (decisionJugador1 == 1 || decisionJugador1 == 2 || decisionJugador1 == 3))
        {
            return 1; // Jugador 1 gana si jugador 2 no elige nada
        }
        else
        {
            return 0; // Ningún jugador elige una opción válida
        }
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
                   // string respuesta = www.downloadHandler.text;
                    P1 = respuesta;
                    // Convierte la respuesta a número (puedes usar int.Parse o float.Parse según el tipo de dato esperado)
                 
                        // Imprime el número en la consola
                        Debug.Log("Número r: " + respuesta);

                    
                  /*  else
                    {
                        Debug.LogError("La respuesta no es un número válido: " + respuesta);
                    }*/
                }
            }
            yield return new WaitForSecondsRealtime(1f);
         
            StopCoroutine(HacerPeticion(null));
        }
    } 
    public IEnumerator HacerPeticion2(string newUrl)
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
                   // string respuesta = www.downloadHandler.text;
                    P2 = respuesta;
                    // Convierte la respuesta a número (puedes usar int.Parse o float.Parse según el tipo de dato esperado)
                 
                        // Imprime el número en la consola
                        Debug.Log("Número recibido: " + respuesta);

                    
                  /*  else
                    {
                        Debug.LogError("La respuesta no es un número válido: " + respuesta);
                    }*/
                }
            }
            yield return new WaitForSecondsRealtime(1f);
          
            StopCoroutine(HacerPeticion2(null));
        }
    }

}
