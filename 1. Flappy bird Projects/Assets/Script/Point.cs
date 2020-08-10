using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;
    
    void Update()
    {
        //melakukan pengecekan burung mati atau tidak
        if(!bird.IsDead())
        {
            //Menggerakkan game object kesebelah kiri dengan kecepatan terentu
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    public void SetSize(float size)
    {
        //mendapatkan komponen boxcollider2d
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        //pengecekan null variable
        if(collider != null)
        {
            //mengubah ukuran collider sesuai dengan parameter
            collider.size = new Vector2(collider.size.x, size);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //mendapatkan komponen Bird
        Bird bird = collision.gameObject.GetComponent<Bird>();

        //Menambah score jika burung tidak null dan belum mati
        if (bird && !bird.IsDead())
        {
            bird.AddScore(1);
        }
    }
}
