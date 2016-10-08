using UnityEngine;
using System.Collections;

public class MovingPlank : MonoBehaviour 
{

    public static MovingPlank Instance;

    private float speed = 2.0f;
    private bool active = true;

    private Transform oldTransform;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    void start()
    {
        oldTransform = this.transform;
    }

    void Update() 
	{   //moveposition includes fiction
        if (active)
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.MovePosition(new Vector3(Mathf.PingPong(Time.time, 2.5f), transform.position.y, transform.position.z));
        }
    }

    public void changeActive()
    {
        active = !active;
    }
    /*
     void FixedUpdate() {
         Rigidbody rigidbody = GetComponent<Rigidbody>();
         rigidbody.position -= transform.forward * speed * Time.deltaTime;
         rigidbody.MovePosition(rigidbody.position + transform.forward * speed * Time.deltaTime);
     }
      */
}