using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class GetIPData : MonoBehaviour
{
    public ApiRequest apiRequest;


    public TMP_InputField ipInputField;
    public TMP_InputField nombre;
    public TMP_InputField edad;
    public TMP_InputField intereses;
    public TMP_InputField vicios;
    public TMP_InputField lenguajes;
    public TMP_InputField lenguajesv;

    private string baseUrl = "http://172.16.48.59:5000/";
    private const string NombreApiPath = "/api/v1/nombre";
    private const string EdadApiPath = "/api/v1/edad";
    private const string InteresesApiPath = "/api/v1/intereses";
    private const string ViciosApiPath = "/api/v1/vicios";
    private const string LenguajesApiPath = "/api/v1/lenguajes";
    private const string LenguajesvApiPath = "/api/v1/lenguajesv";

    public void SendRequest()
    {
        ipInputField.text= apiRequest.apis[apiRequest.index];
        string ip = ipInputField.text;
        string apiUrl = ip;

        StartCoroutine(RequestToAPI(apiUrl, HandleApiResponse));
    }

    public void PideApi()
    {
        string apiUrl = baseUrl + "pide/todos";
        StartCoroutine(RequestToAPI(apiUrl, HandleApiResponse));
    }

    public void PrintApi()
    {
        SendRequest();
        PrintData(NombreApiPath, nombre);
        PrintData(EdadApiPath, edad);
        PrintData(InteresesApiPath, intereses);
        PrintData(ViciosApiPath, vicios);
        PrintData(LenguajesApiPath, lenguajes);
        PrintData(LenguajesvApiPath, lenguajesv);
    }


   

    private void PrintData(string apiPath, TMP_InputField textField)
    {
        string ip = ipInputField.text;
        string apiUrl = ip + apiPath;
        StartCoroutine(RequestToAPI(apiUrl, (response) =>
        {
            textField.text = response;
        }));
    }

    private void HandleApiResponse(string response)
    {
        if (!string.IsNullOrEmpty(response))
        {
            Debug.Log("Respuesta de la API: " + response);
        }
        else
        {
            Debug.LogError("Error en la solicitud a la API");
        }
    }

    IEnumerator RequestToAPI(string url, Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string response = www.downloadHandler.text;
                callback(response);
            }
            else
            {
                Debug.LogError("Error en la solicitud a la API: " + www.error);
                callback(null);
            }
        }
    }
}
