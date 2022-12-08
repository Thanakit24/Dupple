using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueguy : BasePlayer
{
    public float combineDistance = 3f; //initial value
    [SerializeField] private Transform locationToCombine;
    public Vector2 redGuyPos;
    public GameObject mainGuy; 
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        GameManager.instance.blueGuy = this;
        this.arrowSprite.SetActive(true);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    protected override void Update()
    {
        base.Update();
        redGuyPos = GameManager.instance.redGuy.transform.position;
        if (Input.GetKeyDown(KeyCode.E) && (Vector2.Distance(transform.position, redGuyPos) < combineDistance)) //combine //check for distance between this gameobject and redguy gameobject
        {
            print("combine");
            OnCombine();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !GameManager.instance.redGuy.enabled)
        {
            GameManager.instance.redGuy.enabled = true;
            GameManager.instance.redGuy.arrowSprite.SetActive(true);
            this.arrowSprite.SetActive(false);
            rb.velocity = Vector2.zero;
            this.enabled = false;
        }
    }
    void OnCombine()
    {
        Vector2 spawnDistance;  
        spawnDistance.x = transform.position.x + (redGuyPos.x - transform.position.x) / 2;  //finding midpoint between 2 distances // not sure if this is right
        spawnDistance.y = transform.position.y + (redGuyPos.y - transform.position.y) / 2;
        locationToCombine.position = new Vector2(spawnDistance.x, spawnDistance.y);
        Instantiate(mainGuy, locationToCombine.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(GameManager.instance.redGuy.gameObject);
        //destroy this and red guy after
    }
}
