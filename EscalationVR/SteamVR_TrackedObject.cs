using System;
using UnityEngine;
using Valve.VR;

// Token: 0x02000018 RID: 24
public class SteamVR_TrackedObject : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060000EB RID: 235 RVA: 0x0000A464 File Offset: 0x00008664
	private void OnNewPoses(params object[] args)
	{
		bool flag = this.index == global::SteamVR_TrackedObject.EIndex.None;
		if (!flag)
		{
			int num = (int)this.index;
			this.isValid = false;
			global::Valve.VR.TrackedDevicePose_t[] array = (global::Valve.VR.TrackedDevicePose_t[])args[0];
			bool flag2 = array.Length <= num;
			if (!flag2)
			{
				bool flag3 = !array[num].bDeviceIsConnected;
				if (!flag3)
				{
					bool flag4 = !array[num].bPoseIsValid;
					if (!flag4)
					{
						this.isValid = true;
						global::SteamVR_Utils.RigidTransform rigidTransform = new global::SteamVR_Utils.RigidTransform(array[num].mDeviceToAbsoluteTracking);
						bool flag5 = this.origin != null;
						if (flag5)
						{
							rigidTransform = new global::SteamVR_Utils.RigidTransform(this.origin) * rigidTransform;
							rigidTransform.pos.x = rigidTransform.pos.x * this.origin.localScale.x;
							rigidTransform.pos.y = rigidTransform.pos.y * this.origin.localScale.y;
							rigidTransform.pos.z = rigidTransform.pos.z * this.origin.localScale.z;
							base.transform.position = rigidTransform.pos;
							base.transform.rotation = rigidTransform.rot;
						}
						else
						{
							base.transform.localPosition = rigidTransform.pos;
							base.transform.localRotation = rigidTransform.rot;
						}
					}
				}
			}
		}
	}

	// Token: 0x060000EC RID: 236 RVA: 0x0000A5D4 File Offset: 0x000087D4
	private void OnEnable()
	{
		global::SteamVR_Render instance = global::SteamVR_Render.instance;
		bool flag = instance == null;
		if (flag)
		{
			base.enabled = false;
		}
		else
		{
			global::SteamVR_Utils.Event.Listen("new_poses", new global::SteamVR_Utils.Event.Handler(this.OnNewPoses));
		}
	}

	// Token: 0x060000ED RID: 237 RVA: 0x0000A615 File Offset: 0x00008815
	private void OnDisable()
	{
		global::SteamVR_Utils.Event.Remove("new_poses", new global::SteamVR_Utils.Event.Handler(this.OnNewPoses));
	}

	// Token: 0x060000EE RID: 238 RVA: 0x0000A630 File Offset: 0x00008830
	public void SetDeviceIndex(int index)
	{
		bool flag = global::System.Enum.IsDefined(typeof(global::SteamVR_TrackedObject.EIndex), index);
		if (flag)
		{
			this.index = (global::SteamVR_TrackedObject.EIndex)index;
		}
	}

	// Token: 0x040000CA RID: 202
	public global::SteamVR_TrackedObject.EIndex index;

	// Token: 0x040000CB RID: 203
	public global::UnityEngine.Transform origin;

	// Token: 0x040000CC RID: 204
	public bool isValid = false;

	// Token: 0x02000105 RID: 261
	public enum EIndex
	{
		// Token: 0x04000725 RID: 1829
		None = -1,
		// Token: 0x04000726 RID: 1830
		Hmd,
		// Token: 0x04000727 RID: 1831
		Device1,
		// Token: 0x04000728 RID: 1832
		Device2,
		// Token: 0x04000729 RID: 1833
		Device3,
		// Token: 0x0400072A RID: 1834
		Device4,
		// Token: 0x0400072B RID: 1835
		Device5,
		// Token: 0x0400072C RID: 1836
		Device6,
		// Token: 0x0400072D RID: 1837
		Device7,
		// Token: 0x0400072E RID: 1838
		Device8,
		// Token: 0x0400072F RID: 1839
		Device9,
		// Token: 0x04000730 RID: 1840
		Device10,
		// Token: 0x04000731 RID: 1841
		Device11,
		// Token: 0x04000732 RID: 1842
		Device12,
		// Token: 0x04000733 RID: 1843
		Device13,
		// Token: 0x04000734 RID: 1844
		Device14,
		// Token: 0x04000735 RID: 1845
		Device15
	}
}
