using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    public GameObject Vehicle;
    public GameObject Player;
    public double Distance;

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(Vehicle.transform.position, Player.transform.position);
        Distance = distance;
        if (distance < 5)
        {
            SceneManager.LoadScene(2);
        }
    }
}
