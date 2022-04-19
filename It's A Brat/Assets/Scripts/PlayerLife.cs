using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private static int lives;
    [SerializeField] private Text livesText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if(lives == 0)
        {
            lives = 3;
        }
        else
        {
            lives--;
        }
        livesText.text = "Lives: " + lives;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        if(lives == 1)
        {
            SceneManager.LoadScene("GameOver");
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
