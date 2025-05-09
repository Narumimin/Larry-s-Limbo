using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public GameObject JUGADOR;

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

        gameObject.SetActive(false);
    }




    // Update is called once per frame
    void Update()
    {
        transform.position += (JUGADOR.transform.position + Vector3.up) * Time.deltaTime * speed;
        if (transform.position.x < -40)
        {
            gameObject.SetActive(false);
        }
    }
}