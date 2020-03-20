using UnityEngine;
using System.Collections.Generic;

public class MagicGlow : MonoBehaviour
{
    [System.Serializable]
    public struct RendererIndexData
    {
        public Renderer renderer;
        public int materialIndex;

        public RendererIndexData(Renderer renderer, int index)
        {
            this.renderer = renderer;
            this.materialIndex = index;
        }
    }

    [Header("Visual")]
    [Tooltip("The VFX")]
    public ParticleSystem magicVFX;
    [Tooltip("The emission rate for the effect")]
    public float magicVFXEmissionRateMax = 8f;

    //Set gradient field to HDR
    [GradientUsage(true)] 
    [Tooltip("Magic color")]
    public Gradient magictGradient;
    [Tooltip("The material for magic color animation")]
    public Material magicMaterial;



    WeaponController m_Weapon;
    ParticleSystem.EmissionModule m_SteamVFXEmissionModule;

    void Awake()
    {
        var emissionModule = magicVFX.emission;
        emissionModule.rateOverTimeMultiplier = 0f;

        m_SteamVFXEmissionModule = magicVFX.emission;

        m_Weapon = GetComponent<WeaponController>();
        DebugUtility.HandleErrorIfNullGetComponent<WeaponController, OverheatBehavior>(m_Weapon, this, gameObject);
    }

    void Update()
    {
        m_SteamVFXEmissionModule.rateOverTimeMultiplier = magicVFXEmissionRateMax;

    }
}
