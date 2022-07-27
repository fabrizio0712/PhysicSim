using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    //lista de objetos
    public GameObject camera;
    public GameObject wallTrap;
    public GameObject player;
    public GameObject columnx3;
    public GameObject columnx2;
    void Start()
    {
        
    }
    void Update()
    {
        // llamada a colisiones
        PlayerColision(columnx2.transform.position.x, columnx2.transform.position.y,columnx2.GetComponent<WallScript>().midwidth,
                        columnx2.GetComponent<WallScript>().midheight);
        PlayerColision(columnx3.transform.position.x, columnx3.transform.position.y, columnx3.GetComponent<WallScript>().midwidth,
                        columnx3.GetComponent<WallScript>().midheight);
        // condiciones de derrota
        if (player.transform.position.x - player.GetComponent<PlayerScript>().midwidth <=
            wallTrap.transform.position.x + wallTrap.GetComponent<WallTrapScript>().midwidth) 
        {
            camera.GetComponent<CameraScript>().moveEnable = false;
            wallTrap.GetComponent<WallTrapScript>().moveEnable = false;
            player.gameObject.SetActive(false);
        }
        
    }
    void PlayerColision(float posX, float posY, float midWidth, float midHeight) 
    {
        // condicion para la colicion
        if ((player.transform.position.x >= posX - midWidth - player.GetComponent<PlayerScript>().midwidth &&
            player.transform.position.x <= posX + midWidth + player.GetComponent<PlayerScript>().midwidth) &&
            (player.transform.position.y <= posY + midHeight + player.GetComponent<PlayerScript>().midheight &&
            player.transform.position.y >= posY - midHeight - player.GetComponent<PlayerScript>().midheight)) 
        {
            // condiciones en Y
            if (player.transform.position.y > posY + midHeight)
            {
                player.transform.position = new Vector2(player.transform.position.x, posY + midHeight + player.GetComponent<PlayerScript>().midheight);
                player.GetComponent<PlayerScript>().ForceY = 90f;
            }
            else if (player.transform.position.y < posY - midHeight)
            {
                player.transform.position = new Vector2(player.transform.position.x, posY - midHeight - player.GetComponent<PlayerScript>().midheight);
                player.GetComponent<PlayerScript>().Speed = new Vector2(player.GetComponent<PlayerScript>().Speed.x, 0);
                player.GetComponent<PlayerScript>().Accel = new Vector2(player.GetComponent<PlayerScript>().Accel.x, 0);
            }
            else if (player.transform.position.x < posX - midWidth)
            {
                player.transform.position = new Vector2(posX - midWidth - player.GetComponent<PlayerScript>().midwidth, player.transform.position.y);
            }
            else if (player.transform.position.x > posY + midWidth)
            {
                player.transform.position = new Vector2(posX + midWidth + player.GetComponent<PlayerScript>().midwidth, player.transform.position.y);
            }
            


            

        }
    }
}
