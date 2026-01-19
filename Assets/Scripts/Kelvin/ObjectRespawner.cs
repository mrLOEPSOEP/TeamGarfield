using UnityEngine;

public class ObjectRespawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Get the RespawnPoint component from the object
        RespawnPoint respawnPoint = other.GetComponent<RespawnPoint>();
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (respawnPoint != null && respawnPoint.spawnPoint != null && rb != null)
        {
            // Teleport object to its spawn point
            other.transform.position = respawnPoint.spawnPoint.position;
            other.transform.rotation = respawnPoint.spawnPoint.rotation;

            // Stops all movement
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
