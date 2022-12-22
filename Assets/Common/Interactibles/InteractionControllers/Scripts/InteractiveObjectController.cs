using TMPro;
using UnityEngine;

public class InteractiveObjectController : MonoBehaviour
{
    public GameObject interactionMenuPanel;

    public GameObject interactionMenuTextmesh;

    public string interactionMenuText;

    public Color interactionEmissionColor;

    public Material emissionMaterial;

    public bool interactionOnce;

    public bool isPlayerInInteractionCollider;

    private bool isPlayerPointingWithMouse;

    public GameObject interactionCollider;

    private Color originalEmissionColor;

    private GameObject mainCamera;


    void Start() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        interactionCollider.GetComponent<InteractionColliderController>().SetInteractiveObjectController(this);
        
        if(emissionMaterial != null)
            originalEmissionColor = emissionMaterial.GetColor("_EmissionColor");
    }

    void Update() {
        if(isPlayerInInteractionCollider && isPlayerPointingWithMouse) {
            if(Input.GetKeyDown(KeyCode.F)) {

                if(gameObject.GetComponent<ZoomableObjectController>() != null) {
                    gameObject.GetComponent<ZoomableObjectController>().ExecuteLogic();
                }

                if(gameObject.GetComponent<OpenCloseController>() != null) {
                    gameObject.GetComponent<OpenCloseController>().ExecuteLogic();
                }

                if(gameObject.GetComponent<CatchableObjectController>() != null) {
                    gameObject.GetComponent<CatchableObjectController>().ExecuteLogic();                
                }

                if(gameObject.GetComponent<InteractiveRadioController>() != null) {
                    gameObject.GetComponent<InteractiveRadioController>().ExecuteLogic();                
                }

                if(gameObject.GetComponent<CorridorDoorOpener>() != null) {
                    gameObject.GetComponent<CorridorDoorOpener>().ExecuteLogic();                
                }

                if(gameObject.GetComponent<ElectricSwitchController>() != null) {
                    gameObject.GetComponent<ElectricSwitchController>().ExecuteLogic();
                }
            
                DismissInteractionMenu();

                if (interactionOnce) {
                    interactionCollider.SetActive(false);
                    isPlayerInInteractionCollider = false;
                }

            }
        }
    }

    public void InteractionColliderEntered() {
        Debug.Log("Interaction Collider Entered");
        this.isPlayerInInteractionCollider = true;
    }

    public void InteractionColliderExited() {
        Debug.Log("Interaction Collider Exited");
        this.isPlayerInInteractionCollider = false;

        this.DismissInteractionMenu();
    }
    
    void OnMouseEnter()
    {
        Debug.Log("Mouse Enter Object");

        GameObject player = GameObject.Find("First Person Controller").gameObject;
        this.isPlayerPointingWithMouse = true;

        if(this.isPlayerInInteractionCollider && player.GetComponent<CharacterMotor>().canControl) {
            EnableInteractionMenu();
        }

        if(emissionMaterial != null) {
            emissionMaterial.DisableKeyword("_EMISSION");
            emissionMaterial.EnableKeyword("_EMISSION");
            emissionMaterial.SetColor("_EmissionColor",interactionEmissionColor);
        }
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse Exit Object");
        this.isPlayerPointingWithMouse = false;

        if(this.isPlayerInInteractionCollider) {
            this.DismissInteractionMenu();
        }

        if(emissionMaterial != null) {
            emissionMaterial.SetColor("_EmissionColor",originalEmissionColor);
            emissionMaterial.DisableKeyword("_EMISSION");
            emissionMaterial.EnableKeyword("_EMISSION");
            emissionMaterial.SetColor("_EmissionColor",originalEmissionColor);
        }
    }

    // private methods

    private void DismissInteractionMenu() {
        interactionMenuPanel.SetActive(false);
    }

    private void EnableInteractionMenu()
    {
        interactionMenuTextmesh.GetComponent<TextMeshProUGUI>().text = interactionMenuText;
        interactionMenuPanel.SetActive(true);
    }

}
