using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Komponen akan ditambahkan jika tidak ada dan komponen tersebut tidak dapat dibuang
[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    // Global variables
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform nextPos;

    //Dipanggil tiap frame
    void Update()
    {
        //melakukan pengecekan jika burung null atau belum mati
        if (bird == null || (bird !=null && !bird.IsDead()))
        {
            //membuat pipa bergerak kesebelah kiri dengan kecepatan dari variabel speed
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    // method untuk mendapatkan game objek pd posisi nextground
    public void SetNextGround(GameObject ground)
    {
        // pengecekan null value
        if (ground != null)
        {
            //menempatkan ground berikutnya pada posisi nextground
            ground.transform.position = nextPos.position;
        }
    }
    // dipanggil ketika game object bersentuhan dengan game object yang lain
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // membuat burung mati ketika bersentuhan dengan objek ini
        if (bird != null && !bird.IsDead())
        {
            bird.Dead();
        }
    }
}
