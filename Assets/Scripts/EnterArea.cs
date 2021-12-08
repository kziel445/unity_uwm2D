using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterArea : MonoBehaviour
{
    internal bool ifPlayerIn = false;
    internal GameObject playerPosition;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ifPlayerIn = true;
            playerPosition = collision.gameObject;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ifPlayerIn = false;
        }
    }
}
