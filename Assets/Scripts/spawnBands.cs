using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBands : MonoBehaviour
{
    public GameManagerE2 gameManagerE2;

    public GameObject oneRow, finishRow;
    public GameObject parentGameObject;

    public int maxBandGap = 8;

    void Start()
    {
        gameManagerE2 = GameObject.FindGameObjectWithTag("GameManagerE2").GetComponent<GameManagerE2>();

        parentGameObject = this.gameObject;

        int numberOfSlide = 0;
        int slideWay = 1;

        for(int i = 0; i < gameManagerE2.numberOfRow; i++)
        {
            float randomValue = Random.value;



            if(numberOfSlide >= maxBandGap || numberOfSlide <= -maxBandGap)
            {
                slideWay *= -1;
            }

            else if (randomValue > 0.75)
            {
                slideWay *= -1;
            }

            numberOfSlide += 1 * slideWay;

            Instantiate(oneRow, parentGameObject.transform.position - new Vector3(-numberOfSlide, 5 + i, 0), Quaternion.identity, parentGameObject.transform);

            if(i == gameManagerE2.numberOfRow - 1)
            {
                Instantiate(finishRow, parentGameObject.transform.position - new Vector3(0, 10 + i, 0), Quaternion.identity, parentGameObject.transform);
            }
        }

    }
}
