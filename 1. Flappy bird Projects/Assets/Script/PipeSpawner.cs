using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    //Global variables
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp, pipeDown;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] private float holeSize = 1f;
    [SerializeField] private float maxMinOffset = 1;
    [SerializeField] private Point point;

    //variable penampung coroutine yang sedang berjalan
    private Coroutine CR_Spawn;

    // Start is called before the first frame update
    void Start()
    {
        //memulai spawning
        StartSpawn();
    }

    void StartSpawn()
    {
        //Menjalankan fungsi Coroutine IeSpawn()
        if (CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        //Menghentikan Coroutine IeSpawn jika sebelumnya sudah dijalankan
        if(CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        //Menduplikasi game object PipeUp dan menempatkan posisinya sama dengan game object ini tp dirotasi 180 Derajat
        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0,0,180));

        //mengaktifkan game object newPipeUp
        newPipeUp.gameObject.SetActive(true);

        //menduplikasi game object pipeDown dan menempatkanya sama dengan game object
        Pipe newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);

        //mengaktifkan game object newPipDown
        newPipeDown.gameObject.SetActive(true);

        //Random Holesize
        holeSize = Random.Range(2, 4);

        //menempatkan posisi dari pipa yang sudah terbentuk agar memiliki lubang ditengahnya
        newPipeUp.transform.position += Vector3.up * (holeSize / 2);
        newPipeDown.transform.position += Vector3.down * (holeSize / 2);

        //menempatkan posisi pipa yang telah dibentuk agar posisinya menyesuaikan dengan fungsi sin
        float y = maxMinOffset * Mathf.Sin(Time.time);
        newPipeUp.transform.position += Vector3.up * y;
        newPipeDown.transform.position += Vector3.up * y;

        Point newPoint = Instantiate(point, transform.position, Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(holeSize);
        newPoint.transform.position += Vector3.up * y;
    }

    IEnumerator IeSpawn()
    {
        while (true)
        {
            //Jika bird mati stop pembuatan pipa baru
            if (bird.IsDead())
            {
                StopSpawn();
            }

            //Membuat pipa baru
            SpawnPipe();

            //Menunggu beberapa detik sesuai dengan spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
