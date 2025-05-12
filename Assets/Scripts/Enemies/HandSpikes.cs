using UnityEngine;
using System.Collections;

public class HandSpikes : MonoBehaviour
{
    private BoxCollider2D BoxCollider2D;
    private bool spikesUp = false;
    public AudioClip audioClip;

    private void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (spikesUp == false)
        {
            StartCoroutine(SpikesCooldown());
        }
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

    private IEnumerator SpikesCooldown() //cooldown para el salto
    {
        spikesUp = true;
        BoxCollider2D.enabled = true;
        yield return new WaitForSeconds(1);
        BoxCollider2D.enabled = false;
        yield return new WaitForSeconds(1);
        spikesUp = false;
        
    }
    public void HandSpikesAudio()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position, 0.5f);
    }
}
