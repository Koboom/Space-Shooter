using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{

    //bu scripti prefabslar içindeki VFX->explosion dosyası içindeki explosionlar içine atıyoruz ve lifetime a 2 diyoruz
    //böylece 2 saniye sonra hiyerarşi içinde görünen asteroidler 2 saniye sonra fazladan alan kaplamamış oluyor.
    //yalnız bu scriptleri add yapamayabiliriz bazen eğer öyle olursa VFX->explosion içindeki patlamaları hiyerarşi 
    //içine atıyoruz ve VFX içindekileri siliyoruz ve hiyerarşi içindekinin üzerine sağ tıklayıp unpack prefab a tıklıyoruz
    //explosion_enemy üzerine tıkladıktan sonra sağda Inspector kısmında scpript kısmında missing yazar. bu scriptleri 
    //siliyoruz.sonra yeniden tutup prefabsların içine atıyoruz ve hiyerarşidekileri siliyoruz.
    //ve  add den scriptleri ekleyebiliyoruz artık. ama bu prefabsları daha önce nerede kullandıysak yeniden oralara
    //eklememiz gerekiyor.prefabs -> asteroids -> destroy by contract scripti içinde Player explosion içinde missing 
    //yazıyor. Asteroidi hiyerarşiye atıyoruz.aynı işlemleri yapıyoruz yine. asteroid içindeki eksik yere explosion_playerı
    //sürükleyip koyuyoruz.ve Asteroid i yeniden prefabs içine atıyoruz ve hiyerarşidekini siliyoruz.
    //bu kez hiyerarşideki gamecontroller içindeki gamecontroller scripti içinde hazard missing yazıyor.orayada
    //asteroid i sürüklüyoruz.
    public float lifeTime;
    
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    
}
