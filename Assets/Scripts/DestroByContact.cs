using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//5 sırada yazdığımız script.amaç: ışınların ve asteroid in çarpma anında yok olması yani ateş edip hem objenin 
//hem de ateş objesinin kaybolması
public class DestroByContact : MonoBehaviour
{

    public GameObject explosion;//patlama sahnesi için
    public GameObject playerExplosion;//patlama player için
    private GameController gameController;//bunu Gamecontroller scriptine ulaşabilmek için yazdık.bu artık 
    //asteroid içinde görünüyor.ama Hiyerarşiden sürükleyip bırakamayız. bu yüzden start dosyasında tanımlıyoruz aşağıda

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        //Tag olarak gamecontroller vermiştik başlarda. birtane oyun objemiz var ve onu tag i ile birlikte bul ve bunu
        // getcomponent yap yani aynı isimden gatcomponent oluştur.artık yukarıdaki public i private yapabiliriz.artık 
        //Gamecontroller script i içindeki UpdateScore i çağırabiliriz.
        //NOT: Score Text i sürükleyip GameController deki Score Text kısmına atıyoruz.
    }
    void OnTriggerEnter(Collider other)
    {
        //bu aşağıdaki kodu çalıştırdığımız zaman asteroid görünmüyor.çünkü daha önce oluşturduğumuz boundary adlı
        //oyun alanı(bu alana çarpan her nesne yok oluyordu. çünkü ateş ettiğimiz zaman ateş sonsuza kadar gitmesin 
        //yok olsun demiştik.) asteroid i de yok ediyor.o yüzden Boundary yi seçiyoruz. Tag kısmında add Tag kısmına 
        //Boundary yazıp onu seçiyoruz. ve buna referans vereceğiz.

        if(other.gameObject.tag=="Boundary")//eğer gamaobjenin tag ı Boundary ise if dışındaki kodları okuma
        {
            return;
        }
        
        //OBJENİN PATLAMASI İÇİN FONKSİYON
        Instantiate(explosion, transform.position, transform.rotation);//geminin patlamasını temsil ediyor.
                        
        //3 öğe isteniyor. objenin kendisi,pozisyonu ve rotasyonu.
        //1 obje explosionun kendisi olacak.2- playerın kendisi patlayacak çarpışma anında yani transform.position)
        //Instantiate(explosion,transform.position,)
        //VFX içindeki explosion_asteroid adlı daha önceden indirdiğimiz patlama animasyonunun sürükleyip
        //Asteroid içindeki DestroybyContact içindeki exlosion içine atıyoruz.

        //playership kısmında add tag kısmına Player diye tag ekliyoruz ve seçiyoruz.

        //BİZİM PATLAMAMIZ İÇİN FONKSİYON
        if(other.tag=="Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //yukarıdaki explosion instatiate de yaptığımız gibi explosion_player ı sürükleyip playerExplosion
            //kısmına birakıyoruz. böylece uzay gemisi eğer asteroide çarparsa farklı bir ses çıkacak
            gameController.GameOver();//biz ölürsek bu fonksiyonu çağırmış oluyoruz. 
        }

        //işin çarparsa ışını yoket
        Destroy(other.gameObject);
        //ışının çarptığı objeyi yoket.
        Destroy(gameObject);
        gameController.UpdateScore();//yukarıda bunu açıkladık.

    }

}
