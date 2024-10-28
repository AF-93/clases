using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{   
    [SerializeField] private GameObject cam1;//en el inspector seleccionamos la camara actual.
    [SerializeField] private GameObject cam2;//en el inspector seleccionamos a que camara cambiar.
    void OnTriggerEnter2D(Collider2D collision){//Al entrar en coontacto con el collider 2D se activa el Trigger
        cam1.SetActive(false);                  //La camara 1 se desactiva
        cam2.SetActive(true);                   //y activamos la camara 2.
    }
}
//Este Scrip debe ir en un Game Object vacio con un collider2D el cual setearemos como trigger y lo utilizaremos
//para que en cuanto el jugador colisione con este se realize el cambio de camaras.