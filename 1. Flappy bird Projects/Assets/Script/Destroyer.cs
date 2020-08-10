﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//menambahkan komponen Rigidbody2D dan BoxCollider2D
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //memusnahkan object ketika bersentuhan
        Destroy(collision.gameObject);
    }

}
