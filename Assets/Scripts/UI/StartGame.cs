﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void Jugador1(){

        SceneManager.LoadScene(1);
    }

    public void Jugador2(){

        SceneManager.LoadScene(2);
    }
}
