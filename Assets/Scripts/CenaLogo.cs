using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CenaLogo : MonoBehaviour
{
    public Animator animacao;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("IniciarTela");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IniciarTela()
    {
        
        yield return new WaitForSeconds(2.24f);        
        SceneManager.LoadScene("0");
    }
}
