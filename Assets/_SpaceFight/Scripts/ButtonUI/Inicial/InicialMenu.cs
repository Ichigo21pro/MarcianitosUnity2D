using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class InicialMenu : MonoBehaviour
{
    ///////////////////////////////////////////////// VARIABLES ///////////////////////////////////////////////////
    
    [Header("Paneles")]
    public GameObject panelControles; // Panel donde están los controles
    public GameObject panelMenuPrincipal; // Panel principal del menú
    public GameObject panelOpciones; // Panel donde están las opciones

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////// START ////////////////////////////////////////////////////
    void Start()
    {
        if (panelControles != null)
        {
            panelControles.SetActive(false); // Ocultamos el panel de controles al inicio
        }
        if (panelMenuPrincipal != null)
        {
            panelMenuPrincipal.SetActive(true); // Mostramos el panel principal
        }
        if (panelOpciones != null)
        {
            panelOpciones.SetActive(false); // Ocultamos el panel de opciones al inicio
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////// F_PLAY /////////////////////////////////////////////////////
    public void Play()
    {
        SceneManager.LoadScene("SeleccionNave"); //abrimos la escena correspondiente
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////// F_SALIR //////////////////////////////////////////////////////

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        UnityEngine.Application.Quit(); // 👈 aquí aclaramos que es la de Unity
#endif
    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////// F_CONTROLES /////////////////////////////////////////////////////

    public void ShowControls()
    {
        if (panelMenuPrincipal != null) panelMenuPrincipal.SetActive(false);
        if (panelControles != null) panelControles.SetActive(true);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////F_OPCIONES//////////////////////////////////////////////////////

    public void ShowOpcions()
    {
        if (panelMenuPrincipal != null) panelMenuPrincipal.SetActive(false);
        if (panelOpciones != null) panelOpciones.SetActive(true);
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////// F_HIDDE PANELS AND GO MAIN MENU //////////////////////////////////////////////
    public void HiddePanels()
    {
        if (panelOpciones != null) panelOpciones.SetActive(false);
        if (panelControles != null) panelControles.SetActive(false);
        if (panelMenuPrincipal != null) panelMenuPrincipal.SetActive(true);
    }
}
