using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health =4f;
    public static int EnemiesAlive=0;

    // Start is called before the first frame update
    void Start()
    {
        EnemiesAlive++;

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > health)
        {
            
            Die();
            if(EnemiesAlive <=0)
            {
                if(GameManager.GM==null)
                {
                    return;
                }
                if(GameManager.GM.EndingScreen.activeSelf==true)
                {
                    return;
                }
                GameManager.GM.GameOver=true;
            }
        }
    }

    void Die()
    {
        EnemiesAlive--;
        Destroy(gameObject);
    }
}
