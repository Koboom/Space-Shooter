using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bu scripti 4. sırada oluşturuyoruz. 1-PlayerController 2-Mover 3-DestroyByBoundary
public class RandomRotater : MonoBehaviour
{
    Rigidbody physic;
    public int speed;
    void Start()
    {
        //rigidbody tanıtıyoruz.
        physic = GetComponent<Rigidbody>();

        //angularVelocity angular açısal demek. angularvelocity tüm x y z lerde açısal hız kazandırmak demek.
        //her astroidin hareketinin rasgele olmasını istiyoruz.
        //Random.insideUnitSphere; bu bize x y z değerlerini bir defaya mahsus giriyoruz.
        //unity üzerinde speed değerini girip uyguluyoruz.
        //Önemli: asteroids kısmında rigidbody içinde angular drag diye bir yer var burası ilk dönme hızından sonra
        //ne kadar zaman sonra duracağını belirtiyor.0 yaparsak hiç durmaz. bazı oyunlarda bunu kullanabiliriz.
        //ve start içinde uyguladığımız için random değeri bir kere uyguluyoruz.
        physic.angularVelocity = Random.insideUnitSphere*speed;
    }

    
}
