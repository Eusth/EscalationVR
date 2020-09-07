using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x02000086 RID: 134
	public class OpenVR
	{
		// Token: 0x060001F8 RID: 504 RVA: 0x0000D39C File Offset: 0x0000B59C
		public static uint InitInternal(ref global::Valve.VR.EVRInitError peError, global::Valve.VR.EVRApplicationType eApplicationType)
		{
			return global::Valve.VR.OpenVRInterop.InitInternal(ref peError, eApplicationType);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000D3B5 File Offset: 0x0000B5B5
		public static void ShutdownInternal()
		{
			global::Valve.VR.OpenVRInterop.ShutdownInternal();
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000D3C0 File Offset: 0x0000B5C0
		public static bool IsHmdPresent()
		{
			return global::Valve.VR.OpenVRInterop.IsHmdPresent();
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000D3D8 File Offset: 0x0000B5D8
		public static bool IsRuntimeInstalled()
		{
			return global::Valve.VR.OpenVRInterop.IsRuntimeInstalled();
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000D3F0 File Offset: 0x0000B5F0
		public static string GetStringForHmdError(global::Valve.VR.EVRInitError error)
		{
			return global::System.Runtime.InteropServices.Marshal.PtrToStringAnsi(global::Valve.VR.OpenVRInterop.GetStringForHmdError(error));
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000D410 File Offset: 0x0000B610
		public static global::System.IntPtr GetGenericInterface(string pchInterfaceVersion, ref global::Valve.VR.EVRInitError peError)
		{
			return global::Valve.VR.OpenVRInterop.GetGenericInterface(pchInterfaceVersion, ref peError);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000D42C File Offset: 0x0000B62C
		public static bool IsInterfaceVersionValid(string pchInterfaceVersion)
		{
			return global::Valve.VR.OpenVRInterop.IsInterfaceVersionValid(pchInterfaceVersion);
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000D444 File Offset: 0x0000B644
		public static uint GetInitToken()
		{
			return global::Valve.VR.OpenVRInterop.GetInitToken();
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000200 RID: 512 RVA: 0x0000D45B File Offset: 0x0000B65B
		// (set) Token: 0x06000201 RID: 513 RVA: 0x0000D462 File Offset: 0x0000B662
		private static uint VRToken { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000202 RID: 514 RVA: 0x0000D46C File Offset: 0x0000B66C
		private static global::Valve.VR.OpenVR.COpenVRContext OpenVRInternal_ModuleContext
		{
			get
			{
				bool flag = global::Valve.VR.OpenVR._OpenVRInternal_ModuleContext == null;
				if (flag)
				{
					global::Valve.VR.OpenVR._OpenVRInternal_ModuleContext = new global::Valve.VR.OpenVR.COpenVRContext();
				}
				return global::Valve.VR.OpenVR._OpenVRInternal_ModuleContext;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000203 RID: 515 RVA: 0x0000D49C File Offset: 0x0000B69C
		public static global::Valve.VR.CVRSystem System
		{
			get
			{
				return global::Valve.VR.OpenVR.OpenVRInternal_ModuleContext.VRSystem();
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000204 RID: 516 RVA: 0x0000D4B8 File Offset: 0x0000B6B8
		public static global::Valve.VR.CVRChaperone Chaperone
		{
			get
			{
				return global::Valve.VR.OpenVR.OpenVRInternal_ModuleContext.VRChaperone();
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000205 RID: 517 RVA: 0x0000D4D4 File Offset: 0x0000B6D4
		public static global::Valve.VR.CVRChaperoneSetup ChaperoneSetup
		{
			get
			{
				return global::Valve.VR.OpenVR.OpenVRInternal_ModuleContext.VRChaperoneSetup();
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000206 RID: 518 RVA: 0x0000D4F0 File Offset: 0x0000B6F0
		public static global::Valve.VR.CVRCompositor Compositor
		{
			get
			{
				return global::Valve.VR.OpenVR.OpenVRInternal_ModuleContext.VRCompositor();
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000207 RID: 519 RVA: 0x0000D50C File Offset: 0x0000B70C
		public static global::Valve.VR.CVROverlay Overlay
		{
			get
			{
				return global::Valve.VR.OpenVR.OpenVRInternal_ModuleContext.VROverlay();
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000208 RID: 520 RVA: 0x0000D528 File Offset: 0x0000B728
		public static global::Valve.VR.CVRRenderModels RenderModels
		{
			get
			{
				return global::Valve.VR.OpenVR.OpenVRInternal_ModuleContext.VRRenderModels();
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000209 RID: 521 RVA: 0x0000D544 File Offset: 0x0000B744
		public static global::Valve.VR.CVRApplications Applications
		{
			get
			{
				return global::Valve.VR.OpenVR.OpenVRInternal_ModuleContext.VRApplications();
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0000D560 File Offset: 0x0000B760
		public static global::Valve.VR.CVRSettings Settings
		{
			get
			{
				return global::Valve.VR.OpenVR.OpenVRInternal_ModuleContext.VRSettings();
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600020B RID: 523 RVA: 0x0000D57C File Offset: 0x0000B77C
		public static global::Valve.VR.CVRExtendedDisplay ExtendedDisplay
		{
			get
			{
				return global::Valve.VR.OpenVR.OpenVRInternal_ModuleContext.VRExtendedDisplay();
			}
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000D598 File Offset: 0x0000B798
		public static global::Valve.VR.CVRSystem Init(ref global::Valve.VR.EVRInitError peError, global::Valve.VR.EVRApplicationType eApplicationType = global::Valve.VR.EVRApplicationType.VRApplication_Scene)
		{
			global::Valve.VR.OpenVR.VRToken = global::Valve.VR.OpenVR.InitInternal(ref peError, eApplicationType);
			global::Valve.VR.OpenVR.OpenVRInternal_ModuleContext.Clear();
			bool flag = peError > global::Valve.VR.EVRInitError.None;
			global::Valve.VR.CVRSystem result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = global::Valve.VR.OpenVR.IsInterfaceVersionValid("IVRSystem_012");
				bool flag3 = !flag2;
				if (flag3)
				{
					global::Valve.VR.OpenVR.ShutdownInternal();
					peError = global::Valve.VR.EVRInitError.Init_InterfaceNotFound;
					result = null;
				}
				else
				{
					result = global::Valve.VR.OpenVR.System;
				}
			}
			return result;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000D5F6 File Offset: 0x0000B7F6
		public static void Shutdown()
		{
			global::Valve.VR.OpenVR.ShutdownInternal();
		}

		// Token: 0x0400047D RID: 1149
		public const uint k_unTrackingStringSize = 32U;

		// Token: 0x0400047E RID: 1150
		public const uint k_unMaxDriverDebugResponseSize = 32768U;

		// Token: 0x0400047F RID: 1151
		public const uint k_unTrackedDeviceIndex_Hmd = 0U;

		// Token: 0x04000480 RID: 1152
		public const uint k_unMaxTrackedDeviceCount = 16U;

		// Token: 0x04000481 RID: 1153
		public const uint k_unTrackedDeviceIndexInvalid = 4294967295U;

		// Token: 0x04000482 RID: 1154
		public const uint k_unMaxPropertyStringSize = 32768U;

		// Token: 0x04000483 RID: 1155
		public const uint k_unControllerStateAxisCount = 5U;

		// Token: 0x04000484 RID: 1156
		public const ulong k_ulOverlayHandleInvalid = 0UL;

		// Token: 0x04000485 RID: 1157
		public const string IVRSystem_Version = "IVRSystem_012";

		// Token: 0x04000486 RID: 1158
		public const string IVRExtendedDisplay_Version = "IVRExtendedDisplay_001";

		// Token: 0x04000487 RID: 1159
		public const uint k_unMaxApplicationKeyLength = 128U;

		// Token: 0x04000488 RID: 1160
		public const string IVRApplications_Version = "IVRApplications_005";

		// Token: 0x04000489 RID: 1161
		public const string IVRChaperone_Version = "IVRChaperone_003";

		// Token: 0x0400048A RID: 1162
		public const string IVRChaperoneSetup_Version = "IVRChaperoneSetup_005";

		// Token: 0x0400048B RID: 1163
		public const string IVRCompositor_Version = "IVRCompositor_014";

		// Token: 0x0400048C RID: 1164
		public const uint k_unVROverlayMaxKeyLength = 128U;

		// Token: 0x0400048D RID: 1165
		public const uint k_unVROverlayMaxNameLength = 128U;

		// Token: 0x0400048E RID: 1166
		public const uint k_unMaxOverlayCount = 32U;

		// Token: 0x0400048F RID: 1167
		public const string IVROverlay_Version = "IVROverlay_011";

		// Token: 0x04000490 RID: 1168
		public const string k_pch_Controller_Component_GDC2015 = "gdc2015";

		// Token: 0x04000491 RID: 1169
		public const string k_pch_Controller_Component_Base = "base";

		// Token: 0x04000492 RID: 1170
		public const string k_pch_Controller_Component_Tip = "tip";

		// Token: 0x04000493 RID: 1171
		public const string k_pch_Controller_Component_HandGrip = "handgrip";

		// Token: 0x04000494 RID: 1172
		public const string k_pch_Controller_Component_Status = "status";

		// Token: 0x04000495 RID: 1173
		public const string IVRRenderModels_Version = "IVRRenderModels_005";

		// Token: 0x04000496 RID: 1174
		public const uint k_unNotificationTextMaxSize = 256U;

		// Token: 0x04000497 RID: 1175
		public const string IVRNotifications_Version = "IVRNotifications_002";

		// Token: 0x04000498 RID: 1176
		public const uint k_unMaxSettingsKeyLength = 128U;

		// Token: 0x04000499 RID: 1177
		public const string IVRSettings_Version = "IVRSettings_001";

		// Token: 0x0400049A RID: 1178
		public const string k_pch_SteamVR_Section = "steamvr";

		// Token: 0x0400049B RID: 1179
		public const string k_pch_SteamVR_RequireHmd_String = "requireHmd";

		// Token: 0x0400049C RID: 1180
		public const string k_pch_SteamVR_ForcedDriverKey_String = "forcedDriver";

		// Token: 0x0400049D RID: 1181
		public const string k_pch_SteamVR_ForcedHmdKey_String = "forcedHmd";

		// Token: 0x0400049E RID: 1182
		public const string k_pch_SteamVR_DisplayDebug_Bool = "displayDebug";

		// Token: 0x0400049F RID: 1183
		public const string k_pch_SteamVR_DebugProcessPipe_String = "debugProcessPipe";

		// Token: 0x040004A0 RID: 1184
		public const string k_pch_SteamVR_EnableDistortion_Bool = "enableDistortion";

		// Token: 0x040004A1 RID: 1185
		public const string k_pch_SteamVR_DisplayDebugX_Int32 = "displayDebugX";

		// Token: 0x040004A2 RID: 1186
		public const string k_pch_SteamVR_DisplayDebugY_Int32 = "displayDebugY";

		// Token: 0x040004A3 RID: 1187
		public const string k_pch_SteamVR_SendSystemButtonToAllApps_Bool = "sendSystemButtonToAllApps";

		// Token: 0x040004A4 RID: 1188
		public const string k_pch_SteamVR_LogLevel_Int32 = "loglevel";

		// Token: 0x040004A5 RID: 1189
		public const string k_pch_SteamVR_IPD_Float = "ipd";

		// Token: 0x040004A6 RID: 1190
		public const string k_pch_SteamVR_Background_String = "background";

		// Token: 0x040004A7 RID: 1191
		public const string k_pch_SteamVR_GridColor_String = "gridColor";

		// Token: 0x040004A8 RID: 1192
		public const string k_pch_SteamVR_PlayAreaColor_String = "playAreaColor";

		// Token: 0x040004A9 RID: 1193
		public const string k_pch_SteamVR_ActivateMultipleDrivers_Bool = "activateMultipleDrivers";

		// Token: 0x040004AA RID: 1194
		public const string k_pch_SteamVR_PowerOffOnExit_Bool = "powerOffOnExit";

		// Token: 0x040004AB RID: 1195
		public const string k_pch_SteamVR_StandbyAppRunningTimeout_Float = "standbyAppRunningTimeout";

		// Token: 0x040004AC RID: 1196
		public const string k_pch_SteamVR_StandbyNoAppTimeout_Float = "standbyNoAppTimeout";

		// Token: 0x040004AD RID: 1197
		public const string k_pch_SteamVR_DirectMode_Bool = "directMode";

		// Token: 0x040004AE RID: 1198
		public const string k_pch_SteamVR_DirectModeEdidVid_Int32 = "directModeEdidVid";

		// Token: 0x040004AF RID: 1199
		public const string k_pch_SteamVR_DirectModeEdidPid_Int32 = "directModeEdidPid";

		// Token: 0x040004B0 RID: 1200
		public const string k_pch_SteamVR_UsingSpeakers_Bool = "usingSpeakers";

		// Token: 0x040004B1 RID: 1201
		public const string k_pch_SteamVR_SpeakersForwardYawOffsetDegrees_Float = "speakersForwardYawOffsetDegrees";

		// Token: 0x040004B2 RID: 1202
		public const string k_pch_SteamVR_BaseStationPowerManagement_Bool = "basestationPowerManagement";

		// Token: 0x040004B3 RID: 1203
		public const string k_pch_SteamVR_NeverKillProcesses_Bool = "neverKillProcesses";

		// Token: 0x040004B4 RID: 1204
		public const string k_pch_SteamVR_RenderTargetMultiplier_Float = "renderTargetMultiplier";

		// Token: 0x040004B5 RID: 1205
		public const string k_pch_SteamVR_AllowReprojection_Bool = "allowReprojection";

		// Token: 0x040004B6 RID: 1206
		public const string k_pch_Lighthouse_Section = "driver_lighthouse";

		// Token: 0x040004B7 RID: 1207
		public const string k_pch_Lighthouse_DisableIMU_Bool = "disableimu";

		// Token: 0x040004B8 RID: 1208
		public const string k_pch_Lighthouse_UseDisambiguation_String = "usedisambiguation";

		// Token: 0x040004B9 RID: 1209
		public const string k_pch_Lighthouse_DisambiguationDebug_Int32 = "disambiguationdebug";

		// Token: 0x040004BA RID: 1210
		public const string k_pch_Lighthouse_PrimaryBasestation_Int32 = "primarybasestation";

		// Token: 0x040004BB RID: 1211
		public const string k_pch_Lighthouse_LighthouseName_String = "lighthousename";

		// Token: 0x040004BC RID: 1212
		public const string k_pch_Lighthouse_MaxIncidenceAngleDegrees_Float = "maxincidenceangledegrees";

		// Token: 0x040004BD RID: 1213
		public const string k_pch_Lighthouse_UseLighthouseDirect_Bool = "uselighthousedirect";

		// Token: 0x040004BE RID: 1214
		public const string k_pch_Lighthouse_DBHistory_Bool = "dbhistory";

		// Token: 0x040004BF RID: 1215
		public const string k_pch_Lighthouse_OriginOffsetX_Float = "originoffsetx";

		// Token: 0x040004C0 RID: 1216
		public const string k_pch_Lighthouse_OriginOffsetY_Float = "originoffsety";

		// Token: 0x040004C1 RID: 1217
		public const string k_pch_Lighthouse_OriginOffsetZ_Float = "originoffsetz";

		// Token: 0x040004C2 RID: 1218
		public const string k_pch_Lighthouse_HeadingOffset_Float = "headingoffset";

		// Token: 0x040004C3 RID: 1219
		public const string k_pch_Null_Section = "driver_null";

		// Token: 0x040004C4 RID: 1220
		public const string k_pch_Null_EnableNullDriver_Bool = "enable";

		// Token: 0x040004C5 RID: 1221
		public const string k_pch_Null_SerialNumber_String = "serialNumber";

		// Token: 0x040004C6 RID: 1222
		public const string k_pch_Null_ModelNumber_String = "modelNumber";

		// Token: 0x040004C7 RID: 1223
		public const string k_pch_Null_WindowX_Int32 = "windowX";

		// Token: 0x040004C8 RID: 1224
		public const string k_pch_Null_WindowY_Int32 = "windowY";

		// Token: 0x040004C9 RID: 1225
		public const string k_pch_Null_WindowWidth_Int32 = "windowWidth";

		// Token: 0x040004CA RID: 1226
		public const string k_pch_Null_WindowHeight_Int32 = "windowHeight";

		// Token: 0x040004CB RID: 1227
		public const string k_pch_Null_RenderWidth_Int32 = "renderWidth";

		// Token: 0x040004CC RID: 1228
		public const string k_pch_Null_RenderHeight_Int32 = "renderHeight";

		// Token: 0x040004CD RID: 1229
		public const string k_pch_Null_SecondsFromVsyncToPhotons_Float = "secondsFromVsyncToPhotons";

		// Token: 0x040004CE RID: 1230
		public const string k_pch_Null_DisplayFrequency_Float = "displayFrequency";

		// Token: 0x040004CF RID: 1231
		public const string k_pch_UserInterface_Section = "userinterface";

		// Token: 0x040004D0 RID: 1232
		public const string k_pch_UserInterface_StatusAlwaysOnTop_Bool = "StatusAlwaysOnTop";

		// Token: 0x040004D1 RID: 1233
		public const string k_pch_Notifications_Section = "notifications";

		// Token: 0x040004D2 RID: 1234
		public const string k_pch_Notifications_DoNotDisturb_Bool = "DoNotDisturb";

		// Token: 0x040004D3 RID: 1235
		public const string k_pch_Keyboard_Section = "keyboard";

		// Token: 0x040004D4 RID: 1236
		public const string k_pch_Keyboard_TutorialCompletions = "TutorialCompletions";

		// Token: 0x040004D5 RID: 1237
		public const string k_pch_Keyboard_ScaleX = "ScaleX";

		// Token: 0x040004D6 RID: 1238
		public const string k_pch_Keyboard_ScaleY = "ScaleY";

		// Token: 0x040004D7 RID: 1239
		public const string k_pch_Keyboard_OffsetLeftX = "OffsetLeftX";

		// Token: 0x040004D8 RID: 1240
		public const string k_pch_Keyboard_OffsetRightX = "OffsetRightX";

		// Token: 0x040004D9 RID: 1241
		public const string k_pch_Keyboard_OffsetY = "OffsetY";

		// Token: 0x040004DA RID: 1242
		public const string k_pch_Keyboard_Smoothing = "Smoothing";

		// Token: 0x040004DB RID: 1243
		public const string k_pch_Perf_Section = "perfcheck";

		// Token: 0x040004DC RID: 1244
		public const string k_pch_Perf_HeuristicActive_Bool = "heuristicActive";

		// Token: 0x040004DD RID: 1245
		public const string k_pch_Perf_NotifyInHMD_Bool = "warnInHMD";

		// Token: 0x040004DE RID: 1246
		public const string k_pch_Perf_NotifyOnlyOnce_Bool = "warnOnlyOnce";

		// Token: 0x040004DF RID: 1247
		public const string k_pch_Perf_AllowTimingStore_Bool = "allowTimingStore";

		// Token: 0x040004E0 RID: 1248
		public const string k_pch_Perf_SaveTimingsOnExit_Bool = "saveTimingsOnExit";

		// Token: 0x040004E1 RID: 1249
		public const string k_pch_Perf_TestData_Float = "perfTestData";

		// Token: 0x040004E2 RID: 1250
		public const string k_pch_CollisionBounds_Section = "collisionBounds";

		// Token: 0x040004E3 RID: 1251
		public const string k_pch_CollisionBounds_Style_Int32 = "CollisionBoundsStyle";

		// Token: 0x040004E4 RID: 1252
		public const string k_pch_CollisionBounds_GroundPerimeterOn_Bool = "CollisionBoundsGroundPerimeterOn";

		// Token: 0x040004E5 RID: 1253
		public const string k_pch_CollisionBounds_CenterMarkerOn_Bool = "CollisionBoundsCenterMarkerOn";

		// Token: 0x040004E6 RID: 1254
		public const string k_pch_CollisionBounds_PlaySpaceOn_Bool = "CollisionBoundsPlaySpaceOn";

		// Token: 0x040004E7 RID: 1255
		public const string k_pch_CollisionBounds_FadeDistance_Float = "CollisionBoundsFadeDistance";

		// Token: 0x040004E8 RID: 1256
		public const string k_pch_CollisionBounds_ColorGammaR_Int32 = "CollisionBoundsColorGammaR";

		// Token: 0x040004E9 RID: 1257
		public const string k_pch_CollisionBounds_ColorGammaG_Int32 = "CollisionBoundsColorGammaG";

		// Token: 0x040004EA RID: 1258
		public const string k_pch_CollisionBounds_ColorGammaB_Int32 = "CollisionBoundsColorGammaB";

		// Token: 0x040004EB RID: 1259
		public const string k_pch_CollisionBounds_ColorGammaA_Int32 = "CollisionBoundsColorGammaA";

		// Token: 0x040004EC RID: 1260
		public const string k_pch_Camera_Section = "camera";

		// Token: 0x040004ED RID: 1261
		public const string k_pch_Camera_EnableCamera_Bool = "enableCamera";

		// Token: 0x040004EE RID: 1262
		public const string k_pch_Camera_EnableCameraInDashboard_Bool = "enableCameraInDashboard";

		// Token: 0x040004EF RID: 1263
		public const string k_pch_Camera_EnableCameraForCollisionBounds_Bool = "enableCameraForCollisionBounds";

		// Token: 0x040004F0 RID: 1264
		public const string k_pch_Camera_EnableCameraForRoomView_Bool = "enableCameraForRoomView";

		// Token: 0x040004F1 RID: 1265
		public const string k_pch_Camera_BoundsColorGammaR_Int32 = "cameraBoundsColorGammaR";

		// Token: 0x040004F2 RID: 1266
		public const string k_pch_Camera_BoundsColorGammaG_Int32 = "cameraBoundsColorGammaG";

		// Token: 0x040004F3 RID: 1267
		public const string k_pch_Camera_BoundsColorGammaB_Int32 = "cameraBoundsColorGammaB";

		// Token: 0x040004F4 RID: 1268
		public const string k_pch_Camera_BoundsColorGammaA_Int32 = "cameraBoundsColorGammaA";

		// Token: 0x040004F5 RID: 1269
		public const string k_pch_audio_Section = "audio";

		// Token: 0x040004F6 RID: 1270
		public const string k_pch_audio_OnPlaybackDevice_String = "onPlaybackDevice";

		// Token: 0x040004F7 RID: 1271
		public const string k_pch_audio_OnRecordDevice_String = "onRecordDevice";

		// Token: 0x040004F8 RID: 1272
		public const string k_pch_audio_OnPlaybackMirrorDevice_String = "onPlaybackMirrorDevice";

		// Token: 0x040004F9 RID: 1273
		public const string k_pch_audio_OffPlaybackDevice_String = "offPlaybackDevice";

		// Token: 0x040004FA RID: 1274
		public const string k_pch_audio_OffRecordDevice_String = "offRecordDevice";

		// Token: 0x040004FB RID: 1275
		public const string k_pch_audio_VIVEHDMIGain = "viveHDMIGain";

		// Token: 0x040004FD RID: 1277
		private const string FnTable_Prefix = "FnTable:";

		// Token: 0x040004FE RID: 1278
		private static global::Valve.VR.OpenVR.COpenVRContext _OpenVRInternal_ModuleContext = null;

		// Token: 0x020001E9 RID: 489
		private class COpenVRContext
		{
			// Token: 0x06000A26 RID: 2598 RVA: 0x000206F2 File Offset: 0x0001E8F2
			public COpenVRContext()
			{
				this.Clear();
			}

			// Token: 0x06000A27 RID: 2599 RVA: 0x00020704 File Offset: 0x0001E904
			public void Clear()
			{
				this.m_pVRSystem = null;
				this.m_pVRChaperone = null;
				this.m_pVRChaperoneSetup = null;
				this.m_pVRCompositor = null;
				this.m_pVROverlay = null;
				this.m_pVRRenderModels = null;
				this.m_pVRExtendedDisplay = null;
				this.m_pVRSettings = null;
				this.m_pVRApplications = null;
			}

			// Token: 0x06000A28 RID: 2600 RVA: 0x00020754 File Offset: 0x0001E954
			private void CheckClear()
			{
				bool flag = global::Valve.VR.OpenVR.VRToken != global::Valve.VR.OpenVR.GetInitToken();
				if (flag)
				{
					this.Clear();
					global::Valve.VR.OpenVR.VRToken = global::Valve.VR.OpenVR.GetInitToken();
				}
			}

			// Token: 0x06000A29 RID: 2601 RVA: 0x0002078C File Offset: 0x0001E98C
			public global::Valve.VR.CVRSystem VRSystem()
			{
				this.CheckClear();
				bool flag = this.m_pVRSystem == null;
				if (flag)
				{
					global::Valve.VR.EVRInitError evrinitError = global::Valve.VR.EVRInitError.None;
					global::System.IntPtr genericInterface = global::Valve.VR.OpenVRInterop.GetGenericInterface("FnTable:IVRSystem_012", ref evrinitError);
					bool flag2 = genericInterface != global::System.IntPtr.Zero && evrinitError == global::Valve.VR.EVRInitError.None;
					if (flag2)
					{
						this.m_pVRSystem = new global::Valve.VR.CVRSystem(genericInterface);
					}
				}
				return this.m_pVRSystem;
			}

			// Token: 0x06000A2A RID: 2602 RVA: 0x000207F0 File Offset: 0x0001E9F0
			public global::Valve.VR.CVRChaperone VRChaperone()
			{
				this.CheckClear();
				bool flag = this.m_pVRChaperone == null;
				if (flag)
				{
					global::Valve.VR.EVRInitError evrinitError = global::Valve.VR.EVRInitError.None;
					global::System.IntPtr genericInterface = global::Valve.VR.OpenVRInterop.GetGenericInterface("FnTable:IVRChaperone_003", ref evrinitError);
					bool flag2 = genericInterface != global::System.IntPtr.Zero && evrinitError == global::Valve.VR.EVRInitError.None;
					if (flag2)
					{
						this.m_pVRChaperone = new global::Valve.VR.CVRChaperone(genericInterface);
					}
				}
				return this.m_pVRChaperone;
			}

			// Token: 0x06000A2B RID: 2603 RVA: 0x00020854 File Offset: 0x0001EA54
			public global::Valve.VR.CVRChaperoneSetup VRChaperoneSetup()
			{
				this.CheckClear();
				bool flag = this.m_pVRChaperoneSetup == null;
				if (flag)
				{
					global::Valve.VR.EVRInitError evrinitError = global::Valve.VR.EVRInitError.None;
					global::System.IntPtr genericInterface = global::Valve.VR.OpenVRInterop.GetGenericInterface("FnTable:IVRChaperoneSetup_005", ref evrinitError);
					bool flag2 = genericInterface != global::System.IntPtr.Zero && evrinitError == global::Valve.VR.EVRInitError.None;
					if (flag2)
					{
						this.m_pVRChaperoneSetup = new global::Valve.VR.CVRChaperoneSetup(genericInterface);
					}
				}
				return this.m_pVRChaperoneSetup;
			}

			// Token: 0x06000A2C RID: 2604 RVA: 0x000208B8 File Offset: 0x0001EAB8
			public global::Valve.VR.CVRCompositor VRCompositor()
			{
				this.CheckClear();
				bool flag = this.m_pVRCompositor == null;
				if (flag)
				{
					global::Valve.VR.EVRInitError evrinitError = global::Valve.VR.EVRInitError.None;
					global::System.IntPtr genericInterface = global::Valve.VR.OpenVRInterop.GetGenericInterface("FnTable:IVRCompositor_014", ref evrinitError);
					bool flag2 = genericInterface != global::System.IntPtr.Zero && evrinitError == global::Valve.VR.EVRInitError.None;
					if (flag2)
					{
						this.m_pVRCompositor = new global::Valve.VR.CVRCompositor(genericInterface);
					}
				}
				return this.m_pVRCompositor;
			}

			// Token: 0x06000A2D RID: 2605 RVA: 0x0002091C File Offset: 0x0001EB1C
			public global::Valve.VR.CVROverlay VROverlay()
			{
				this.CheckClear();
				bool flag = this.m_pVROverlay == null;
				if (flag)
				{
					global::Valve.VR.EVRInitError evrinitError = global::Valve.VR.EVRInitError.None;
					global::System.IntPtr genericInterface = global::Valve.VR.OpenVRInterop.GetGenericInterface("FnTable:IVROverlay_011", ref evrinitError);
					bool flag2 = genericInterface != global::System.IntPtr.Zero && evrinitError == global::Valve.VR.EVRInitError.None;
					if (flag2)
					{
						this.m_pVROverlay = new global::Valve.VR.CVROverlay(genericInterface);
					}
				}
				return this.m_pVROverlay;
			}

			// Token: 0x06000A2E RID: 2606 RVA: 0x00020980 File Offset: 0x0001EB80
			public global::Valve.VR.CVRRenderModels VRRenderModels()
			{
				this.CheckClear();
				bool flag = this.m_pVRRenderModels == null;
				if (flag)
				{
					global::Valve.VR.EVRInitError evrinitError = global::Valve.VR.EVRInitError.None;
					global::System.IntPtr genericInterface = global::Valve.VR.OpenVRInterop.GetGenericInterface("FnTable:IVRRenderModels_005", ref evrinitError);
					bool flag2 = genericInterface != global::System.IntPtr.Zero && evrinitError == global::Valve.VR.EVRInitError.None;
					if (flag2)
					{
						this.m_pVRRenderModels = new global::Valve.VR.CVRRenderModels(genericInterface);
					}
				}
				return this.m_pVRRenderModels;
			}

			// Token: 0x06000A2F RID: 2607 RVA: 0x000209E4 File Offset: 0x0001EBE4
			public global::Valve.VR.CVRExtendedDisplay VRExtendedDisplay()
			{
				this.CheckClear();
				bool flag = this.m_pVRExtendedDisplay == null;
				if (flag)
				{
					global::Valve.VR.EVRInitError evrinitError = global::Valve.VR.EVRInitError.None;
					global::System.IntPtr genericInterface = global::Valve.VR.OpenVRInterop.GetGenericInterface("FnTable:IVRExtendedDisplay_001", ref evrinitError);
					bool flag2 = genericInterface != global::System.IntPtr.Zero && evrinitError == global::Valve.VR.EVRInitError.None;
					if (flag2)
					{
						this.m_pVRExtendedDisplay = new global::Valve.VR.CVRExtendedDisplay(genericInterface);
					}
				}
				return this.m_pVRExtendedDisplay;
			}

			// Token: 0x06000A30 RID: 2608 RVA: 0x00020A48 File Offset: 0x0001EC48
			public global::Valve.VR.CVRSettings VRSettings()
			{
				this.CheckClear();
				bool flag = this.m_pVRSettings == null;
				if (flag)
				{
					global::Valve.VR.EVRInitError evrinitError = global::Valve.VR.EVRInitError.None;
					global::System.IntPtr genericInterface = global::Valve.VR.OpenVRInterop.GetGenericInterface("FnTable:IVRSettings_001", ref evrinitError);
					bool flag2 = genericInterface != global::System.IntPtr.Zero && evrinitError == global::Valve.VR.EVRInitError.None;
					if (flag2)
					{
						this.m_pVRSettings = new global::Valve.VR.CVRSettings(genericInterface);
					}
				}
				return this.m_pVRSettings;
			}

			// Token: 0x06000A31 RID: 2609 RVA: 0x00020AAC File Offset: 0x0001ECAC
			public global::Valve.VR.CVRApplications VRApplications()
			{
				this.CheckClear();
				bool flag = this.m_pVRApplications == null;
				if (flag)
				{
					global::Valve.VR.EVRInitError evrinitError = global::Valve.VR.EVRInitError.None;
					global::System.IntPtr genericInterface = global::Valve.VR.OpenVRInterop.GetGenericInterface("FnTable:IVRApplications_005", ref evrinitError);
					bool flag2 = genericInterface != global::System.IntPtr.Zero && evrinitError == global::Valve.VR.EVRInitError.None;
					if (flag2)
					{
						this.m_pVRApplications = new global::Valve.VR.CVRApplications(genericInterface);
					}
				}
				return this.m_pVRApplications;
			}

			// Token: 0x04000739 RID: 1849
			private global::Valve.VR.CVRSystem m_pVRSystem;

			// Token: 0x0400073A RID: 1850
			private global::Valve.VR.CVRChaperone m_pVRChaperone;

			// Token: 0x0400073B RID: 1851
			private global::Valve.VR.CVRChaperoneSetup m_pVRChaperoneSetup;

			// Token: 0x0400073C RID: 1852
			private global::Valve.VR.CVRCompositor m_pVRCompositor;

			// Token: 0x0400073D RID: 1853
			private global::Valve.VR.CVROverlay m_pVROverlay;

			// Token: 0x0400073E RID: 1854
			private global::Valve.VR.CVRRenderModels m_pVRRenderModels;

			// Token: 0x0400073F RID: 1855
			private global::Valve.VR.CVRExtendedDisplay m_pVRExtendedDisplay;

			// Token: 0x04000740 RID: 1856
			private global::Valve.VR.CVRSettings m_pVRSettings;

			// Token: 0x04000741 RID: 1857
			private global::Valve.VR.CVRApplications m_pVRApplications;
		}
	}
}
