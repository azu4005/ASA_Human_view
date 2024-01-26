using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPostion : MonoBehaviour
{
    public GameObject Bird;
    private BoxCollider Rd;
    // Start is called before the first frame update

    private void OnCollisionStay(Collision Rb)
    {
        if (Rb.gameObject.name == "Bird")
        {
             Debug.Log(this.transform.parent.InverseTransformPoint(Bird.transform.position));
        }
  
    }
    void Start()
    {
        Rd = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
