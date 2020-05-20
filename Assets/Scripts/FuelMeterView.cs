using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class FuelMeterView : MonoBehaviour
{
    public Image fuelView;
    public Movement player;
    private float maxFuel = 100f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float fuel = player.fuelJetpack;
        fuel = Mathf.Clamp(fuel, 0, 100);
        fuelView.transform.localScale = new Vector2(1, fuel/maxFuel);
    }
}
