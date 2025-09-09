using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System.Collections;

public class Enemy1 : MonoBehaviour
{
    public float speed = 2f;
    public GameObject Player;
    private bool isSpawned = false;
    private Vector3 direction;
    private Vector3 movement;
    public AudioClip attackClip;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawned == false)
        {
            AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
            direction = Player.transform.position - transform.position;
            movement = direction.normalized;
            StartCoroutine(EnemyCooldown());
            if (movement.x < 0)
                transform.localScale = new Vector3(1f, 1f, 1f);
            if (movement.x > 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        transform.position = transform.position + movement * Time.deltaTime * speed;

        //if (transform.position.x < JUGADOR.transform.position.x - 40)
        //{
        //    gameObject.SetActive(false);
        //}
    }

    private IEnumerator EnemyCooldown () //cooldown para el salto
    {
        isSpawned = true;
        yield return new WaitForSeconds(2f);
        isSpawned = false;
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
            Destroy(gameObject);
        }
    }

}