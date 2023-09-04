using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool _toTheNextStage = false;

    public float maxKeys=3;
    public float currentKeys=0;

    public float timeToKey = 1.8f;

    public List<GameObject> iceBlocks = new List<GameObject>();


    private void OnEnable()
    {
      
            Instance = this;
        
    }

    private void Start()
    {
        currentKeys = 0;
        _toTheNextStage = false;
    }




    public void Update()
    {
        if (currentKeys >= maxKeys)
        {
            _toTheNextStage = true;
        }
    }

    public void AddKey()
    {
        currentKeys++;
    }

    private void OnDestroy()
    {
        Instance = this;
    }


    public void ActiveKey(GameObject Key)
    {
            StartCoroutine(ActiveUIKey(Key));   
       // StopAllCoroutines();    
    }

    public IEnumerator ActiveUIKey(GameObject KeyImage)
    {
        yield return new WaitForSeconds(timeToKey); 
        KeyImage.SetActive(true);
    }

    public void ActivateIceBlocks()
    {
        foreach (GameObject Block in iceBlocks)
        {
           Block.SetActive(true);
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
