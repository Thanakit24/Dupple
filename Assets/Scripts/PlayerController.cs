using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BasePlayer
{
    [Header("Dupple Dudes")]
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private GameObject blueGuy;
    [SerializeField] private GameObject redGuy;

    public override void Update()
    {
        base.Update();
        
        if (Input.GetKeyDown(KeyCode.E)) //duplicating/split characters
        {
            print("duplicate");
            OnDuplicate();
        }

    }
    void OnDuplicate()  
    {
        //duplicate 2 players at a specified location
      
        Instantiate(redGuy, transform.position, Quaternion.identity);
        Instantiate(blueGuy, new Vector2(spawnLocation.position.x, spawnLocation.position.y), Quaternion.identity);
        Destroy(this.gameObject);

        //add feedback that it spawned
        //add arrow on top of dupp characters for feedback of which character the player's controlling. 
    }
}
    
