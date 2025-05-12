using UnityEngine;

public class Following_Enemy : MonoBehaviour
{
    public Transform player;
    public Transform detectionArea;
    public float detectionRadius;
    public LayerMask detectionLayer;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 movment;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movment = direction;

        if(movment.x < 0)
            transform.localScale = new Vector3(-1f,-1f,1f);
        if(movment.x > 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

    }

    private void FixedUpdate()
    {
        if (IsDetectingPlayer())
        {
            MoveCharacter(movment);
        }
    }

    public void StopEnemy()
    {
        speed = 0;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    public bool IsDetectingPlayer()
    {
        return Physics2D.OverlapCircle(detectionArea.position, detectionRadius, detectionLayer);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var healthComponent = collision.GetComponent<HealthController>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");
        }
       
    }

    private void OnDrawGizmos() // gizmo para checar el circulo que se usa en la funcion isGrounded
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(detectionArea.position, detectionRadius);
    }

}
