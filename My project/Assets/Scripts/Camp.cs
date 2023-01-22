using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : MonoBehaviour
{
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask playerLayerMask;

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, checkRadius, playerLayerMask))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<PlayerInventory>().UnpackInventory();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
