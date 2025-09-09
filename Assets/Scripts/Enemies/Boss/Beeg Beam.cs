using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class BeegBeam : MonoBehaviour
{
    public GameObject Player;
    public bool isSpawned = false;

    private Vector3 direction;
    private Vector3 movement;
    private Vector3 originalPosition;
    public GameObject spawnPoint;
    private BoxCollider2D boxCollider;
    //public AudioClip attackClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        transform.position = spawnPoint.transform.position;
        originalPosition = transform.position;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(EnemyCooldown());
    }

    private IEnumerator EnemyCooldown()
    {
        isSpawned = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void EnableHitbox()
    {
        boxCollider.enabled = true;
    }

    private void DisableHitbox()
    {
        boxCollider.enabled = false;
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
}
