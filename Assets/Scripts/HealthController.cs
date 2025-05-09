using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Collections;

public class HealthController : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;

    private bool takingDamage = false;

    private PlayerMovement Player;
    public GameObject deathPannel;

    [SerializeField] private Image[] hearts;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void TakeDamage(int damage)
    {
        if (takingDamage == false)
        {
            health -= damage;
            StartCoroutine(DamageCooldown());
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].color = Color.red;
                }
                else
                {
                    hearts[i].color = Color.black;
                }
            }
            if (health <= 0)
            {
                Death();
            }
        }
    }

    public IEnumerator DamageCooldown() //cooldown para el daño
    {
        takingDamage = true;
        yield return new WaitForSeconds(1f);
        takingDamage = false;
    }

    private void Death()
    {
        deathPannel.SetActive(true);
        Player.velocity = 0;
        Player.jumpVel = 0;
    }

}
