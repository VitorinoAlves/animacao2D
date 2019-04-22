using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serra_rotacao : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tr;
    public float velocidadeRotacao=150f;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RodasSerra();
    }

    private void RodasSerra()
    {
        z += Time.deltaTime * velocidadeRotacao;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
