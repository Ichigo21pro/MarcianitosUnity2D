using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [Header("Drop Calidad")]
    public TMP_Dropdown dropdownCalidad;
    public int calidad;
    [Header("Drop Resolucion")]
    public TMP_Dropdown dropdownResolucion;
    Resolution[] resoluciones;



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
        // === PANTALLA COMPLETA ===
        if (togglePC != null)
        {
            togglePC.isOn = Screen.fullScreen;
        }

        // === CALIDAD ===

        if (dropdownCalidad != null )
        {
            calidad = PlayerPrefs.GetInt("numeroDeCalidad", 3);
            dropdownCalidad.value = calidad;
            AjustarCalidad();
        }

        // === RESOLUCION ===

        if(dropdownResolucion != null)
        {
            resoluciones = Screen.resolutions;  // <-- inicializar aquí
            RevisarResolucion();
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

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////// F_Calidad ////////////////////////////////////////////////////

    public void AjustarCalidad() 
    {
        QualitySettings.SetQualityLevel(dropdownCalidad.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdownCalidad.value);
        calidad = dropdownCalidad.value;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////// F_Resolucion ////////////////////////////////////////////////////

    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;
        dropdownResolucion.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + "x" + resoluciones[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }

        dropdownResolucion.AddOptions(opciones);
        int resolucionGuardada = PlayerPrefs.GetInt("numeroResolucion", resolucionActual);
        dropdownResolucion.value = resolucionGuardada;
        dropdownResolucion.RefreshShownValue();

    }

    public void CambiarResolucion(int indiceResolucion)
    {
        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
        PlayerPrefs.SetInt("numeroResolucion", indiceResolucion);
    }
}
