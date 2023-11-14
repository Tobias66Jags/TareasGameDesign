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
            Debug.Log("Nadie Gan�");
        }
        else if (v == 1)
        {
            Debug.Log("Player 1 Gan�");
        }
           else if (v == 2)
        {
            Debug.Log("Player 2 Gan�");
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
            return 0; // Ning�n jugador elige una opci�n v�lida
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
                    // La respuesta de la API est� en www.downloadHandler.text
                    string respuesta = www.downloadHandler.text;
                   // string respuesta = www.downloadHandler.text;
                    P1 = respuesta;
                    // Convierte la respuesta a n�mero (puedes usar int.Parse o float.Parse seg�n el tipo de dato esperado)
                 
                        // Imprime el n�mero en la consola
                        Debug.Log("N�mero r: " + respuesta);

                    
                  /*  else
                    {
                        Debug.LogError("La respuesta no es un n�mero v�lido: " + respuesta);
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
                    // La respuesta de la API est� en www.downloadHandler.text
                    string respuesta = www.downloadHandler.text;
                   // string respuesta = www.downloadHandler.text;
                    P2 = respuesta;
                    // Convierte la respuesta a n�mero (puedes usar int.Parse o float.Parse seg�n el tipo de dato esperado)
                 
                        // Imprime el n�mero en la consola
                        Debug.Log("N�mero recibido: " + respuesta);

                    
                  /*  else
                    {
                        Debug.LogError("La respuesta no es un n�mero v�lido: " + respuesta);
                    }*/
                }
            }
            yield return new WaitForSecondsRealtime(1f);
          
            StopCoroutine(HacerPeticion2(null));
        }
    }

}
