using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Toast.Analytics;

public class SampleScript : MonoBehaviour {


	
	// 캠페인 등록시 설정한 "노출위치"의 KEY 입니다.
	private const string ADSPACE_NAME = "CAMPAIGN_SPACE";
	
	
	void Start () {
		Debug.Log ("Unity Plugin Version : " + PluginVersion.VersionString);
		GameAnalytics.setDebugMode(true);
		GameAnalytics.setCampaignListener (new MyCampaignListener ());
		
		// 게임의 APP Key, Company ID, 게임 버전을 입력합니다.
		GameAnalytics.initializeSdk ("51bb03803a76daef79fce61cd73de826fe94f1e6c432698c4a4ee2d6e6795191", "GiAtQUYC", "1.0.0", true);
		
		// 게임에서 사용하는 사용자 ID를 입력합니다.
		GameAnalytics.setUserId("GAME_USER_ID", true);
		
		// Analytics를 시작합니다.
		GameAnalytics.traceActivation ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit(); 
		}
	}
	
	void OnApplicationPause(bool paused) {
		
		// 앱이 Background/Foregorund로 이동하는 상황에 대한 처리입니다.
		if(paused) {
			Debug.Log ("Background...");
			GameAnalytics.traceDeactivation();
		} else {
			Debug.Log ("Foreground...");
			GameAnalytics.traceActivation();
		}
	}
	
	void OnGUI() {
		
		// 캠페인 기능 테스트.
		if (GUI.Button (new Rect(10,10,Screen.width-20,150), "Show Campaign")) {
			
			// 게임에서 적절한 시점에 캠페인을 노출합니다.
			// 캠페인 이미지를 다운로드 받기 전이나 캠페인 노출이 불가능한 상황에는 아무런 동작도 하지 않습니다.
			// 이 경우 return code를 확인하면 정확한 원인을 알 수 있습니다.
			int result = GameAnalytics.showCampaign(ADSPACE_NAME);
			Debug.Log ("showCampaign : " + result);
			
			/* 
			 * Show/Hide는 게임 상황에 맞춰 여러가지 방법으로 사용 가능합니다.
			 * 자세한 내용은 Programmer Guide를 참고하세요
			 * 
			 * GameAnalytics.showCampaign(ADSPACE_NAME, GameAnalytics.AnimationType.NONE, 1000);
			 * GameAnalytics.showCampaign(ADSPACE_NAME, GameAnalytics.AnimationType.FADE, 1000);
			 * GameAnalytics.showCampaign(ADSPACE_NAME, GameAnalytics.AnimationType.SILDE, 1000);
			 * 
			 * GameAnalytics.hideCampaign(ADSPACE_NAME);
			 * GameAnalytics.hideCampaign(ADSPACE_NAME, GameAnalytics.AnimationType.NONE);
			 * GameAnalytics.hideCampaign(ADSPACE_NAME, GameAnalytics.AnimationType.FADE);
			 * GameAnalytics.hideCampaign(ADSPACE_NAME, GameAnalytics.AnimationType.SILDE);
			 */
		}
		
		// 프로모션 기능 테스트.
		if (GUI.Button (new Rect(10,200,Screen.width-20,150), "Show PromotiON")) {
			// 실제 게임에서는 아래 코드와 같이 사용하지 마세요.
			// 우선 isPromotionAvailable 함수를 이용하여 프로모션 진행 가능 여부를 체크합니다.
			// true가 리턴되면 getPromotionButtonImagePath를 이용하여 이미지가 저장된 경로(SDK에서 다운로드 하여 저장해 놓습니다.)를 가져와 버튼을 생성합니다.
			// 그 버튼을 누르면 launchPromotionPage을 호출하여 프로모션 보드를 실행합니다.
			if (GameAnalytics.isPromotionAvailable() == true) {
				Debug.Log ("Show Toast Promotion Button");
				string buttonImageUri = GameAnalytics.getPromotionButtonImagePath();
				Debug.Log ("Button Image Uri : " + buttonImageUri);
				loadButtonImageTexture(buttonImageUri);
				GameAnalytics.launchPromotionPage();
			} else {
				Debug.Log ("Hide Toast Promotion Button");
			}
		}
		
		// 로그 추적 API 테스트
		if (GUI.Button (new Rect(10,400,Screen.width-20,150), "Test Trace* APIs")) {
			int result;
			
			result = GameAnalytics.traceStartSpeed ("ScreenCode");
			Debug.Log ("traceStartSpeed : " + result);
			
			result = GameAnalytics.traceLevelUp (2);
			Debug.Log ("traceLevelUp : " + result);
			result = GameAnalytics.traceEvent ("Type", "Code", "Param1", "Param2", 99, 2);
			Debug.Log ("traceEvent : " + result);
			result = GameAnalytics.traceMoneyAcquisition("usageCode", "0", 100, 2);
			Debug.Log ("traceMoneyAcquisition : " + result);
			result = GameAnalytics.traceMoneyConsumption ("usageCode", "0", 100, 2);
			Debug.Log ("traceMoneyConsumption : " + result);
			result = GameAnalytics.tracePurchase("itemCode", 0.99f, 0.99f, "USD", 2);
			Debug.Log ("tracePurchase : " + result);
			result = GameAnalytics.traceFriendCount(100);
			Debug.Log ("traceFriendCount : " + result);
			
			result = GameAnalytics.traceEndSpeed ("ScreenCode");
			Debug.Log ("traceEndSpeed : " + result);
		}
	}
	
	private void loadButtonImageTexture(string buttonImageUri) {
		#if !UNITY_EDITOR && UNITY_ANDROID
		Texture2D tex = null;
		byte[] fileData;
		
		Debug.Log ("loadButtonImageTexture : " + buttonImageUri);
		
		if (File.Exists(buttonImageUri)) {
			Debug.Log ("button image file exist!!!!");
			fileData = File.ReadAllBytes(buttonImageUri);
			Debug.Log ("button image data size : " + fileData.Length);
			
			tex = new Texture2D(2, 2);
			tex.LoadImage(fileData);
			
			//			GUI.DrawTexture(new Rect
			// ......
		}
		#endif
		
	}
	
	public class MyCampaignListener : CampaignListener
	{
		public void OnCampaignVisibilityChanged(string adspaceName, bool show)
		{
			Debug.Log ("OnCampaignVisibilityChanged : " + adspaceName + " / " + show);
		}
		
		public void OnCampaignLoadSuccess(string adspaceName)
		{
			Debug.Log ("OnCampaignLoadSuccess : " + adspaceName);
		}
		
		public void OnCampaignLoadFail(string adspaceName, int errorCode, string errorMessage)
		{
			Debug.Log ("OnCampaignLoadFail : " + adspaceName + " / " + errorCode + " / " + errorMessage);
		}
		
		public void OnMissionComplete(List<string> missionList)
		{
			Debug.Log ("OnMissionComplete");
			foreach(string mission in missionList) {
				Debug.Log ("Mission - " + mission);
			}
		}
		
		public void OnPromotionVisibilityChanged(bool show)
		{
			Debug.Log ("OnPromotionVisibilityChanged : " + show);
		}
	}


}
