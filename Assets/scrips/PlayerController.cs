using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Movimento
    public float speed = 3.0f;

    // Vida
    public int maxHealth = 5;
    private int currentHealth;
    public int health { get { return currentHealth; } }

    // Invencibilidade
    public float timeInvincible = 2.0f;
    private bool isInvincible;
    private float damageCooldown;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Movimento
        float horizontal = 0.0f;
        float vertical = 0.0f;

        if (Keyboard.current.leftArrowKey.isPressed)
            horizontal = -1.0f;
        else if (Keyboard.current.rightArrowKey.isPressed)
            horizontal = 1.0f;

        if (Keyboard.current.upArrowKey.isPressed)
            vertical = 1.0f;
        else if (Keyboard.current.downArrowKey.isPressed)
            vertical = -1.0f;

        Vector2 position = transform.position;
        position.x += speed * Time.deltaTime * horizontal;
        position.y += speed * Time.deltaTime * vertical;
        transform.position = position;

        // Invencibilidade
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown <= 0)
            {
                isInvincible = false;
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log($"Vida: {currentHealth}/{maxHealth}");
    }
}
