using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleculeQuanityAdapter : MonoBehaviour
{
    public RectTransform prefab;
    public RectTransform reagentes;
    public RectTransform produtos;
    private static Transform eventSystem;
    private List<GameObject> instancias = new List<GameObject>();
    
    private void Start()
    {
        iniciarQuantidadeMoleculas();
        eventSystem = GetComponent<Transform>();
    }

    private void iniciarQuantidadeMoleculas()
    {
        instanciarMoleculas(NucleoController.instance().currentEquation.quantidadeAtomosProduto(),produtos);
        instanciarMoleculas(NucleoController.instance().currentEquation.quantidadeAtomosReagente(),reagentes);
    }

    private void instanciarMoleculas(List< AtomoQuantificado> atomos, RectTransform list)
    {
        foreach (AtomoQuantificado atomo in atomos){
            GameObject instance = Instantiate(prefab.gameObject);
            instance.transform.SetParent(list.Find("ViewPort/Content"),false);
            instancias.Add(instance);
            initializeItemView(instance,atomo);
        }
    }

    public void atualizarQuantidadesMoleculas()
    {
        List<AtomoQuantificado> atomos =
            NucleoController.instance().currentEquation.quantidadeAtomosProduto();
        int i = 0;
        
        foreach (AtomoQuantificado produto in atomos)
        {
            initializeItemView(instancias[i],produto);
            i++;
        }
        
        atomos = NucleoController.instance().currentEquation.quantidadeAtomosReagente();
        foreach (AtomoQuantificado reagente in atomos)
        {
            initializeItemView(instancias[i],reagente);
            i++;
        }
    }

    private void initializeItemView(GameObject viewGameObject,  AtomoQuantificado molecula){
        viewGameObject.transform.GetComponent<Text>().text=$"{molecula.Atomo.Sigla} : {molecula.Quantidade}";
    }

    public static void atualizarBalanco(String formuleName, int tipo, int value)
    {
        List<MoleculaForma> moleculas;
        
        if(tipo == 0)
            moleculas = NucleoController.instance().currentEquation.Produto;
        else
            moleculas = NucleoController.instance().currentEquation.Reagente;

        foreach (var molecula in moleculas)
        {
            if (molecula.Molecula.ToString() == formuleName)
            {
                molecula.Balanco = value;
                break;
            }
        }
        eventSystem.GetComponent<MoleculeQuanityAdapter>().atualizarQuantidadesMoleculas();
    }
}
