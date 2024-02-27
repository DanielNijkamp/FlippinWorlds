using UnityEngine;
using UnityEngine.Advertisements;
using UnityEditor;
/// <summary>
/// This script will handle all ad behaviour.
/// While some functions are not used they should not be deleted, otherwise it will cause errors.
/// </summary>

[RequireComponent(typeof(InterstitialAdHandler), typeof(RewardedAdHandler))]
public class AdManager : MonoBehaviour , IUnityAdsInitializationListener 
{

    [Header("Ad Game ID")]

    [Tooltip("IOS game ID from Unity Dashboard website")]
    [SerializeField] private string _iosGameID = "";
    [Tooltip("Android game ID from the Unity Dashboard website")]
    [SerializeField] private string _androidGameID = "";

    [Header("Debugging")]
    [SerializeField] private bool testMode = false;
    
    public static AdManager Instance;
    private RewardedAdHandler _rewardedAdHandler;
    private InterstitialAdHandler _interstitialAdHandler;

    private string platform;
    private string platformID;

    void Awake()
    {
        _rewardedAdHandler = gameObject.GetComponent<RewardedAdHandler>();
        _interstitialAdHandler = gameObject.GetComponent<InterstitialAdHandler>();
        InitializeAds();
    }
    #region display ads
    public void PlayRewardedAd()
    {
        _rewardedAdHandler.ShowAd();
    }
    public void PlayInterstitialAd()
    {
        _interstitialAdHandler.ShowAd();
    }
    #endregion
    #region Initialize Ads
    public void InitializeAds()
    {
        platform = (Application.platform == RuntimePlatform.IPhonePlayer) ? "iPhone" : "Android";
        platformID = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iosGameID : _androidGameID;
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(platformID , testMode, this);
        }
    }


    public void OnInitializationComplete()
    {
        if (testMode)
            Debug.Log("Unity Ads initialization complete.");
        _rewardedAdHandler.SetupAd(platform , testMode);
        _interstitialAdHandler.SetupAd(platform , testMode);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        if (testMode)
            Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
    #endregion

}
