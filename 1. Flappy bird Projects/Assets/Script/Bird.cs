using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    //  Global Variables
    [SerializeField] private float upForce = 100;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent OnJump, OnDead;
    [SerializeField] private int score;
    [SerializeField] private UnityEvent OnAddPoint;
    [SerializeField] private Text scoreText;

    private Rigidbody2D rigidbody2D;
    private Animator animator;

    // init variable
    void Start()
    {
        // mendapatkan komponen baru ketika game baru berjalan
        rigidbody2D = GetComponent<Rigidbody2D>();

        // mendapatkan komponen animator pada game object
        animator = GetComponent<Animator>();
    }

    // Update tiap frame
    void Update()
    {
        // melakukan pengecekan jika belum mati dan klik kiri pada mouse
        if (!isDead && Input.GetMouseButtonDown(0))
        {
            //Burung loncat
            Jump();
        }

    }

    // Fungsi untuk ngecek mati atau belum
    public bool IsDead()
    {
        return isDead;
    }
    // membuat burung mati
    public void Dead()
    {
        // pengecekan jika belum mati dan value OnDead tidak sama dengan null
        if (!isDead && OnDead != null)
        {
            // Memanggil semua event pada OnDead
            OnDead.Invoke();
        }
        // set variable dead menjadi true
        isDead = true;
    }

    void Jump()
    {
        // cek rigidbody null atau tidak
        if(rigidbody2D)
        {
            // menghentikan kecepatan burung saat jatuh
            rigidbody2D.velocity = Vector2.zero;

            // Menambah gaya ke arah sumbu y agar burung loncat
            rigidbody2D.AddForce(new Vector2(0, upForce));
        }

        //pengecekan null variable
        if(OnJump != null)
        {
            // menjalankan semua event onJump
            OnJump.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // menghentikan animasi burung ketika bersentuhan dengan objek lain
        animator.enabled = false;
    }

    public void AddScore(int value)
    {
        //Menambahkan Score value
        score += value;

        //Pengecekan Null Value
        if (OnAddPoint != null)
        {
            //Memamnggil semua event pd OnAddPoint
            OnAddPoint.Invoke();
        }

        //Mengubah Nilai text pd score text
        scoreText.text = score.ToString();
    }
}

