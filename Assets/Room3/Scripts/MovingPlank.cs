using UnityEngine;
using System.Collections;

public class MovingPlank : MonoBehaviour 
{

    public static MovingPlank Instance;

	public float speed = 0.1f;
	private bool active = false;

    private Transform oldTransform;
	private float positonx;

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
		positonx = this.transform.position.x;
    }

    void Update() 
	{   //moveposition includes fiction
        if (active)
        {
			positonx += speed;
			if (positonx >= 2.5f) {
				speed *= -1;
				positonx = 2.5f;
			} else if (positonx <= 0.0f) {
				speed *= -1; 
				positonx = 0.0f;
			} 
            Rigidbody rigidbody = GetComponent<Rigidbody>();
			rigidbody.MovePosition(new Vector3(positonx, transform.position.y, transform.position.z));
        }
    }

	public void changeActive(bool status)
    {
		active = status;
    }
    /*
     void FixedUpdate() {
         Rigidbody rigidbody = GetComponent<Rigidbody>();
         rigidbody.position -= transform.forward * speed * Time.deltaTime;
         rigidbody.MovePosition(rigidbody.position + transform.forward * speed * Time.deltaTime);
     }
      */
}