package com.nhnent.toastanalytics.sample;

import java.util.List;

import com.toast.android.analytics.GameAnalytics;
import com.toast.android.analytics.GameAnalytics.CampaignListener;
import com.toast.android.analytics.exception.CampaignException;

import android.annotation.SuppressLint;
import android.annotation.TargetApi;
import android.app.Activity;
import android.content.Context;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class MainActivity extends Activity {
	
	private static final String APP_ID = "51bb03803a76daef79fce61cd73de826fe94f1e6c432698c4a4ee2d6e6795191";			// Analytics WebPage의 App 설정 메뉴에서 확인할 수 있습니다.
	private static final String COMPANY_ID = "GiAtQUYC";	// Analytics WebPage의 App 설정 메뉴에서 확인할 수 있습니다.
	private static final String APP_VERISION = "app_ver";	// Game에서 임의로 정의하여 사용합니다. 보통 게임 버전을 사용하면 됩니다.
	
	private static final String USER_ID = "userid";
	private static final String ADSPACE_NAME = "CAMPAIGN_SPACE";
	
	private Activity activity;
	private Context context;
	
	private Button btnPromotion;
	private Button btnCampaign;

	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		btnPromotion = (Button)findViewById(R.id.btn_promotion);
		btnCampaign = (Button)findViewById(R.id.btn_campaign);

		activity = this;
		context = getApplicationContext();
		
		/*
		 * 디버그 모드를 설정합니다.
		 *   true로 설정하면 LogCat에 로그가 출력됩니다. 또한 Webpage의 "웹 콘솔"에서 실시간 로그 확인이 가능합니다.
		 *   출시 빌드에서는 반드시 false로 설정해야 합니다.
		 */
		GameAnalytics.setDebugMode(true);
		
		/*
		 * CampaignListener를 등록합니다.
		 *  프로모션및 캠페인에서 callback을 받을 수 있습니다.
		 */
		GameAnalytics.setCampaignListener(campaignListener);
		
		/*
		 * SDK를 초기화 합니다.
		 *  useLoggingUserId flag는 게임의 상황에 따라 사용하면 됩니다.
		 *  true인 경우 사용자 기준이 게임에서 setUserId에서 제공하는 id입니다.
		 *  false인 경우 사용자 기준이 Advertise ID입니다.
		 *  각각의 특성이 있으니 게임에서 고려하여 결정하면 됩니다. 
		 *  단 true를 사용하는 경우 setUserId를 이용하여 반드시 사용자 ID를 SDK에 전달해야 합니다.
		 */
		GameAnalytics.initializeSdk(context, APP_ID, COMPANY_ID, APP_VERISION, false);
		
		/*
		 * USERID를 설정합니다.
		 *  이 함수는 로그인이 완료되어 사용자 ID를 가져올 수 있는 시점에 호출하면 됩니다.
		 *  USER_ID는 게임에서 사용하는 사용자 ID입니다. user id, member no, kakao id, facebook id 등 게임에서 사용자를 구분할때 사용하는 값을 이용하면 됩니다.
		 *  initializeSdk에서 useLoggingUserId를 true로 설정하면 setUserId를 통해서 사용자 ID를 받는 시점에 로그 전송을 시작합니다.
		 *  initializeSdk에서 useLoggingUserId를 false로 설정하더라도 프로모션을 사용하는 경우 setUserId를 호출해야 합니다.
		 */
		GameAnalytics.setUserId(USER_ID, true);

		
		/*
		 * Promotion 가능 여부를 체크합니다.
		 * Promotion 실행에 대한 정보는 initializeSDK 시점에 서버에서 받아옵니다.
		 * 보통 앱 시작하면서 initiailzeSDK를 호출하고 인증 및 게임 초기화 이후에 isPromotionAvailable을 호출하기 때문에 아래 샘플 코드와 같이 일부러 sleep을 줄 필요는 없습니다.
		 * 
		 * isPromotionAvailable으로 프로모션 가능 여부를 체크한 뒤 true가 리턴되는 경우(즉 프로모션 진행이 가능한 상태인 경우) 프로모션 버튼을 생성합니다.
		 * 프로모션 페이지에 등록한 버튼 이미지를 이용하려면 getPromotionButtonImagePath을 호출하면 로컬에 저장된 이미지 경로(png파일)를 알려 줍니다.
		 * 이 이미지를 이용하지 않고 게임 리소스에 포함된 이미지를 사용하여도 됩니다.
		 * 버튼을 생성하고 버튼 터치 이벤트 발생시 launchPromotionPage을 호출하면 프로모션 보드 웹뷰가 뜹니다.
		 * 이때 두개의 callback이 발생하는데 onMissionComplete을 통해 프로모션 보상을 지급하고 onPromotionVisibilityChanged을 통해서 Rendering 성능을 조절할 수 있습니다.
		 */
		CheckTask task = new CheckTask();
		task.execute();
		
		
		btnCampaign.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				/*
				 * 캠페인 배너/팝업을 노출합니다.
				 * 게임에서 적절한 시점에 호출해 주세요.
				 * ADSPCE는 프로모션 등록시 설정한 노출위치의 Key 입니다.
				 */
				GameAnalytics.showCampaign(ADSPACE_NAME, activity);	
			}
		});
		
		
		appRunning();
	}
	
	@Override
	protected void onResume() {
		/*
		 * Analytics 로그 전송을 시작합니다.
		 */
		GameAnalytics.traceActivation(this);		
		
		super.onResume();
	}
	
	@Override
	protected void onPause() {
		/*
		 * Analytics 로그 수집을 멈춥니다.
		 */
		GameAnalytics.traceDeactivation(this);
		
		super.onPause();
	}

	private void appRunning() {
		
		/*
		 * 게임에서 적절한 상황에 맞게 trace* 함수들을 호출하면 됩니다.
		 */
		GameAnalytics.traceLevelUp(10);
		GameAnalytics.traceEvent("EVENT_TYPE", "EVENT_CODE", "PARAM1", "PARAM2", 10.0f, 10);
		GameAnalytics.traceFriendCount(10);
		GameAnalytics.traceMoneyAcquisition("USAGE_CODE", "0", 10.0f, 10);
		GameAnalytics.traceMoneyConsumption("USAGE_CODE", "1", 10.0f, 10);
		GameAnalytics.tracePurchase("ITEM_CODE", 10.0f, 10.0f, "KRW", 10);
		GameAnalytics.traceStartSpeed("INTERVAL");
		GameAnalytics.traceEndSpeed("INTERVAL");
		
	}
	
	
	private class CheckTask extends AsyncTask<String, Void, String> {

		@Override
		protected String doInBackground(String... arg0) {
			int retryCount = 0;
			while(true) {
				try {
					Thread.sleep(2000);
				} catch (InterruptedException e) {
					e.printStackTrace();
				}
				
				if (GameAnalytics.isPromotionAvailable()) {
					break;
				}
				
				retryCount++;
				
				if (retryCount > 5) {
					break;
				}
			}
			
			return GameAnalytics.getPromotionButtonImagePath();
		}
		
		@TargetApi(Build.VERSION_CODES.JELLY_BEAN)
		@Override
		protected void onPostExecute(String buttonImagePath) {
			
			if (buttonImagePath == null || buttonImagePath.length() == 0) {
				return;
			}
			
			Drawable d = new BitmapDrawable(activity.getResources(), buttonImagePath);
			if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.JELLY_BEAN) {
				btnPromotion.setBackground(d);
			} else {
				btnPromotion.setBackgroundDrawable(d);
			}

			btnPromotion.setOnClickListener(new OnClickListener() {
				@Override
				public void onClick(View v) {
					GameAnalytics.launchPromotionPage(activity);
				}
			});	
		}	
	}
	

	CampaignListener campaignListener = new CampaignListener() {
		@Override
		public void onMissionComplete(List<String> missionList) {
			/*
			 *  미션 정보가 있는 경우 이 Callback이 호출됩니다.
			 *
			 *  String은 MissionKey와 MissionValue로 구성되어 있습니다.
			 *  '|'을 splitter로 가집니다.
			 *  
			 *  여기서 받은 Key와 Value를 게임서버로 전송하고, 게임서버에서는 Promotion server의 check-mission API를 호출하여 보상 정보를 확인합니다.
			 */
			
//			String mission = missionList.get(0);
//			String[] missionInfo = mission.split("\\|");
		}

		@Override
		public void onCampaignVisibilityChanged(String adSpaceName, boolean show) {
			/*
			 * 캠페인 팝업이나 배너가 화면에 보이고 닫힐때 호출됩니다.
			 */
		}

		@Override
		public void onCampaignLoadSuccess(String adSpaceName) { 
			/*
			 * 디버깅용입니다.
			 */
		}

		@Override
		public void onCampaignLoadFail(String adSpaceName, CampaignException exception) {
			/*
			 * 디버깅용입니다.
			 */
		}

		@Override
		public void onPromotionVisibilityChanged(boolean show) { 
			/*
			 * 프로모션 보드가 화면에 보이고 닫힐때 호출됩니다.
			 */
		}
	};
	
}
