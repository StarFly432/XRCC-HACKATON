using UnityEngine;

public class MicrogestureInput : MonoBehaviour
{
    [Tooltip("The OVRHand component to read microgestures from.")]
    public OVRHand ovrHand;

    [Tooltip("The Animator component on the GameObject you want to animate.")]
    public Animator targetAnimator;

    [Tooltip("The name of the trigger parameter in the Animator Controller to activate on a thumb tap.")]
    public string animationTriggerName = "ThumbTapped";

    private Vector2 moveInput = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        // It's good practice to check if ovrHand is assigned to prevent errors.
        if (ovrHand == null)
        {
            return;
        }

        OVRHand.MicrogestureType microGesture = ovrHand.GetMicrogestureType();

        switch (microGesture)
        {
            case OVRHand.MicrogestureType.SwipeLeft:
                break;
            case OVRHand.MicrogestureType.SwipeRight:
                break;
            case OVRHand.MicrogestureType.ThumbTap:
                moveInput = Vector2.up;

                // Trigger the animation if the Animator is set
                if (targetAnimator != null && !string.IsNullOrEmpty(animationTriggerName))
                {
                    targetAnimator.SetTrigger(animationTriggerName);
                }
                break;
            case OVRHand.MicrogestureType.Invalid:
                break;
        }

    }
}
