using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{   
    public enum PlayerStates{ //lista de estados del jugador
        FullHealth,
        MidHeath,
        Death

    }
    private PlayerStates currentState; //declaramos una variable para el estado actual del jugador
    public int Vida = 100; //variable con los puntos de vida del jugador
   void Start()
    {
        currentState = PlayerStates.FullHealth; //iniciamos la escena con el estado FullHealth

    }

    void Update()
    {
        switch(currentState) //mediante un switch utilizamos distintos metodos dependiendo el estado actual.
        {
            case PlayerStates.FullHealth:
                FullHealth();
            break;
            case PlayerStates.MidHeath:
                MidHeath();
            break;
            case PlayerStates.Death:
                Death();
                break;
        }
        }

       
    void FullHealth(){ //Metodo Full Health
        
        GetComponent<Renderer>().material.color = Color.green; //Pinta al personaje de verde
        if(Vida <= 50){ // si la vida es de menos o igual a 50 puntos...
            currentState = PlayerStates.MidHeath; //Cambia el estado a MidHealth
        }
    }
    void MidHeath(){
            GetComponent<Renderer>().material.color = Color.yellow;//Cambia el color a amarillo
            if (Vida <= 0){                         //si la vida es menor o igual a 0
                currentState = PlayerStates.Death;  //Cambia el estado a Death
                }
            if (Vida >50){                              //Si la vida vuelve a pasar la barrera de los 50
                currentState = PlayerStates.FullHealth; //Vuelve al estado FullHealth
            }
    }
    void Death(){
        GetComponent<Renderer>().material.color = Color.red; //Pinta de rojo al personaje
            Time.timeScale = 0;                              //Pausa el tiempo en el juego
    }

    void OnCollisionEnter2D(Collision2D other){     //detecta las colisiones
        if(other.gameObject.CompareTag("Enemy")){   //si el tag del objeto es Enemy
            Vida-=15;                               //Resta 15 puntos de vida
                }
        if(other.gameObject.CompareTag("HP")){      //si el tag del objeto es HP
            Vida+=25;   	                        //Suma 25 de vida 
            other.gameObject.SetActive(false);      //desactiva el objeto con el tag HP
        }
            }
        }
    