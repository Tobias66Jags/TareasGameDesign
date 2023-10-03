using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetName : MonoBehaviour
{
    public TextMeshProUGUI name;
    void Start()
    {
        int index = Random.Range(0, ApiRequest.Instance.apisnames.Count - 1);
        string newName = ApiRequest.Instance.apisnames[index];
        name.text = newName;
    }

  
}
