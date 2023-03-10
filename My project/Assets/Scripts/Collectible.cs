using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private CollectibleScriptableObject collectible;

    private void Awake()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Extrapolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        GetComponent<MeshCollider>().convex = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerInventory>())
        {
            if (collision.gameObject.GetComponent<PlayerInventory>().CheckInventory())
            {
                collision.gameObject.GetComponent<PlayerInventory>().AddInventory(collectible.GetScore());
                Destroy(gameObject);
            }
        }
    }
}
