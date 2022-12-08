using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlatform : MonoBehaviour
{
    private void OnCollisionTriggerEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.gameObject.layer == LayerMask.NameToLayer("RedGuy"))
        {
            Destroy(gameObject);
        }
    }
}
