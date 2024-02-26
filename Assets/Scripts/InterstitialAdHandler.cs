using UnityEngine;
using UnityEngine.Advertisements;

/// <summary>
/// This script will handle interstitial ad behaviour.
/// While some functions are not used they should not be deleted, otherwise it will cause errors.
/// </summary>

[RequireComponent(typeof(AdManager), typeof(RewardedAdHandler))]
public class InterstitialAdHandler : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [Header("Ad ID configuration")]
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iosAdUnitId = "Interstitial_iOS";

    private bool debugMode;
    private string _adUnitId;

    public void SetupAd(string platform, bool testmode)
    {
        _adUnitId = (platform == "iPhone" ? _iosAdUnitId : _androidAdUnitId);
        debugMode = testmode;
        LoadAd();
    }

    public void LoadAd()
    {
        if (debugMode)
            Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    public void ShowAd()
    {
        if (debugMode)
            Debug.Log("Showing Ad: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        if (debugMode)
            Debug.Log("Ad Loaded: " + adUnitId);
    }

    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
    {
        if (debugMode)
            Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
    {
        if (debugMode)
            Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad..
    }

    // can be used durring the life time of a ad for example start can be used to pause the game and click is used if the user clicks the ad.
    //mainly handy for Analytics or Game State Management.
    //Complete can be used to do something after the ad is over.
    public void OnUnityAdsShowStart(string _adUnitId) { }
    public void OnUnityAdsShowClick(string _adUnitId) { }
    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) { }
}
