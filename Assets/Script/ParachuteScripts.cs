using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteScripts : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        gameObject.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
    }
}
