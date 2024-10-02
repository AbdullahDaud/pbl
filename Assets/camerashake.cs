using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float duration = 0.1f; // Durasi guncangan
    public float magnitude = 0.2f; // Intensitas guncangan
    private Vector3 originalPosition; // Posisi awal kamera

    private void Start()
    {
        originalPosition = transform.localPosition; // Simpan posisi awal kamera
    }

    public IEnumerator Shake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Guncangan hanya pada sumbu X dan Y
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            // Set posisi baru, tetapi jaga posisi Z tetap sama
            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Kembalikan posisi kamera ke semula setelah guncangan selesai
        transform.localPosition = originalPosition;
    }
}