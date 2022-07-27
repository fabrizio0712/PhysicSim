using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    public GameObject parachute;
    public GameObject Bullet;
    static Vector2 speed;
    public Vector2 Speed { get => speed; set => speed = value; }
    static Vector2 accel;
    public Vector2 Accel { get => accel; set => accel = value; }
    static Vector2 force;
    static float mass { get; set; }
    static bool onfloor = false;
    static float gravity = -9.81f;
    static float parachuteforce = 0;
    static float forceX = 0;
    static float forceY = 0;
    public float ForceY { get => forceY; set => forceY = value; }
    static float jumpforce = 5000;
    static float gravityforce = 0;
    static float bulletforce = 0;
    public float midheight = 0.5f;
    public float midwidth = 0.5f;
    
    
    
    void Start()
    {
        accel = new Vector2(0, 0);
        force = new Vector2(0, 0);
        mass = 10;
        gravityforce = gravity * mass;
        parachute.GetComponent<SpriteRenderer>().enabled = false;
    }
    void Update()
    {
        if (speed.x > 0)
        {
            speed = new Vector2(speed.x - speed.x * Time.deltaTime, speed.y);
        }
        if (gameObject.transform.position.y <= 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, 0);
            speed = new Vector2(speed.x, 0);
            onfloor = true;
        }
        if (Input.GetKey(KeyCode.D) && accel.x < 3)
        {
            forceX = 180;
        }
        else 
        {
            forceX = 0;
        }
        if (Input.GetKeyDown(KeyCode.W) && onfloor)
        {
            forceY = jumpforce;
            onfloor = false;
        }
        else 
        {
            forceY = 0;
        }
        if (Input.GetKey(KeyCode.Space) && onfloor == false && speed.y <= 0)
        {
            parachuteforce = 95f;
            parachute.GetComponent<SpriteRenderer>().enabled = true;
        }
        else 
        {
            parachuteforce = 0;
            parachute.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(Bullet);
            Bullet.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            bulletforce = -10;
        }
        else 
        {
            bulletforce = 0;
        }
    }
    private void FixedUpdate()
    {
        force = new Vector2(0, 0);

        force = new Vector2(forceX + bulletforce, forceY + parachuteforce + gravityforce);

        accel = new Vector2(force.x / mass, force.y / mass);

        speed = new Vector2(speed.x + accel.x * Time.deltaTime,
                            speed.y + accel.y * Time.deltaTime);

        gameObject.transform.position =  new Vector2(gameObject.transform.position.x + speed.x * Time.deltaTime +
                                                     0.5f * accel.x * Time.deltaTime * Time.deltaTime,
                                                     gameObject.transform.position.y + speed.y * Time.deltaTime +
                                                     0.5f * accel.y * Time.deltaTime * Time.deltaTime);
    }
    
}
