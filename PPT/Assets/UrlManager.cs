using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlManager : MonoBehaviour
{
    public static string url;
    public string viewUrl, readyUrl;

    public string trueSet;


    public string PlayerID;

    private void Update()
    {
        viewUrl = url;
        readyUrl = url+"Ready/"+trueSet;
    }

    public void setUrl(string newUrl)
    {
        url = newUrl;
    } 
    public void setId(string id)
    {
        PlayerID = id;
    }
}
