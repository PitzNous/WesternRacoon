using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] float speed;
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.layer == 7)
            {
                collision.gameObject.GetComponent<FreezeMasterScript>().FreezeObject();
            }
            if (collision.gameObject.layer != 6)
            {
                Destroy(gameObject);
            }
        }
    }
}
