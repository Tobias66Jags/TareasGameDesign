using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class Request : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public InputField urlInputField;

    private void Start()
    {
        // Agrega un listener al campo de entrada para que se actualice cuando se cambie el texto.
        urlInputField.onEndEdit.AddListener(OnUrlInputEndEdit);
    }

    private void OnUrlInputEndEdit(string text)
    {
        // Cuando se complete la edición del campo de entrada, inicia la solicitud web.
        StartCoroutine(FetchTextFromWeb(text));
    }

    private IEnumerator FetchTextFromWeb(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error al obtener el contenido de la página web: " + www.error);
            }
            else
            {
                string webText = www.downloadHandler.text;
                textMeshPro.text = webText;
            }
        }
    }
}
