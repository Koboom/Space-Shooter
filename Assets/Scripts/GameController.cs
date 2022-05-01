using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//bunu biz tanımladık.Unity de Scene den birşeyler çağıracağımız zaman bu kütüphaneyi
//çağırıyoruz.void update içinde kullanacağız.

//NoT: boşgameobje oluşturuyoruz.Adı GameController diyoruz.tag da gamecontroller seçiyoruz.
//burada amacımız asteroidlerin oluşturulma islemini burada yapacağız. çünkü asteroid i prefabs içine attık.

public class GameController : MonoBehaviour
{
    public GameObject hazard; //hazard:engel demek.açılan göze Asteroid prefabs ini sürükleyip bırakıyoruz.
    public int spawnCount;
    public float spawnWait;//0.5 yazıyoruz yerine
    public float startSpawn;
    public float waveWait;//döngüler arası bekleme süresi için.
    public Text scoreText;//score texti için oluşturduk. Ui dosyası kendi oluşmuyor dikkat.
    public int score;//score için int değer.

    public Text GameOverText;//Gameover içint text 
    public Text restartText;//yeniden başlama için text 
    //oluşan gözlerin içine oluşturduğumuz textleri atıyoruz.
    public Text quitText;//bunu tanımladıktan sonra hiyerarşideki QuitText dosyasını buraya sürüklüyoruz.

    private bool gameOver;
    private bool restart;

    void Update()
    {
        if(restart==true)//eğer game over olursa restart ı true demiştik. ve true olursa eğer
        {
            if(Input.GetKeyDown(KeyCode.R))//R tuşuna basarsak eğer ki bu yazı görünecek sağ üst köşede
            {
                SceneManager.LoadScene(0);//bu kodu ezberliyoruz. ve 0 yazıyoruz. 0 sayısını built dersek eğer
                //built etmek istediğimiz dosyanın sağında int bir değer var onu içine yazıyoruz. 
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
    }
    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(startSpawn);//bu bekleme süresi.oyun başladığı zaman asteroidler aşağıya inerken
        //biraz bekleyecek. biz 0.5 saniye demiştik bekleme süresi için.
        while (true)//bu döngü içindeki kodları her zaman çalıştır.biz oyuna kadar.
        {

        
        for(int i=0;i<spawnCount;i++)//döngüyü oluşturuyoruz çünkü Gamecontroler kısmına ne kadar döngü istersek
            //yazar ve o kadar çok asteroid random bir şekilde aşağıya düşmesini istiyoruz. spawnCount a sayiyi biz giriyoruz
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
            //posizyon için xyz atıyoruz.y 0 olur. çünkü yukarı ve aşağı oynatmıyoruz.
            //z ise kamera dışından gelecek gibi ayarlıyoruz.
            //x ise sağ ve sol en son alabileceği değerleri bulacağız ama random olarak ayarlayacağız.-3 3 olarak uygun.
            //Random.Range(-3,3) bu kod çok kullanılıyormuş. bu değerler arasında x ekseninde en random değerler atıyor.
            Quaternion spawnRotation = Quaternion.identity;
            //bu sadece rotasyon ayarlarında kullanılır. daha önce tanımladığımız için new Quaternion(); i kullanmıyoruz
            //ve Quaternion.identity; kullanıyoruz. bu herhangi bir rotasyon verme demek.

            Instantiate(hazard, spawnPosition, spawnRotation);
            //1 hangi obje ise:hazard 2 hangi posizyon ise 3 hangi dönme hızı ise.
            //1 i hazarddan içine ne attıysak ve içine asteroid i attık.
            //2 posizyonunu vectör olarak xyz değerlerinden alıyoruz.
            //3 dönme hızını ise daha önce belirlediğimiz için değiştirme yapmıyoruz. 
            //olarak kullanmıyoruz.

            //Coroutine : kodları bekletme işlemi normalde programı çok yorar. bunu java da yapmak için tredler oluşturulur.
            //ama unitide bir yapı var buna coroutine denir.yani zamanı ayarlıyoruz.burada amaç bu aşağıdaki kodu yazmazsak
            //asteroidler random oluştuğu için çarpışabiliyor ve patlıyabiliyor. o yüzden zaman aralıkları içinde yapıyoruz

            yield return new WaitForSeconds(spawnWait);
            //biz buraya hangi sayıyı girersek o kadar bekletecek ve bu düzenden dolayı SpawnValues önündeki void i siliyoruz
            //yerine IEnumerator yazıyoruz.aynı zamanda start içine SpawnValues(); şeklinde değil
            //StartCorouteni(SpawnValues()); şeklinde yazıyoruz.
            //yukarıda yazdığımız kodların hepsine döngü dahil coroutine diyoruz.

            //couroutine ile void metodları arasındaki farklar
            //1 couroutine ler IEnumerator döndürmek zorundadır.
            //2 en az bir adet yield ifadesi bulunmalidir. 
            //3 StartCoroutine metodu ile çağrılmalıdır.
        }

            yield return new WaitForSeconds(waveWait);//döngüler arası bekleme süresini belirlemek için

            if (gameOver == true)//eğer oyun game over olursa aşağıdaki yazıyı yazdır.
            {
                restartText.text = "Press R for Restart";
                quitText.text = "Press Q for Quit";
                restart = true;//daha önce false diye tanımlamıştık şimdi true olsun diyoruz.
                break;//bu şartlar oluşursa while döngüsü içindeki true yi burada yok ediyoruz.
            }
        }
        
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;//bu void dosyasını her çağırdığımız da score ı 10 artır ve yaz.
        //bunu asteroid yok edildiği zaman çağırabilmemiz için Asteroid içindeki Desteroy by Contact scriptini açıyoruz.
    }

    public void GameOver()//Başlangıçta aşagıdaki fonksiyonları çağıracağız. eğer gemi patlarsa 
        //aşağıdaki fonksiyonu tanımlıyoruz. bu yazı çıkmadan önce bu fonksiyonu false olarak belirliyoruz.
        //geminin patlamasını bilebilmek ve bu aşağıdaki fonksiyonu çağırabilmek için DestroybyContact script i içine 
        //gidiyoruz. bu fonksiyonu orada çağırıyoruz. gameController.GameOver();
    {
        GameOverText.text = "Game Over";
        gameOver = true;
    }
    void Start()
    {

        GameOverText.text = "";
        restartText.text = "";
        quitText.text = "";
        gameOver = false;
        restart = false;
        StartCoroutine(SpawnValues());

    }

    
}
