using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Comparador : MonoBehaviour
{
    public float PS1;
    public float PS2;
    public float PS3;
    public float PS4;
    public float PS5;

    void Start()
    {
        StartCoroutine(HacerPeticionPS1("34.139.173.148/serv/tobias/get/Player1Card"));
       

    }
    public void SetNewCardValue()
    {
       
    }
    public void GetAValues()
    {

    }

    public void EncontrarMayor(float ps1, float ps2, float ps3, float ps4, float ps5)
    {
        float mayor = Mathf.Max(ps1, ps2, ps3, ps4, ps5); // Obtén el mayor de forma inicial

        bool hayEmpate = false; // Variable para controlar si hay un empate

        // Verifica si hay empate con PS1
        if (ps1 == mayor)
        {
            hayEmpate = true;
        }

        // Verifica si hay empate con PS2
        if (ps2 == mayor)
        {
            hayEmpate = true;
        }

        // Verifica si hay empate con PS3
        if (ps3 == mayor)
        {
            hayEmpate = true;
        }

        // Verifica si hay empate con PS4
        if (ps4 == mayor)
        {
            hayEmpate = true;
        }

        // Verifica si hay empate con PS5
        if (ps5 == mayor)
        {
            hayEmpate = true;
        }

        // Imprime el resultado
        if (hayEmpate)
        {
            Debug.Log("Hay un empate. No se puede determinar el mayor.");
        }
        else
        {
            Debug.Log("El mayor es: " + mayor);
        }
    }

    public IEnumerator HacerPeticionPS1(string newUrl)
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
                    if (float.TryParse(respuesta, out PS1))
                    {
                        // Imprime el número en la consola
                        Debug.Log("carta " + PS1);
                        
                    }
                    else
                    {
                        Debug.LogError("La respuesta no es un número válido: " + respuesta);
                    }
                }


            }
            yield return new WaitForSecondsRealtime(0.2f);

        }

    }
}