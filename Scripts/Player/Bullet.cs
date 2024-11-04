using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void OnCollisionEnter(Collision c)
    {
        if(c != null)
        {
            if (c.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                EnemyStart enemyStart = c.gameObject.GetComponent<EnemyStart>();

                if (enemyStart != null)
                {
                    enemyStart.takeDamage(10f);
                }
            }
        }
    }
}
