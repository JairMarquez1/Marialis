using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class FuelMeterView : MonoBehaviour
{
    public Image baseView; 
    public Image iconView;
    public Image fuelView; 
    public Movement player;

    // Update is called once per frame
    void FixedUpdate()
    {
        float fuel = player.fuelJetpack;
        bool hasJetPack = player.hasJetPack;


        /*Muestra el medidor de combustible si el jugador tiene (o no) el JetPack*/
        if (hasJetPack)
        {
            fuel = Mathf.Clamp(fuel, 0, 100);
            fuelView.transform.localScale = new Vector2(1, fuel / 100); //Barra de combustible. (Escala de 0 a 1)
            baseView.enabled = true;
            fuelView.enabled = true;
            iconView.enabled = true;
        }
        else
        {
            baseView.enabled = false;
            fuelView.enabled = false;
            iconView.enabled = false;
        }                    
    }
}
