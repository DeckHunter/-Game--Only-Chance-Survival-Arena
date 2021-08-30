using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {


    CharacterController controller;

    Vector3 forward;
    Vector3 strafe;
    Vector3 verticalVelocity;

    Vector3 direction;
    Vector3 velocity;

    Vector3 currentVelocity;

    float acceleration = 50f;
    float maxSpeed = 10f;

    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 2f;
    float timeToMaxHeight = 0.5f;

    public Animator anim;

    [Space]
    [Header("Chaves")]
    public bool Chave_1 = false;
    public bool Chave_2 = false;
    public bool Chave_3 = false;

    [Space]
    [Header("Particulas")]
    public GameObject isHealing;
    public GameObject isFurious;
    float tempo = 100f;

    [Space]
    [Header("Atributos Do Player")]

    private int life = 100;
    private float fury = 0f;
    private int armor = 0;

    private int danoBase = 0;

    private int moedas;
    public Text Qtd_Moedas;

    private int kitMedico;
    public Text Qtd_Kits;

    public Slider lifeBar;
    public Slider furyBar;
    public Slider armorBar;
    public bool inFury = false;

    public bool playerInShop = false;

    public void PegarChave_1(){
        Chave_1 = true;
    }
    public void PegarChave_2()
    {
        Chave_2 = true;
    }
    public void PegarChave_3()
    {
        Chave_3 = true;
    }

    public bool GetChave_1() {
    
       return Chave_1;
    }
    public bool GetChave_2() { 
    
        return Chave_2;
    }
    public bool GetChave_3() { 
    
        return Chave_3;
    }

    public bool GetplayerInShop(){
        return playerInShop;
    }
    public void SetplayerInShop(bool b) {
        playerInShop = b;
    }
    public void StopPlayer(){
        acceleration = 0f;
    }
    public void StartPlayer()
    {
        acceleration = 50f;
    }
    public void setArmor(){
        armor = 100;
    }
    public int GetArmor() {
        return armor;
    }
    public int GetDanoBase() {
        return danoBase;
    }
    public void SetQtdKits(){
        kitMedico += 1;
    }
    public float getFury(){
        return fury;
    }
    public void AddKitMedico(){
        kitMedico += 1;
    }

    public void setFury(float valor){
        fury += valor;
    }

    public int getLifeAtual(){
        return life;
    }

    public void tomarDano(int dano){
        life -= dano;
    }
    public void tomarDanoArmadura(int dano)
    {
        armor -= dano;
    }
    public void curar(int curar){
        life += curar;
    }
    
    void Start() {

        controller = GetComponent<CharacterController>();
        gravity    = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed  = (2 * maxJumpHeight) / timeToMaxHeight;

    }
    void Update() {

        lifeBar.value = life;
        furyBar.value = fury;
        armorBar.value = armor;
        Qtd_Moedas.text ="X"+ moedas.ToString();
        Qtd_Kits.text = "X" + kitMedico.ToString();

        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");
    
        forward = forwardInput * transform.forward;
        strafe  = strafeInput * transform.right;

        direction = (forward + strafe).normalized;

        verticalVelocity += gravity * Time.deltaTime * Vector3.up;

        if (life <= 0){
            Morrer();
        }

        if (forwardInput != 0f || strafeInput != 0f)
        {
            anim.SetInteger("Transition", 1);
        }
        else{
            anim.SetInteger("Transition", 0);
        }

        if (controller.isGrounded) {
            verticalVelocity = Vector3.down;
            anim.SetBool("IsJump", false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded && playerInShop == false) {
            verticalVelocity = jumpSpeed * Vector3.up;
            anim.SetBool("IsJump", true);
        }

        if (verticalVelocity.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0) {
            verticalVelocity = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && life > 0 && life < 100 && kitMedico > 0 && playerInShop == false)
        {
            curar(30);
            kitMedico -= 1;
            isHealing.SetActive(true);
            Debug.Log("Player Curaddo Em 30");
        }

        if (isHealing.activeSelf && tempo > 0f)
        {
            tempo -= (Time.deltaTime * 15);
            Debug.Log("Tempo : " + tempo);
        }
        else { 
            isHealing.SetActive(false);
            tempo = 100;
        }
        if (Input.GetKeyDown(KeyCode.Q) && life > 0 && playerInShop == false)
        {
            inFury = true;
            isFurious.SetActive(true);
            Debug.Log("Furia Ativada");
        }
        if (inFury == true && fury >= 0.0f && life > 0)
        {
            danoBase = 3;
            maxSpeed = 20;
            maxJumpHeight = 4f;
            fury -= ( Time.deltaTime * 10 );
            Debug.Log("Tempo De Furia : " + fury);
        }
        else{
            Debug.Log("Furia Desativada");
            danoBase = 0;
            maxSpeed = 10;
            maxJumpHeight = 2f;
            inFury = false;
            isFurious.SetActive(false);
        }
        velocity = Vector3.SmoothDamp(velocity, direction * maxSpeed, ref currentVelocity, maxSpeed / acceleration);
        
        controller.Move((velocity + verticalVelocity) * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Coin"))
        {
            other.GetComponent<Coin>().Coletar();
            moedas += 1;
        }
    }
    public void Morrer(){
        //Destroy(gameObject);
        Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayerMorte");

    }

    public void VencerOJogo() {
        Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Player Vitoria");
    }

    public void RemoveMoedas(int i){
        moedas -= i;
    }
    public int GetMoedas()
    {
        return moedas;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Chave_City") {
            PegarChave_1();
            Destroy(other);
        }
        if (other.tag == "Chave_Fab")
        {
            PegarChave_2();
            Destroy(other);
        }
        if (other.tag == "Chave_Lab")
        {
            PegarChave_3();
            Destroy(other);
        }
    }
}


