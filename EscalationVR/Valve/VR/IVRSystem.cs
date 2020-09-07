using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Valve.VR
{
	// Token: 0x0200001B RID: 27
	public struct IVRSystem
	{
		// Token: 0x040000CD RID: 205
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetRecommendedRenderTargetSize GetRecommendedRenderTargetSize;

		// Token: 0x040000CE RID: 206
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetProjectionMatrix GetProjectionMatrix;

		// Token: 0x040000CF RID: 207
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetProjectionRaw GetProjectionRaw;

		// Token: 0x040000D0 RID: 208
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._ComputeDistortion ComputeDistortion;

		// Token: 0x040000D1 RID: 209
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetEyeToHeadTransform GetEyeToHeadTransform;

		// Token: 0x040000D2 RID: 210
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetTimeSinceLastVsync GetTimeSinceLastVsync;

		// Token: 0x040000D3 RID: 211
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetD3D9AdapterIndex GetD3D9AdapterIndex;

		// Token: 0x040000D4 RID: 212
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetDXGIOutputInfo GetDXGIOutputInfo;

		// Token: 0x040000D5 RID: 213
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._IsDisplayOnDesktop IsDisplayOnDesktop;

		// Token: 0x040000D6 RID: 214
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._SetDisplayVisibility SetDisplayVisibility;

		// Token: 0x040000D7 RID: 215
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetDeviceToAbsoluteTrackingPose GetDeviceToAbsoluteTrackingPose;

		// Token: 0x040000D8 RID: 216
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._ResetSeatedZeroPose ResetSeatedZeroPose;

		// Token: 0x040000D9 RID: 217
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetSeatedZeroPoseToStandingAbsoluteTrackingPose GetSeatedZeroPoseToStandingAbsoluteTrackingPose;

		// Token: 0x040000DA RID: 218
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetRawZeroPoseToStandingAbsoluteTrackingPose GetRawZeroPoseToStandingAbsoluteTrackingPose;

		// Token: 0x040000DB RID: 219
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetSortedTrackedDeviceIndicesOfClass GetSortedTrackedDeviceIndicesOfClass;

		// Token: 0x040000DC RID: 220
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetTrackedDeviceActivityLevel GetTrackedDeviceActivityLevel;

		// Token: 0x040000DD RID: 221
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._ApplyTransform ApplyTransform;

		// Token: 0x040000DE RID: 222
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetTrackedDeviceIndexForControllerRole GetTrackedDeviceIndexForControllerRole;

		// Token: 0x040000DF RID: 223
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetControllerRoleForTrackedDeviceIndex GetControllerRoleForTrackedDeviceIndex;

		// Token: 0x040000E0 RID: 224
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetTrackedDeviceClass GetTrackedDeviceClass;

		// Token: 0x040000E1 RID: 225
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._IsTrackedDeviceConnected IsTrackedDeviceConnected;

		// Token: 0x040000E2 RID: 226
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetBoolTrackedDeviceProperty GetBoolTrackedDeviceProperty;

		// Token: 0x040000E3 RID: 227
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetFloatTrackedDeviceProperty GetFloatTrackedDeviceProperty;

		// Token: 0x040000E4 RID: 228
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetInt32TrackedDeviceProperty GetInt32TrackedDeviceProperty;

		// Token: 0x040000E5 RID: 229
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetUint64TrackedDeviceProperty GetUint64TrackedDeviceProperty;

		// Token: 0x040000E6 RID: 230
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetMatrix34TrackedDeviceProperty GetMatrix34TrackedDeviceProperty;

		// Token: 0x040000E7 RID: 231
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetStringTrackedDeviceProperty GetStringTrackedDeviceProperty;

		// Token: 0x040000E8 RID: 232
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetPropErrorNameFromEnum GetPropErrorNameFromEnum;

		// Token: 0x040000E9 RID: 233
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._PollNextEvent PollNextEvent;

		// Token: 0x040000EA RID: 234
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._PollNextEventWithPose PollNextEventWithPose;

		// Token: 0x040000EB RID: 235
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetEventTypeNameFromEnum GetEventTypeNameFromEnum;

		// Token: 0x040000EC RID: 236
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetHiddenAreaMesh GetHiddenAreaMesh;

		// Token: 0x040000ED RID: 237
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetControllerState GetControllerState;

		// Token: 0x040000EE RID: 238
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetControllerStateWithPose GetControllerStateWithPose;

		// Token: 0x040000EF RID: 239
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._TriggerHapticPulse TriggerHapticPulse;

		// Token: 0x040000F0 RID: 240
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetButtonIdNameFromEnum GetButtonIdNameFromEnum;

		// Token: 0x040000F1 RID: 241
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._GetControllerAxisTypeNameFromEnum GetControllerAxisTypeNameFromEnum;

		// Token: 0x040000F2 RID: 242
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._CaptureInputFocus CaptureInputFocus;

		// Token: 0x040000F3 RID: 243
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._ReleaseInputFocus ReleaseInputFocus;

		// Token: 0x040000F4 RID: 244
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._IsInputFocusCapturedByAnotherProcess IsInputFocusCapturedByAnotherProcess;

		// Token: 0x040000F5 RID: 245
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._DriverDebugRequest DriverDebugRequest;

		// Token: 0x040000F6 RID: 246
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._PerformFirmwareUpdate PerformFirmwareUpdate;

		// Token: 0x040000F7 RID: 247
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._AcknowledgeQuit_Exiting AcknowledgeQuit_Exiting;

		// Token: 0x040000F8 RID: 248
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRSystem._AcknowledgeQuit_UserPrompt AcknowledgeQuit_UserPrompt;

		// Token: 0x02000109 RID: 265
		// (Invoke) Token: 0x060006A7 RID: 1703
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _GetRecommendedRenderTargetSize(ref uint pnWidth, ref uint pnHeight);

		// Token: 0x0200010A RID: 266
		// (Invoke) Token: 0x060006AB RID: 1707
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.HmdMatrix44_t _GetProjectionMatrix(global::Valve.VR.EVREye eEye, float fNearZ, float fFarZ, global::Valve.VR.EGraphicsAPIConvention eProjType);

		// Token: 0x0200010B RID: 267
		// (Invoke) Token: 0x060006AF RID: 1711
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _GetProjectionRaw(global::Valve.VR.EVREye eEye, ref float pfLeft, ref float pfRight, ref float pfTop, ref float pfBottom);

		// Token: 0x0200010C RID: 268
		// (Invoke) Token: 0x060006B3 RID: 1715
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.DistortionCoordinates_t _ComputeDistortion(global::Valve.VR.EVREye eEye, float fU, float fV);

		// Token: 0x0200010D RID: 269
		// (Invoke) Token: 0x060006B7 RID: 1719
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.HmdMatrix34_t _GetEyeToHeadTransform(global::Valve.VR.EVREye eEye);

		// Token: 0x0200010E RID: 270
		// (Invoke) Token: 0x060006BB RID: 1723
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetTimeSinceLastVsync(ref float pfSecondsSinceLastVsync, ref ulong pulFrameCounter);

		// Token: 0x0200010F RID: 271
		// (Invoke) Token: 0x060006BF RID: 1727
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate int _GetD3D9AdapterIndex();

		// Token: 0x02000110 RID: 272
		// (Invoke) Token: 0x060006C3 RID: 1731
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _GetDXGIOutputInfo(ref int pnAdapterIndex);

		// Token: 0x02000111 RID: 273
		// (Invoke) Token: 0x060006C7 RID: 1735
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _IsDisplayOnDesktop();

		// Token: 0x02000112 RID: 274
		// (Invoke) Token: 0x060006CB RID: 1739
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _SetDisplayVisibility(bool bIsVisibleOnDesktop);

		// Token: 0x02000113 RID: 275
		// (Invoke) Token: 0x060006CF RID: 1743
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _GetDeviceToAbsoluteTrackingPose(global::Valve.VR.ETrackingUniverseOrigin eOrigin, float fPredictedSecondsToPhotonsFromNow, [global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] global::Valve.VR.TrackedDevicePose_t[] pTrackedDevicePoseArray, uint unTrackedDevicePoseArrayCount);

		// Token: 0x02000114 RID: 276
		// (Invoke) Token: 0x060006D3 RID: 1747
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _ResetSeatedZeroPose();

		// Token: 0x02000115 RID: 277
		// (Invoke) Token: 0x060006D7 RID: 1751
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.HmdMatrix34_t _GetSeatedZeroPoseToStandingAbsoluteTrackingPose();

		// Token: 0x02000116 RID: 278
		// (Invoke) Token: 0x060006DB RID: 1755
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.HmdMatrix34_t _GetRawZeroPoseToStandingAbsoluteTrackingPose();

		// Token: 0x02000117 RID: 279
		// (Invoke) Token: 0x060006DF RID: 1759
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetSortedTrackedDeviceIndicesOfClass(global::Valve.VR.ETrackedDeviceClass eTrackedDeviceClass, [global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] uint[] punTrackedDeviceIndexArray, uint unTrackedDeviceIndexArrayCount, uint unRelativeToTrackedDeviceIndex);

		// Token: 0x02000118 RID: 280
		// (Invoke) Token: 0x060006E3 RID: 1763
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EDeviceActivityLevel _GetTrackedDeviceActivityLevel(uint unDeviceId);

		// Token: 0x02000119 RID: 281
		// (Invoke) Token: 0x060006E7 RID: 1767
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _ApplyTransform(ref global::Valve.VR.TrackedDevicePose_t pOutputPose, ref global::Valve.VR.TrackedDevicePose_t pTrackedDevicePose, ref global::Valve.VR.HmdMatrix34_t pTransform);

		// Token: 0x0200011A RID: 282
		// (Invoke) Token: 0x060006EB RID: 1771
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetTrackedDeviceIndexForControllerRole(global::Valve.VR.ETrackedControllerRole unDeviceType);

		// Token: 0x0200011B RID: 283
		// (Invoke) Token: 0x060006EF RID: 1775
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.ETrackedControllerRole _GetControllerRoleForTrackedDeviceIndex(uint unDeviceIndex);

		// Token: 0x0200011C RID: 284
		// (Invoke) Token: 0x060006F3 RID: 1779
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.ETrackedDeviceClass _GetTrackedDeviceClass(uint unDeviceIndex);

		// Token: 0x0200011D RID: 285
		// (Invoke) Token: 0x060006F7 RID: 1783
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _IsTrackedDeviceConnected(uint unDeviceIndex);

		// Token: 0x0200011E RID: 286
		// (Invoke) Token: 0x060006FB RID: 1787
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetBoolTrackedDeviceProperty(uint unDeviceIndex, global::Valve.VR.ETrackedDeviceProperty prop, ref global::Valve.VR.ETrackedPropertyError pError);

		// Token: 0x0200011F RID: 287
		// (Invoke) Token: 0x060006FF RID: 1791
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate float _GetFloatTrackedDeviceProperty(uint unDeviceIndex, global::Valve.VR.ETrackedDeviceProperty prop, ref global::Valve.VR.ETrackedPropertyError pError);

		// Token: 0x02000120 RID: 288
		// (Invoke) Token: 0x06000703 RID: 1795
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate int _GetInt32TrackedDeviceProperty(uint unDeviceIndex, global::Valve.VR.ETrackedDeviceProperty prop, ref global::Valve.VR.ETrackedPropertyError pError);

		// Token: 0x02000121 RID: 289
		// (Invoke) Token: 0x06000707 RID: 1799
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate ulong _GetUint64TrackedDeviceProperty(uint unDeviceIndex, global::Valve.VR.ETrackedDeviceProperty prop, ref global::Valve.VR.ETrackedPropertyError pError);

		// Token: 0x02000122 RID: 290
		// (Invoke) Token: 0x0600070B RID: 1803
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.HmdMatrix34_t _GetMatrix34TrackedDeviceProperty(uint unDeviceIndex, global::Valve.VR.ETrackedDeviceProperty prop, ref global::Valve.VR.ETrackedPropertyError pError);

		// Token: 0x02000123 RID: 291
		// (Invoke) Token: 0x0600070F RID: 1807
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetStringTrackedDeviceProperty(uint unDeviceIndex, global::Valve.VR.ETrackedDeviceProperty prop, global::System.Text.StringBuilder pchValue, uint unBufferSize, ref global::Valve.VR.ETrackedPropertyError pError);

		// Token: 0x02000124 RID: 292
		// (Invoke) Token: 0x06000713 RID: 1811
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::System.IntPtr _GetPropErrorNameFromEnum(global::Valve.VR.ETrackedPropertyError error);

		// Token: 0x02000125 RID: 293
		// (Invoke) Token: 0x06000717 RID: 1815
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _PollNextEvent(ref global::Valve.VR.VREvent_t pEvent, uint uncbVREvent);

		// Token: 0x02000126 RID: 294
		// (Invoke) Token: 0x0600071B RID: 1819
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _PollNextEventWithPose(global::Valve.VR.ETrackingUniverseOrigin eOrigin, ref global::Valve.VR.VREvent_t pEvent, uint uncbVREvent, ref global::Valve.VR.TrackedDevicePose_t pTrackedDevicePose);

		// Token: 0x02000127 RID: 295
		// (Invoke) Token: 0x0600071F RID: 1823
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::System.IntPtr _GetEventTypeNameFromEnum(global::Valve.VR.EVREventType eType);

		// Token: 0x02000128 RID: 296
		// (Invoke) Token: 0x06000723 RID: 1827
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.HiddenAreaMesh_t _GetHiddenAreaMesh(global::Valve.VR.EVREye eEye);

		// Token: 0x02000129 RID: 297
		// (Invoke) Token: 0x06000727 RID: 1831
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetControllerState(uint unControllerDeviceIndex, ref global::Valve.VR.VRControllerState_t pControllerState);

		// Token: 0x0200012A RID: 298
		// (Invoke) Token: 0x0600072B RID: 1835
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetControllerStateWithPose(global::Valve.VR.ETrackingUniverseOrigin eOrigin, uint unControllerDeviceIndex, ref global::Valve.VR.VRControllerState_t pControllerState, ref global::Valve.VR.TrackedDevicePose_t pTrackedDevicePose);

		// Token: 0x0200012B RID: 299
		// (Invoke) Token: 0x0600072F RID: 1839
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _TriggerHapticPulse(uint unControllerDeviceIndex, uint unAxisId, char usDurationMicroSec);

		// Token: 0x0200012C RID: 300
		// (Invoke) Token: 0x06000733 RID: 1843
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::System.IntPtr _GetButtonIdNameFromEnum(global::Valve.VR.EVRButtonId eButtonId);

		// Token: 0x0200012D RID: 301
		// (Invoke) Token: 0x06000737 RID: 1847
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::System.IntPtr _GetControllerAxisTypeNameFromEnum(global::Valve.VR.EVRControllerAxisType eAxisType);

		// Token: 0x0200012E RID: 302
		// (Invoke) Token: 0x0600073B RID: 1851
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _CaptureInputFocus();

		// Token: 0x0200012F RID: 303
		// (Invoke) Token: 0x0600073F RID: 1855
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _ReleaseInputFocus();

		// Token: 0x02000130 RID: 304
		// (Invoke) Token: 0x06000743 RID: 1859
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _IsInputFocusCapturedByAnotherProcess();

		// Token: 0x02000131 RID: 305
		// (Invoke) Token: 0x06000747 RID: 1863
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _DriverDebugRequest(uint unDeviceIndex, string pchRequest, string pchResponseBuffer, uint unResponseBufferSize);

		// Token: 0x02000132 RID: 306
		// (Invoke) Token: 0x0600074B RID: 1867
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRFirmwareError _PerformFirmwareUpdate(uint unDeviceIndex);

		// Token: 0x02000133 RID: 307
		// (Invoke) Token: 0x0600074F RID: 1871
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _AcknowledgeQuit_Exiting();

		// Token: 0x02000134 RID: 308
		// (Invoke) Token: 0x06000753 RID: 1875
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _AcknowledgeQuit_UserPrompt();
	}
}
