using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class ApiRequest : MonoBehaviour
{
    public GetIPData getIPData;


    public static ApiRequest Instance;

    public int index = 0;
    int edad = 0;


    //  [SerializeField] string apiURL, myIP;
    [SerializeField] List<string> IPList = new List<string>();
    [SerializeField] GameObject ipNameObject;

    [Header("Parse")]
    [SerializeField] public List<string> apis = new List<string>();
    [SerializeField] public List<string> apisnames = new List<string>();
    [SerializeField] public List<string> apisages = new List<string>();


    [SerializeField] string apiURL, myIP, ips;

    UnityWebRequestAsyncOperation operation;
    string resutado = "";

    public string apiToGet = "";


   public TMP_InputField apiRegister, getApi;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this.gameObject);
    }

    public async void GetApi()
    {
        ips = getApi.text;
        await GetRequest(ips);
    }

    [ContextMenu("Request Api")]
    public async void GetAllElements()
    {
        await GetRequest(apiURL);
    }

    [ContextMenu("Register Api")]
    public async void RegisterIP(string ip)
    {
        await GetRequest(ip);
        Parse(resutado);
    }


    async Task GetRequest(string Url)
    {
        using var www = UnityWebRequest.Get(Url);
        operation = www.SendWebRequest();
        while (!operation.isDone) await Task.Yield();

        if (www.result == UnityWebRequest.Result.Success)
        {
            resutado = www.downloadHandler.text;
            Debug.Log(resutado);

        }
    }


    [ContextMenu("Parse")]
    public void Parse(string textoCompleto)
    {
        List<(string, string)> nombresYIPs = new List<(string, string)>();
        List<string> nombres = new List<string>();
        List<string> ips = new List<string>();
        // Tu texto completo como un solo string
     //  string textoCompleto = "([('nestor', '172.16.48.100'), ('ricardo', '172.16.48.132'), ('aldo', '172.16.48.154'), ('pedro', '172.16.48.32'), ('tobias', '172.16.48.139'), ('carla', '172.16.48.69'), ('alam', '172.16.48.153')], ['nestor', 'ricardo', 'aldo', 'pedro', 'tobias', 'carla', 'alam'], ['172.16.48.100', '172.16.48.132', '172.16.48.154', '172.16.48.32', '172.16.48.139', '172.16.48.69', '172.16.48.153'])";
      //  string textoCompleto = "([('nestor', '172.16.48.100'), ('ricardo', '172.16.48.132'), ('aldo', '172.16.48.154'), ('pedro', '172.16.48.32'), ('tobias', '172.16.48.139'), ('carla', '172.16.48.69'), ('alam', '172.16.48.153')], ['nestor', 'ricardo', 'aldo', 'pedro', 'tobias', 'carla', 'alam'], ['172.16.48.100', '172.16.48.132', '172.16.48.154', '172.16.48.32', '172.16.48.139', '172.16.48.69', '172.16.48.153'])";

        // Usar expresiones regulares para extraer los nombres y direcciones IP

        // Patrón de coincidencia para los pares (nombre, IP)
        string patron = @"\('([^']*)', '([^']*)'\)";

        MatchCollection coincidencias = Regex.Matches(textoCompleto, patron);

        foreach (Match coincidencia in coincidencias)
        {
            string nombre = coincidencia.Groups[1].Value;
            string ip = coincidencia.Groups[2].Value;
            nombresYIPs.Add((nombre, ip));
        }

        // Patrón de coincidencia para la lista de nombres
        patron = @"\['([^']*)'\]";
        coincidencias = Regex.Matches(textoCompleto, patron);

        foreach (Match coincidencia in coincidencias)
        {
            string nombre = coincidencia.Groups[1].Value;


        }

        // Patrón de coincidencia para la lista de IPs
        patron = @"\['([^']*)'\]";
        coincidencias = Regex.Matches(textoCompleto, patron);

        foreach (Match coincidencia in coincidencias)
        {
            string ip = coincidencia.Groups[1].Value;
            ips.Add(ip);
            apis.Add(ip);
        }

        // Mostrar los resultados para verificar
        Console.WriteLine("Nombres y Direcciones IP:");
        foreach (var (nombre, ip) in nombresYIPs)
        {
            apisnames.Add(nombre);
            apis.Add(ip);
            Debug.Log($"{nombre}: {ip}");
        }

        Console.WriteLine("\nNombres:");
        foreach (var nombre in nombres)
        {
            apisnames.Add(nombre);
            Debug.Log(nombre);
        }

        Console.WriteLine("\nDirecciones IP:");
        foreach (var ip in ips)
        {
            apis.Add(ip);
            Debug.Log(ip);
        }
    }


    private void Update()
    {
       
        if (apis.Count>0)
        {

           
         
            SetNewApi();
        }
    }

    [ContextMenu("Set New Api")]
    public void SetNewApi()
    {


        apiToGet = apis[index];
        
        

        if (Input.GetKeyDown("d")) 
        {
            getIPData.PideApi();
            getIPData.PrintApi();
            index ++;
           
            if (index>=apis.Count-1)
            {
                index = 0;
            }
        } 
        
       /* if (Input.GetKeyDown("a") ) 
        {
            index --;
            getIPData.PideApi();
            getIPData.PrintApi();
            if (index==-1)
            {
                index = apis.Count-1;
            }
        }*/
    }

}
