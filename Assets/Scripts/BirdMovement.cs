using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Bird movement code
        transform.Translate (speed * Time.deltaTime * 0.5f, 0, 0);
        transform.localScale = new Vector2 (5f, 5f);

    }
}
