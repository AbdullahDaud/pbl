using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints; // Waypoints
    public int targetPoint;
    public float speed;
    public float rotationSpeed;

    private int maxEnemies = 5; // Batas maksimal kapal yang dapat beroperasi
    private int currentEnemies = 0; // Jumlah kapal yang saat ini beroperasi

    private Rigidbody rb;

    void Start()
    {
        targetPoint = 0;
        rb = GetComponent<Rigidbody>(); // Mendapatkan Rigidbody kapal
    }

    void Update()
    {
        PatrolMovement();
    }

    void PatrolMovement()
    {
        if (currentEnemies >= maxEnemies)
        {
            return; // Hentikan pergerakan jika sudah mencapai batas
        }

        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
        }

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

        Vector3 direction = (patrolPoints[targetPoint].position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void increaseTargetInt()
    {
        // Jika kapal mencapai waypoint terakhir
        if (targetPoint >= patrolPoints.Length - 1)
        {
            Destroy(gameObject);
        }
        else
        {
            targetPoint++;
            currentEnemies++; // Tambah jumlah kapal yang beroperasi
        }
    }
}
