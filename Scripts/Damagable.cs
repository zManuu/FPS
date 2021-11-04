using UnityEngine;

public class Damagable : MonoBehaviour
{

    public float health;

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

}
