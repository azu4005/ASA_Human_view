using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfCube : MonoBehaviour
{
    GameObject original;
    // Start is called before the first frame update
    void Start()
    {
        original = GameObject.Find("original_shlf");
        this.transform.position = original.transform.position;
        this.transform.rotation = original.transform.rotation;
        this.transform.localScale = original.transform.localScale;
        Debug.Log("cube");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
