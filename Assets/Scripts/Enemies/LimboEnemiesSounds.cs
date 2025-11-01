using UnityEngine;

public class LimboEnemiesSounds : MonoBehaviour
{
    public AudioClip attackClip;
    public AudioClip deathClip;
    public AudioClip damageClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void attack()
    {
        AudioSource.PlayClipAtPoint(attackClip, transform.position, 0.3f);
    }

    public void death()
    {
        AudioSource.PlayClipAtPoint(deathClip, transform.position, 0.5f);
    }

    public void damage()
    {
        AudioSource.PlayClipAtPoint(damageClip, transform.position, 0.5f);
    }
}
