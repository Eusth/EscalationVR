using System;
using UnityEngine;
using Valve.VR;

// Token: 0x02000007 RID: 7
public class SteamVR_ControllerManager : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000054 RID: 84 RVA: 0x00003C84 File Offset: 0x00001E84
	private void Awake()
	{
		int num = (this.objects != null) ? this.objects.Length : 0;
		global::UnityEngine.GameObject[] array = new global::UnityEngine.GameObject[2 + num];
		this.indices = new uint[2 + num];
		array[0] = this.right;
		this.indices[0] = uint.MaxValue;
		array[1] = this.left;
		this.indices[1] = uint.MaxValue;
		for (int i = 0; i < num; i++)
		{
			array[2 + i] = this.objects[i];
			this.indices[2 + i] = uint.MaxValue;
		}
		this.objects = array;
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00003D14 File Offset: 0x00001F14
	private void OnEnable()
	{
		for (int i = 0; i < this.objects.Length; i++)
		{
			global::UnityEngine.GameObject gameObject = this.objects[i];
			bool flag = gameObject != null;
			if (flag)
			{
				gameObject.SetActive(false);
			}
		}
		this.OnTrackedDeviceRoleChanged(global::System.Array.Empty<object>());
		for (int j = 0; j < global::SteamVR.connected.Length; j++)
		{
			bool flag2 = global::SteamVR.connected[j];
			if (flag2)
			{
				this.OnDeviceConnected(new object[]
				{
					j,
					true
				});
			}
		}
		global::SteamVR_Utils.Event.Listen("input_focus", new global::SteamVR_Utils.Event.Handler(this.OnInputFocus));
		global::SteamVR_Utils.Event.Listen("device_connected", new global::SteamVR_Utils.Event.Handler(this.OnDeviceConnected));
		global::SteamVR_Utils.Event.Listen("TrackedDeviceRoleChanged", new global::SteamVR_Utils.Event.Handler(this.OnTrackedDeviceRoleChanged));
	}

	// Token: 0x06000056 RID: 86 RVA: 0x00003DF4 File Offset: 0x00001FF4
	private void OnDisable()
	{
		global::SteamVR_Utils.Event.Remove("input_focus", new global::SteamVR_Utils.Event.Handler(this.OnInputFocus));
		global::SteamVR_Utils.Event.Remove("device_connected", new global::SteamVR_Utils.Event.Handler(this.OnDeviceConnected));
		global::SteamVR_Utils.Event.Remove("TrackedDeviceRoleChanged", new global::SteamVR_Utils.Event.Handler(this.OnTrackedDeviceRoleChanged));
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00003E48 File Offset: 0x00002048
	private void OnInputFocus(params object[] args)
	{
		bool flag = (bool)args[0];
		bool flag2 = flag;
		if (flag2)
		{
			for (int i = 0; i < this.objects.Length; i++)
			{
				global::UnityEngine.GameObject gameObject = this.objects[i];
				bool flag3 = gameObject != null;
				if (flag3)
				{
					string text = (i < 2) ? global::SteamVR_ControllerManager.labels[i] : (i - 1).ToString();
					this.ShowObject(gameObject.transform, "hidden (" + text + ")");
				}
			}
		}
		else
		{
			for (int j = 0; j < this.objects.Length; j++)
			{
				global::UnityEngine.GameObject gameObject2 = this.objects[j];
				bool flag4 = gameObject2 != null;
				if (flag4)
				{
					string text2 = (j < 2) ? global::SteamVR_ControllerManager.labels[j] : (j - 1).ToString();
					this.HideObject(gameObject2.transform, "hidden (" + text2 + ")");
				}
			}
		}
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00003F50 File Offset: 0x00002150
	private void HideObject(global::UnityEngine.Transform t, string name)
	{
		global::UnityEngine.Transform transform = new global::UnityEngine.GameObject(name).transform;
		transform.parent = t.parent;
		t.parent = transform;
		transform.gameObject.SetActive(false);
	}

	// Token: 0x06000059 RID: 89 RVA: 0x00003F8C File Offset: 0x0000218C
	private void ShowObject(global::UnityEngine.Transform t, string name)
	{
		global::UnityEngine.Transform parent = t.parent;
		bool flag = parent.gameObject.name != name;
		if (!flag)
		{
			t.parent = parent.parent;
			global::UnityEngine.Object.Destroy(parent.gameObject);
		}
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00003FD4 File Offset: 0x000021D4
	private void SetTrackedDeviceIndex(int objectIndex, uint trackedDeviceIndex)
	{
		bool flag = trackedDeviceIndex != uint.MaxValue;
		if (flag)
		{
			for (int i = 0; i < this.objects.Length; i++)
			{
				bool flag2 = i != objectIndex && this.indices[i] == trackedDeviceIndex;
				if (flag2)
				{
					global::UnityEngine.GameObject gameObject = this.objects[i];
					bool flag3 = gameObject != null;
					if (flag3)
					{
						gameObject.SetActive(false);
					}
					this.indices[i] = uint.MaxValue;
				}
			}
		}
		bool flag4 = trackedDeviceIndex != this.indices[objectIndex];
		if (flag4)
		{
			this.indices[objectIndex] = trackedDeviceIndex;
			global::UnityEngine.GameObject gameObject2 = this.objects[objectIndex];
			bool flag5 = gameObject2 != null;
			if (flag5)
			{
				bool flag6 = trackedDeviceIndex == uint.MaxValue;
				if (flag6)
				{
					gameObject2.SetActive(false);
				}
				else
				{
					gameObject2.SetActive(true);
					gameObject2.BroadcastMessage("SetDeviceIndex", (int)trackedDeviceIndex, 1);
				}
			}
		}
	}

	// Token: 0x0600005B RID: 91 RVA: 0x000040B6 File Offset: 0x000022B6
	private void OnTrackedDeviceRoleChanged(params object[] args)
	{
		this.Refresh();
	}

	// Token: 0x0600005C RID: 92 RVA: 0x000040C0 File Offset: 0x000022C0
	private void OnDeviceConnected(params object[] args)
	{
		uint num = (uint)((int)args[0]);
		bool flag = this.connected[(int)num];
		this.connected[(int)num] = false;
		bool flag2 = (bool)args[1];
		bool flag3 = flag2;
		if (flag3)
		{
			global::Valve.VR.CVRSystem system = global::Valve.VR.OpenVR.System;
			bool flag4 = system != null && system.GetTrackedDeviceClass(num) == global::Valve.VR.ETrackedDeviceClass.Controller;
			if (flag4)
			{
				this.connected[(int)num] = true;
				flag = !flag;
			}
		}
		bool flag5 = flag;
		if (flag5)
		{
			this.Refresh();
		}
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00004138 File Offset: 0x00002338
	public void Refresh()
	{
		int i = 0;
		global::Valve.VR.CVRSystem system = global::Valve.VR.OpenVR.System;
		bool flag = system != null;
		if (flag)
		{
			this.leftIndex = system.GetTrackedDeviceIndexForControllerRole(global::Valve.VR.ETrackedControllerRole.LeftHand);
			this.rightIndex = system.GetTrackedDeviceIndexForControllerRole(global::Valve.VR.ETrackedControllerRole.RightHand);
		}
		bool flag2 = this.leftIndex == uint.MaxValue && this.rightIndex == uint.MaxValue;
		if (flag2)
		{
			uint num = 0U;
			while ((ulong)num < (ulong)((long)this.connected.Length))
			{
				bool flag3 = this.connected[(int)num];
				if (flag3)
				{
					this.SetTrackedDeviceIndex(i++, num);
					break;
				}
				num += 1U;
			}
		}
		else
		{
			this.SetTrackedDeviceIndex(i++, ((ulong)this.rightIndex < (ulong)((long)this.connected.Length) && this.connected[(int)this.rightIndex]) ? this.rightIndex : uint.MaxValue);
			this.SetTrackedDeviceIndex(i++, ((ulong)this.leftIndex < (ulong)((long)this.connected.Length) && this.connected[(int)this.leftIndex]) ? this.leftIndex : uint.MaxValue);
			bool flag4 = this.leftIndex != uint.MaxValue && this.rightIndex != uint.MaxValue;
			if (flag4)
			{
				uint num2 = 0U;
				while ((ulong)num2 < (ulong)((long)this.connected.Length))
				{
					bool flag5 = i >= this.objects.Length;
					if (flag5)
					{
						break;
					}
					bool flag6 = !this.connected[(int)num2];
					if (!flag6)
					{
						bool flag7 = num2 != this.leftIndex && num2 != this.rightIndex;
						if (flag7)
						{
							this.SetTrackedDeviceIndex(i++, num2);
						}
					}
					num2 += 1U;
				}
			}
		}
		while (i < this.objects.Length)
		{
			this.SetTrackedDeviceIndex(i++, uint.MaxValue);
		}
	}

	// Token: 0x04000023 RID: 35
	public global::UnityEngine.GameObject left;

	// Token: 0x04000024 RID: 36
	public global::UnityEngine.GameObject right;

	// Token: 0x04000025 RID: 37
	public global::UnityEngine.GameObject[] objects;

	// Token: 0x04000026 RID: 38
	private uint[] indices;

	// Token: 0x04000027 RID: 39
	private bool[] connected = new bool[16];

	// Token: 0x04000028 RID: 40
	private uint leftIndex = uint.MaxValue;

	// Token: 0x04000029 RID: 41
	private uint rightIndex = uint.MaxValue;

	// Token: 0x0400002A RID: 42
	private static string[] labels = new string[]
	{
		"left",
		"right"
	};
}
