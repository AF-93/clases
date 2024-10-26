using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{   public float JumpForce; // Fuerza del salto
    public float CoyoteTimeDuration;// tiempo de duracion del coyote time
    public float CoyoteTimeCounter;// contador para realizar el salto
    public float moveSpeed; // Velocidad de Movimiento
    private bool IsGrounded; // Si esta o no tocando suelo
    private bool OnWall; //Detectamos si estamos en la pared
    private Rigidbody2D rb; //Declaramos la variable del RigidBody para trabajar con ella

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // obtenemos el RigidBody del objeto 2D
    }

    void Update()
    {   
        float horizontalMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // Obtenemos el movimiento a realizar horizontalmente
        
        transform.Translate(horizontalMove,0,0); // Realizamos el movimiento en el eje X y eje horizontal

        // si estamos tocando el suelo, el contador sera igual al tiempo de gracia asignado antes
        if (IsGrounded | OnWall ){
            CoyoteTimeCounter = CoyoteTimeDuration;
        }else{
            CoyoteTimeCounter -= Time.deltaTime; // caso contrario se ira restando el tiempo.
        }
        //mientras el contador sea mayor a 0 y presionemos la tecla asignada podremos realizar el salto.
        if(CoyoteTimeCounter > 0 && Input.GetKeyDown(KeyCode.Space) | OnWall && Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
        if(OnWall){ //si estamos en contacto con la pared
            rb.velocity = new Vector2(0,0); //el movimiento es 0 en ejes vertical y horizontal
            rb.gravityScale = 0;            //desactivamos la gravedad para que no caiga
        }else{
            rb.gravityScale = 1;           //caso contrario regresamos la gravedad a 1
        }
    }
    //Detectamos si estamos colisionando con el suelo y la pared, y seteamos el booleano en True o False segun corresponda.
    void OnCollisionEnter2D(Collision2D collision){ //Detectamos si estamos colisionando
        if(collision.gameObject.CompareTag("Ground")){
            IsGrounded = true;
        }
        if(collision.gameObject.CompareTag("Wall")){
            OnWall = true;
        }
    }
   
    void OnCollisionExit2D(Collision2D collision) //Detectamos si dejamos de colisionar
    {   if(collision.gameObject.CompareTag("Ground")){
        IsGrounded=false;
        }
        if(collision.gameObject.CompareTag("Wall")){
            OnWall = false;
        }
    }
    // Metodo para realizar el salto, al rigidbody le aplicamos una fuerza que lo movera en el eje Y o vertical.
    void Jump()
    {
        rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
    }

}

//En este script aprovechamos el coyote time para la mecanica de escalar entre paredes.