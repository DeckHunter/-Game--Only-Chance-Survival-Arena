using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun_2 : MonoBehaviour
{

    [Header("Gun Configuration 1")]
    public float damage;
    public float range;
    public float firerate;
    public float waitToFireRate;
    public Camera cam;
    //public ParticleSystem ammoParticle;
    //public ParticleSystem impact;
    public bool hold = false;
    // Start is called before the first frame update
    [Space]
    [Header("Ammo")]
    public int maxAmmonInPaint;
    public int Ammo;
    public int AmmoInPaint;
    public int TimeReload;
    private bool isReload = false;
    private int TimeTr;

    [Space]
    [Header("HUD")]
    public Text ammo_Gun_2;
    public Slider reloadTime;
    public GameObject reloadGO;

    [Space]
    [Header("Player")]
    public Player player;
    private AudioSource audio;

    [Space]
    [Header("Inimigo")]
    public LayerMask Layer_inimigo;
    private void Start()
    {
        reloadTime.maxValue = TimeReload;
        audio = GetComponent<AudioSource>();
    }
    public void AddMunicao(int municao)
    {
        Ammo += municao;
    }
    void Update()
    {
        reloadTime.value = TimeTr;
        ammo_Gun_2.text = AmmoInPaint + "/" + Ammo;

        if (Input.GetButtonDown("Fire1") && player.getLifeAtual() > 0 && player.GetplayerInShop() == false)
        {
            Debug.Log("Fire 1 Precionado");
            hold = true;
        }
        if (Input.GetButtonUp("Fire1") && player.getLifeAtual() > 0 && player.GetplayerInShop() == false)
        {
            Debug.Log("Fire 1 Apertado");
            hold = false;
        }
        if (hold == true)
        {
            waitToFireRate += 1;
        }
        if (waitToFireRate > firerate && player.getLifeAtual() > 0 && player.GetplayerInShop() == false)
        {
            Shoot();
        }
        if (Input.GetButtonDown("Recarga") && AmmoInPaint != maxAmmonInPaint && Ammo != 0 && isReload == false && player.getLifeAtual() > 0 && player.GetplayerInShop() == false)
        {
          
            reloadGO.SetActive(true);
            isReload = true;
            Debug.Log("R precionado");
        }
        if (isReload == true && player.getLifeAtual() > 0 && player.GetplayerInShop() == false)
        {
            if (TimeTr > TimeReload)
            {
                for (int i = 0; i < maxAmmonInPaint; i++)
                {
                    if (AmmoInPaint < maxAmmonInPaint && Ammo > 0)
                    {
                        Ammo -= 1;
                        AmmoInPaint += 1;
                    }
                    else
                    {
                        break;
                    }
                }
                reloadGO.SetActive(false);
                isReload = false;
                TimeTr = 0;
            }
            else
            {
                TimeTr += 1;
            }
        }
    }
    void Shoot()
    {
        waitToFireRate = 0;
        if (AmmoInPaint > 0 && isReload == false)
        {
            AmmoInPaint -= 1;
            audio.Play();

            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, Layer_inimigo))
            {
                {
                    Debug.Log("Mirando Em : " + hit.transform.name);

                    if (hit.collider != null)
                    {
                        if (hit.collider.CompareTag("Inimigo"))
                        {

                            if (hit.collider.GetComponent<Inimigo>().GetLife() > 0)
                            {
                                hit.collider.GetComponent<Inimigo>().LevarDano(3f + player.GetDanoBase());
                            }

                            if (player.getFury() < 100)
                            {
                                player.setFury(2f);
                            }
                        }
                        if (hit.collider.CompareTag("Boss"))
                        {

                            if (hit.collider.GetComponent<Boss>().GetLife() > 0)
                            {
                                hit.collider.GetComponent<Boss>().LevarDano(3 + player.GetDanoBase());
                            }

                            if (player.getFury() < 100)
                            {
                                player.setFury(2f);
                            }
                        }
                    }
                }
            }
        }
    }
}

