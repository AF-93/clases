using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{   [SerializeField] private GameObject Exclamation; //GameObject que se activara para mostrar que podes dialogar.
    [SerializeField] private GameObject DialogeBox;  //Caja de dialogo.
    [SerializeField] private string[] Dialogues;    //Linea o lineas de dialogo que deseas agregar.
    [SerializeField] private TMP_Text DialogueTxt;  //Texto de Text Mesh Pro.
    private bool CanTalk;                           //Booleano que habilita o desabilita el dialogo.
    void Update()
    { 
        if(CanTalk){
            if(Input.GetKeyDown(KeyCode.T)){   //si CanTalk es True se mostrara el cuadro de dialogo y desactivara la exclamacion al presionar la tecla designada
                DialogeBox.SetActive(true);
                Exclamation.SetActive(false);
                int Rand =  UnityEngine.Random.Range(0,Dialogues.Length);//elije un numero al azar entre 0 y el tamaño de la lista de dialogos.
                DialogueTxt.text = Dialogues[Rand]; //Cambia el texto dependiendo del indice al azar que haya salido.
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){ //si detecta que el jugador hace contacto con el collider se mostrara el signo de exclamacion
        Exclamation.SetActive(true);                    //y se cambiara el booleano CanTalk a true habilitando el dialogo        
        CanTalk = true;                                 
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){ //al salir del area de deteccion se desactivan tanto el cuadro de dialogo como el signo de exclamacion
        Exclamation.SetActive(false);                  //y el booleano CanTalk se cambiara a false, deshabilitando el dialgo.
        DialogeBox.SetActive(false);
        CanTalk = false;
        }
    }
}
