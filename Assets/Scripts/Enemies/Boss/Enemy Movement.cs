using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyMovement : MonoBehaviour
{
    public float speed; //Velocidad de las plataformas
    public int startingPoint; //Punto inicial para la paltaforma
    public Transform[] points;
    public int damage;
    private bool moving;
    private bool attacking;
    private int randomNumber;
    private int currentPoint;
    private int nextPoint;
    public GameObject skinnyBeam;
    public GameObject BeegBeam1;
    public GameObject BeegBeam2;
    public GameObject BeegBeam3;
    public GameObject BeegBeam4;
    public GameObject BeegBeam5;
    public GameObject BeegBeam6;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    public Animator animator;
    private int i; //incrementador
    private Boss1Sounds sounds;

    private void Start()
    {
        sounds = GetComponent<Boss1Sounds>();
        transform.position = points[startingPoint].position; //Teleporta el objeto al punto inicial
        currentPoint = startingPoint;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        
        //sounds = GetComponent<EnemySounds>();
    }

    void Update()
    {
        if (moving == false)
        {
            randomNumber = Random.Range(startingPoint, points.Length);
            nextPoint = randomNumber;
            moving = true;

        }

        if (Vector2.Distance(transform.position, points[randomNumber].position) < 0.1f) //compara la distancia entre el objeto y uno de los puntos donde va a pasar
        {
            transform.position = points[randomNumber].position;
            moving = false;
            if (attacking == false)
            {
                StartCoroutine(Attacking(9));
            }
        }        
        
        if (attacking == false)
        {
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            Vector2 movement = transform.position - points[randomNumber].position;
            if (movement.x < 0)
                transform.localScale = new Vector3(1f, 1f, 1f);
            if (movement.x > 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);
            transform.position = Vector2.MoveTowards(transform.position, points[randomNumber].position, speed * Time.deltaTime); //Mueve el onjeto hacia uno de los puntos donde va a pasar
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

    private IEnumerator SkinnyBeamAttack(float timeAttack)
    {
        attacking = true;
        //StartCoroutine(DashSound(timeAttack));
        yield return new WaitForSeconds(timeAttack);
    }

    private IEnumerator BeegBeamAttack(float timeAttack)
    {
        attacking = true;
        //StartCoroutine(DashSound(timeAttack));
        yield return new WaitForSeconds(timeAttack);
    }

    private IEnumerator DashSound(float timeAttack)
    {
        yield return new WaitForSeconds(timeAttack);
        //sounds.dash();
    }

    private IEnumerator Attacking(float time) 
    {
        attacking = true;
        spriteRenderer.enabled = true;
        boxCollider2D.enabled = true;

        
        yield return new WaitForSeconds(1.5f);
        sounds.smolAttack();
        animator.SetTrigger("smol");
        yield return new WaitForSeconds(0.5f);

        GameObject skinny = Instantiate(skinnyBeam);
        skinny.GetComponent<SkinnyBeam>().isSpawned = true;
        StartCoroutine(SkinnyBeamAttack(2f));

        yield return new WaitForSeconds(1f);

        sounds.beegAttack();
        GameObject beeg = Instantiate(BeegBeam1);
        beeg.GetComponent<BeegBeam>().isSpawned = true;
        StartCoroutine(BeegBeamAttack(2f));
        GameObject beeg1 = Instantiate(BeegBeam2);
        beeg1.GetComponent<BeegBeam>().isSpawned = true;
        StartCoroutine(BeegBeamAttack(2f));
        GameObject beeg2 = Instantiate(BeegBeam3);
        beeg2.GetComponent<BeegBeam>().isSpawned = true;
        StartCoroutine(BeegBeamAttack(2f));
        GameObject beeg3 = Instantiate(BeegBeam4);
        beeg3.GetComponent<BeegBeam>().isSpawned = true;
        StartCoroutine(BeegBeamAttack(2f));
        GameObject beeg4 = Instantiate(BeegBeam5);
        beeg4.GetComponent<BeegBeam>().isSpawned = true;
        StartCoroutine(BeegBeamAttack(2f));
        GameObject beeg5 = Instantiate(BeegBeam6);
        beeg5.GetComponent<BeegBeam>().isSpawned = true;
        StartCoroutine(BeegBeamAttack(2f));

        yield return new WaitForSeconds(2.5f);
        animator.SetTrigger("smol");
        sounds.smolAttack();
        yield return new WaitForSeconds(0.5f);

        GameObject skinny2 = Instantiate(skinnyBeam);
        skinny2.GetComponent<SkinnyBeam>().isSpawned = true;
        StartCoroutine(SkinnyBeamAttack(2f));
        
        yield return new WaitForSeconds(2f);

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
