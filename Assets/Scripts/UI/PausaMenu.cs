using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenu : MonoBehaviour
{
    [SerializeField] private GameObject PausaMenuUI;
    [SerializeField] private bool Pausado;

    private void Update() {

        //bool userAction = 

        if (Input.GetKeyDown(KeyCode.Escape)) {

            Pausado = !Pausado;
        }

        /*if (Input.GetMouseButtonDown(0))
        {
            EmpezarDeNuevo();
        }*/


        if (Pausado){
            ActivarMenu();
        }
        else {
            DesactivarMenu();
        }

        
    }

    public void ActivarMenu()
    {
        Time.timeScale = 0;
        PausaMenuUI.SetActive(true);
    }

    public void DesactivarMenu()
    {
        Time.timeScale = 1;
        PausaMenuUI.SetActive(false);
        Pausado = false;
    }

    public void EmpezarDeNuevo() {
        SceneManager.LoadScene(1);
    }
}
