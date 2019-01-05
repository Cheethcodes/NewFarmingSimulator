using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plantInfo : MonoBehaviour {

    // Health bar and water bar
    public Slider healthbar, waterbar;
    public static float healthbarValue, waterbarValue;
    public Text healthbarPercentage, waterbarPercentage;
    public static float healthbarPercentageTXT, waterbarPercentageTXT;

    // Amount of fertilizer left
    public Text amtNitrogen, amtPhosphorus, amtPotassium;
    public static float fNitrogen, fPhosphorus, fPotassium;

    // Estimated elapsed time before harvest
    public Text harvestETA;
    public static float harvestTimeLeft;

	void Update ()
    {
        // Update time left until harvest
        harvestETA.text = harvestTimeLeft.ToString() + " days";

        // Update read values for water
        waterbarValue = Mathf.Clamp(waterbarValue, 0, 100);
        waterbar.value = waterbarValue / 100;
        waterbarPercentage.text = waterbarValue.ToString("n2") + " %";

        healthbarValue = Mathf.Clamp(healthbarValue, 0, 100);
        healthbar.value = healthbarValue / 100;
        healthbarPercentage.text = healthbarValue.ToString("n2") + " %";

        // Update read values for fertilizer
        amtNitrogen.text = fNitrogen.ToString("n2");
        amtPhosphorus.text = fPhosphorus.ToString("n2");
        amtPotassium.text = fPotassium.ToString("n2");
	}

    public void closePlantInfoPanel()
    {
        this.gameObject.SetActive(false);

        // Reset all values so that the characteristic of the game object read before will not overwrite the properties to be read in the next object
        waterbarValue = 0;
        healthbarValue = 0;
        fNitrogen = 0;
        fPhosphorus = 0;
        fPotassium = 0;
        harvestTimeLeft = 0;
    }
}
