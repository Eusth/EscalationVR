using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x02000027 RID: 39
	public class CVRApplications
	{
		// Token: 0x06000136 RID: 310 RVA: 0x0000B81D File Offset: 0x00009A1D
		internal CVRApplications(global::System.IntPtr pInterface)
		{
			this.FnTable = (global::Valve.VR.IVRApplications)global::System.Runtime.InteropServices.Marshal.PtrToStructure(pInterface, typeof(global::Valve.VR.IVRApplications));
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000B844 File Offset: 0x00009A44
		public global::Valve.VR.EVRApplicationError AddApplicationManifest(string pchApplicationManifestFullPath, bool bTemporary)
		{
			return this.FnTable.AddApplicationManifest(pchApplicationManifestFullPath, bTemporary);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000B86C File Offset: 0x00009A6C
		public global::Valve.VR.EVRApplicationError RemoveApplicationManifest(string pchApplicationManifestFullPath)
		{
			return this.FnTable.RemoveApplicationManifest(pchApplicationManifestFullPath);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000B894 File Offset: 0x00009A94
		public bool IsApplicationInstalled(string pchAppKey)
		{
			return this.FnTable.IsApplicationInstalled(pchAppKey);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000B8BC File Offset: 0x00009ABC
		public uint GetApplicationCount()
		{
			return this.FnTable.GetApplicationCount();
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000B8E0 File Offset: 0x00009AE0
		public global::Valve.VR.EVRApplicationError GetApplicationKeyByIndex(uint unApplicationIndex, string pchAppKeyBuffer, uint unAppKeyBufferLen)
		{
			return this.FnTable.GetApplicationKeyByIndex(unApplicationIndex, pchAppKeyBuffer, unAppKeyBufferLen);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000B908 File Offset: 0x00009B08
		public global::Valve.VR.EVRApplicationError GetApplicationKeyByProcessId(uint unProcessId, string pchAppKeyBuffer, uint unAppKeyBufferLen)
		{
			return this.FnTable.GetApplicationKeyByProcessId(unProcessId, pchAppKeyBuffer, unAppKeyBufferLen);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000B930 File Offset: 0x00009B30
		public global::Valve.VR.EVRApplicationError LaunchApplication(string pchAppKey)
		{
			return this.FnTable.LaunchApplication(pchAppKey);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000B958 File Offset: 0x00009B58
		public global::Valve.VR.EVRApplicationError LaunchTemplateApplication(string pchTemplateAppKey, string pchNewAppKey, global::Valve.VR.AppOverrideKeys_t[] pKeys)
		{
			return this.FnTable.LaunchTemplateApplication(pchTemplateAppKey, pchNewAppKey, pKeys, (uint)pKeys.Length);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000B984 File Offset: 0x00009B84
		public global::Valve.VR.EVRApplicationError LaunchDashboardOverlay(string pchAppKey)
		{
			return this.FnTable.LaunchDashboardOverlay(pchAppKey);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000B9AC File Offset: 0x00009BAC
		public bool CancelApplicationLaunch(string pchAppKey)
		{
			return this.FnTable.CancelApplicationLaunch(pchAppKey);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000B9D4 File Offset: 0x00009BD4
		public global::Valve.VR.EVRApplicationError IdentifyApplication(uint unProcessId, string pchAppKey)
		{
			return this.FnTable.IdentifyApplication(unProcessId, pchAppKey);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000B9FC File Offset: 0x00009BFC
		public uint GetApplicationProcessId(string pchAppKey)
		{
			return this.FnTable.GetApplicationProcessId(pchAppKey);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000BA24 File Offset: 0x00009C24
		public string GetApplicationsErrorNameFromEnum(global::Valve.VR.EVRApplicationError error)
		{
			global::System.IntPtr intPtr = this.FnTable.GetApplicationsErrorNameFromEnum(error);
			return (string)global::System.Runtime.InteropServices.Marshal.PtrToStructure(intPtr, typeof(string));
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000BA60 File Offset: 0x00009C60
		public uint GetApplicationPropertyString(string pchAppKey, global::Valve.VR.EVRApplicationProperty eProperty, string pchPropertyValueBuffer, uint unPropertyValueBufferLen, ref global::Valve.VR.EVRApplicationError peError)
		{
			return this.FnTable.GetApplicationPropertyString(pchAppKey, eProperty, pchPropertyValueBuffer, unPropertyValueBufferLen, ref peError);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000BA8C File Offset: 0x00009C8C
		public bool GetApplicationPropertyBool(string pchAppKey, global::Valve.VR.EVRApplicationProperty eProperty, ref global::Valve.VR.EVRApplicationError peError)
		{
			return this.FnTable.GetApplicationPropertyBool(pchAppKey, eProperty, ref peError);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0000BAB4 File Offset: 0x00009CB4
		public ulong GetApplicationPropertyUint64(string pchAppKey, global::Valve.VR.EVRApplicationProperty eProperty, ref global::Valve.VR.EVRApplicationError peError)
		{
			return this.FnTable.GetApplicationPropertyUint64(pchAppKey, eProperty, ref peError);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000BADC File Offset: 0x00009CDC
		public global::Valve.VR.EVRApplicationError SetApplicationAutoLaunch(string pchAppKey, bool bAutoLaunch)
		{
			return this.FnTable.SetApplicationAutoLaunch(pchAppKey, bAutoLaunch);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000BB04 File Offset: 0x00009D04
		public bool GetApplicationAutoLaunch(string pchAppKey)
		{
			return this.FnTable.GetApplicationAutoLaunch(pchAppKey);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000BB2C File Offset: 0x00009D2C
		public global::Valve.VR.EVRApplicationError GetStartingApplication(string pchAppKeyBuffer, uint unAppKeyBufferLen)
		{
			return this.FnTable.GetStartingApplication(pchAppKeyBuffer, unAppKeyBufferLen);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000BB54 File Offset: 0x00009D54
		public global::Valve.VR.EVRApplicationTransitionState GetTransitionState()
		{
			return this.FnTable.GetTransitionState();
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000BB78 File Offset: 0x00009D78
		public global::Valve.VR.EVRApplicationError PerformApplicationPrelaunchCheck(string pchAppKey)
		{
			return this.FnTable.PerformApplicationPrelaunchCheck(pchAppKey);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000BBA0 File Offset: 0x00009DA0
		public string GetApplicationsTransitionStateNameFromEnum(global::Valve.VR.EVRApplicationTransitionState state)
		{
			global::System.IntPtr intPtr = this.FnTable.GetApplicationsTransitionStateNameFromEnum(state);
			return (string)global::System.Runtime.InteropServices.Marshal.PtrToStructure(intPtr, typeof(string));
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000BBDC File Offset: 0x00009DDC
		public bool IsQuitUserPromptRequested()
		{
			return this.FnTable.IsQuitUserPromptRequested();
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000BC00 File Offset: 0x00009E00
		public global::Valve.VR.EVRApplicationError LaunchInternalProcess(string pchBinaryPath, string pchArguments, string pchWorkingDirectory)
		{
			return this.FnTable.LaunchInternalProcess(pchBinaryPath, pchArguments, pchWorkingDirectory);
		}

		// Token: 0x040001AF RID: 431
		private global::Valve.VR.IVRApplications FnTable;
	}
}
