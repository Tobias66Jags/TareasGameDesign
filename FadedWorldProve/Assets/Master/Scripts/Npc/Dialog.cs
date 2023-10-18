using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public List<string> dialogues = new List<string>();

    public GameObject panel, indicator;
    public TextMeshProUGUI dialogueText;

    private bool _dialogueActive = false;
    private bool _isTalking = false;
    private bool _canTalk = true;

    int _index = 0;

    private void Update()
    {
        if (_dialogueActive)
        {
            indicator.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.Instance.ChangeGameState();
                _dialogueActive = false;
                _canTalk = false;
                _isTalking = true;
            }

        }
        else
        {
            indicator.SetActive(false);
        }

        if (_isTalking)
        {
            Talking();
        }
    }

    public void Talking()
    {

        panel.SetActive(true);

       dialogueText.text= dialogues[_index];

        if (Input.GetKeyDown(KeyCode.C))
        {
            _index++;
        }
        if(_index>=dialogues.Count)
        {
            _index = 0;
            GameManager.Instance.ChangeGameState();
            _dialogueActive = true;
            _isTalking=false;
            panel.SetActive(false);
            _canTalk=true;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _canTalk)
        {
            _dialogueActive = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _dialogueActive = false;
        }
    }



}
