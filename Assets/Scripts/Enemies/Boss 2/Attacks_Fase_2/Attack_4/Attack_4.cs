using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


public class Attack_4 : MonoBehaviour
{
    public float speed = 20f;
    public Transform spawnpoint;
    public Transform finalpoint;
    public GameObject Ray_1;
    public GameObject Ray_2;
    public GameObject Ray_3;
    public GameObject Ray_4;
    public GameObject Ray_5;
    public GameObject Ray_6;
    public GameObject Ray_7;
    public GameObject Ray_8;
    private Boss2Sounds sounds;
    private bool attacking = false;

    public void Start()
    {
        sounds = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss2Sounds>();
        float randomZAngle = Random.Range(0f, 360f);
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, randomZAngle);
        transform.rotation = randomRotation;

        Ray_1.SetActive(false);
        Ray_2.SetActive(false);
        Ray_3.SetActive(false);
        Ray_4.SetActive(false);
        Ray_5.SetActive(false);
        Ray_6.SetActive(false);
        Ray_7.SetActive(false);
        Ray_8.SetActive(false);
    }

    void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, finalpoint.position, speed * Time.deltaTime);
        if (attacking == false)
        {
            StartCoroutine(Ray());
        }
    }
    IEnumerator Ray()
    {
        attacking = true;
        yield return new WaitForSeconds(1f);
        sounds.beamAttack();
        yield return new WaitForSeconds(1f);
        Ray_1.SetActive(true);
        Ray_2.SetActive(true);
        Ray_3.SetActive(true);
        Ray_4.SetActive(true);
        Ray_5.SetActive(true);
        Ray_6.SetActive(true);
        Ray_7.SetActive(true);
        Ray_8.SetActive(true);
        StartCoroutine(Disapear());
    }

    IEnumerator Disapear()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Ray_1.SetActive(false);
        Ray_2.SetActive(false);
        Ray_3.SetActive(false);
        Ray_4.SetActive(false);
        Ray_5.SetActive(false);
        Ray_6.SetActive(false);
        Ray_7.SetActive(false);
        Ray_8.SetActive(false);
    }
}
