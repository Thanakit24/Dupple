using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlatforms : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !(collision.gameObject.layer == LayerMask.NameToLayer("RedGuy")))
        {
            print("game lost");
        }
    }
}
