using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform positionPlayer;


    void Update()
    {
        transform.position = new Vector3(positionPlayer.position.x, positionPlayer.position.y, 0);
        LimitandoTela();
    }

    void LimitandoTela()
    {
        if (transform.position.y <= 15f || transform.position.y >= 2.4f)
        {      
            float YPos = Mathf.Clamp(transform.position.y, 2.4f, 15f);            
            transform.position = new Vector3(transform.position.x, YPos, transform.position.z);
        }
    }
}
