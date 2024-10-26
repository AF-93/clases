using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum EnemyStateMachine //Lista de Estados
    {
        Idle,
        Perseguir,
        Atacar,
        Morir
    }
    public GameObject Triangle; //GameObject con el que trabajaremos
    private EnemyStateMachine currentState; //Declaramos Variable para el estado actual
    public Transform jugador; //Obtenemos la posicion del jugador
    public float vida = 100; //Variable de vida de nuestro npc
    public float rangoAtaque = 2f; //Rango de ataque
    public float rangoDeteccion = 5f; // Rango de deteccion
    public float velocidad = 3f; //Velocidad del movimiento

    private bool isDead = false; //Variable para saber si el npc esta muerto

    void Start()
    {
        currentState = EnemyStateMachine.Idle; //Declaramos Idle como estado actual al iniciar el script
    }

    void Update()
    {
        switch (currentState) //Utilizamos switch para utilizar metodos dependiendo del estado actual
        {
            case EnemyStateMachine.Idle:
                Idle();
                break;

            case EnemyStateMachine.Perseguir:
                Perseguir();
                break;

            case EnemyStateMachine.Atacar:
                Atacar();
                break;

            case EnemyStateMachine.Morir: 
                Morir();
                break;
        }
    }

    void Idle()
    {
        if (Vector3.Distance(transform.position, jugador.position) < rangoDeteccion && !isDead) //si la distancia entre la posicion
        {                                                  //del GameObject y el jugador es menor a la distancia elegida y no esta muerto
            currentState = EnemyStateMachine.Perseguir;    //se activa el estado perseguir
        }
    }

    void Perseguir()
    {
        transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime); //se mueve hacia la posicion
                                                                                                        //del jugador...
        if (Vector3.Distance(transform.position, jugador.position) < rangoAtaque)//Si la distancia del jugador y el GameObject es menor al rango de ataque
        {
            currentState = EnemyStateMachine.Atacar; //Cambia al estado Atacar
        }

        if (Vector3.Distance(transform.position, jugador.position) > rangoDeteccion) //Si la distancia es mayor al rango de deteccion
        {
            currentState = EnemyStateMachine.Idle;                                   //Vuelve al estado Idle
        }
    }
    void OnCollisionEnter2D(Collision2D other){ //Detecta la colision
            if (other.gameObject.CompareTag("Player")){ //si el otro objeto tiene el tag Player
                vida-=20;                               //Reduce la variable vida en 20 
            }
        }
    void Atacar()
    {   
        transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime); //Persigue al jugador
        if (vida <= 0){                             //si la vida baja a 0
            currentState = EnemyStateMachine.Morir; //Cambia al estado Morir
        }
        if (Vector3.Distance(transform.position, jugador.position) > rangoDeteccion) //Si la distancia es mayor al rango de deteccion
        {
            currentState = EnemyStateMachine.Idle;                                   //Vuelve al estado Idle
        }
    }
    
    void Morir()
    {
        Triangle.SetActive(false); //desactiva el game object con el que estamos trabajando
    }

}
