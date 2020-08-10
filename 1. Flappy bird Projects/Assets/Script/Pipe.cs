using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    //global variable
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;

    
    // dipanggil tiap frame
    void Update()
    {
        //pengecekan jika burung belum mati
        if(!bird.IsDead())
        {
            //membuat pipa bergerak ke kiri dengan kecepatan tertentu
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    //Membuat bird mati ketika bersentuhan dan menjatuhkannya ke ground jika mengenai di atas collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {

            Bird bird = collision.gameObject.GetComponent<Bird>();

            //cek null value
            if (bird)
            {
                //mendapatkan komponen collider pada game object
                Collider2D collider = GetComponent<Collider2D>();

                //melakukan pengecekan null vaariable atau tidak
                if (collider)
                {
                    //menonaktifkan collider
                    collider.enabled = false;
                }

                //bird mati
                bird.Dead();
            }
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
