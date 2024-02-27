using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Advertisements;

/// <summary>
/// This script will handle rewarded ad behaviour.
/// While some functions are not used they should not be deleted, otherwise it will cause errors.
/// </summary>

[RequireComponent(typeof(InterstitialAdHandler), typeof(AdManager))]
public class RewardedAdHandler : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [Header("Ad ID configuration")]
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";

    [Header("Implementation")]
    [SerializeField] private UnityEvent OnReward = new UnityEvent();
    private bool debugMode;
    private string _adUnitId = null;

    public void SetupAd(string platform , bool testmode)
    {
        _adUnitId = (platform == "iPhone" ? _iOSAdUnitId : _androidAdUnitId);
        debugMode = testmode;
        LoadAd();
    }
    public void LoadAd()
    {
        if(debugMode) 
            Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }


    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        if (debugMode)
            Debug.Log("Ad Loaded: " + adUnitId);
    }

    public void ShowAd()
    {
        if (debugMode)
            Debug.Log("Showing Ad: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            if (debugMode)
                Debug.Log("Player rewarded");
            //reward de player and load another ad
            OnReward.Invoke();
            LoadAd();
        }
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        if (debugMode)
            Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        if (debugMode)
            Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    // can be used durring the life time of a ad for example start can be used to pause the game and click is used if the user clicks the ad
    //mainly handy for Analytics or Game State Management
    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

}