using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}