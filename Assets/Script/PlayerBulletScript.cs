using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    private float moveforce = 1000;
    private Vector2 speed;
    private Vector2 accel;
    private float mass = 1;

    void Start()
    {
        
    }

 
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        accel = new Vector2( moveforce / mass, 0);
        speed = new Vector2( accel.x * Time.deltaTime, 0);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + speed.x * Time.deltaTime +
                                                    accel.x * 0.5f * Time.deltaTime * Time.deltaTime, 0);
    }
}
