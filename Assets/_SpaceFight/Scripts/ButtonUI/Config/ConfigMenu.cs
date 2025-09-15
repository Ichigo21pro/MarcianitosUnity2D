using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigMenu : MonoBehaviour
{
    ///////////////////////////////////////////////// VARIABLES ///////////////////////////////////////////////////

    [Header("Slider")]
    public Slider sliderSound; // Slider donde configurar el volumen
    public float sliderValueSound; // Valor del Slider
    public Image imagenMute; // imagen en caso de estar sin sonido
    [Header("Brillo")]
    public Slider sliderBrightness; // Slider donde configurar el brillo
    public float sliderValueBrightness; // Valor del Slider
    public Image panelBrillo;
    [Header("Toggle Pantalla Completa")]
    public Toggle togglePC;


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////// START ////////////////////////////////////////////////////
    private void Start()
    {
        // === SONIDO ===
        if (sliderSound != null)
        {
            sliderSound.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
            sliderValueSound = sliderSound.value;
            AudioListener.volume = sliderValueSound;
            RevisarSiEstoyMute();
        }

        // === BRILLO ===
        if (sliderBrightness != null && panelBrillo != null)
        {
            sliderBrightness.value = PlayerPrefs.GetFloat("brillo", 0.5f);
            panelBrillo.color = new Color(
                panelBrillo.color.r,
                panelBrillo.color.g,
                panelBrillo.color.b,
                sliderBrightness.value
            );
        }
        // === BRILLO ===
        if (togglePC != null)
        {
            togglePC.isOn = Screen.fullScreen;
        }
    }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////// F_SliderSound /////////////////////////////////////////////////////

        public void ChangeSliderSound(float valor)
    {
        sliderValueSound = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValueSound);

        if (sliderSound != null)
        {
            AudioListener.volume = sliderSound.value;
        }

        RevisarSiEstoyMute();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////// F_SliderBrightness /////////////////////////////////////////////////

    public void ChangeSliderBrightness(float valor)
    {
        sliderValueBrightness = valor;
        PlayerPrefs.SetFloat("brillo", sliderValueBrightness);

        if (panelBrillo != null)
        {
            panelBrillo.color = new Color(
                panelBrillo.color.r,
                panelBrillo.color.g,
                panelBrillo.color.b,
                sliderBrightness.value
            );
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////// F_Muted /////////////////////////////////////////////////////

    public void RevisarSiEstoyMute()
    {
        if (imagenMute != null)
        {
            imagenMute.enabled = (sliderValueSound == 0);
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////// F_TogglePC ///////////////////////////////////////////////////
    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        if (togglePC != null)
        {
            Screen.fullScreen = pantallaCompleta;
        }
    }
}
