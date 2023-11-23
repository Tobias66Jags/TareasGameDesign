using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Data;

public class SetCard : MonoBehaviour
{
    public TextMeshProUGUI numP1;
    public TextMeshProUGUI numP2;
    public TextMeshProUGUI numP3;
    public TextMeshProUGUI numP4;
    public TextMeshProUGUI numP5;
    public float numeroRespuesta;

    int random =0;

    private void Start()
    {
        numP1.text = null;
        numP2.text = null;
        numP3.text = null;
        numP4.text = null;
        numP5.text = null;
    }
    public void RandomCard()
    {
        random = Random.Range(1, 52);
        
        numP1.text= random.ToString(); 
        numP2.text= random.ToString(); 
        numP3.text= random.ToString(); 
        numP4.text= random.ToString(); 
        numP5.text= random.ToString(); 
    }

    public void SetNewCardValue(string a)
    {
        StartCoroutine(HacerPeticion(a+random));
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
