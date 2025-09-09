using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Attack1 : MonoBehaviour
{
    public float speed = 5;
    public Transform spawnpoint;
    public int damage = 1;
    private Boss2Sounds sounds;

    public void Start()
    {
        sounds = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss2Sounds>();
        transform.position = spawnpoint.position;
        StartCoroutine(EnemyCooldown());
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

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private IEnumerator EnemyCooldown()
    {
        yield return new WaitForSeconds(2f);
        sounds.impactingRock();
        Destroy(gameObject);
    }
}
