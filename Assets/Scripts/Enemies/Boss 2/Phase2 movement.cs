using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Phase2Movement : MonoBehaviour
{
    public float speed;
    public float ramAttackSpeedMult;
    public int startingPoint; //Punto inicial para la paltaforma
    public Transform[] points;
    public int damage;
    private bool moving;
    private bool attacking;
    private bool ramAttacking = false;
    private int randomNumber;
    private int currentPoint;
    private int nextPoint;
    public GameObject rock1;
    public GameObject rock2;
    public GameObject rock3;
    public GameObject rock4;
    public GameObject rock5;
    public GameObject rock6;
    public GameObject crow;
    private SpriteRenderer spriteRenderer;
    public GameObject ballAttack;
    private BoxCollider2D boxCollider2D;
    public Animator animator;
    private int i; //incrementador
    private Boss2Sounds sounds;

    private void Start()
    {
        sounds = GetComponent<Boss2Sounds>();
        transform.position = points[startingPoint].position; //Teleporta el objeto al punto inicial
        currentPoint = startingPoint;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (moving == false)
        {
            randomNumber = Random.Range(startingPoint, points.Length);
            nextPoint = randomNumber;
            moving = true;

        }

        if (attacking == false)
        {
            Vector2 movement = transform.position - points[i].position;
            if (movement.x < 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);
            if (movement.x > 0)
                transform.localScale = new Vector3(1f, 1f, 1f);
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * ramAttackSpeedMult * Time.deltaTime); //Mueve el onjeto hacia uno de los puntos donde va a pasar
        }

        if (attacking == true && ramAttacking == true)
        {
            Vector2 movement = transform.position - points[i].position;
            if (movement.x < 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);
            if (movement.x > 0)
                transform.localScale = new Vector3(1f, 1f, 1f);
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * ramAttackSpeedMult * Time.deltaTime); //Mueve el onjeto hacia uno de los puntos donde va a pasar
        }

        if (Vector2.Distance(transform.position, points[i].position) < 0.1f) //compara la distancia entre el objeto y uno de los puntos donde va a pasar
        {
            i++; // cuenta para arriba para pasar al siguiente punto
            if (i == points.Length) //compara cuantos por cuantos puntos ha pasado el objeto al numero de puntos totales
            {
                i = 0; //reinicia los puntos al inicio para que el objeto regrese a su lugar inicial
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
                moving = false;
            ramAttacking = false;
            animator.SetBool("ram", false);
            if (attacking == false)
            {
                StartCoroutine(Attacking(9));
            }
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

    private IEnumerator BallAttack(float timeAttack)
    {
        sounds.vomitAttack();
        animator.SetTrigger("Vomit");
        attacking = true;
        yield return new WaitForSeconds(timeAttack);
        GameObject ball = Instantiate(ballAttack, transform.position + new Vector3(-0.5f,1.7f,0f) , transform.rotation);
        //StartCoroutine(DashSound(timeAttack));
        
    }

    private IEnumerator RamAttack(float timeAttack)
    {
        attacking = true;
        sounds.ramAttack();
        yield return new WaitForSeconds(timeAttack);
        ramAttacking = true;
        animator.SetBool("ram", true);
    }


    private IEnumerator RawrAttack(float timeAttack)
    {
        animator.SetTrigger("lion");
        sounds.rawrAttack();
        attacking = true;
        yield return new WaitForSeconds(timeAttack);
        GameObject fallingRock1 = Instantiate(rock1);
        GameObject fallingRock2 = Instantiate(rock2);
        GameObject fallingRock3 = Instantiate(rock3);
        GameObject fallingRock4 = Instantiate(rock4);
        GameObject fallingRock5 = Instantiate(rock5);
        GameObject fallingRock6 = Instantiate(rock6);
        
    }

    private IEnumerator CrowAttack(float timeAttack)
    {
        animator.SetTrigger("crow");
        sounds.cawcawAttack();
        yield return new WaitForSeconds(timeAttack);
        GameObject cawcaw1 = Instantiate(crow, transform.position + Vector3.up*3, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        GameObject cawcaw2 = Instantiate(crow, transform.position + Vector3.up*6, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        GameObject cawcaw3 = Instantiate(crow, transform.position + Vector3.up*9, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        GameObject cawcaw4 = Instantiate(crow, transform.position + Vector3.up*12, transform.rotation);

        //sounds.dash();
    }


    
    private IEnumerator Attacking(float time)
    {
        attacking = true;
        spriteRenderer.enabled = true;
        boxCollider2D.enabled = true;
        yield return new WaitForSeconds(1f);

        StartCoroutine(BallAttack(0.8f));

        yield return new WaitForSeconds(5.5f);

        StartCoroutine(RamAttack(1.5f));

        yield return new WaitForSeconds(3.5f);

        StartCoroutine(RawrAttack(3f));

        yield return new WaitForSeconds(5f);

        StartCoroutine(RamAttack(1.5f));

        yield return new WaitForSeconds(3.5f);

        StartCoroutine(CrowAttack(1f));

        yield return new WaitForSeconds(4f);

        sounds.ramAttack();

        yield return new WaitForSeconds(1.5f);
        animator.SetBool("ram", true);

        attacking = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var healthComponent = collision.GetComponent<HealthController>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //animator.SetTrigger("Attack");
        }
    }
}

