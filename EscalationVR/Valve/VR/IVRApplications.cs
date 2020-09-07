using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x0200001D RID: 29
	public struct IVRApplications
	{
		// Token: 0x040000FC RID: 252
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._AddApplicationManifest AddApplicationManifest;

		// Token: 0x040000FD RID: 253
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._RemoveApplicationManifest RemoveApplicationManifest;

		// Token: 0x040000FE RID: 254
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._IsApplicationInstalled IsApplicationInstalled;

		// Token: 0x040000FF RID: 255
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._GetApplicationCount GetApplicationCount;

		// Token: 0x04000100 RID: 256
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._GetApplicationKeyByIndex GetApplicationKeyByIndex;

		// Token: 0x04000101 RID: 257
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._GetApplicationKeyByProcessId GetApplicationKeyByProcessId;

		// Token: 0x04000102 RID: 258
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._LaunchApplication LaunchApplication;

		// Token: 0x04000103 RID: 259
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._LaunchTemplateApplication LaunchTemplateApplication;

		// Token: 0x04000104 RID: 260
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._LaunchDashboardOverlay LaunchDashboardOverlay;

		// Token: 0x04000105 RID: 261
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._CancelApplicationLaunch CancelApplicationLaunch;

		// Token: 0x04000106 RID: 262
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._IdentifyApplication IdentifyApplication;

		// Token: 0x04000107 RID: 263
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._GetApplicationProcessId GetApplicationProcessId;

		// Token: 0x04000108 RID: 264
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._GetApplicationsErrorNameFromEnum GetApplicationsErrorNameFromEnum;

		// Token: 0x04000109 RID: 265
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._GetApplicationPropertyString GetApplicationPropertyString;

		// Token: 0x0400010A RID: 266
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._GetApplicationPropertyBool GetApplicationPropertyBool;

		// Token: 0x0400010B RID: 267
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._GetApplicationPropertyUint64 GetApplicationPropertyUint64;

		// Token: 0x0400010C RID: 268
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._SetApplicationAutoLaunch SetApplicationAutoLaunch;

		// Token: 0x0400010D RID: 269
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._GetApplicationAutoLaunch GetApplicationAutoLaunch;

		// Token: 0x0400010E RID: 270
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._GetStartingApplication GetStartingApplication;

		// Token: 0x0400010F RID: 271
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._GetTransitionState GetTransitionState;

		// Token: 0x04000110 RID: 272
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._PerformApplicationPrelaunchCheck PerformApplicationPrelaunchCheck;

		// Token: 0x04000111 RID: 273
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._GetApplicationsTransitionStateNameFromEnum GetApplicationsTransitionStateNameFromEnum;

		// Token: 0x04000112 RID: 274
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._IsQuitUserPromptRequested IsQuitUserPromptRequested;

		// Token: 0x04000113 RID: 275
		[global::System.Runtime.InteropServices.MarshalAs(38)]
		internal global::Valve.VR.IVRApplications._LaunchInternalProcess LaunchInternalProcess;

		// Token: 0x02000138 RID: 312
		// (Invoke) Token: 0x06000763 RID: 1891
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRApplicationError _AddApplicationManifest(string pchApplicationManifestFullPath, bool bTemporary);

		// Token: 0x02000139 RID: 313
		// (Invoke) Token: 0x06000767 RID: 1895
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRApplicationError _RemoveApplicationManifest(string pchApplicationManifestFullPath);

		// Token: 0x0200013A RID: 314
		// (Invoke) Token: 0x0600076B RID: 1899
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _IsApplicationInstalled(string pchAppKey);

		// Token: 0x0200013B RID: 315
		// (Invoke) Token: 0x0600076F RID: 1903
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetApplicationCount();

		// Token: 0x0200013C RID: 316
		// (Invoke) Token: 0x06000773 RID: 1907
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRApplicationError _GetApplicationKeyByIndex(uint unApplicationIndex, string pchAppKeyBuffer, uint unAppKeyBufferLen);

		// Token: 0x0200013D RID: 317
		// (Invoke) Token: 0x06000777 RID: 1911
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRApplicationError _GetApplicationKeyByProcessId(uint unProcessId, string pchAppKeyBuffer, uint unAppKeyBufferLen);

		// Token: 0x0200013E RID: 318
		// (Invoke) Token: 0x0600077B RID: 1915
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRApplicationError _LaunchApplication(string pchAppKey);

		// Token: 0x0200013F RID: 319
		// (Invoke) Token: 0x0600077F RID: 1919
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRApplicationError _LaunchTemplateApplication(string pchTemplateAppKey, string pchNewAppKey, [global::System.Runtime.InteropServices.In] [global::System.Runtime.InteropServices.Out] global::Valve.VR.AppOverrideKeys_t[] pKeys, uint unKeys);

		// Token: 0x02000140 RID: 320
		// (Invoke) Token: 0x06000783 RID: 1923
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRApplicationError _LaunchDashboardOverlay(string pchAppKey);

		// Token: 0x02000141 RID: 321
		// (Invoke) Token: 0x06000787 RID: 1927
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _CancelApplicationLaunch(string pchAppKey);

		// Token: 0x02000142 RID: 322
		// (Invoke) Token: 0x0600078B RID: 1931
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRApplicationError _IdentifyApplication(uint unProcessId, string pchAppKey);

		// Token: 0x02000143 RID: 323
		// (Invoke) Token: 0x0600078F RID: 1935
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetApplicationProcessId(string pchAppKey);

		// Token: 0x02000144 RID: 324
		// (Invoke) Token: 0x06000793 RID: 1939
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::System.IntPtr _GetApplicationsErrorNameFromEnum(global::Valve.VR.EVRApplicationError error);

		// Token: 0x02000145 RID: 325
		// (Invoke) Token: 0x06000797 RID: 1943
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate uint _GetApplicationPropertyString(string pchAppKey, global::Valve.VR.EVRApplicationProperty eProperty, string pchPropertyValueBuffer, uint unPropertyValueBufferLen, ref global::Valve.VR.EVRApplicationError peError);

		// Token: 0x02000146 RID: 326
		// (Invoke) Token: 0x0600079B RID: 1947
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetApplicationPropertyBool(string pchAppKey, global::Valve.VR.EVRApplicationProperty eProperty, ref global::Valve.VR.EVRApplicationError peError);

		// Token: 0x02000147 RID: 327
		// (Invoke) Token: 0x0600079F RID: 1951
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate ulong _GetApplicationPropertyUint64(string pchAppKey, global::Valve.VR.EVRApplicationProperty eProperty, ref global::Valve.VR.EVRApplicationError peError);

		// Token: 0x02000148 RID: 328
		// (Invoke) Token: 0x060007A3 RID: 1955
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRApplicationError _SetApplicationAutoLaunch(string pchAppKey, bool bAutoLaunch);

		// Token: 0x02000149 RID: 329
		// (Invoke) Token: 0x060007A7 RID: 1959
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _GetApplicationAutoLaunch(string pchAppKey);

		// Token: 0x0200014A RID: 330
		// (Invoke) Token: 0x060007AB RID: 1963
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRApplicationError _GetStartingApplication(string pchAppKeyBuffer, uint unAppKeyBufferLen);

		// Token: 0x0200014B RID: 331
		// (Invoke) Token: 0x060007AF RID: 1967
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRApplicationTransitionState _GetTransitionState();

		// Token: 0x0200014C RID: 332
		// (Invoke) Token: 0x060007B3 RID: 1971
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRApplicationError _PerformApplicationPrelaunchCheck(string pchAppKey);

		// Token: 0x0200014D RID: 333
		// (Invoke) Token: 0x060007B7 RID: 1975
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::System.IntPtr _GetApplicationsTransitionStateNameFromEnum(global::Valve.VR.EVRApplicationTransitionState state);

		// Token: 0x0200014E RID: 334
		// (Invoke) Token: 0x060007BB RID: 1979
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate bool _IsQuitUserPromptRequested();

		// Token: 0x0200014F RID: 335
		// (Invoke) Token: 0x060007BF RID: 1983
		[global::System.Runtime.InteropServices.UnmanagedFunctionPointer(3)]
		internal delegate global::Valve.VR.EVRApplicationError _LaunchInternalProcess(string pchBinaryPath, string pchArguments, string pchWorkingDirectory);
	}
}
