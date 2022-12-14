using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float speed = 8;
    private float timer = 0;
    public bool moveEnable = true;

    void Start()
    {

    }
    void Update()
    {
        if (moveEnable)
        {
            if (timer < 3)
            {
                timer += Time.deltaTime;
            }
            if (timer > 3)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed * Time.deltaTime,
                                                        gameObject.transform.position.y, -10);
            }
        }
    }
}
