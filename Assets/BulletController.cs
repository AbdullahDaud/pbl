using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifetime = 2f; // Waktu hidup bullet
    public float damage = 10f; // Kerusakan yang diberikan

    void Start()
    {
        // Hancurkan bullet setelah waktu tertentu
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kapalbesar")) // Pastikan musuh memiliki tag "Enemy"
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(20f); // Kurangi HP musuh sebesar 20
            }

            Destroy(gameObject); // Hancurkan proyektil
        }

        if (other.CompareTag("kapalkecil")) // Pastikan musuh memiliki tag "Enemy"
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(50f); // Kurangi HP musuh sebesar 20
            }

            Destroy(gameObject); // Hancurkan proyektil
        }

        if (other.CompareTag("kapalsedang")) // Pastikan musuh memiliki tag "Enemy"
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(35f); // Kurangi HP musuh sebesar 20
            }

            Destroy(gameObject); // Hancurkan proyektil
        }
    }   

       
}