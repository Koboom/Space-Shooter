using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary//class oluşturduk heryerden çağırabiliriz.
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    Rigidbody physic;//tanımlıyoruz burada.
    AudioSource audioPlayer; //ses dosyası için tanımlıyoruz.
    [SerializeField]int speed;//heryerden okunabilsin diye
    [SerializeField] int tilt;//heryerden okunabilsin diye
    [SerializeField] float nextFire;//bir sonraki ateş
    [SerializeField] float fireRate;//ateşleme oranı
    public Boundary boundary;
    public GameObject shot;//obje olarak veriyoruz.lazerin kendisi.oluşan yere Bolt diye oluşturduğumuz lazer görünümlü
    //resim i sürükleyip bırakıyoruz.
    public GameObject shotSpawn;//ışının çıktığı yer.buraya da shotSpawn ı sürükleyip bırakıyoruz.
    

    void Start()
    {
        physic = GetComponent<Rigidbody>();//bir kere component içinde tanımlıyoruz.
        audioPlayer = GetComponent<AudioSource>(); //bir kere component içinde tanımlıyoruz.  
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time>nextFire)
        {
            physic.freezeRotation = true;
            nextFire = Time.time+fireRate;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);

            //bu lazer oluştuktan hemen sonra lazer sesinin oluşmasını istiyoruz.önce weapensound tu tutup
            //playership içine sürüklüyoruz ve ses içindeki play on aweke tikini kaldırıyoruz. ses dosyalarını
            //her oyun objesinin içine sürükleyebiliriz istersek.
            audioPlayer.Play();//bu komutla artık biz ateş ettiğimiz zaman ses çıkaracak.
            //arka plana da ses ekliyoruz ve loop özelliğini tikliyoruz ve müzik kesilmeden devam edebiliyor.
        }
        
        //her frame de lazer üret
        //lazerin kendisi,ışının pozisyonu,ışının yönü
        //shotspawn ı sürükleyip playership içinde oluşan shotSpawn içine atıyoruz.
        //prefabs içindeki bolt u sürükleyip playership içinde oluşan Shot içine atıyoruz.
    }
    void FixedUpdate()
    {

        physic.freezeRotation = true;
        float moveHorizontal = Input.GetAxis("Horizontal");//sağ-sol
        float moveVertical = Input.GetAxis("Vertical");//öne-arkaya

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);//movement içine atıyoruz vektör değerlerini

        physic.velocity = movement*speed;//hızı ekrandan değiştirebiliriz.
        //x y z değerleri için hangi sınırlar içinde oynayabiliriz tanımlıyoruz.
        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x,boundary.xMin,boundary.xMax),
            0,
            Mathf.Clamp(physic.position.z,boundary.zMin,boundary.zMax)
            );
        physic.position = position;//tanımladığımız sınırları fizik değerlerinin içine atıyoruz.

        physic.rotation = Quaternion.Euler(0,0,physic.velocity.x*tilt);//dönüşlerde eğimi sağlıyoruz.
        
    }
}
