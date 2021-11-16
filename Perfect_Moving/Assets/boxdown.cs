using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxdown : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.CompareTag("Player"))
        {
            Dead();
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.01f, 0);

        if (transform.position.y < -5.0f)
        {
            Dead();
        }
    }
}
