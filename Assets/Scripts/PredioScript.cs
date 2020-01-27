using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredioScript : MonoBehaviour
{

    public Animator animationPredio1, animationPredio2, animationPredio3,animationPredio4,animationPredio5,animationPredio6;
    int ValorRandom,ValorRandom2,ValorRandom3,ValorRandom4,ValorRandom5,ValorRandom6;

    // Start is called before the first frame update
    void Start()
    {
        animacaoPredio01();
        animacaoPredio02();
        animacaoPredio03();
        animacaoPredio04();
        animacaoPredio05();
        animacaoPredio06();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void animacaoPredio01()
    {
        ValorRandom = Random.Range(1, 10);
        switch (ValorRandom)
        {
            case 1:
                animationPredio1.SetBool("anima01", true);
                animationPredio1.SetBool("anima02", false);
                animationPredio1.SetBool("anima03", false);
                animationPredio1.SetBool("anima04", false);
                animationPredio1.SetBool("anima05", false);
                animationPredio1.SetBool("anima06", false);
                animationPredio1.SetBool("anima07", false);
                animationPredio1.SetBool("anima08", false);
                animationPredio1.SetBool("anima09", false);
                break;
            case 2:
                animationPredio1.SetBool("anima01", false);
                animationPredio1.SetBool("anima02", true);
                animationPredio1.SetBool("anima03", false);
                animationPredio1.SetBool("anima04", false);
                animationPredio1.SetBool("anima05", false);
                animationPredio1.SetBool("anima06", false);
                animationPredio1.SetBool("anima07", false);
                animationPredio1.SetBool("anima08", false);
                animationPredio1.SetBool("anima09", false);
                break;
            case 3:
                animationPredio1.SetBool("anima01", false);
                animationPredio1.SetBool("anima02", false);
                animationPredio1.SetBool("anima03", true);
                animationPredio1.SetBool("anima04", false);
                animationPredio1.SetBool("anima05", false);
                animationPredio1.SetBool("anima06", false);
                animationPredio1.SetBool("anima07", false);
                animationPredio1.SetBool("anima08", false);
                animationPredio1.SetBool("anima09", false);
                break;
            case 4:
                animationPredio1.SetBool("anima01", false);
                animationPredio1.SetBool("anima02", false);
                animationPredio1.SetBool("anima03", false);
                animationPredio1.SetBool("anima04", true);
                animationPredio1.SetBool("anima05", false);
                animationPredio1.SetBool("anima06", false);
                animationPredio1.SetBool("anima07", false);
                animationPredio1.SetBool("anima08", false);
                animationPredio1.SetBool("anima09", false);
                break;
            case 5:
                animationPredio1.SetBool("anima01", false);
                animationPredio1.SetBool("anima02", false);
                animationPredio1.SetBool("anima03", false);
                animationPredio1.SetBool("anima04", false);
                animationPredio1.SetBool("anima05", true);
                animationPredio1.SetBool("anima06", false);
                animationPredio1.SetBool("anima07", false);
                animationPredio1.SetBool("anima08", false);
                animationPredio1.SetBool("anima09", false);
                break;
            case 6:
                animationPredio1.SetBool("anima01", false);
                animationPredio1.SetBool("anima02", false);
                animationPredio1.SetBool("anima03", false);
                animationPredio1.SetBool("anima04", false);
                animationPredio1.SetBool("anima05", false);
                animationPredio1.SetBool("anima06", true);
                animationPredio1.SetBool("anima07", false);
                animationPredio1.SetBool("anima08", false);
                animationPredio1.SetBool("anima09", false);
                break;
            case 7:
                animationPredio1.SetBool("anima01", false);
                animationPredio1.SetBool("anima02", false);
                animationPredio1.SetBool("anima03", false);
                animationPredio1.SetBool("anima04", false);
                animationPredio1.SetBool("anima05", false);
                animationPredio1.SetBool("anima06", false);
                animationPredio1.SetBool("anima07", true);
                animationPredio1.SetBool("anima08", false);
                animationPredio1.SetBool("anima09", false);
                break;
            case 8:
                animationPredio1.SetBool("anima01", false);
                animationPredio1.SetBool("anima02", false);
                animationPredio1.SetBool("anima03", false);
                animationPredio1.SetBool("anima04", false);
                animationPredio1.SetBool("anima05", false);
                animationPredio1.SetBool("anima06", false);
                animationPredio1.SetBool("anima07", false);
                animationPredio1.SetBool("anima08", true);
                animationPredio1.SetBool("anima09", false);
                break;
            case 9:
                animationPredio1.SetBool("anima01", false);
                animationPredio1.SetBool("anima02", false);
                animationPredio1.SetBool("anima03", false);
                animationPredio1.SetBool("anima04", false);
                animationPredio1.SetBool("anima05", false);
                animationPredio1.SetBool("anima06", false);
                animationPredio1.SetBool("anima07", false);
                animationPredio1.SetBool("anima08", false);
                animationPredio1.SetBool("anima09", true);
                break;
            default:
                break;
        }

    }

    void animacaoPredio02()
    {
        ValorRandom2 = Random.Range(1, 4);
        switch (ValorRandom2)
        {
            case 1:
                animationPredio2.SetBool("anima01", true);
                animationPredio2.SetBool("anima02", false);
                animationPredio2.SetBool("anima03", false);
                break;
            case 2:
                animationPredio2.SetBool("anima01", false);
                animationPredio2.SetBool("anima02", true);
                animationPredio2.SetBool("anima03", false);
                break;
            case 3:
                animationPredio2.SetBool("anima01", false);
                animationPredio2.SetBool("anima02", false);
                animationPredio2.SetBool("anima03", true);
                break;
            default:
                break;
        }
    }
    void animacaoPredio03()
    {
        ValorRandom3 = Random.Range(1, 3);
        switch (ValorRandom3)
        {
            case 1:
                animationPredio3.SetBool("anima01", true);
                animationPredio3.SetBool("anima02", false);
                break;
            case 2:
                animationPredio3.SetBool("anima01", false);
                animationPredio3.SetBool("anima02", true);
                break;
            default:
                break;
        }
    }

    void animacaoPredio04()
    {
        ValorRandom4 = Random.Range(1, 6);
        switch (ValorRandom4)
        {
            case 1:
                animationPredio4.SetBool("anima01", true);
                animationPredio4.SetBool("anima02", false);
                animationPredio4.SetBool("anima03", false);
                animationPredio4.SetBool("anima04", false);
                animationPredio4.SetBool("anima05", false);
                break;
            case 2:
                animationPredio4.SetBool("anima01", false);
                animationPredio4.SetBool("anima02", true);
                animationPredio4.SetBool("anima03", false);
                animationPredio4.SetBool("anima04", false);
                animationPredio4.SetBool("anima05", false);
                break;
            case 3:
                animationPredio4.SetBool("anima01", false);
                animationPredio4.SetBool("anima02", false);
                animationPredio4.SetBool("anima03", true);
                animationPredio4.SetBool("anima04", false);
                animationPredio4.SetBool("anima05", false);
                break;
            case 4:
                animationPredio4.SetBool("anima01", false);
                animationPredio4.SetBool("anima02", false);
                animationPredio4.SetBool("anima03", false);
                animationPredio4.SetBool("anima04", true);
                animationPredio4.SetBool("anima05", false);
                break;
            case 5:
                animationPredio4.SetBool("anima01", false);
                animationPredio4.SetBool("anima02", false);
                animationPredio4.SetBool("anima03", false);
                animationPredio4.SetBool("anima04", false);
                animationPredio4.SetBool("anima05", true);
                break;
            default:
                break;
        }
    }
    void animacaoPredio05()
    {
        ValorRandom5 = Random.Range(1, 4);
        switch (ValorRandom5)
        {
            case 1:
                animationPredio5.SetBool("anima01", true);
                animationPredio5.SetBool("anima02", false);
                animationPredio5.SetBool("anima03", false);
                break;
            case 2:
                animationPredio5.SetBool("anima01", false);
                animationPredio5.SetBool("anima02", true);
                animationPredio5.SetBool("anima03", false);
                break;
            case 3:
                animationPredio5.SetBool("anima01", false);
                animationPredio5.SetBool("anima02", false);
                animationPredio5.SetBool("anima03", true);
                break;
            default:
                break;
        }
    }
    void animacaoPredio06()
    {
        ValorRandom6 = Random.Range(1, 7);
        switch (ValorRandom6)
        {
            case 1:
                animationPredio6.SetBool("anima01", true);
                animationPredio6.SetBool("anima02", false);
                animationPredio6.SetBool("anima03", false);
                animationPredio6.SetBool("anima04", false);
                animationPredio6.SetBool("anima05", false);
                animationPredio6.SetBool("anima06", false);
                break;
            case 2:
                animationPredio6.SetBool("anima01", false);
                animationPredio6.SetBool("anima02", true);
                animationPredio6.SetBool("anima03", false);
                animationPredio6.SetBool("anima04", false);
                animationPredio6.SetBool("anima05", false);
                animationPredio6.SetBool("anima06", false);
                break;
            case 3:
                animationPredio6.SetBool("anima01", false);
                animationPredio6.SetBool("anima02", false);
                animationPredio6.SetBool("anima03", true);
                animationPredio6.SetBool("anima04", false);
                animationPredio6.SetBool("anima05", false);
                animationPredio6.SetBool("anima06", false);
                break;
            case 4:
                animationPredio6.SetBool("anima01", false);
                animationPredio6.SetBool("anima02", false);
                animationPredio6.SetBool("anima03", false);
                animationPredio6.SetBool("anima04", true);
                animationPredio6.SetBool("anima05", false);
                animationPredio6.SetBool("anima06", false);
                break;
            case 5:
                animationPredio6.SetBool("anima01", false);
                animationPredio6.SetBool("anima02", false);
                animationPredio6.SetBool("anima03", false);
                animationPredio6.SetBool("anima04", false);
                animationPredio6.SetBool("anima05", true);
                animationPredio6.SetBool("anima06", false);
                break;
            case 6:
                animationPredio6.SetBool("anima01", false);
                animationPredio6.SetBool("anima02", false);
                animationPredio6.SetBool("anima03", false);
                animationPredio6.SetBool("anima04", false);
                animationPredio6.SetBool("anima05", false);
                animationPredio6.SetBool("anima06", true);
                break;
            default:
                break;
        }
    }
}
