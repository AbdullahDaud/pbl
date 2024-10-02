using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f; // HP maksimum musuh
    private float currentHealth; // HP saat ini
    public Slider healthBar; // Referensi ke Slider UI

    private void Start()
    {
        currentHealth = maxHealth; // Set HP awal
        UpdateHealthBar(); // Update bar HP di awal
    }

    // Fungsi untuk mengurangi HP
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Pastikan HP tidak kurang dari 0
        UpdateHealthBar(); // Update bar HP setelah menerima damage

        if (currentHealth <= 0)
        {
            Die(); // Panggil fungsi mati jika HP habis
        }
    }

    // Fungsi untuk memperbarui bar HP
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth; // Update nilai slider
        }
    }

    // Fungsi untuk menangani kematian musuh
    private void Die()
    {
        // Tambahkan logika kematian di sini, seperti menghancurkan objek musuh
        Destroy(gameObject);
    }
}