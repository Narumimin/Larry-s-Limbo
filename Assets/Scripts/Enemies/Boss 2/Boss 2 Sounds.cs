using UnityEngine;

public class Boss2Sounds : MonoBehaviour
{
    public AudioClip ramAttackClip;
    public AudioClip rawrAttackClip;
    public AudioClip cawcawAttackClip;
    public AudioClip vomitAttackClip;
    public AudioClip beamClip;
    public AudioClip fallingRockClip;
    public AudioClip impactingRockClip;
    public AudioClip deathClip;
    public AudioClip damageClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void ramAttack()
    {
        AudioSource.PlayClipAtPoint(ramAttackClip, Vector3.zero, 1f);
    }

    public void rawrAttack()
    {
        AudioSource.PlayClipAtPoint(rawrAttackClip, Vector3.zero, 1f);
    }
    public void cawcawAttack()
    {
        AudioSource.PlayClipAtPoint(cawcawAttackClip, Vector3.zero, 1f);
    }
    public void vomitAttack()
    {
        AudioSource.PlayClipAtPoint(vomitAttackClip, Vector3.zero, 1f);
    }

    public void fallingRock()
    {
        AudioSource.PlayClipAtPoint(fallingRockClip, Vector3.zero, 1f);
    }
    public void impactingRock()
    {
        AudioSource.PlayClipAtPoint(impactingRockClip, Vector3.zero, 1f);
    }

    public void beamAttack() 
    {
        AudioSource.PlayClipAtPoint(beamClip, Vector3.zero, 1f);
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
