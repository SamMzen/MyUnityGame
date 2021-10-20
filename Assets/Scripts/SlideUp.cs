using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideUp : MonoBehaviour
{
    public GameManagerE2 gameManagerE2;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerE2 = GameObject.FindGameObjectWithTag("GameManagerE2").GetComponent<GameManagerE2>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 2 * Time.deltaTime * gameManagerE2.bandSpeed, 0);
    }
}
