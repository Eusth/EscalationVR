using System;

namespace Valve.VR
{
	// Token: 0x0200003B RID: 59
	public enum EVREventType
	{
		// Token: 0x04000242 RID: 578
		VREvent_None,
		// Token: 0x04000243 RID: 579
		VREvent_TrackedDeviceActivated = 100,
		// Token: 0x04000244 RID: 580
		VREvent_TrackedDeviceDeactivated,
		// Token: 0x04000245 RID: 581
		VREvent_TrackedDeviceUpdated,
		// Token: 0x04000246 RID: 582
		VREvent_TrackedDeviceUserInteractionStarted,
		// Token: 0x04000247 RID: 583
		VREvent_TrackedDeviceUserInteractionEnded,
		// Token: 0x04000248 RID: 584
		VREvent_IpdChanged,
		// Token: 0x04000249 RID: 585
		VREvent_EnterStandbyMode,
		// Token: 0x0400024A RID: 586
		VREvent_LeaveStandbyMode,
		// Token: 0x0400024B RID: 587
		VREvent_TrackedDeviceRoleChanged,
		// Token: 0x0400024C RID: 588
		VREvent_ButtonPress = 200,
		// Token: 0x0400024D RID: 589
		VREvent_ButtonUnpress,
		// Token: 0x0400024E RID: 590
		VREvent_ButtonTouch,
		// Token: 0x0400024F RID: 591
		VREvent_ButtonUntouch,
		// Token: 0x04000250 RID: 592
		VREvent_MouseMove = 300,
		// Token: 0x04000251 RID: 593
		VREvent_MouseButtonDown,
		// Token: 0x04000252 RID: 594
		VREvent_MouseButtonUp,
		// Token: 0x04000253 RID: 595
		VREvent_FocusEnter,
		// Token: 0x04000254 RID: 596
		VREvent_FocusLeave,
		// Token: 0x04000255 RID: 597
		VREvent_Scroll,
		// Token: 0x04000256 RID: 598
		VREvent_TouchPadMove,
		// Token: 0x04000257 RID: 599
		VREvent_InputFocusCaptured = 400,
		// Token: 0x04000258 RID: 600
		VREvent_InputFocusReleased,
		// Token: 0x04000259 RID: 601
		VREvent_SceneFocusLost,
		// Token: 0x0400025A RID: 602
		VREvent_SceneFocusGained,
		// Token: 0x0400025B RID: 603
		VREvent_SceneApplicationChanged,
		// Token: 0x0400025C RID: 604
		VREvent_SceneFocusChanged,
		// Token: 0x0400025D RID: 605
		VREvent_InputFocusChanged,
		// Token: 0x0400025E RID: 606
		VREvent_HideRenderModels = 410,
		// Token: 0x0400025F RID: 607
		VREvent_ShowRenderModels,
		// Token: 0x04000260 RID: 608
		VREvent_OverlayShown = 500,
		// Token: 0x04000261 RID: 609
		VREvent_OverlayHidden,
		// Token: 0x04000262 RID: 610
		VREvent_DashboardActivated,
		// Token: 0x04000263 RID: 611
		VREvent_DashboardDeactivated,
		// Token: 0x04000264 RID: 612
		VREvent_DashboardThumbSelected,
		// Token: 0x04000265 RID: 613
		VREvent_DashboardRequested,
		// Token: 0x04000266 RID: 614
		VREvent_ResetDashboard,
		// Token: 0x04000267 RID: 615
		VREvent_RenderToast,
		// Token: 0x04000268 RID: 616
		VREvent_ImageLoaded,
		// Token: 0x04000269 RID: 617
		VREvent_ShowKeyboard,
		// Token: 0x0400026A RID: 618
		VREvent_HideKeyboard,
		// Token: 0x0400026B RID: 619
		VREvent_OverlayGamepadFocusGained,
		// Token: 0x0400026C RID: 620
		VREvent_OverlayGamepadFocusLost,
		// Token: 0x0400026D RID: 621
		VREvent_OverlaySharedTextureChanged,
		// Token: 0x0400026E RID: 622
		VREvent_DashboardGuideButtonDown,
		// Token: 0x0400026F RID: 623
		VREvent_DashboardGuideButtonUp,
		// Token: 0x04000270 RID: 624
		VREvent_Notification_Shown = 600,
		// Token: 0x04000271 RID: 625
		VREvent_Notification_Hidden,
		// Token: 0x04000272 RID: 626
		VREvent_Notification_BeginInteraction,
		// Token: 0x04000273 RID: 627
		VREvent_Notification_Destroyed,
		// Token: 0x04000274 RID: 628
		VREvent_Quit = 700,
		// Token: 0x04000275 RID: 629
		VREvent_ProcessQuit,
		// Token: 0x04000276 RID: 630
		VREvent_QuitAborted_UserPrompt,
		// Token: 0x04000277 RID: 631
		VREvent_QuitAcknowledged,
		// Token: 0x04000278 RID: 632
		VREvent_DriverRequestedQuit,
		// Token: 0x04000279 RID: 633
		VREvent_ChaperoneDataHasChanged = 800,
		// Token: 0x0400027A RID: 634
		VREvent_ChaperoneUniverseHasChanged,
		// Token: 0x0400027B RID: 635
		VREvent_ChaperoneTempDataHasChanged,
		// Token: 0x0400027C RID: 636
		VREvent_ChaperoneSettingsHaveChanged,
		// Token: 0x0400027D RID: 637
		VREvent_SeatedZeroPoseReset,
		// Token: 0x0400027E RID: 638
		VREvent_AudioSettingsHaveChanged = 820,
		// Token: 0x0400027F RID: 639
		VREvent_BackgroundSettingHasChanged = 850,
		// Token: 0x04000280 RID: 640
		VREvent_CameraSettingsHaveChanged,
		// Token: 0x04000281 RID: 641
		VREvent_ReprojectionSettingHasChanged,
		// Token: 0x04000282 RID: 642
		VREvent_StatusUpdate = 900,
		// Token: 0x04000283 RID: 643
		VREvent_MCImageUpdated = 1000,
		// Token: 0x04000284 RID: 644
		VREvent_FirmwareUpdateStarted = 1100,
		// Token: 0x04000285 RID: 645
		VREvent_FirmwareUpdateFinished,
		// Token: 0x04000286 RID: 646
		VREvent_KeyboardClosed = 1200,
		// Token: 0x04000287 RID: 647
		VREvent_KeyboardCharInput,
		// Token: 0x04000288 RID: 648
		VREvent_KeyboardDone,
		// Token: 0x04000289 RID: 649
		VREvent_ApplicationTransitionStarted = 1300,
		// Token: 0x0400028A RID: 650
		VREvent_ApplicationTransitionAborted,
		// Token: 0x0400028B RID: 651
		VREvent_ApplicationTransitionNewAppStarted,
		// Token: 0x0400028C RID: 652
		VREvent_Compositor_MirrorWindowShown = 1400,
		// Token: 0x0400028D RID: 653
		VREvent_Compositor_MirrorWindowHidden,
		// Token: 0x0400028E RID: 654
		VREvent_Compositor_ChaperoneBoundsShown = 1410,
		// Token: 0x0400028F RID: 655
		VREvent_Compositor_ChaperoneBoundsHidden,
		// Token: 0x04000290 RID: 656
		VREvent_TrackedCamera_StartVideoStream = 1500,
		// Token: 0x04000291 RID: 657
		VREvent_TrackedCamera_StopVideoStream,
		// Token: 0x04000292 RID: 658
		VREvent_TrackedCamera_PauseVideoStream,
		// Token: 0x04000293 RID: 659
		VREvent_TrackedCamera_ResumeVideoStream,
		// Token: 0x04000294 RID: 660
		VREvent_PerformanceTest_EnableCapture = 1600,
		// Token: 0x04000295 RID: 661
		VREvent_PerformanceTest_DisableCapture,
		// Token: 0x04000296 RID: 662
		VREvent_PerformanceTest_FidelityLevel,
		// Token: 0x04000297 RID: 663
		VREvent_VendorSpecific_Reserved_Start = 10000,
		// Token: 0x04000298 RID: 664
		VREvent_VendorSpecific_Reserved_End = 19999
	}
}
