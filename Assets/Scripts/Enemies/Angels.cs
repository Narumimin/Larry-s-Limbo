using UnityEngine;
using System.Collections;

public class Angels : MonoBehaviour
{
    public int speed = 3;
    public GameObject BEAM;
    private bool shooting = false;
    public AudioClip audioClip;

    public void Update()
    {
        if (shooting == false)
        {
            StartCoroutine((ShotingCooldown()));
        }
    }

    public IEnumerator ShotingCooldown()
    {
        shooting = true;
        StartCoroutine(ShootingAngel());
        yield return new WaitForSeconds(3);
        shooting = false;
    }
    public IEnumerator ShootingAngel()
    {
        AngelAudio();
        yield return new WaitForSeconds(0.5f);
        BEAM.SetActive(true);
        yield return new WaitForSeconds(1f);
        BEAM.SetActive(false);
    }
    public void AngelAudio()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position, 0.3f);
    }
}
