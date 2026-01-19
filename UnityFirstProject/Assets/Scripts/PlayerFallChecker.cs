using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFallChecker : MonoBehaviour
{
    public float fallY = -5f;
    private bool isDead = false;

    void Update()
    {
        if (isDead) return;

        if (transform.position.y < fallY)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}

