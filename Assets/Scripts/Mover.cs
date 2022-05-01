using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody physics;
    [SerializeField] float speed;

    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.velocity = transform.forward*speed;//ateş ettiğimiz yönü belirliyoruz.
        //bu kodu nereye atarsak onu hareket ettiriyor.
        //bu script i asteroid içine atıyoruz ve speed kısmını -1 yazıyoruz ve aşağıya doğru iniyor.
        //istersek level a göre otomatik hızı artabilir ve zorluk derecesi ona göre artmış olur.
        //NOT: asteroid adlı gameobje yi prefab a çeviriyoruz.
        
    }
}
