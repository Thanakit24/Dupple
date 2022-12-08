using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakyPlatforms : MonoBehaviour
{
    public float breakTime = 2f;
    public bool playerStepped = false;
    private Material material;
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
        if (collision.gameObject.CompareTag("Player") && !playerStepped)
        {
            //print("player stepped");
            if (collision.gameObject.layer == LayerMask.NameToLayer("RedGuy"))
                return;
            else
                playerStepped = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (playerStepped && collision.gameObject.CompareTag("Player") && (collision.gameObject.layer == LayerMask.NameToLayer("RedGuy")))
        {
            print("true p step");
            playerStepped = false;
            breakTime = 2f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.layer == LayerMask.NameToLayer("RedGuy"))
        {
            breakTime = 1f;
            playerStepped = true; 
        }
    }
}
