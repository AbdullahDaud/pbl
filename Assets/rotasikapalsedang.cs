using UnityEngine;

public class RotateModel : MonoBehaviour
{
    void Start()
    {
        // Rotasi model 90 derajat di sumbu X
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}