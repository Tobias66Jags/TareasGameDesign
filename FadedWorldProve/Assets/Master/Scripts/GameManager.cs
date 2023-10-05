using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isPlay = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this.gameObject);
    }







    [ContextMenu("ChangeState")]
    public void ChangeGameState()
    {
        isPlay = !isPlay;
    }
}
