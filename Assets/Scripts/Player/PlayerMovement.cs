using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.Mathematics;

public class PlayerMovement : MonoBehaviour
{
    public float velocity = 5f; //Velocidad del jugador

    public float jumpVel; //Velocidad del salto
    public float jumpHeight = 5f;
    public float timeToJumpApex = 0.5f;
    private bool isJumping = false;
    [SerializeField] private float gravity;
    [SerializeField] private float gravityChange = 1f;

    private Vector2 movement; //Vector para saber la direccion del movimiento del jugador
    private Rigidbody2D rb; //Rigidbody

    public Animator animator; //Animator

    public LayerMask GroundLayer; //Detectar objetos con cierta layer puesta

    public Transform groundCheckPoint; //Punto donde se dibuja la esfera para checar si el jugador esta en el suelo
    public float radius; //Radio de la esfera mencionada
    
    private float coyoteTime = 0.1f; //Tiempo que queremos que dure el coyote time
    private float coyoteTimeCounter; //Contador con el que checamos el coyote time


    private Sounds sounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sounds = GetComponent<Sounds>();
        gravity = (2 * jumpHeight) / math.pow(timeToJumpApex, 2);
        jumpVel = math.abs(gravity) * timeToJumpApex;
        rb.gravityScale = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        rb.WakeUp();
        movement.x = Input.GetAxisRaw("Horizontal"); // recibir input de derecha o izquierda

        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        animator.SetBool("onFloor", isGrounded());
        animator.SetFloat("movement", movement.x);

        if (isGrounded()) //Coyote time related stuff
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimeCounter > 0f && !isJumping) //jump action
        {
            sounds.jump();
            Jump();
            coyoteTimeCounter = 0f;
            StartCoroutine(JumpCooldown());
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(movement * velocity * Time.deltaTime); //mover el jugador de derecha a izquierda
    }

    private bool isGrounded() // funcion para checar si el jugador esta en el piso
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, radius, GroundLayer);
    }

    private void Jump() // funcion para saltaar
    {
        rb.linearVelocityY = jumpVel;
        //rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVel);
        //animator.SetBool("onFloor", false);
    }

    private IEnumerator JumpCooldown() //cooldown para el salto
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }

    private void OnDrawGizmos() // gizmo para checar el circulo que se usa en la funcion isGrounded
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheckPoint.position, radius);
    }
}
