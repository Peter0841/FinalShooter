using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStart : MonoBehaviour
{
    public float enemyHealth = 50f;
    private Renderer objectRenderer;
    private Color originalColor;
    private HudController hudController;

    void Start()
    {
        Invoke("delayAddingScript", 1.5f);
    }

    void delayAddingScript()
    {
        hudController = GameObject.Find("Canvas").GetComponent<HudController>();
        gameObject.AddComponent<NavMeshAgent>();
        gameObject.AddComponent<EnemyAI>();
        Destroy(GetComponent<Rigidbody>());
    }

    public void takeDamage(float amt)
    {
        if (gameObject != null)
        {
            enemyHealth -= amt;
            if (enemyHealth <= 0)
            {
                hudController.AddScore(1);
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Player"))
        {            
            PlayerController playerController = c.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.takeDamage(10f);
            }
        }
    }
}
