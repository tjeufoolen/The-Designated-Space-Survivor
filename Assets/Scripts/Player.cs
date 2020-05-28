using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private ParticleSystem smoke = null;
    [SerializeField] private float tapForce = 10;
    [SerializeField] private Game game = null;
    [SerializeField] private HealthBar healthBar = null;
    [SerializeField] private GameObject damageIndicator = null;

    private Rigidbody2D rb;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health = 100;

    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (!isAlive())
        {
            game.Die();
            Destroy(gameObject);
            return;
        }

        if (Input.GetButton("Jump"))
        {
            rb.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
            createSmoke();
        }
    }

    private bool isAlive()
    {
        return health > 0;
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        StartCoroutine(FlickerDamageIndicator());
    }

    private IEnumerator FlickerDamageIndicator()
    {
        damageIndicator.SetActive(true);
        yield return new WaitForSecondsRealtime(0.3f);
        damageIndicator.SetActive(false);
    }

    private void createSmoke()
    {
        smoke.Play();
    }
}
