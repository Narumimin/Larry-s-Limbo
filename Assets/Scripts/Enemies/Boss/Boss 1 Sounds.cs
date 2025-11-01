using UnityEngine;

public class Boss1Sounds : MonoBehaviour
{
    public AudioClip beegAttackClip;
    public AudioClip smolAttackClip;
    public AudioClip deathClip;
    public AudioClip damageClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void beegAttack()
    {
        AudioSource.PlayClipAtPoint(beegAttackClip, Vector3.zero, 1f);
    }

    public void smolAttack()
    {
        AudioSource.PlayClipAtPoint(smolAttackClip, Vector3.zero, 1f);
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
