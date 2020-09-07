using System;

namespace Valve.VR
{
	// Token: 0x02000037 RID: 55
	public enum ETrackedDeviceProperty
	{
		// Token: 0x040001D6 RID: 470
		Prop_TrackingSystemName_String = 1000,
		// Token: 0x040001D7 RID: 471
		Prop_ModelNumber_String,
		// Token: 0x040001D8 RID: 472
		Prop_SerialNumber_String,
		// Token: 0x040001D9 RID: 473
		Prop_RenderModelName_String,
		// Token: 0x040001DA RID: 474
		Prop_WillDriftInYaw_Bool,
		// Token: 0x040001DB RID: 475
		Prop_ManufacturerName_String,
		// Token: 0x040001DC RID: 476
		Prop_TrackingFirmwareVersion_String,
		// Token: 0x040001DD RID: 477
		Prop_HardwareRevision_String,
		// Token: 0x040001DE RID: 478
		Prop_AllWirelessDongleDescriptions_String,
		// Token: 0x040001DF RID: 479
		Prop_ConnectedWirelessDongle_String,
		// Token: 0x040001E0 RID: 480
		Prop_DeviceIsWireless_Bool,
		// Token: 0x040001E1 RID: 481
		Prop_DeviceIsCharging_Bool,
		// Token: 0x040001E2 RID: 482
		Prop_DeviceBatteryPercentage_Float,
		// Token: 0x040001E3 RID: 483
		Prop_StatusDisplayTransform_Matrix34,
		// Token: 0x040001E4 RID: 484
		Prop_Firmware_UpdateAvailable_Bool,
		// Token: 0x040001E5 RID: 485
		Prop_Firmware_ManualUpdate_Bool,
		// Token: 0x040001E6 RID: 486
		Prop_Firmware_ManualUpdateURL_String,
		// Token: 0x040001E7 RID: 487
		Prop_HardwareRevision_Uint64,
		// Token: 0x040001E8 RID: 488
		Prop_FirmwareVersion_Uint64,
		// Token: 0x040001E9 RID: 489
		Prop_FPGAVersion_Uint64,
		// Token: 0x040001EA RID: 490
		Prop_VRCVersion_Uint64,
		// Token: 0x040001EB RID: 491
		Prop_RadioVersion_Uint64,
		// Token: 0x040001EC RID: 492
		Prop_DongleVersion_Uint64,
		// Token: 0x040001ED RID: 493
		Prop_BlockServerShutdown_Bool,
		// Token: 0x040001EE RID: 494
		Prop_CanUnifyCoordinateSystemWithHmd_Bool,
		// Token: 0x040001EF RID: 495
		Prop_ContainsProximitySensor_Bool,
		// Token: 0x040001F0 RID: 496
		Prop_DeviceProvidesBatteryStatus_Bool,
		// Token: 0x040001F1 RID: 497
		Prop_DeviceCanPowerOff_Bool,
		// Token: 0x040001F2 RID: 498
		Prop_Firmware_ProgrammingTarget_String,
		// Token: 0x040001F3 RID: 499
		Prop_DeviceClass_Int32,
		// Token: 0x040001F4 RID: 500
		Prop_HasCamera_Bool,
		// Token: 0x040001F5 RID: 501
		Prop_DriverVersion_String,
		// Token: 0x040001F6 RID: 502
		Prop_Firmware_ForceUpdateRequired_Bool,
		// Token: 0x040001F7 RID: 503
		Prop_ReportsTimeSinceVSync_Bool = 2000,
		// Token: 0x040001F8 RID: 504
		Prop_SecondsFromVsyncToPhotons_Float,
		// Token: 0x040001F9 RID: 505
		Prop_DisplayFrequency_Float,
		// Token: 0x040001FA RID: 506
		Prop_UserIpdMeters_Float,
		// Token: 0x040001FB RID: 507
		Prop_CurrentUniverseId_Uint64,
		// Token: 0x040001FC RID: 508
		Prop_PreviousUniverseId_Uint64,
		// Token: 0x040001FD RID: 509
		Prop_DisplayFirmwareVersion_Uint64,
		// Token: 0x040001FE RID: 510
		Prop_IsOnDesktop_Bool,
		// Token: 0x040001FF RID: 511
		Prop_DisplayMCType_Int32,
		// Token: 0x04000200 RID: 512
		Prop_DisplayMCOffset_Float,
		// Token: 0x04000201 RID: 513
		Prop_DisplayMCScale_Float,
		// Token: 0x04000202 RID: 514
		Prop_EdidVendorID_Int32,
		// Token: 0x04000203 RID: 515
		Prop_DisplayMCImageLeft_String,
		// Token: 0x04000204 RID: 516
		Prop_DisplayMCImageRight_String,
		// Token: 0x04000205 RID: 517
		Prop_DisplayGCBlackClamp_Float,
		// Token: 0x04000206 RID: 518
		Prop_EdidProductID_Int32,
		// Token: 0x04000207 RID: 519
		Prop_CameraToHeadTransform_Matrix34,
		// Token: 0x04000208 RID: 520
		Prop_DisplayGCType_Int32,
		// Token: 0x04000209 RID: 521
		Prop_DisplayGCOffset_Float,
		// Token: 0x0400020A RID: 522
		Prop_DisplayGCScale_Float,
		// Token: 0x0400020B RID: 523
		Prop_DisplayGCPrescale_Float,
		// Token: 0x0400020C RID: 524
		Prop_DisplayGCImage_String,
		// Token: 0x0400020D RID: 525
		Prop_LensCenterLeftU_Float,
		// Token: 0x0400020E RID: 526
		Prop_LensCenterLeftV_Float,
		// Token: 0x0400020F RID: 527
		Prop_LensCenterRightU_Float,
		// Token: 0x04000210 RID: 528
		Prop_LensCenterRightV_Float,
		// Token: 0x04000211 RID: 529
		Prop_UserHeadToEyeDepthMeters_Float,
		// Token: 0x04000212 RID: 530
		Prop_CameraFirmwareVersion_Uint64,
		// Token: 0x04000213 RID: 531
		Prop_CameraFirmwareDescription_String,
		// Token: 0x04000214 RID: 532
		Prop_DisplayFPGAVersion_Uint64,
		// Token: 0x04000215 RID: 533
		Prop_DisplayBootloaderVersion_Uint64,
		// Token: 0x04000216 RID: 534
		Prop_DisplayHardwareVersion_Uint64,
		// Token: 0x04000217 RID: 535
		Prop_AudioFirmwareVersion_Uint64,
		// Token: 0x04000218 RID: 536
		Prop_CameraCompatibilityMode_Int32,
		// Token: 0x04000219 RID: 537
		Prop_AttachedDeviceId_String = 3000,
		// Token: 0x0400021A RID: 538
		Prop_SupportedButtons_Uint64,
		// Token: 0x0400021B RID: 539
		Prop_Axis0Type_Int32,
		// Token: 0x0400021C RID: 540
		Prop_Axis1Type_Int32,
		// Token: 0x0400021D RID: 541
		Prop_Axis2Type_Int32,
		// Token: 0x0400021E RID: 542
		Prop_Axis3Type_Int32,
		// Token: 0x0400021F RID: 543
		Prop_Axis4Type_Int32,
		// Token: 0x04000220 RID: 544
		Prop_FieldOfViewLeftDegrees_Float = 4000,
		// Token: 0x04000221 RID: 545
		Prop_FieldOfViewRightDegrees_Float,
		// Token: 0x04000222 RID: 546
		Prop_FieldOfViewTopDegrees_Float,
		// Token: 0x04000223 RID: 547
		Prop_FieldOfViewBottomDegrees_Float,
		// Token: 0x04000224 RID: 548
		Prop_TrackingRangeMinimumMeters_Float,
		// Token: 0x04000225 RID: 549
		Prop_TrackingRangeMaximumMeters_Float,
		// Token: 0x04000226 RID: 550
		Prop_ModeLabel_String,
		// Token: 0x04000227 RID: 551
		Prop_VendorSpecific_Reserved_Start = 10000,
		// Token: 0x04000228 RID: 552
		Prop_VendorSpecific_Reserved_End = 10999
	}
}
