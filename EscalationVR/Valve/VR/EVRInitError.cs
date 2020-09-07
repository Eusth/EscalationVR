using System;

namespace Valve.VR
{
	// Token: 0x02000046 RID: 70
	public enum EVRInitError
	{
		// Token: 0x040002E9 RID: 745
		None,
		// Token: 0x040002EA RID: 746
		Unknown,
		// Token: 0x040002EB RID: 747
		Init_InstallationNotFound = 100,
		// Token: 0x040002EC RID: 748
		Init_InstallationCorrupt,
		// Token: 0x040002ED RID: 749
		Init_VRClientDLLNotFound,
		// Token: 0x040002EE RID: 750
		Init_FileNotFound,
		// Token: 0x040002EF RID: 751
		Init_FactoryNotFound,
		// Token: 0x040002F0 RID: 752
		Init_InterfaceNotFound,
		// Token: 0x040002F1 RID: 753
		Init_InvalidInterface,
		// Token: 0x040002F2 RID: 754
		Init_UserConfigDirectoryInvalid,
		// Token: 0x040002F3 RID: 755
		Init_HmdNotFound,
		// Token: 0x040002F4 RID: 756
		Init_NotInitialized,
		// Token: 0x040002F5 RID: 757
		Init_PathRegistryNotFound,
		// Token: 0x040002F6 RID: 758
		Init_NoConfigPath,
		// Token: 0x040002F7 RID: 759
		Init_NoLogPath,
		// Token: 0x040002F8 RID: 760
		Init_PathRegistryNotWritable,
		// Token: 0x040002F9 RID: 761
		Init_AppInfoInitFailed,
		// Token: 0x040002FA RID: 762
		Init_Retry,
		// Token: 0x040002FB RID: 763
		Init_InitCanceledByUser,
		// Token: 0x040002FC RID: 764
		Init_AnotherAppLaunching,
		// Token: 0x040002FD RID: 765
		Init_SettingsInitFailed,
		// Token: 0x040002FE RID: 766
		Init_ShuttingDown,
		// Token: 0x040002FF RID: 767
		Init_TooManyObjects,
		// Token: 0x04000300 RID: 768
		Init_NoServerForBackgroundApp,
		// Token: 0x04000301 RID: 769
		Init_NotSupportedWithCompositor,
		// Token: 0x04000302 RID: 770
		Init_NotAvailableToUtilityApps,
		// Token: 0x04000303 RID: 771
		Init_Internal,
		// Token: 0x04000304 RID: 772
		Driver_Failed = 200,
		// Token: 0x04000305 RID: 773
		Driver_Unknown,
		// Token: 0x04000306 RID: 774
		Driver_HmdUnknown,
		// Token: 0x04000307 RID: 775
		Driver_NotLoaded,
		// Token: 0x04000308 RID: 776
		Driver_RuntimeOutOfDate,
		// Token: 0x04000309 RID: 777
		Driver_HmdInUse,
		// Token: 0x0400030A RID: 778
		Driver_NotCalibrated,
		// Token: 0x0400030B RID: 779
		Driver_CalibrationInvalid,
		// Token: 0x0400030C RID: 780
		Driver_HmdDisplayNotFound,
		// Token: 0x0400030D RID: 781
		IPC_ServerInitFailed = 300,
		// Token: 0x0400030E RID: 782
		IPC_ConnectFailed,
		// Token: 0x0400030F RID: 783
		IPC_SharedStateInitFailed,
		// Token: 0x04000310 RID: 784
		IPC_CompositorInitFailed,
		// Token: 0x04000311 RID: 785
		IPC_MutexInitFailed,
		// Token: 0x04000312 RID: 786
		IPC_Failed,
		// Token: 0x04000313 RID: 787
		Compositor_Failed = 400,
		// Token: 0x04000314 RID: 788
		Compositor_D3D11HardwareRequired,
		// Token: 0x04000315 RID: 789
		Compositor_FirmwareRequiresUpdate,
		// Token: 0x04000316 RID: 790
		VendorSpecific_UnableToConnectToOculusRuntime = 1000,
		// Token: 0x04000317 RID: 791
		VendorSpecific_HmdFound_CantOpenDevice = 1101,
		// Token: 0x04000318 RID: 792
		VendorSpecific_HmdFound_UnableToRequestConfigStart,
		// Token: 0x04000319 RID: 793
		VendorSpecific_HmdFound_NoStoredConfig,
		// Token: 0x0400031A RID: 794
		VendorSpecific_HmdFound_ConfigTooBig,
		// Token: 0x0400031B RID: 795
		VendorSpecific_HmdFound_ConfigTooSmall,
		// Token: 0x0400031C RID: 796
		VendorSpecific_HmdFound_UnableToInitZLib,
		// Token: 0x0400031D RID: 797
		VendorSpecific_HmdFound_CantReadFirmwareVersion,
		// Token: 0x0400031E RID: 798
		VendorSpecific_HmdFound_UnableToSendUserDataStart,
		// Token: 0x0400031F RID: 799
		VendorSpecific_HmdFound_UnableToGetUserDataStart,
		// Token: 0x04000320 RID: 800
		VendorSpecific_HmdFound_UnableToGetUserDataNext,
		// Token: 0x04000321 RID: 801
		VendorSpecific_HmdFound_UserDataAddressRange,
		// Token: 0x04000322 RID: 802
		VendorSpecific_HmdFound_UserDataError,
		// Token: 0x04000323 RID: 803
		VendorSpecific_HmdFound_ConfigFailedSanityCheck,
		// Token: 0x04000324 RID: 804
		Steam_SteamInstallationNotFound = 2000
	}
}
