using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Diagnostics;

namespace Toast.Analytics {
	public class GameAnalyticsWebPlayer : MonoBehaviour {

		void Start()
		{
			GameAnalyticsWebPlayer.UniqueInstance = this;
		}
		
		// Constants
		private const string SDK_VERSION = "1.1.3";
		private const string PROTOCOL_VERSION = "1.0";
		private const string AFLAT_SERVER_URL = "https://api-log-analytics.cloud.toast.com/am";
//		private const string AFLAT_SERVER_URL = "https://api-log-analytics.cloud.toast.com/am";

		// Singleton
		public static GameAnalyticsWebPlayer UniqueInstance { get;  private set; }
		
		// private fields
		private bool _useLoggingUserId;
		private Stopwatch _appStopwatch;
		private Stopwatch _activationStopwatch;
		private Dictionary<string, Stopwatch> _speedStopwatches;
		
		// Fields to send
		private string _appId;
		private string _companyId;
		private string _appVersion;
		
		#region Public Properties
		
		public bool IsInitialized { get; private set; }
		public bool IsTraceStartLogged { get; private set; }
		public IDeviceCollectableInfo DeviceInfo { get; private set; }
		
		public bool DebugFlag { get; private set; }
		public string UserId { get; private set; }
		public bool UseLoggingUserId { get { return _useLoggingUserId; } }
		
		#endregion
		
		#region Public APIs
		
		// Configuration APIs
		public static string getVersion() {
			return SDK_VERSION;
		}
		
		public static void setDebugMode(bool enable) {
			UniqueInstance.DebugFlag = enable;
		}
		
		public static bool getDebugMode() {
			return UniqueInstance.DebugFlag;
		}
		
		public static string getDeviceInfo(string key) {
			// TODO. implement me
			return "";
			//throw new System.NotImplementedException();
		}
		
		public static int setUserId(string userId, bool useCampaignOrPromotion) {
			UniqueInstance.UserId = userId;
			
			if (UniqueInstance.UseLoggingUserId == true && 
			    UniqueInstance.IsInitialized == true && 
			    UniqueInstance.IsTraceStartLogged == false)
			{
				UniqueInstance.TraceStart();
			}
			
			return ReturnCode.S_SUCCESS;
		}
		
		public static string getResultMessage(int errorCode)
		{
			try {
				return ReturnCode.RESULT_STRING[errorCode];
				
			} catch (KeyNotFoundException) {
				return "ErrorCode doest NOT exist";
			} 
		}
		
		// Trace APIs
		public static int initializeSdk(string appId, string companyId, string appVersion, bool useLoggingUserId) { 

			if (UniqueInstance.IsInitialized == true) { 
				return ReturnCode.W_ALREADY_INITIALIZED; 
			} 
			
			try 
			{
				// init unique Analytics instance
				UniqueInstance.Initialize(appId, companyId, appVersion, useLoggingUserId);
				
				// instantiate IDeviceCollectable regarding to OS 
				if (SystemInfo.operatingSystem.Contains("Windows")) { UniqueInstance.DeviceInfo = new WindowsCollectableInfo(); }
				else { UniqueInstance.DeviceInfo = new MacCollaectableInfo(); }

				// start or pend
				if (useLoggingUserId == true && UniqueInstance.UserId == null)
				{
					// pend traceStart
				}
				else
				{
					UniqueInstance.TraceStart();
				}
				
				return ReturnCode.S_SUCCESS;
				
			} catch (System.Exception e) {
				return ReturnCode.E_INTERNAL_ERROR;
			}
			
		}
		
		public static int traceActivation() 
		{
			int returnCode = CommonTraceTask(() => 
			                                 {
				UniqueInstance.TraceActivation();
				
				return ReturnCode.S_SUCCESS;
			});
			
			return returnCode;
		}
		
		public static int traceDeactivation() 
		{
			int returnCode = CommonTraceTask(() =>
			                                 {
				UniqueInstance.TraceDeactivation();
				return ReturnCode.S_SUCCESS;
			});
			return returnCode;
		}
		
		public static int traceFriendCount(int friendCount) 
		{
			int returnCode = CommonTraceTask(() => 
			                                 {
				UniqueInstance.TraceFriendCount(friendCount);
				return ReturnCode.S_SUCCESS;
			});
			
			return returnCode;
		}
		
		public static int tracePurchase(string itemCode, float payment, float unitCost, string currency,  int level)
		{
			int returnCode = CommonTraceTask(() =>
			                                 {
				UniqueInstance.TracePurchase(itemCode, payment, unitCost, currency, level);
				return ReturnCode.S_SUCCESS;
			});
			
			return returnCode;
		}
		
		public static int traceMoneyAcquisition(string usageCode, string type, double acquistionAmount, int level)
		{
			int returnCode = CommonTraceTask(() =>
			                                 {
				UniqueInstance.TraceMoneyAcquisition(usageCode, type, acquistionAmount, level);
				return ReturnCode.S_SUCCESS;
			});
			
			return returnCode;
		}
		
		public static int traceMoneyConsumption(string usageCode, string type, double consumptionAmount, int level)
		{
			int returnCode = CommonTraceTask(() =>
			                                 {
				UniqueInstance.TraceMoneyConsumption(usageCode, type, consumptionAmount, level);
				return ReturnCode.S_SUCCESS;
			});
			
			return returnCode;
		}
		
		public static int traceLevelUp(int level)
		{
			int returnCode = CommonTraceTask(() =>
			                                 {
				UniqueInstance.TraceLevelUp(level);
				return ReturnCode.S_SUCCESS;
			});
			
			return returnCode;
		}
		
		public static int traceEvent(string eventType, string eventCode, string param1, string param2, double value, int level)
		{
			int returnCode = CommonTraceTask(() =>
			                                 {
				UniqueInstance.TraceEvent(eventType, eventCode, param1, param2, value, level);
				return ReturnCode.S_SUCCESS;
			});
			
			return returnCode;
		}
		
		public static int traceStartSpeed(string intervalName)
		{
			int returnCode = CommonTraceTask(() =>
			                                 {
				int subReturnCode = UniqueInstance.TraceStartSpeed(intervalName);
				return subReturnCode;
			});
			
			return returnCode;
		}
		
		public static int traceEndSpeed(string intervalName)
		{
			int returnCode = CommonTraceTask(() =>
			                                 {
				int subReturnCode = UniqueInstance.TraceEndSpeed(intervalName);
				return subReturnCode;
			});
			
			return returnCode;
		}
		
		/*
		// Campaign API
		public static int showCampaign(string adspaceName) { return 0; }
		public static int showCampaign(string adspaceName, int animation, int lifeTime) { return 0; }
		public static int hideCampaign(string adspaceName) { return 0; }
		public static int hideCampaign(string adspaceName, int animation) { return 0; }
		
		// Toast Promotion API - Android Only
		public static bool isPromotionAvailable() { return false; }
		public static string getPromotionButtonImagePath() { return ""; }
		public static int launchPromotionPage() { return 0; }
		*/
		#endregion
		
		// -------------- 
		
		// Prevent instantiation by third party developer
		private GameAnalyticsWebPlayer() : base() { }
		
		private void Initialize(string appId, string companyId, string appVersion, bool useLoggingUserId)
		{
			_appId = appId;
			_companyId = companyId;
			_appVersion = appVersion;
			_useLoggingUserId = useLoggingUserId;
			
			this.IsInitialized = true;
			_appStopwatch = new Stopwatch();
			_activationStopwatch = new Stopwatch();
			_speedStopwatches = new Dictionary<string, Stopwatch>();
		}
		
		// -------------- 
		
		private static int CommonTraceTask(System.Func<int> predicate)
		{
			if (UniqueInstance == null || UniqueInstance.IsInitialized == false) { return ReturnCode.E_NOT_INITIALIZED; }
			if (UniqueInstance.IsTraceStartLogged == false) { return ReturnCode.E_SESSION_CLOSED; }
			
			int returnCode = predicate();
			
			return returnCode;
		}
		
		// -----------------
		
		#region non-static trace methods
		
		private int TraceStart()
		{
			SendTraceStart();
			
			this.IsTraceStartLogged = true;
			_appStopwatch.Start();
			return ReturnCode.S_SUCCESS;
		}
		
		private void SendTraceStart()
		{
			TraceLogSerializer traceLog = new TraceLogSerializer();
			AssignDefaultMandatoryAndDebugFields(traceLog, ActionType.TRACE_START, this.DebugFlag);
			AssignDefaultOptionalISFields(traceLog);
			
			SendTraceLog(traceLog);
		}
		
		// -----------------
		
		public void TraceActivation()
		{
			_activationStopwatch.Reset();
			_activationStopwatch.Start();
			SendTraceActivation();
		}
		
		private void SendTraceActivation()
		{
			TraceLogSerializer traceLog = new TraceLogSerializer();
			AssignDefaultMandatoryAndDebugFields(traceLog, ActionType.TRACE_ACTIVATION, this.DebugFlag);
//			AssignDefaultOptionalISFields(traceLog);
			
			SendTraceLog(traceLog);
		}
		
		// -----------------
		
		private void TraceDeactivation()
		{
			_activationStopwatch.Stop();
			int duration = (int)_activationStopwatch.Elapsed.TotalSeconds;
			SendTraceDeactivation(duration);
		}
		
		private void SendTraceDeactivation(int duration)
		{
			TraceLogSerializer traceLog = new TraceLogSerializer();
			AssignDefaultMandatoryAndDebugFields(traceLog, ActionType.TRACE_DEACTIVATION, this.DebugFlag);
			traceLog.AddTraceDeactivateField(duration);
			
			SendTraceLog(traceLog);
		}
		
		// -----------------
		
		private void TraceFriendCount(int friendCount)
		{
			SendTraceFriendCount(friendCount);
		}
		
		private void SendTraceFriendCount(int friendCount)
		{
			TraceLogSerializer traceLog = new TraceLogSerializer();
			AssignDefaultMandatoryAndDebugFields(traceLog, ActionType.TRACE_FRIENDS_COUNT, this.DebugFlag);
			traceLog.AddTraceFriendField(friendCount.ToString());
			
			SendTraceLog(traceLog);
		}
		
		// -----------------
		
		private void TracePurchase(string itemCode, float payment, float unitCost, string currency, int level)
		{
			SendTracePurchase(itemCode, (decimal)unitCost, currency, (decimal)payment, level);
		}
		
		private void SendTracePurchase(string itemCode, decimal unitCost, string currency, decimal payment, int level)
		{
			TraceLogSerializer traceLog = new TraceLogSerializer();
			AssignDefaultMandatoryAndDebugFields(traceLog, ActionType.TRACE_PURCHASE, this.DebugFlag);
			traceLog.AddTracePurchaseFields(itemCode, unitCost, currency, payment);
			traceLog.AddExtendedLevelField(level);
			
			SendTraceLog(traceLog);
		}
		
		// -----------------
		
		private void TraceMoneyAcquisition(string usageCode, string type, double acquistionAmount, int level) 
		{
			// 0: "do" code for acquisition
			SendTraceMoney(usageCode, type, "0", (decimal)acquistionAmount, level);
		}
		
		private void TraceMoneyConsumption(string usageCode, string type, double consumptionAmount, int level) 
		{
			// 1: "do" code for consumption
			SendTraceMoney(usageCode, type, "1", (decimal)consumptionAmount, level);
		}
		
		private void SendTraceMoney(string usageCode, string type, string @do, decimal amount, decimal level) 
		{
			TraceLogSerializer traceLog = new TraceLogSerializer();
			AssignDefaultMandatoryAndDebugFields(traceLog, ActionType.TRACE_MONEY, this.DebugFlag);
			traceLog.AddTraceGoodsFields(usageCode, type, @do, amount, level);
			
			SendTraceLog(traceLog);
		}
		
		// -------------------
		
		private void TraceLevelUp(int level) 
		{
			SendTraceLevelUp(level);
		}
		
		private void SendTraceLevelUp(decimal level) 
		{
			TraceLogSerializer traceLog = new TraceLogSerializer();
			AssignDefaultMandatoryAndDebugFields(traceLog, ActionType.TRACE_LEVELUP, this.DebugFlag);
			traceLog.AddTraceLevelUpField(level);
			
			SendTraceLog(traceLog);
		}
		
		// -------------------
		
		private void TraceEvent(string eventType, string eventCode, string param1, string param2, double value, int level) 
		{
			SendTraceEvent(eventType, eventCode, param1, param2, (decimal)value, level);
		}
		
		private void SendTraceEvent(string eventType, string eventCode, string param1, string param2, decimal value, int level)
		{
			TraceLogSerializer traceLog = new TraceLogSerializer();
			AssignDefaultMandatoryAndDebugFields(traceLog, ActionType.TRACE_EVENT, this.DebugFlag);
			traceLog.AddTraceEventFields(eventType, eventCode, param1, param2, value);
			traceLog.AddExtendedLevelField(level);
			
			SendTraceLog(traceLog);
		}
		
		// -------------------
		
		private int TraceStartSpeed(string intervalName) 
		{
			if (_speedStopwatches.ContainsKey(intervalName) == true) { return ReturnCode.E_ALREADY_EXISTS; }
			
			_speedStopwatches.Add(intervalName, new Stopwatch());
			_speedStopwatches[intervalName].Start();
			
			return ReturnCode.S_SUCCESS;
		}
		
		private int TraceEndSpeed(string intervalName) 
		{
			if (_speedStopwatches.ContainsKey(intervalName) == false) { return ReturnCode.E_INSUFFICIENT_OPERATION; }
			
			_speedStopwatches[intervalName].Stop();
			long elapsed = _speedStopwatches[intervalName].ElapsedMilliseconds;
			_speedStopwatches.Remove(intervalName);
			
			SendTraceSpeed(intervalName, elapsed);
			return ReturnCode.S_SUCCESS;
		}
		
		private void SendTraceSpeed(string intervalName, decimal loadingTime) 
		{
			TraceLogSerializer traceLog = new TraceLogSerializer();
			AssignDefaultMandatoryAndDebugFields(traceLog, ActionType.TRACE_SPEED, this.DebugFlag);
			traceLog.AddTraceSpeedFields(intervalName, loadingTime);
			
			SendTraceLog(traceLog);
		}
		
		// -------------------
		
		private void SendTraceLog(TraceLogSerializer traceLog)
		{
			string json = traceLog.BuildJSON();
			UnityEngine.Debug.Log ("Send Data : " + json);

			string encodedJSON = WWW.EscapeURL(json);
			WWW postLogRequest = new WWW(AFLAT_SERVER_URL, System.Text.Encoding.UTF8.GetBytes(encodedJSON));
			StartCoroutine(WaitForRequest(postLogRequest));
		}
		
		#endregion
		
		private TraceLogSerializer AssignDefaultMandatoryAndDebugFields(TraceLogSerializer logSerializer, string actionType, bool isDebug)
		{
			TraceLogMandatoryField mandatory = new TraceLogMandatoryField()
			{
				ProtocolVersion = PROTOCOL_VERSION,
				SDKVersion = SDK_VERSION,
				CompanyId = _companyId,
				AppId = _appId,
				AppVersion = _appVersion,
				UserId = (_useLoggingUserId ? this.UserId : this.DeviceInfo.DeviceID),
				DeviceId = this.DeviceInfo.DeviceID,
				ClientIP = this.DeviceInfo.IP,
				ClientTimeStamp = (int)(System.DateTime.UtcNow - new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds,
				ActionType = actionType,
			};
			
			logSerializer.AddMandatoryFields(mandatory);
			logSerializer.IsDebug = isDebug;

			return logSerializer;
		}
		
		public TraceLogSerializer AssignDefaultOptionalISFields(TraceLogSerializer logSerializaer)
		{
			TraceLogOptionalISField optional = new TraceLogOptionalISField()
			{
				DeviceName = this.DeviceInfo.DeviceName,
				Carrier = this.DeviceInfo.Carrier,
				OS = this.DeviceInfo.OS,
				OSVerions = this.DeviceInfo.OSVersion,
				TimeZone = this.DeviceInfo.TimeZone,
				CountryCode = this.DeviceInfo.CountryCode,
				Locale = this.DeviceInfo.Locale
			};
			
			logSerializaer.AddOptionalISFields(optional);
			
			return logSerializaer;
		}
		
		private IEnumerator WaitForRequest(WWW www)
		{
			yield return www;
				
			if (www.error == null)
			{
				string headerStr = "";
				foreach(KeyValuePair<string, string> entry in www.responseHeaders)
				{
					headerStr += entry.Key + " : " + entry.Value + "\n";
				}
				UnityEngine.Debug.Log("HTTP Response Header\n" + headerStr);
			}
			else
			{
				UnityEngine.Debug.Log("HTTP Request Failed. Reason : " + www.error);
			}
		}
		
		#region nested classes
		
		public class TraceLogSerializer
		{
			private Dictionary<string, string> _basicFields = new Dictionary<string, string>();
			private Dictionary<string, decimal> _basicNumberFields = new Dictionary<string, decimal>();
			private Dictionary<string, string> _extendedFields = new Dictionary<string, string>();
			private Dictionary<string, decimal> _extendedNumberFields = new Dictionary<string, decimal>();
			
			public bool IsDebug { get; set; }

			// Add Level for Extended field
			public void AddExtendedLevelField (int level)
			{
				_extendedNumberFields.Add("lv", level);
			}

			// Add Mandatory Field
			public void AddMandatoryFields(TraceLogMandatoryField mandatory)
			{
				_basicFields.Add("pv", mandatory.ProtocolVersion);
				_basicFields.Add("kv", mandatory.SDKVersion);
				_basicFields.Add("cid", mandatory.CompanyId);
				_basicFields.Add("aid", mandatory.AppId);
				_basicFields.Add("av", mandatory.AppVersion);
				_basicFields.Add("uid", mandatory.UserId);
				_basicFields.Add("did", mandatory.DeviceId);
				_basicFields.Add("ip", mandatory.ClientIP);
				_basicFields.Add("t", mandatory.ActionType);
				_basicNumberFields.Add("ts", mandatory.ClientTimeStamp);
			}

			public void AddOptionalISFields(TraceLogOptionalISField optional)
			{
				_basicFields.Add("dnm", optional.DeviceName);
				_basicFields.Add("cr", optional.Carrier);
				_basicFields.Add("os", optional.OS);
				_basicFields.Add("osv", optional.OSVerions);
				_basicFields.Add("tz", optional.TimeZone);
				_basicFields.Add("cc", optional.CountryCode);
				_basicFields.Add("lc", optional.Locale);
			}
			
			public void AddTraceInstallField(string store)
			{
				_basicFields.Add("store", store);
			}
			
			public void AddTraceDeactivateField(decimal duration)
			{
				_basicNumberFields.Add("du", duration);
			}
			
			public void AddTraceFinishFields(decimal duration)
			{
				_extendedNumberFields.Add("du", duration);
			}
			
			public void AddTracePurchaseFields(string itemCode, decimal unitCost, string currency, decimal payment)
			{
				_basicFields.Add("icd", itemCode);
				_basicNumberFields.Add("cost", unitCost);
				_basicFields.Add("curr", currency);
				_basicNumberFields.Add("pay", payment);
			}
			
			public void AddTraceGoodsFields(string usageCode, string type, string @do, decimal amount, decimal level)
			{
				_basicFields.Add("ucd", usageCode);
				_basicFields.Add("ty", type);
				_basicFields.Add("do", @do);
				_basicNumberFields.Add("am", amount);
				_basicNumberFields.Add("lv", level);
			}
			
			public void AddTraceLevelUpField(decimal level)
			{
				_basicNumberFields.Add("lv", level);
			}
			
			public void AddTraceEventFields(string eventType, string eventCode, string param1, string param2, decimal value)
			{
				_basicFields.Add("evt", eventType);
				_basicFields.Add("ev", eventCode);
				_basicFields.Add("prm1", param1);
				_basicFields.Add("prm2", param2);
				_basicNumberFields.Add("val", value);
			}
			
			public void AddTraceSpeedFields(string intervalName, decimal loadingTime)
			{
				_basicFields.Add("ivn", intervalName);
				_basicNumberFields.Add("ldt", loadingTime);
			}
			
			public void AddTraceFriendField(string friends)
			{
				_basicFields.Add("friends", friends);
			}
			
			public string BuildJSON()
			{
				// Debug mode
				if (IsDebug == true) { _basicFields.Add("debug", "on"); }
				
				bool firstItem = true;
				StringBuilder jsonBuilder = new StringBuilder();
				jsonBuilder.Append("{");
				
				// basic fields
				foreach(var basicField in _basicFields)
				{
					jsonBuilder.Append(firstItem ? string.Empty : ",");
					firstItem = false;
					jsonBuilder.AppendFormat(@"""{0}"":""{1}""", basicField.Key, basicField.Value);
				}
				
				foreach (var basicNumberField in _basicNumberFields)
				{
					jsonBuilder.Append(firstItem ? string.Empty : ",");
					firstItem = false;
					jsonBuilder.AppendFormat(@"""{0}"":{1}", basicNumberField.Key, basicNumberField.Value);
				}
				
				if (_extendedFields.Count != 0 || _extendedNumberFields.Count != 0) 
				{
					// build extended fields
					jsonBuilder.Append(",");
					jsonBuilder.AppendFormat(@"""ex"":{0}", BuildExtendedJSON());
				}
				
				jsonBuilder.Append("}");
				
				return jsonBuilder.ToString();
			}
			
			private string BuildExtendedJSON()
			{
				bool firstItem = true;
				StringBuilder jsonBuilder = new StringBuilder();
				jsonBuilder.Append("{");
				
				foreach (var field in _extendedFields)
				{
					jsonBuilder.Append(firstItem ? string.Empty : ",");
					firstItem = false;
					jsonBuilder.AppendFormat(@"""{0}"":""{1}""", field.Key, field.Value);
				}
				
				foreach (var numberField in _extendedNumberFields)
				{
					jsonBuilder.Append(firstItem ? string.Empty : ",");
					firstItem = false;
					jsonBuilder.AppendFormat(@"""{0}"":{1}", numberField.Key, numberField.Value);
				}
				
				jsonBuilder.Append("}");
				
				return jsonBuilder.ToString();
			}
		}
		
		public class TraceLogMandatoryField
		{
			public string ProtocolVersion { get; set; }
			public string SDKVersion { get; set; }
			public string CompanyId { get; set; }
			public string AppId { get; set; }
			public string AppVersion { get; set; }
			public string UserId { get; set; }
			public string DeviceId { get; set; }
			
			public string ClientIP { get; set; }
			public int ClientTimeStamp { get; set; }
			public string ActionType { get; set; }
		}
		
		public class TraceLogOptionalISField
		{
			public string DeviceName { get; set; }
			public string Carrier { get;set; }
			public string OS { get; set; }
			public string OSVerions { get; set; }
			
			public string TimeZone { get; set; }
			public string CountryCode { get; set; }
			public string Locale { get; set; }
		}
		
		public static class ActionType {
			public const string TRACE_ACTIVATION = "a";
			public const string TRACE_DEACTIVATION = "d";
			public const string TRACE_PURCHASE = "p";
			public const string TRACE_MONEY = "g";
			public const string TRACE_LEVELUP = "l";
			public const string TRACE_EVENT = "e";
			public const string TRACE_FRIENDS_COUNT = "n";
			public const string TRACE_SPEED = "v";
			public const string TRACE_INSTALL = "i";
			public const string TRACE_START = "s";
			public const string TRACE_FINISH = "f";
		}
		
		public static class ReturnCode {
			public const int S_SUCCESS = 0x0000;
			
			public const int W_ALREADY_INITIALIZED = 0x1000;
			
			public const int E_NOT_INITIALIZED = 0x8000;
			public const int E_SESSION_CLOSED = 0x8001;
			public const int E_INVALID_PARAMS = 0x8002;
			public const int E_ALREADY_EXISTS = 0x8003;
			public const int E_INTERNAL_ERROR = 0x8004;
			public const int E_INSUFFICIENT_OPERATION = 0x8005;
			public const int E_APP_ID_IS_EMPTY = 0x8006;
			public const int E_ENTERPRISE_ID_IS_EMPTY = 0x8007;
			public const int E_APP_VERSION_IS_EMPTY = 0x8008;
			public const int E_TOKEN_EMPTY = 0x8009;
			public const int E_PARENT_EMPTY = 0x800A;
			public const int E_LOGGING_USER_ID_IS_EMPTY = 0x800B;
			
			public const int E_CAMPAIGN_SHOW_EXPIRED = 0x7000;
			public const int E_CAMPAIGN_SHOW_ALREADY = 0x7001;
			public const int E_CAMPAIGN_SHOW_PENDING = 0x7002;
			public const int E_CAMPAIGN_SHOW_FAIL = 0x7003;
			public const int E_CAMPAIGN_SHOW_BLOCKED = 0x7004;
			public const int E_CAMPAIGN_NOTEXIST = 0x7005;
			public const int E_CAMPAIGN_DISABLED = 0x7006;
			public const int E_CAMPAIGN_USER_ID_IS_EMPTY = 0x7007;
			
			internal static readonly Dictionary<int, string> RESULT_STRING = new Dictionary<int, string>() {
				{S_SUCCESS, "S_SUCCESS"},
				{W_ALREADY_INITIALIZED, "W_ALREADY_INITIALIZED"},
				
				{E_NOT_INITIALIZED, "E_NOT_INITIALIZED"},
				{E_SESSION_CLOSED, "E_SESSION_CLOSED"},
				{E_INVALID_PARAMS, "E_INVALID_PARAMS"},
				{E_ALREADY_EXISTS, "E_ALREADY_EXISTS"},
				{E_INTERNAL_ERROR, "E_INTERNAL_ERROR"},
				{E_INSUFFICIENT_OPERATION, "E_INSUFFICIENT_OPERATION"},
				{E_APP_ID_IS_EMPTY, "E_APP_ID_IS_EMPTY"},
				{E_ENTERPRISE_ID_IS_EMPTY, "E_ENTERPRISE_ID_IS_EMPTY"},
				{E_APP_VERSION_IS_EMPTY, "E_APP_VERSION_IS_EMPTY"},
				{E_TOKEN_EMPTY, "E_TOKEN_EMPTY"},
				{E_PARENT_EMPTY, "E_PARENT_EMPTY"},
				{E_LOGGING_USER_ID_IS_EMPTY, "E_LOGGING_USER_ID_IS_EMPTY"},
				
				{E_CAMPAIGN_SHOW_EXPIRED, "E_CAMPAIGN_SHOW_EXPIRED"},
				{E_CAMPAIGN_SHOW_ALREADY, "E_CAMPAIGN_SHOW_ALREADY"},
				{E_CAMPAIGN_SHOW_PENDING, "E_CAMPAIGN_SHOW_PENDING"},
				{E_CAMPAIGN_SHOW_FAIL, "E_CAMPAIGN_SHOW_FAIL"},
				{E_CAMPAIGN_SHOW_BLOCKED, "E_CAMPAIGN_SHOW_BLOCKED"},
				{E_CAMPAIGN_NOTEXIST, "E_CAMPAIGN_NOTEXIST"},
				{E_CAMPAIGN_DISABLED, "E_CAMPAIGN_DISABLED"},
				{E_CAMPAIGN_USER_ID_IS_EMPTY, "E_CAMPAIGN_USER_ID_IS_EMPTY"}
			};
		}
		
		#endregion
	}

	
	// System Language : http://docs.unity3d.com/ScriptReference/SystemLanguage.html
	// Platform : http://docs.unity3d.com/ScriptReference/RuntimePlatform.html


	public class WindowsCollectableInfo : IDeviceCollectableInfo
	{
		public string OS { get { return SystemInfo.operatingSystem; } }
		public string DeviceName { get { return SystemInfo.deviceModel; } }
		public string OSVersion { get { return SystemInfo.operatingSystem; } }
		public string IP { get { return Network.player.ipAddress; } }
		public string DeviceID { get { return SystemInfo.deviceUniqueIdentifier; } }
		public string TimeZone { get { return System.TimeZone.CurrentTimeZone.StandardName; } }
		public string Locale { get { return Application.systemLanguage.ToString(); } }
		public string CountryCode { get { return string.Empty; } }
		public string Carrier { get { return Application.platform.ToString(); } }
	}
	
	public class MacCollaectableInfo: IDeviceCollectableInfo
	{
		public string OS { get { return SystemInfo.operatingSystem; } }
		public string DeviceName { get { return SystemInfo.deviceModel; } }
		public string OSVersion { get { return SystemInfo.operatingSystem; } }
		public string IP { get { return Network.player.ipAddress; } }
		public string DeviceID { get { return SystemInfo.deviceUniqueIdentifier; } }
		public string TimeZone { get { return System.TimeZone.CurrentTimeZone.StandardName; } }
		public string Locale { get { return Application.systemLanguage.ToString(); } }
		public string CountryCode { get { return string.Empty; } }
		public string Carrier { get { return Application.platform.ToString(); } }
	}
	
	public interface IDeviceCollectableInfo {
		string OS { get; }
		string DeviceName { get; }
		string OSVersion { get; }
		string IP { get; }
		string DeviceID { get; }
		string TimeZone { get; }
		string Locale { get; }
		string CountryCode { get; }
		string Carrier { get; }
	}
}
