using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Settings : MonoBehaviour
{
    public Slider brightnessSlider;
    public Slider contrastSlider;

    public PostProcessProfile profile;
    public PostProcessLayer layer;

    AutoExposure exposure;
    ColorGrading grading;

    private void Start() {
        profile.TryGetSettings(out exposure);
        profile.TryGetSettings(out grading);

        brightnessSlider.value = exposure.keyValue.value;
        contrastSlider.value = grading.contrast.value;

        AdjustBrightness();
        AdjustContrast();
    }

    public void AdjustBrightness() {
        exposure.keyValue.value = brightnessSlider.value;
    }

    public void AdjustContrast() {
        grading.contrast.value = contrastSlider.value;
    }
}
