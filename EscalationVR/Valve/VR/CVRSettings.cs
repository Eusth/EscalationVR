using System;
using System.Runtime.InteropServices;

namespace Valve.VR
{
	// Token: 0x0200002E RID: 46
	public class CVRSettings
	{
		// Token: 0x060001E2 RID: 482 RVA: 0x0000D1D9 File Offset: 0x0000B3D9
		internal CVRSettings(global::System.IntPtr pInterface)
		{
			this.FnTable = (global::Valve.VR.IVRSettings)global::System.Runtime.InteropServices.Marshal.PtrToStructure(pInterface, typeof(global::Valve.VR.IVRSettings));
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0000D200 File Offset: 0x0000B400
		public string GetSettingsErrorNameFromEnum(global::Valve.VR.EVRSettingsError eError)
		{
			global::System.IntPtr intPtr = this.FnTable.GetSettingsErrorNameFromEnum(eError);
			return (string)global::System.Runtime.InteropServices.Marshal.PtrToStructure(intPtr, typeof(string));
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000D23C File Offset: 0x0000B43C
		public bool Sync(bool bForce, ref global::Valve.VR.EVRSettingsError peError)
		{
			return this.FnTable.Sync(bForce, ref peError);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000D264 File Offset: 0x0000B464
		public bool GetBool(string pchSection, string pchSettingsKey, bool bDefaultValue, ref global::Valve.VR.EVRSettingsError peError)
		{
			return this.FnTable.GetBool(pchSection, pchSettingsKey, bDefaultValue, ref peError);
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000D28D File Offset: 0x0000B48D
		public void SetBool(string pchSection, string pchSettingsKey, bool bValue, ref global::Valve.VR.EVRSettingsError peError)
		{
			this.FnTable.SetBool(pchSection, pchSettingsKey, bValue, ref peError);
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0000D2A8 File Offset: 0x0000B4A8
		public int GetInt32(string pchSection, string pchSettingsKey, int nDefaultValue, ref global::Valve.VR.EVRSettingsError peError)
		{
			return this.FnTable.GetInt32(pchSection, pchSettingsKey, nDefaultValue, ref peError);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000D2D1 File Offset: 0x0000B4D1
		public void SetInt32(string pchSection, string pchSettingsKey, int nValue, ref global::Valve.VR.EVRSettingsError peError)
		{
			this.FnTable.SetInt32(pchSection, pchSettingsKey, nValue, ref peError);
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0000D2EC File Offset: 0x0000B4EC
		public float GetFloat(string pchSection, string pchSettingsKey, float flDefaultValue, ref global::Valve.VR.EVRSettingsError peError)
		{
			return this.FnTable.GetFloat(pchSection, pchSettingsKey, flDefaultValue, ref peError);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000D315 File Offset: 0x0000B515
		public void SetFloat(string pchSection, string pchSettingsKey, float flValue, ref global::Valve.VR.EVRSettingsError peError)
		{
			this.FnTable.SetFloat(pchSection, pchSettingsKey, flValue, ref peError);
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0000D32E File Offset: 0x0000B52E
		public void GetString(string pchSection, string pchSettingsKey, string pchValue, uint unValueLen, string pchDefaultValue, ref global::Valve.VR.EVRSettingsError peError)
		{
			this.FnTable.GetString(pchSection, pchSettingsKey, pchValue, unValueLen, pchDefaultValue, ref peError);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0000D34B File Offset: 0x0000B54B
		public void SetString(string pchSection, string pchSettingsKey, string pchValue, ref global::Valve.VR.EVRSettingsError peError)
		{
			this.FnTable.SetString(pchSection, pchSettingsKey, pchValue, ref peError);
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0000D364 File Offset: 0x0000B564
		public void RemoveSection(string pchSection, ref global::Valve.VR.EVRSettingsError peError)
		{
			this.FnTable.RemoveSection(pchSection, ref peError);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0000D37A File Offset: 0x0000B57A
		public void RemoveKeyInSection(string pchSection, string pchSettingsKey, ref global::Valve.VR.EVRSettingsError peError)
		{
			this.FnTable.RemoveKeyInSection(pchSection, pchSettingsKey, ref peError);
		}

		// Token: 0x040001B6 RID: 438
		private global::Valve.VR.IVRSettings FnTable;
	}
}
