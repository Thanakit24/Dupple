using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakyPlatforms : MonoBehaviour
{
    public float breakTime = 2f;
    public bool playerStepped = false;

    private void Update()
    {
        if (playerStepped)
        {
            //play shaking platform animation or add small effects
            breakTime -= Time.deltaTime;

            if (breakTime <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //print("player stepped");
            if (collision.gameObject.layer == LayerMask.NameToLayer("RedGuy"))
                return;
            else
                playerStepped = true;
        }
    }
}
