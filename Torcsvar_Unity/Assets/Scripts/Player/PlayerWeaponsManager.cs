using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerWeaponsManager : MonoBehaviour
{
    public enum WeaponSwitchState
    {
        Up,
        Down,
        PutDownPrevious,
        PutUpNew,
    }

    [Tooltip("List of weapon the player will start with")]
    public List<WeaponController> startingWeapons = new List<WeaponController>();

    [Header("References")]
    [Tooltip("Secondary camera used to avoid seeing weapon go throw geometries")]
    public Camera weaponCamera;
    [Tooltip("Parent transform where all weapon will be added in the hierarchy")]
    public Transform weaponParentSocket;
    [Tooltip("Position for weapons when active but not actively aiming")]
    public Transform defaultWeaponPosition;
    [Tooltip("Position for weapons when aiming")]
    public Transform aimingWeaponPosition;
    [Tooltip("Position for innactive weapons")]
    public Transform downWeaponPosition;

    [Header("Weapon Bob")]
    [Tooltip("Frequency at which the weapon will move around in the screen when the player is in movement")]
    public float bobFrequency = 10f;
    [Tooltip("How fast the weapon bob is applied, the bigger value the fastest")]
    public float bobSharpness = 10f;
    [Tooltip("Distance the weapon bobs when not aiming")]
    public float defaultBobAmount = 0.05f;
    [Tooltip("Distance the weapon bobs when aiming")]
    public float aimingBobAmount = 0.02f;

    [Header("Weapon Recoil")]
    [Tooltip("This will affect how fast the recoil moves the weapon, the bigger the value, the fastest")]
    public float recoilSharpness = 50f;
    [Tooltip("Maximum distance the recoil can affect the weapon")]
    public float maxRecoilDistance = 0.5f;
    [Tooltip("How fast the weapon goes back to it's original position after the recoil is finished")]
    public float recoilRestitutionSharpness = 10f;

    [Header("Misc")]
    [Tooltip("Speed at which the aiming animatoin is played")]
    public float aimingAnimationSpeed = 10f;
    [Tooltip("Field of view when not aiming")]
    public float defaultFOV = 60f;
    [Tooltip("Portion of the regular FOV to apply to the weapon camera")]
    public float weaponFOVMultiplier = 1f;
    [Tooltip("Delay before switching weapon a second time, to avoid recieving multiple inputs from mouse wheel")]
    public float weaponSwitchDelay = 1f;
    [Tooltip("Layer to set FPS weapon gameObjects to")]
    public LayerMask FPSWeaponLayer;

    public bool isAiming { get; private set; }
    public bool isPointingAtEnemy { get; private set; }
    public int activeWeaponIndex { get; private set; }

    public UnityAction<WeaponController> onSwitchedToWeapon;
    public UnityAction<WeaponController, int> onAddedWeapon;
    public UnityAction<WeaponController, int> onRemovedWeapon;

    WeaponController[] m_WeaponSlots = new WeaponController[9]; // 9 available weapon slots
    PlayerInputHandler m_InputHandler;
    PlayerCharacterController m_PlayerCharacterController;
    float m_WeaponBobFactor;
    Vector3 m_LastCharacterPosition;
    Vector3 m_WeaponMainLocalPosition;
    Vector3 m_WeaponBobLocalPosition;
    Vector3 m_WeaponRecoilLocalPosition;
    Vector3 m_AccumulatedRecoil;
    float m_TimeStartedWeaponSwitch;
    int m_WeaponSwitchNewWeaponIndex;

    private void Start()
    {
        activeWeaponIndex = -1;

        m_InputHandler = GetComponent<PlayerInputHandler>();

        m_PlayerCharacterController = GetComponent<PlayerCharacterController>();

        SetFOV(defaultFOV);
    }

    private void Update()
    {
    }

    // Sets the FOV of the main camera and the weapon camera simultaneously
    public void SetFOV(float fov)
    {
        m_PlayerCharacterController.playerCamera.fieldOfView = fov;
        weaponCamera.fieldOfView = fov * weaponFOVMultiplier;
    }
}
