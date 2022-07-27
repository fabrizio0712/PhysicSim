using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    public GameObject camera;
    private float lenght = 23.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < camera.transform.position.x - lenght)
        {
            gameObject.transform.position = new Vector2(camera.transform.position.x + lenght,gameObject.transform.position.y);
        }
    }
}
