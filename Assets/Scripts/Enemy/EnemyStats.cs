using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    // Start is called before the first frame update
    EnermyAnimationHandler animator;
    public EnemyHealthBar enemyHealthBar;
    [SerializeField] private Material material;
    private float dissolveAmount = -1f;

    private void Awake()
    {
        animator = GetComponentInChildren<EnermyAnimationHandler>();
        
    }
    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        enemyHealthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        // Debug.Log(material.shader.renderQueue); 
    }

    // Update is called once per frame

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;
        currentHealth = currentHealth - damage;
        enemyHealthBar.SetHealth(currentHealth);
        animator.PlayTargetAnimation("BodyHit", true);

        // play take damge
        if (currentHealth <= 0)
        {
            // play dead
            currentHealth = 0;
            animator.PlayTargetAnimation("Dead_01", true);
            isDead = true;
            Destroy(gameObject,2);
        }
    }
}
