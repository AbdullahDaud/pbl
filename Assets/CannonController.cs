using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject bulletPrefab; // Drag prefab bullet ke sini di Inspector
    public Transform bulletSpawnPoint; // Titik di mana bullet akan ditembakkan
    public float bulletSpeed = 20f; // Kecepatan bullet
    public float rotationSpeed = 50f; // Kecepatan rotasi horizontal
    public float tiltSpeed = 2f; // Kecepatan pergerakan vertikal
    public float verticalSensitivity = 2f; // Sensitivitas pergerakan vertikal
    public float minTiltAngle = -30f; // Sudut minimum meriam
    public float maxTiltAngle = 30f; // Sudut maksimum meriam

    private float currentTiltAngle = 0f; // Sudut rotasi saat ini

    // Tambahkan referensi ke CameraShake
    public CameraShake cameraShake; // Drag skrip CameraShake ke sini di Inspector

    void Update()
    {
        // Menembak bullet saat spasi ditekan
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        // Input kontrol untuk meriam
        HandleMovement();
    }


    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A & D
        float vertical = Input.GetAxis("Vertical"); // W & S

        // Rotasi horizontal untuk mengarahkan meriam
        if (horizontal != 0)
        {
            transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);
        }

        // Menggunakan sensitivitas vertikal
        if (vertical != 0)
        {
            currentTiltAngle -= vertical * verticalSensitivity * tiltSpeed; // Tambahkan sensitivitas
            currentTiltAngle = Mathf.Clamp(currentTiltAngle, minTiltAngle, maxTiltAngle); // Batasi sudut rotasi

            // Mengubah rotasi lokal meriam berdasarkan sudut tilt
            transform.localRotation = Quaternion.Euler(currentTiltAngle, transform.localEulerAngles.y, 0); // Ubah rotasi meriam
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = bulletSpawnPoint.forward * bulletSpeed; // Mengatur kecepatan bullet
            }
            else
            {
                Debug.LogError("Rigidbody not found on bullet prefab!");
            }

            // Panggil CameraShake saat menembak
            if (cameraShake != null)
            {
                StartCoroutine(cameraShake.Shake());
            }
            else
            {
                Debug.LogError("CameraShake script is not assigned!");
            }
        }
        else
        {
            Debug.LogError("Bullet Prefab or Bullet Spawn Point is not assigned in the Inspector!");
        }
    }
}
