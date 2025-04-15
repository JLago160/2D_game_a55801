using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;





 

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;

    void Update()
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

        // Debug
        Debug.Log($"Horizontal: {horizontal}, Vertical: {vertical}");

        // Movimento
        Vector2 position = transform.position;
        position.x += speed * Time.deltaTime * horizontal;
        position.y += speed * Time.deltaTime * vertical;
        transform.position = position;
    }
}




