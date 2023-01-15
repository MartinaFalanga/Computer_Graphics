using UnityEngine;

public class ElectricSwitch : MonoBehaviour, IInteractiveObject
{

    public GameObject[] lamps;

    public GameObject[] otherLightsToSwitchOn;

    public Material lampEmissionMaterial;

    
    public void ExecuteLogic() {
        SwitchOnLights(lamps);
    }

    // private methods

    private void SwitchOnLights(GameObject[] lamps) {
        foreach(GameObject lampGo in lamps) {
            foreach(Transform child in lampGo.transform) {
                child.gameObject.SetActive(true);
            }
        }

        lampEmissionMaterial.DisableKeyword("_EMISSION");
        lampEmissionMaterial.EnableKeyword("_EMISSION");
    }

    
}
