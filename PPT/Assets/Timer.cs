using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class Timer : MonoBehaviour
{
    public Comparador comparador;


    public float numeroRespuesta;

    public float maxTime = 5;
    public float currentTime;

    public TextMeshProUGUI timerView;

    public string url1, url2;
    private void Start()
    {
        currentTime = maxTime;
        SetP("34.139.173.148/serv/tobias/Timer/" + maxTime.ToString());
        StartCoroutine(SetTimer());
      
    }

    public void SetP(string a)
    {
        StartCoroutine(HacerPeticion(a));
    }

    [ContextMenu("Timer")]
    public void InitializeTimer()
    {
        
        currentTime = maxTime;
        StartCoroutine(SetTimer());
    }

    private void Update()

    {

        if (currentTime <= 3)
        {
            Debug.Log("UWU");
            comparador.SetNewCardValue();
        }

        if (currentTime <= 0)
        {
            StopCoroutine(HacerPeticion("34.139.173.148/serv/tobias/Timer/" + currentTime.ToString()));
            comparador.EncontrarMayor(comparador.PS1, comparador.PS2, comparador.PS3, comparador.PS4, comparador.PS5);
        }
      
        Debug.Log(currentTime);
        timerView.text = currentTime.ToString();
    }
    public IEnumerator SetTimer ()
    {
        while (currentTime>0)
        {

            SetP("34.139.173.148/serv/tobias/Timer/" + currentTime.ToString());
            yield return new WaitForSecondsRealtime(1);
            currentTime--;
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
            yield return new WaitForSecondsRealtime(1f);
          //  StopAllCoroutines();
        }
    }
}
