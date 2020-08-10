using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class GroundSpawner : MonoBehaviour
{
    // menampung referensi ground yang ingin dibuat
    [SerializeField]
    private Ground groundRef;

    //menampung ground sebelumnya
    private Ground prevGround;

    //method yang akan membuat ground game object baru
    private void SpawnGround()
    {
        //cek null variable
        if (prevGround != null)
        {
            //duplikasi groundref
            Ground newGround = Instantiate(groundRef);

            //menagktifkan gameobject
            newGround.gameObject.SetActive(true);

            //menempatkan newground dengan posisi nextground dari prevground agar posisinya sejajar dg ground sebeumnya  
            prevGround.SetNextGround(newGround.gameObject);
        }
    }

    // Method ini akan dipanggil ketika terdapat game object lain yang memliki komponen collider keluar dari are collider 
    private void OnTriggerExit2D(Collider2D collision)
    {
        //mancari komponen ground dari object yang keluar dari area trigger 
        Ground ground = collision.GetComponent<Ground>();

        //pengecekan null variabel
        if(ground)
        {
            //mengisi variable ground
            prevGround = ground;
            
            //membuat ground baru
            SpawnGround();
        }
    }

}
