using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 500; // vida total
    public int health; // vida actual
    private bool isDead = false;
    public Slider slider;
    private EnemyMovement jefe;
    public GameObject requiemAeternam;
    public AudioSource AudioSource;
    private Boss1Sounds sound;
    public Animator animator;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        sound = GetComponent<Boss1Sounds>();
        slider.maxValue = maxHealth;
        health = maxHealth;
        jefe = gameObject.GetComponent<EnemyMovement>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
        if (health <= 0 && isDead == false)
        {
            //animator.SetTrigger("Dead");
            Die();
        }
    }

    private void healthCheck()
    {

    }

    private void Die()
    {
        isDead = true;
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        //AudioSource.Pause();
        StartCoroutine(ShowRequiemAeternam());
        //sound.bossEnd();
        jefe.enabled = false;
    }

    private IEnumerator ShowRequiemAeternam()
    {
        //requiemAeternam.SetActive(true);
        yield return new WaitForSeconds(3f);
        //requiemAeternam.SetActive(false);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}
