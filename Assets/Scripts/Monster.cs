using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    [HideInInspector]
    public float speed;
    public Rigidbody2D myBody;

    void Awake() {
      myBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      myBody.velocity = new Vector3(speed, myBody.velocity.y, 0);
    }
}
