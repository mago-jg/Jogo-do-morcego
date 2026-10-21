using UnityEngine;
using UnityEngine.UIElements;

public class vermelho : MonoBehaviour
{


    [Header("Atributos(0 a 100)")]
    public float fome = 100f;
    public float felecidade = 100f;

    [Header("taxa de Redução")]
    public float fomeDEcreaseRate = 2f;
    public float felecidadeDecreseRate = 1.5f;

    [Header("Elemetos Ui")]
    public Slider fomeSlider;
    public Slider FelecidadeSlider;


    void Update()
    {
        // O time deltatime serve para detirma o tempo da fome tipo quando pasar 5 seg  ele 
        // para sentir fome 
        fome = fomeDEcreaseRate * Time.deltaTime;
        felecidade = felecidadeDecreseRate * Time.deltaTime;


        /// Agora determinar o tempo da fomer
        fome = Mathf.Clamp(fome, 0f, 100f);
        felecidade = Mathf.Clamp(felecidade, 0f, 100f);



        if (fomeSlider != null) fomeSlider.value = fome;
        if (FelecidadeSlider != null) FelecidadeSlider.value = felecidade;
    }

    public void Feed()
    {
        fome += 20f;
    }

    // Método para brincar com o pet
    public void Play()
    {
        felecidade += 25f;
    }
}



