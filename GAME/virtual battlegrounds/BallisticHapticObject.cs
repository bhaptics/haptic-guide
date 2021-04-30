using Ballistics;
using Bhaptics.Tact.Unity;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallisticObject))]
public class BallisticHapticObject : MonoBehaviour
{
    private BallisticObject ballisticObject;

    [SerializeField] private VestHapticClip HapticClip;
    [SerializeField] private float targetHeight = 1f;

    private UnityAction<ImpactInfo> OnImpact;


    void OnEnable()
    {
        OnImpact += OnImpactFunction;
        ballisticObject = GetComponent<BallisticObject>();
        ballisticObject.OnImpact.AddListener(OnImpact);
    }

    private void OnImpactFunction(ImpactInfo arg0)
    {
        var velocity = arg0.entryVelocity.magnitude;

        Debug.Log(velocity);

        // use speed for intensity? 
        var intensity = velocity * 0.001; 

        var angle = BhapticsUtils.Angle(transform.forward, arg0.entryPosition - transform.position);

        if (HapticClip != null)
        {
            // HapticClip.Play(1f, 0.5f, 360 - angle, 0);

            // USE OFFSET
            var offsetY = (arg0.entryPosition.y - transform.position.y) / targetHeight;
            HapticClip.Play(1f, 0.5f, 360 - angle, offsetY);
        }

        // Debug.LogError(angle);
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    void OnDisable()
    {
        OnImpact -= OnImpactFunction;
    }
}
