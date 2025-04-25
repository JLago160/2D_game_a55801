using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;

    public int maxHealth = 5;
    private int currentHealth;

    private void Start()
    {
        // Inicializa a vida no início
        currentHealth = maxHealth;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontal = 0.0f;
        float vertical = 0.0f;

        // Movimento horizontal
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -1.0f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1.0f;
        }

        // Movimento vertical
        if (Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 1.0f;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -1.0f;
        }

        Vector2 move = new Vector2(horizontal, vertical).normalized; // Normaliza para velocidade igual em diagonal
        transform.Translate(move * speed * Time.deltaTime);
    }

    // Função pública para receber dano
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took damage! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }
}

