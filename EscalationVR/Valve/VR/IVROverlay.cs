using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Valve.VR
{
	// Token: 0x02000021 RID: 33
	public struct IVROverlay
	{
		// Token: 0x0400014D RID: 333
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._FindOverlay FindOverlay;

		// Token: 0x0400014E RID: 334
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._CreateOverlay CreateOverlay;

		// Token: 0x0400014F RID: 335
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._DestroyOverlay DestroyOverlay;

		// Token: 0x04000150 RID: 336
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetHighQualityOverlay SetHighQualityOverlay;

		// Token: 0x04000151 RID: 337
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetHighQualityOverlay GetHighQualityOverlay;

		// Token: 0x04000152 RID: 338
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayKey GetOverlayKey;

		// Token: 0x04000153 RID: 339
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayName GetOverlayName;

		// Token: 0x04000154 RID: 340
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayImageData GetOverlayImageData;

		// Token: 0x04000155 RID: 341
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayErrorNameFromEnum GetOverlayErrorNameFromEnum;

		// Token: 0x04000156 RID: 342
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayRenderingPid SetOverlayRenderingPid;

		// Token: 0x04000157 RID: 343
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayRenderingPid GetOverlayRenderingPid;

		// Token: 0x04000158 RID: 344
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayFlag SetOverlayFlag;

		// Token: 0x04000159 RID: 345
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayFlag GetOverlayFlag;

		// Token: 0x0400015A RID: 346
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayColor SetOverlayColor;

		// Token: 0x0400015B RID: 347
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayColor GetOverlayColor;

		// Token: 0x0400015C RID: 348
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayAlpha SetOverlayAlpha;

		// Token: 0x0400015D RID: 349
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayAlpha GetOverlayAlpha;

		// Token: 0x0400015E RID: 350
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayWidthInMeters SetOverlayWidthInMeters;

		// Token: 0x0400015F RID: 351
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayWidthInMeters GetOverlayWidthInMeters;

		// Token: 0x04000160 RID: 352
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayAutoCurveDistanceRangeInMeters SetOverlayAutoCurveDistanceRangeInMeters;

		// Token: 0x04000161 RID: 353
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayAutoCurveDistanceRangeInMeters GetOverlayAutoCurveDistanceRangeInMeters;

		// Token: 0x04000162 RID: 354
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayTextureColorSpace SetOverlayTextureColorSpace;

		// Token: 0x04000163 RID: 355
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayTextureColorSpace GetOverlayTextureColorSpace;

		// Token: 0x04000164 RID: 356
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayTextureBounds SetOverlayTextureBounds;

		// Token: 0x04000165 RID: 357
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayTextureBounds GetOverlayTextureBounds;

		// Token: 0x04000166 RID: 358
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayTransformType GetOverlayTransformType;

		// Token: 0x04000167 RID: 359
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayTransformAbsolute SetOverlayTransformAbsolute;

		// Token: 0x04000168 RID: 360
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayTransformAbsolute GetOverlayTransformAbsolute;

		// Token: 0x04000169 RID: 361
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayTransformTrackedDeviceRelative SetOverlayTransformTrackedDeviceRelative;

		// Token: 0x0400016A RID: 362
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayTransformTrackedDeviceRelative GetOverlayTransformTrackedDeviceRelative;

		// Token: 0x0400016B RID: 363
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayTransformTrackedDeviceComponent SetOverlayTransformTrackedDeviceComponent;

		// Token: 0x0400016C RID: 364
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayTransformTrackedDeviceComponent GetOverlayTransformTrackedDeviceComponent;

		// Token: 0x0400016D RID: 365
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._ShowOverlay ShowOverlay;

		// Token: 0x0400016E RID: 366
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._HideOverlay HideOverlay;

		// Token: 0x0400016F RID: 367
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._IsOverlayVisible IsOverlayVisible;

		// Token: 0x04000170 RID: 368
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetTransformForOverlayCoordinates GetTransformForOverlayCoordinates;

		// Token: 0x04000171 RID: 369
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._PollNextOverlayEvent PollNextOverlayEvent;

		// Token: 0x04000172 RID: 370
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayInputMethod GetOverlayInputMethod;

		// Token: 0x04000173 RID: 371
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayInputMethod SetOverlayInputMethod;

		// Token: 0x04000174 RID: 372
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayMouseScale GetOverlayMouseScale;

		// Token: 0x04000175 RID: 373
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayMouseScale SetOverlayMouseScale;

		// Token: 0x04000176 RID: 374
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._ComputeOverlayIntersection ComputeOverlayIntersection;

		// Token: 0x04000177 RID: 375
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._HandleControllerOverlayInteractionAsMouse HandleControllerOverlayInteractionAsMouse;

		// Token: 0x04000178 RID: 376
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._IsHoverTargetOverlay IsHoverTargetOverlay;

		// Token: 0x04000179 RID: 377
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetGamepadFocusOverlay GetGamepadFocusOverlay;

		// Token: 0x0400017A RID: 378
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetGamepadFocusOverlay SetGamepadFocusOverlay;

		// Token: 0x0400017B RID: 379
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayNeighbor SetOverlayNeighbor;

		// Token: 0x0400017C RID: 380
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._MoveGamepadFocusToNeighbor MoveGamepadFocusToNeighbor;

		// Token: 0x0400017D RID: 381
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayTexture SetOverlayTexture;

		// Token: 0x0400017E RID: 382
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._ClearOverlayTexture ClearOverlayTexture;

		// Token: 0x0400017F RID: 383
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayRaw SetOverlayRaw;

		// Token: 0x04000180 RID: 384
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetOverlayFromFile SetOverlayFromFile;

		// Token: 0x04000181 RID: 385
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetOverlayTexture GetOverlayTexture;

		// Token: 0x04000182 RID: 386
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._ReleaseNativeOverlayHandle ReleaseNativeOverlayHandle;

		// Token: 0x04000183 RID: 387
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._CreateDashboardOverlay CreateDashboardOverlay;

		// Token: 0x04000184 RID: 388
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._IsDashboardVisible IsDashboardVisible;

		// Token: 0x04000185 RID: 389
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._IsActiveDashboardOverlay IsActiveDashboardOverlay;

		// Token: 0x04000186 RID: 390
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetDashboardOverlaySceneProcess SetDashboardOverlaySceneProcess;

		// Token: 0x04000187 RID: 391
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetDashboardOverlaySceneProcess GetDashboardOverlaySceneProcess;

		// Token: 0x04000188 RID: 392
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._ShowDashboard ShowDashboard;

		// Token: 0x04000189 RID: 393
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetPrimaryDashboardDevice GetPrimaryDashboardDevice;

		// Token: 0x0400018A RID: 394
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._ShowKeyboard ShowKeyboard;

		// Token: 0x0400018B RID: 395
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._ShowKeyboardForOverlay ShowKeyboardForOverlay;

		// Token: 0x0400018C RID: 396
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._GetKeyboardText GetKeyboardText;

		// Token: 0x0400018D RID: 397
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._HideKeyboard HideKeyboard;

		// Token: 0x0400018E RID: 398
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetKeyboardTransformAbsolute SetKeyboardTransformAbsolute;

		// Token: 0x0400018F RID: 399
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVROverlay._SetKeyboardPositionForOverlay SetKeyboardPositionForOverlay;

		// Token: 0x02000189 RID: 393
		// (Invoke) Token: 0x060008A7 RID: 2215
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _FindOverlay(string pchOverlayKey, ref ulong pOverlayHandle);

		// Token: 0x0200018A RID: 394
		// (Invoke) Token: 0x060008AB RID: 2219
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _CreateOverlay(string pchOverlayKey, string pchOverlayFriendlyName, ref ulong pOverlayHandle);

		// Token: 0x0200018B RID: 395
		// (Invoke) Token: 0x060008AF RID: 2223
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _DestroyOverlay(ulong ulOverlayHandle);

		// Token: 0x0200018C RID: 396
		// (Invoke) Token: 0x060008B3 RID: 2227
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetHighQualityOverlay(ulong ulOverlayHandle);

		// Token: 0x0200018D RID: 397
		// (Invoke) Token: 0x060008B7 RID: 2231
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate ulong _GetHighQualityOverlay();

		// Token: 0x0200018E RID: 398
		// (Invoke) Token: 0x060008BB RID: 2235
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetOverlayKey(ulong ulOverlayHandle, global::System.Text.StringBuilder pchValue, uint unBufferSize, ref global::Valve.VR.EVROverlayError pError);

		// Token: 0x0200018F RID: 399
		// (Invoke) Token: 0x060008BF RID: 2239
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetOverlayName(ulong ulOverlayHandle, global::System.Text.StringBuilder pchValue, uint unBufferSize, ref global::Valve.VR.EVROverlayError pError);

		// Token: 0x02000190 RID: 400
		// (Invoke) Token: 0x060008C3 RID: 2243
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayImageData(ulong ulOverlayHandle, global::System.IntPtr pvBuffer, uint unBufferSize, ref uint punWidth, ref uint punHeight);

		// Token: 0x02000191 RID: 401
		// (Invoke) Token: 0x060008C7 RID: 2247
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::System.IntPtr _GetOverlayErrorNameFromEnum(global::Valve.VR.EVROverlayError error);

		// Token: 0x02000192 RID: 402
		// (Invoke) Token: 0x060008CB RID: 2251
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayRenderingPid(ulong ulOverlayHandle, uint unPID);

		// Token: 0x02000193 RID: 403
		// (Invoke) Token: 0x060008CF RID: 2255
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetOverlayRenderingPid(ulong ulOverlayHandle);

		// Token: 0x02000194 RID: 404
		// (Invoke) Token: 0x060008D3 RID: 2259
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayFlag(ulong ulOverlayHandle, global::Valve.VR.VROverlayFlags eOverlayFlag, bool bEnabled);

		// Token: 0x02000195 RID: 405
		// (Invoke) Token: 0x060008D7 RID: 2263
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayFlag(ulong ulOverlayHandle, global::Valve.VR.VROverlayFlags eOverlayFlag, ref bool pbEnabled);

		// Token: 0x02000196 RID: 406
		// (Invoke) Token: 0x060008DB RID: 2267
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayColor(ulong ulOverlayHandle, float fRed, float fGreen, float fBlue);

		// Token: 0x02000197 RID: 407
		// (Invoke) Token: 0x060008DF RID: 2271
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayColor(ulong ulOverlayHandle, ref float pfRed, ref float pfGreen, ref float pfBlue);

		// Token: 0x02000198 RID: 408
		// (Invoke) Token: 0x060008E3 RID: 2275
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayAlpha(ulong ulOverlayHandle, float fAlpha);

		// Token: 0x02000199 RID: 409
		// (Invoke) Token: 0x060008E7 RID: 2279
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayAlpha(ulong ulOverlayHandle, ref float pfAlpha);

		// Token: 0x0200019A RID: 410
		// (Invoke) Token: 0x060008EB RID: 2283
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayWidthInMeters(ulong ulOverlayHandle, float fWidthInMeters);

		// Token: 0x0200019B RID: 411
		// (Invoke) Token: 0x060008EF RID: 2287
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayWidthInMeters(ulong ulOverlayHandle, ref float pfWidthInMeters);

		// Token: 0x0200019C RID: 412
		// (Invoke) Token: 0x060008F3 RID: 2291
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayAutoCurveDistanceRangeInMeters(ulong ulOverlayHandle, float fMinDistanceInMeters, float fMaxDistanceInMeters);

		// Token: 0x0200019D RID: 413
		// (Invoke) Token: 0x060008F7 RID: 2295
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayAutoCurveDistanceRangeInMeters(ulong ulOverlayHandle, ref float pfMinDistanceInMeters, ref float pfMaxDistanceInMeters);

		// Token: 0x0200019E RID: 414
		// (Invoke) Token: 0x060008FB RID: 2299
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayTextureColorSpace(ulong ulOverlayHandle, global::Valve.VR.EColorSpace eTextureColorSpace);

		// Token: 0x0200019F RID: 415
		// (Invoke) Token: 0x060008FF RID: 2303
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayTextureColorSpace(ulong ulOverlayHandle, ref global::Valve.VR.EColorSpace peTextureColorSpace);

		// Token: 0x020001A0 RID: 416
		// (Invoke) Token: 0x06000903 RID: 2307
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayTextureBounds(ulong ulOverlayHandle, ref global::Valve.VR.VRTextureBounds_t pOverlayTextureBounds);

		// Token: 0x020001A1 RID: 417
		// (Invoke) Token: 0x06000907 RID: 2311
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayTextureBounds(ulong ulOverlayHandle, ref global::Valve.VR.VRTextureBounds_t pOverlayTextureBounds);

		// Token: 0x020001A2 RID: 418
		// (Invoke) Token: 0x0600090B RID: 2315
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayTransformType(ulong ulOverlayHandle, ref global::Valve.VR.VROverlayTransformType peTransformType);

		// Token: 0x020001A3 RID: 419
		// (Invoke) Token: 0x0600090F RID: 2319
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayTransformAbsolute(ulong ulOverlayHandle, global::Valve.VR.ETrackingUniverseOrigin eTrackingOrigin, ref global::Valve.VR.HmdMatrix34_t pmatTrackingOriginToOverlayTransform);

		// Token: 0x020001A4 RID: 420
		// (Invoke) Token: 0x06000913 RID: 2323
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayTransformAbsolute(ulong ulOverlayHandle, ref global::Valve.VR.ETrackingUniverseOrigin peTrackingOrigin, ref global::Valve.VR.HmdMatrix34_t pmatTrackingOriginToOverlayTransform);

		// Token: 0x020001A5 RID: 421
		// (Invoke) Token: 0x06000917 RID: 2327
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayTransformTrackedDeviceRelative(ulong ulOverlayHandle, uint unTrackedDevice, ref global::Valve.VR.HmdMatrix34_t pmatTrackedDeviceToOverlayTransform);

		// Token: 0x020001A6 RID: 422
		// (Invoke) Token: 0x0600091B RID: 2331
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayTransformTrackedDeviceRelative(ulong ulOverlayHandle, ref uint punTrackedDevice, ref global::Valve.VR.HmdMatrix34_t pmatTrackedDeviceToOverlayTransform);

		// Token: 0x020001A7 RID: 423
		// (Invoke) Token: 0x0600091F RID: 2335
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayTransformTrackedDeviceComponent(ulong ulOverlayHandle, uint unDeviceIndex, string pchComponentName);

		// Token: 0x020001A8 RID: 424
		// (Invoke) Token: 0x06000923 RID: 2339
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayTransformTrackedDeviceComponent(ulong ulOverlayHandle, ref uint punDeviceIndex, string pchComponentName, uint unComponentNameSize);

		// Token: 0x020001A9 RID: 425
		// (Invoke) Token: 0x06000927 RID: 2343
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _ShowOverlay(ulong ulOverlayHandle);

		// Token: 0x020001AA RID: 426
		// (Invoke) Token: 0x0600092B RID: 2347
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _HideOverlay(ulong ulOverlayHandle);

		// Token: 0x020001AB RID: 427
		// (Invoke) Token: 0x0600092F RID: 2351
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _IsOverlayVisible(ulong ulOverlayHandle);

		// Token: 0x020001AC RID: 428
		// (Invoke) Token: 0x06000933 RID: 2355
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetTransformForOverlayCoordinates(ulong ulOverlayHandle, global::Valve.VR.ETrackingUniverseOrigin eTrackingOrigin, global::Valve.VR.HmdVector2_t coordinatesInOverlay, ref global::Valve.VR.HmdMatrix34_t pmatTransform);

		// Token: 0x020001AD RID: 429
		// (Invoke) Token: 0x06000937 RID: 2359
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _PollNextOverlayEvent(ulong ulOverlayHandle, ref global::Valve.VR.VREvent_t pEvent, uint uncbVREvent);

		// Token: 0x020001AE RID: 430
		// (Invoke) Token: 0x0600093B RID: 2363
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayInputMethod(ulong ulOverlayHandle, ref global::Valve.VR.VROverlayInputMethod peInputMethod);

		// Token: 0x020001AF RID: 431
		// (Invoke) Token: 0x0600093F RID: 2367
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayInputMethod(ulong ulOverlayHandle, global::Valve.VR.VROverlayInputMethod eInputMethod);

		// Token: 0x020001B0 RID: 432
		// (Invoke) Token: 0x06000943 RID: 2371
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayMouseScale(ulong ulOverlayHandle, ref global::Valve.VR.HmdVector2_t pvecMouseScale);

		// Token: 0x020001B1 RID: 433
		// (Invoke) Token: 0x06000947 RID: 2375
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayMouseScale(ulong ulOverlayHandle, ref global::Valve.VR.HmdVector2_t pvecMouseScale);

		// Token: 0x020001B2 RID: 434
		// (Invoke) Token: 0x0600094B RID: 2379
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _ComputeOverlayIntersection(ulong ulOverlayHandle, ref global::Valve.VR.VROverlayIntersectionParams_t pParams, ref global::Valve.VR.VROverlayIntersectionResults_t pResults);

		// Token: 0x020001B3 RID: 435
		// (Invoke) Token: 0x0600094F RID: 2383
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _HandleControllerOverlayInteractionAsMouse(ulong ulOverlayHandle, uint unControllerDeviceIndex);

		// Token: 0x020001B4 RID: 436
		// (Invoke) Token: 0x06000953 RID: 2387
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _IsHoverTargetOverlay(ulong ulOverlayHandle);

		// Token: 0x020001B5 RID: 437
		// (Invoke) Token: 0x06000957 RID: 2391
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate ulong _GetGamepadFocusOverlay();

		// Token: 0x020001B6 RID: 438
		// (Invoke) Token: 0x0600095B RID: 2395
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetGamepadFocusOverlay(ulong ulNewFocusOverlay);

		// Token: 0x020001B7 RID: 439
		// (Invoke) Token: 0x0600095F RID: 2399
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayNeighbor(global::Valve.VR.EOverlayDirection eDirection, ulong ulFrom, ulong ulTo);

		// Token: 0x020001B8 RID: 440
		// (Invoke) Token: 0x06000963 RID: 2403
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _MoveGamepadFocusToNeighbor(global::Valve.VR.EOverlayDirection eDirection, ulong ulFrom);

		// Token: 0x020001B9 RID: 441
		// (Invoke) Token: 0x06000967 RID: 2407
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayTexture(ulong ulOverlayHandle, ref global::Valve.VR.Texture_t pTexture);

		// Token: 0x020001BA RID: 442
		// (Invoke) Token: 0x0600096B RID: 2411
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _ClearOverlayTexture(ulong ulOverlayHandle);

		// Token: 0x020001BB RID: 443
		// (Invoke) Token: 0x0600096F RID: 2415
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayRaw(ulong ulOverlayHandle, global::System.IntPtr pvBuffer, uint unWidth, uint unHeight, uint unDepth);

		// Token: 0x020001BC RID: 444
		// (Invoke) Token: 0x06000973 RID: 2419
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetOverlayFromFile(ulong ulOverlayHandle, string pchFilePath);

		// Token: 0x020001BD RID: 445
		// (Invoke) Token: 0x06000977 RID: 2423
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetOverlayTexture(ulong ulOverlayHandle, ref global::System.IntPtr pNativeTextureHandle, global::System.IntPtr pNativeTextureRef, ref uint pWidth, ref uint pHeight, ref uint pNativeFormat, ref global::Valve.VR.EGraphicsAPIConvention pAPI, ref global::Valve.VR.EColorSpace pColorSpace);

		// Token: 0x020001BE RID: 446
		// (Invoke) Token: 0x0600097B RID: 2427
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _ReleaseNativeOverlayHandle(ulong ulOverlayHandle, global::System.IntPtr pNativeTextureHandle);

		// Token: 0x020001BF RID: 447
		// (Invoke) Token: 0x0600097F RID: 2431
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _CreateDashboardOverlay(string pchOverlayKey, string pchOverlayFriendlyName, ref ulong pMainHandle, ref ulong pThumbnailHandle);

		// Token: 0x020001C0 RID: 448
		// (Invoke) Token: 0x06000983 RID: 2435
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _IsDashboardVisible();

		// Token: 0x020001C1 RID: 449
		// (Invoke) Token: 0x06000987 RID: 2439
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _IsActiveDashboardOverlay(ulong ulOverlayHandle);

		// Token: 0x020001C2 RID: 450
		// (Invoke) Token: 0x0600098B RID: 2443
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _SetDashboardOverlaySceneProcess(ulong ulOverlayHandle, uint unProcessId);

		// Token: 0x020001C3 RID: 451
		// (Invoke) Token: 0x0600098F RID: 2447
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _GetDashboardOverlaySceneProcess(ulong ulOverlayHandle, ref uint punProcessId);

		// Token: 0x020001C4 RID: 452
		// (Invoke) Token: 0x06000993 RID: 2451
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _ShowDashboard(string pchOverlayToShow);

		// Token: 0x020001C5 RID: 453
		// (Invoke) Token: 0x06000997 RID: 2455
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetPrimaryDashboardDevice();

		// Token: 0x020001C6 RID: 454
		// (Invoke) Token: 0x0600099B RID: 2459
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _ShowKeyboard(int eInputMode, int eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText, bool bUseMinimalMode, ulong uUserValue);

		// Token: 0x020001C7 RID: 455
		// (Invoke) Token: 0x0600099F RID: 2463
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVROverlayError _ShowKeyboardForOverlay(ulong ulOverlayHandle, int eInputMode, int eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText, bool bUseMinimalMode, ulong uUserValue);

		// Token: 0x020001C8 RID: 456
		// (Invoke) Token: 0x060009A3 RID: 2467
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetKeyboardText(global::System.Text.StringBuilder pchText, uint cchText);

		// Token: 0x020001C9 RID: 457
		// (Invoke) Token: 0x060009A7 RID: 2471
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _HideKeyboard();

		// Token: 0x020001CA RID: 458
		// (Invoke) Token: 0x060009AB RID: 2475
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SetKeyboardTransformAbsolute(global::Valve.VR.ETrackingUniverseOrigin eTrackingOrigin, ref global::Valve.VR.HmdMatrix34_t pmatTrackingOriginToKeyboardTransform);

		// Token: 0x020001CB RID: 459
		// (Invoke) Token: 0x060009AF RID: 2479
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate void _SetKeyboardPositionForOverlay(ulong ulOverlayHandle, global::Valve.VR.HmdRect2_t avoidRect);
	}
}
