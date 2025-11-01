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

    private void SpikesUp()
    {
        BoxCollider2D.enabled = true;
    }
    private void SpikesDown()
    {
        BoxCollider2D.enabled = false;
    }

    public void HandSpikesAudio()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position, 0.5f);
    }
}
