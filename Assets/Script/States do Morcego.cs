using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI; // Usando a biblioteca padrão de UI do Unity

public class Statesdopolvo : MonoBehaviour
{
    private SpriteRenderer[] MorcegoTela; /// o que isso Sinfica o SpriteRendere onde controla cores do Objetos. 
    public float tempoSemMouse = 0f;
    public float tempoDoente = 0f;
    public float tempoContedortedio = 0f;
    public float tempoContedormorto = 0f;
    public float tempoContedorFeliz = 0f;
    public bool estaComFome = false;
    public bool estaDoente = false;
    public bool estaTedio = false;
    public bool estaMorto = false;
    public bool estaFeliz = false;
    public bool estaEnjoando = false;
    public bool cura = false;
    public float tempoEsperadoFome = 0f;
    public bool comida = false;

    // Variáveis do sistema de pontos e tempo de brincar
    public int pontosAtuais = 0;
    public float tempoBrincando = 0f;
    public bool jogandoMinigame = false;

    [Header("Arraste o seu Plcar de Pontos aqui!")]
    public Text textoPontos; // MUDADO DE VOLTA PARA TEXT LEGACY DO UNITY!

    private void Start()
    {
        // Essa variavel para busca tio lider dos circulo que chamando polvo 
        MorcegoTela = GetComponentsInChildren<SpriteRenderer>();
        estaTedio = true;
        estaComFome = false;
        estaFeliz = false;
        estaMorto = false;
        // O que Sinfica essa variavel em baixo quando jogo incair ele vai ficar com tédio 
        MudarCorDeTodos(Color.magenta);
        Debug.Log("quando jogo incia vai ficar com tédio");

        AtualizarTextoPontos();
    }

    // Essa função para todos circulos que eu coloquei ficar com mesma cor // para forma polvo 
    private void MudarCorDeTodos(Color novaCor)
    {
        if (MorcegoTela != null)
        {
            foreach (SpriteRenderer circulo in MorcegoTela)
            {
                if (circulo != null)
                {
                    circulo.color = novaCor;
                }
            }
        }
    }

    // botão Vermelho para pet ficar fome! 
    public void ApertaBotaoVermelho()
    {
        if (estaMorto == true) { return; }
        estaComFome = true;
        Debug.Log("O botao vermelho foi apertado ! pet esta com fome!");
        MudarCorDeTodos(Color.red);
    }

    public void Apertabotaocomida()
    {
        if (estaMorto == true) { return; }
        if (estaComFome == true)
        {
            estaComFome = false;
            MudarCorDeTodos(Color.pink);
            Debug.Log("Quanddo botao foi apertado pet vai comer");
        }
    }

    void Update()
    {
        if (estaMorto == true) { return; }

        // Lógica de brincar: se passar de 15 segundos e não fizer 20 pontos, o bicho morre
        if (jogandoMinigame == true)
        {
            tempoBrincando += Time.deltaTime;
            if (tempoBrincando >= 15f)
            {
                if (pontosAtuais < 20)
                {
                    jogandoMinigame = false;
                    estaMorto = true;
                    MudarCorDeTodos(Color.gray);
                    Debug.Log("O bicho nao fez 20 pontos em 15 segundos e morreu de tedio!");
                }
                else
                {
                    jogandoMinigame = false;
                    estaTedio = false;
                    MudarCorDeTodos(Color.blue);
                    Debug.Log("Parabens! Salvou o bicho do tedio!");
                }
            }
        }

        //// parte onde meu pet morreer 
        if (estaDoente == true)
        {
            tempoContedormorto += Time.deltaTime;
            if (tempoContedormorto >= 6f)
            {
                estaMorto = true;
                MudarCorDeTodos(Color.gray);
                Debug.Log("quando passar 6 ele vai ta morto");
            }
        }
    }

    // Botão de brincar e ganhar pontos ao mesmo tempo!
    public void ApertaBotãoRosabixovaiBrincar()
    {
        if (estaMorto == true) { return; }

        // Se NÃO estava jogando ainda, ativa o minigame e começa a contar
        if (jogandoMinigame == false && estaTedio == true)
        {
            jogandoMinigame = true;
            tempoBrincando = 0f;
            pontosAtuais = 0;
            MudarCorDeTodos(Color.cyan); // Muda para azul claro cor de brincar
            Debug.Log("Bicho comecou a brincar!");
        }

        // Se o minigame já começou, CADA CLIQUE NESSE MESMO BOTÃO dá 1 ponto!
        if (jogandoMinigame == true)
        {
            pontosAtuais++;
            AtualizarTextoPontos(); // Força o número a mudar na tela!

            // Se fizer os 20 pontos antes do tempo acabar, ganha o jogo!
            if (pontosAtuais >= 20)
            {
                jogandoMinigame = false;
                estaTedio = false;
                MudarCorDeTodos(Color.blue); // Fica azul normal de feliz
                Debug.Log("Voce conseguiu os 20 pontos a tempo!");
            }
        }
    }

    // botão verde 
    public void ApertaBotaoverde()
    {
        if (estaMorto == true) { return; }
        if (estaDoente == true) { return; }
        estaDoente = true;
        estaEnjoando = true;
        tempoContedormorto = 0f;
        MudarCorDeTodos(Color.green);
        Debug.Log("O botao verde foi apertado ! pet esta doente");
    }

    public void ApertaBotaocura()
    {
        if (estaMorto == true) { return; }
        if (estaDoente == false) { return; }
        estaDoente = false;
        estaEnjoando = false;
        tempoContedormorto = 0f;
        MudarCorDeTodos(Color.brown);
        Debug.Log("quando aperta botao marrom apertado para fica doente! ");
    }

    // Função que atualiza o texto na tela do jogo
    private void AtualizarTextoPontos()
    {
        if (textoPontos != null)
        {
            textoPontos.text = "Pontos: " + pontosAtuais;
        }
    }
}
