using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABMovement : MonoBehaviour
{
    [SerializeField] Vector3 pointA;
    [SerializeField] Vector3 pointB;
    public Vector3 actualPoint;
    [SerializeField] float movementSpeed;
    public bool ifAggro = false;

    [SerializeField] EnterArea protectedArea;

    private void Start()
    {
        actualPoint = pointA;
    }
    // Update is called once per frame
    void Update()
    {
        ifAggro = protectedArea.ifPlayerIn;

        if(!ifAggro)
        {
            if (transform.position.x == pointA.x) actualPoint = pointB;
            else if (transform.position.x == pointB.x) actualPoint = pointA;

            transform.position = Movement(actualPoint, movementSpeed);
        }
        if(ifAggro)
        {
            ColliderDistance2D colliderDistance = 
                gameObject.GetComponent<Collider2D>()
                .Distance(protectedArea.playerPosition.GetComponent<Collider2D>());

            if(colliderDistance.distance > 0.05f)
            {
                transform.position = 
                    Movement(protectedArea.playerPosition.transform.position, movementSpeed * 2);
            }
            
        }
    }
    Vector3 Movement(Vector3 position, float speed)
    {
        return Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }
}
