using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public HealthUIController healthUI; // Referencia al script de UI

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthUI.UpdateHearts(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        animator.SetTrigger("Hurt");

        healthUI.UpdateHearts(currentHealth);

        
        if (currentHealth <= 0)
        {
            Debug.Log("Jugador muerto");
            animator.SetTrigger("Dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

    
}
