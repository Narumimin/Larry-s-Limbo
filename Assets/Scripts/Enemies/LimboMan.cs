using Unity.VisualScripting;
using UnityEngine;

public class LimboMan : MonoBehaviour
{
    public float speed; //Velocidad de las plataformas
    public int startingPoint; //Punto inicial para la paltaforma
    public Transform[] points;
    public Animator animator;
    private int i; //incrementador
    private LimboEnemiesSounds sounds;

    private void Start()
    {
        transform.position = points[startingPoint].position; //Teleporta el objeto al punto inicial
        sounds = GetComponent<LimboEnemiesSounds>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.1f) //compara la distancia entre el objeto y uno de los puntos donde va a pasar
        {
            i++; // cuenta para arriba para pasar al siguiente punto
            if (i == points.Length) //compara cuantos por cuantos puntos ha pasado el objeto al numero de puntos totales
            {
                //transform.localScale = new Vector3(-1, 1, 1);
                i = 0; //reinicia los puntos al inicio para que el objeto regrese a su lugar inicial
            }
            else
            {
                //transform.localScale = new Vector3(1, 1, 1);
            }
        }
        Vector2 movement = transform.position - points[i].position;
        if (movement.x < 0)
           transform.localScale = new Vector3(1f, 1f, 1f);
        if (movement.x > 0)
           transform.localScale = new Vector3(-1f, 1f, 1f);
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime); //Mueve el onjeto hacia uno de los puntos donde va a pasar
    }

    public void StopEnemy()
    {
        speed = 0;
    }

    public void Death()
    {
        Destroy(gameObject);
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

}
