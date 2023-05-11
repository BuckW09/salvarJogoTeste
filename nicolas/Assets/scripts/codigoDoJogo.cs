using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codigoDoJogo : MonoBehaviour
{
    public int velocidade; //define a velocidade de movimentação 
    private Rigidbody2D AHHH; //criar variavel para receber os componentes de fisica
    public float forcaPulo;  // define a forca do pulo
    public bool sensor;   // posição onde o sensor sera posicionado 
    public Transform posicaoSensor;  //posição onde o sensor sera´posicionadoo
    public LayerMask layerChao; //Camada de interação
    // Start is called before the first frame update
    void Start()
    {
        AHHH = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimentoX = Input.GetAxisRaw("Horizontal");

        AHHH.velocity = new Vector2(movimentoX * velocidade, AHHH.velocity.y);

        if(Input.GetButtonDown("Jump") && sensor == true)
        {
            AHHH.AddForce(new Vector2(0, forcaPulo));
        }
    }
    private void FixedUpdate()  //comando para ver se ta em contato com  ochao
    {
        //cria um sensor em posição definida com raio e layer tambem definidas
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f ,layerChao);
    }
}
