using System;
using UnityEngine;
using Valve.VR;

// Token: 0x02000008 RID: 8
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.AudioListener))]
public class SteamVR_Ears : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000060 RID: 96 RVA: 0x00004340 File Offset: 0x00002540
	private void OnNewPosesApplied(params object[] args)
	{
		global::UnityEngine.Transform origin = this.vrcam.origin;
		global::UnityEngine.Quaternion quaternion = (origin != null) ? origin.rotation : global::UnityEngine.Quaternion.identity;
		base.transform.rotation = quaternion * this.offset;
	}

	// Token: 0x06000061 RID: 97 RVA: 0x0000438C File Offset: 0x0000258C
	private void OnEnable()
	{
		this.usingSpeakers = false;
		global::Valve.VR.CVRSettings settings = global::Valve.VR.OpenVR.Settings;
		bool flag = settings != null;
		if (flag)
		{
			global::Valve.VR.EVRSettingsError evrsettingsError = global::Valve.VR.EVRSettingsError.None;
			bool @bool = settings.GetBool("steamvr", "usingSpeakers", false, ref evrsettingsError);
			if (@bool)
			{
				this.usingSpeakers = true;
				float @float = settings.GetFloat("steamvr", "speakersForwardYawOffsetDegrees", 0f, ref evrsettingsError);
				this.offset = global::UnityEngine.Quaternion.Euler(0f, @float, 0f);
			}
		}
		bool flag2 = this.usingSpeakers;
		if (flag2)
		{
			global::SteamVR_Utils.Event.Listen("new_poses_applied", new global::SteamVR_Utils.Event.Handler(this.OnNewPosesApplied));
		}
	}

	// Token: 0x06000062 RID: 98 RVA: 0x00004428 File Offset: 0x00002628
	private void OnDisable()
	{
		bool flag = this.usingSpeakers;
		if (flag)
		{
			global::SteamVR_Utils.Event.Remove("new_poses_applied", new global::SteamVR_Utils.Event.Handler(this.OnNewPosesApplied));
		}
	}

	// Token: 0x0400002B RID: 43
	public global::SteamVR_Camera vrcam;

	// Token: 0x0400002C RID: 44
	private bool usingSpeakers;

	// Token: 0x0400002D RID: 45
	private global::UnityEngine.Quaternion offset;
}
