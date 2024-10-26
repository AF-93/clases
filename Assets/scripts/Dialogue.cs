using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{   [SerializeField] private GameObject Exclamation;
    [SerializeField] private GameObject DialogeBox;
    [SerializeField] private string[] Dialogues;
    [SerializeField] private TMP_Text DialogueTxt;
    private bool CanTalk;
    void Update()
    { 
        if(CanTalk){
            if(Input.GetKeyDown(KeyCode.T)){
                DialogeBox.SetActive(true);
                Exclamation.SetActive(false);
                int Rand =  UnityEngine.Random.Range(0,Dialogues.Length);
                DialogueTxt.text = Dialogues[Rand];
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
        Exclamation.SetActive(true);
        CanTalk = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
        Exclamation.SetActive(false);
        DialogeBox.SetActive(false);
        CanTalk = false;
        }
    }
}
