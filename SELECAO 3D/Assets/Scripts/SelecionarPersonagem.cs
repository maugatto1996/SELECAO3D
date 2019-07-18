using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionarPersonagem : MonoBehaviour
{

    public Transform esquerdaFora;
    public Transform esquerda;
    public Transform centro;
    public Transform direita;
    public Transform direitaFora;
    public Transform[] listaPersonagens;
    private GameObject[] personagens;
    private int personagemAtual = 0;





    void Start()
    {
        personagens = new GameObject[listaPersonagens.Length];
        int indice = 0;
        foreach(Transform t in listaPersonagens)
        {
            personagens[indice++] = GameObject.Instantiate(t.gameObject, direitaFora.position, Quaternion.identity) as GameObject;
        }
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(10,(Screen.height - 50)/2 , 100 , 50 ), "Anterior"))
        {
            personagemAtual--;
            if(personagemAtual < 0)
            {
                personagemAtual = 0;
            }

        }

        if (GUI.Button(new Rect(Screen.width - 100 - 10,(Screen.height -50)/2, 100, 50), "Proximo"))
        {
            personagemAtual++;
            if (personagemAtual >= personagens.Length)
            {
                personagemAtual = personagens.Length - 1;
            }

        }

        GameObject personagemSelecionado = personagens[personagemAtual];
        string nomePersonagem = personagemSelecionado.name;

        GUI.Label(new Rect((Screen.width-100)/2 , 20, 200, 50), nomePersonagem);

        int indicePersonagemMeio = personagemAtual;
        int indicePersonagemEsquerda = personagemAtual - 1;
        int indicePersonagemDireita = personagemAtual + 1;

        for(int indice = 0; indice < personagens.Length; indice++)
        {
            Transform transf = personagens[indice].transform;
            if(indice < indicePersonagemEsquerda)
            {
                transf.position = Vector3.Lerp(transf.position, esquerdaFora.position, Time.deltaTime);

            }else if(indice > indicePersonagemDireita)
            {
                transf.position = Vector3.Lerp(transf.position, direitaFora.position, Time.deltaTime);
            }else if( indice == indicePersonagemEsquerda)
            {
                transf.position = Vector3.Lerp(transf.position, esquerda.position, Time.deltaTime);
            }
            else if (indice == indicePersonagemDireita)
            {
                transf.position = Vector3.Lerp(transf.position, direita.position, Time.deltaTime);
            }
            else if (indice == indicePersonagemMeio)
            {
                transf.position = Vector3.Lerp(transf.position, centro.position, Time.deltaTime);
            }
        }


    }

}
