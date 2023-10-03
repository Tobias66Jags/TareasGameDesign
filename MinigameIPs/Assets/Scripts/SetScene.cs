using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetScene : MonoBehaviour
{
  

    public void newScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
