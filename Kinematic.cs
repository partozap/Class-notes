using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    //position comes from attached gameobject transform
    //Rotation as well
    public Vector3 linearVelocity;
    public float angularVelocity; //this is in degrees
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += linearVelocity * Time.deltaTime;
        Vector3 angularIncrement = new Vector3(0, angularVelocity * Time.deltaTime);
        transform.eulerAngles += angularIncrement;

        //uodate linear and angular velocities
        TextbookSeek mySeek = new TextbookSeek();
        mySeek.character = this;
        mySeek.target = target;
        SteeringOutput steering = mySeek.getSteering();
        linearVelocity += steering.linear * Time.deltaTime;
        angularVelocity += steering.angular* Time.deltaTime;
    }
}
