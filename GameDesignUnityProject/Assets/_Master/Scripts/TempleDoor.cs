using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TempleDoor : MonoBehaviour
{
    public TextMeshProUGUI entranceText;

    public string lockText = "you need the three keys to enter";
    public string openText = "You got the three keys" +
        "press E to enter";

    private void Update()
    {
        if (!GameManager.Instance._toTheNextStage)
        {
            entranceText.text = lockText;
        }
        else
        {
            entranceText.text = openText;   
        }
    }


    public void LoadScene(string sceneName)
    {
        if (GameManager.Instance._toTheNextStage)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
