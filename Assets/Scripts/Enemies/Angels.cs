using UnityEngine;
using System.Collections;

public class Angels : MonoBehaviour
{
    public int speed = 3;
    public GameObject BEAM;
    private bool shooting = false;

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
        yield return new WaitForSeconds(5);
        shooting = false;
    }
    public IEnumerator ShootingAngel()
    {
        BEAM.SetActive(true);
        yield return new WaitForSeconds(1);
        BEAM.SetActive(false);
    }
}
