using System;
using System.Collections;
using System.Collections.Generic;
using controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Roulette : MonoBehaviour
{
    public GameObject roulette; 
    public GameObject spinner;
    private bool spinnerDirection;
    public static bool isRotate;
    private int speed;
    private int trueSpeed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        trueSpeed = speed;
        isRotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRotate)
            Rotate();
    }

    public void sortRoulette()
    {
        if(!isRotate)
        {
            isRotate = true;
            speed = 11 * generateRandom(10, 40);
        }
    }

    private void Rotate()
    {
        roulette.GetComponent<Transform>().Rotate(0,0,trueSpeed*Time.deltaTime);
        if(speed>0){
            if(speed<34)
                moveSpinner(1);
            else if(speed<110)
                moveSpinner(2);
            else
                moveSpinner(3);
            
            if (speed % 11 == 0)
            {
                trueSpeed = speed;
            }
        }
        else if(verifyStop())
        {
            moveSpinner(0);
            isRotate = false;
            trueSpeed = 0;
            verifyResult();
            return;
        }
        else
        {
            speed = 11;
        }

        speed --;
    }

    private int generateRandom(int min, int max)
    {
        Random random = new Random();

        return random.Next(min, max);
    }
    /*
     * Verifica os pontos criticos em que a roleta nao pode parar
     */
    private bool verifyStop()
    {
        float angle = roulette.GetComponent<Transform>().localEulerAngles.z;
        
        if (angle >= 355 || angle <= 5)
            return false;
        if (angle <= 50 && angle >= 40)
            return false;
        if (angle <= 95 && angle >= 85)
            return false;
        if (angle <= 140 && angle >= 130)
            return false;
        if (angle <= 185 && angle >= 175)
            return false;
        if (angle <= 230 && angle >= 220)
            return false;
        if (angle <= 275 && angle >= 265)
            return false;
        if (angle <= 320 && angle >= 310)
            return false;

        return true;
    }

    private void verifyResult()
    {
        float angle = roulette.GetComponent<Transform>().localEulerAngles.z;

        if (angle <= 45)//vermelho de baixo
        {
            PrincipalController.idCor = 1;
            SceneManager.LoadScene(0);
            return;
        }
        if (angle <= 90)//amarelo de baixo
        {
            PrincipalController.idCor = 2;
            SceneManager.LoadScene(0);
            return;
        }
        if (angle<=135)//azul de cima
        {
            PrincipalController.idCor = 3;
            SceneManager.LoadScene(0);
            return;
        }
        if (angle<=180)//verde de cima
        {
            PrincipalController.idCor = 4;
            SceneManager.LoadScene(0);
            return;
        }
        if (angle<=225)//vermelho de cima
        {
            PrincipalController.idCor = 5;
            SceneManager.LoadScene(0);
            return;
        }
        if (angle<=270)//amarelo de cima
        {
            PrincipalController.idCor = 6;
            SceneManager.LoadScene(0);
            return;
        }
        if (angle<=315)//azul de baixo
        {
            PrincipalController.idCor = 7;
            SceneManager.LoadScene(0);
            return;
        }
        
        //verde de baixo
        PrincipalController.idCor = 8;
        SceneManager.LoadScene(0);
    }

    private void moveSpinner(int velocity)
    {
        Transform spinner = this.spinner.gameObject.GetComponent<Transform>();
        switch (velocity)
        {
            case 0:
                spinner.Rotate(0,0,0);
                break;
            case 1:
                if (speed % 11 == 0)
                {
                    if(spinnerDirection)
                    {
                        spinner.Rotate(0, 0, -5.0f);
                        spinnerDirection = false;
                    }
                    else
                    {
                        spinner.Rotate(0, 0, 5.0f);
                        spinnerDirection = true;
                    }
                }
                break;
            case 2:
                if (speed % 7 == 0)
                {
                    if(spinnerDirection)
                    {
                        spinner.Rotate(0, 0, -5.0f);
                        spinnerDirection = false;
                    }
                    else
                    {
                        spinner.Rotate(0, 0, 5.0f);
                        spinnerDirection = true;
                    }
                }
                break;
            case 3:
                if (speed % 3 == 0)
                {
                    if(spinnerDirection)
                    {
                        spinner.Rotate(0, 0, -5.0f);
                        spinnerDirection = false;
                    }
                    else
                    {
                        spinner.Rotate(0, 0, 5.0f);
                        spinnerDirection = true;
                    }
                }
                break;
        }
    }
}
