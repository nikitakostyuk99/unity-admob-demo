using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using GoogleMobileAds;
using GoogleMobileAds.Api;

public class RewardedVideo : MonoBehaviour {

	[SerializeField]
	private UnityEngine.UI.Image showRewardedBasedVideoBtn;

	private RewardBasedVideoAd rewardBasedVideo;

	void Awake(){
		try{
			#if UNITY_ANDROID
			string appId = "ca-app-pub-5538586303013353~5140709220";
			#elif UNITY_IPHONE
			string appId = "ca-app-pub-3940256099942544~1458002511";
			#else
			string appId = "unexpected_platform";
			#endif

			// Initialize the Google Mobile Ads SDK.
			MobileAds.Initialize(appId);

		}
			catch{
			Camera.main.backgroundColor = Color.red;
		
		}
	}


	void Start () {

		this.rewardBasedVideo = RewardBasedVideoAd.Instance;

		// Called when an ad request has successfully loaded.
		rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
		// Called when an ad request failed to load.
		rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
		// Called when an ad is shown.
		rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
		// Called when the ad starts to play.
		rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
		// Called when the user should be rewarded for watching a video.
		rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
		// Called when the ad is closed.
		rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
		// Called when the ad click caused the user to leave the application.
		rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
		this.RequestRewardedVideo ();
	}
	
	public void RequestRewardedVideo()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-5538586303013353/8094175625";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3940256099942544/1712485313";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the rewarded video ad with the request.
		this.rewardBasedVideo.LoadAd(request, adUnitId);
	}

	public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
	{
		showRewardedBasedVideoBtn.color = Color.white;
		MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
	}

	public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print(
		"HandleRewardBasedVideoFailedToLoad event received with message: "
		+ args.Message);
	}

	public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
	}

	public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
	}

	public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
	}

	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
	{
		string type = args.Type;
		double amount = args.Amount;
		MonoBehaviour.print(
		"HandleRewardBasedVideoRewarded event received for "
		+ amount.ToString() + " " + type);
	}

	public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
	{
		MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
	}

	public void ShowRewardedBasedVideo()
	{
		if (rewardBasedVideo.IsLoaded()) {
			rewardBasedVideo.Show();
		}
	}


}
