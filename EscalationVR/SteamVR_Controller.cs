using System;
using UnityEngine;
using Valve.VR;

// Token: 0x02000006 RID: 6
public class SteamVR_Controller
{
	// Token: 0x06000050 RID: 80 RVA: 0x00003A44 File Offset: 0x00001C44
	public static global::SteamVR_Controller.Device Input(int deviceIndex)
	{
		bool flag = global::SteamVR_Controller.devices == null;
		if (flag)
		{
			global::SteamVR_Controller.devices = new global::SteamVR_Controller.Device[16];
			uint num = 0U;
			while ((ulong)num < (ulong)((long)global::SteamVR_Controller.devices.Length))
			{
				global::SteamVR_Controller.devices[(int)num] = new global::SteamVR_Controller.Device(num);
				num += 1U;
			}
		}
		return global::SteamVR_Controller.devices[deviceIndex];
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00003A9C File Offset: 0x00001C9C
	public static void Update()
	{
		int num = 0;
		while ((long)num < 16L)
		{
			global::SteamVR_Controller.Input(num).Update();
			num++;
		}
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00003ACC File Offset: 0x00001CCC
	public static int GetDeviceIndex(global::SteamVR_Controller.DeviceRelation relation, global::Valve.VR.ETrackedDeviceClass deviceClass = global::Valve.VR.ETrackedDeviceClass.Controller, int relativeTo = 0)
	{
		int num = -1;
		global::SteamVR_Utils.RigidTransform t = (relativeTo < 16) ? global::SteamVR_Controller.Input(relativeTo).transform.GetInverse() : global::SteamVR_Utils.RigidTransform.identity;
		global::Valve.VR.CVRSystem system = global::Valve.VR.OpenVR.System;
		bool flag = system == null;
		int result;
		if (flag)
		{
			result = num;
		}
		else
		{
			float num2 = float.MinValue;
			int num3 = 0;
			while ((long)num3 < 16L)
			{
				bool flag2 = num3 == relativeTo || system.GetTrackedDeviceClass((uint)num3) != deviceClass;
				if (!flag2)
				{
					global::SteamVR_Controller.Device device = global::SteamVR_Controller.Input(num3);
					bool flag3 = !device.connected;
					if (!flag3)
					{
						bool flag4 = relation == global::SteamVR_Controller.DeviceRelation.First;
						if (flag4)
						{
							return num3;
						}
						global::UnityEngine.Vector3 vector = t * device.transform.pos;
						bool flag5 = relation == global::SteamVR_Controller.DeviceRelation.FarthestRight;
						float num4;
						if (flag5)
						{
							num4 = vector.x;
						}
						else
						{
							bool flag6 = relation == global::SteamVR_Controller.DeviceRelation.FarthestLeft;
							if (flag6)
							{
								num4 = -vector.x;
							}
							else
							{
								global::UnityEngine.Vector3 normalized = new global::UnityEngine.Vector3(vector.x, 0f, vector.z).normalized;
								float num5 = global::UnityEngine.Vector3.Dot(normalized, global::UnityEngine.Vector3.forward);
								global::UnityEngine.Vector3 vector2 = global::UnityEngine.Vector3.Cross(normalized, global::UnityEngine.Vector3.forward);
								bool flag7 = relation == global::SteamVR_Controller.DeviceRelation.Leftmost;
								if (flag7)
								{
									num4 = ((vector2.y > 0f) ? (2f - num5) : num5);
								}
								else
								{
									num4 = ((vector2.y < 0f) ? (2f - num5) : num5);
								}
							}
						}
						bool flag8 = num4 > num2;
						if (flag8)
						{
							num = num3;
							num2 = num4;
						}
					}
				}
				num3++;
			}
			result = num;
		}
		return result;
	}

	// Token: 0x04000022 RID: 34
	private static global::SteamVR_Controller.Device[] devices;

	// Token: 0x020000F6 RID: 246
	public class ButtonMask
	{
		// Token: 0x040006A7 RID: 1703
		public const ulong System = 1UL;

		// Token: 0x040006A8 RID: 1704
		public const ulong ApplicationMenu = 2UL;

		// Token: 0x040006A9 RID: 1705
		public const ulong Grip = 4UL;

		// Token: 0x040006AA RID: 1706
		public const ulong Axis0 = 4294967296UL;

		// Token: 0x040006AB RID: 1707
		public const ulong Axis1 = 8589934592UL;

		// Token: 0x040006AC RID: 1708
		public const ulong Axis2 = 17179869184UL;

		// Token: 0x040006AD RID: 1709
		public const ulong Axis3 = 34359738368UL;

		// Token: 0x040006AE RID: 1710
		public const ulong Axis4 = 68719476736UL;

		// Token: 0x040006AF RID: 1711
		public const ulong Touchpad = 4294967296UL;

		// Token: 0x040006B0 RID: 1712
		public const ulong Trigger = 8589934592UL;
	}

	// Token: 0x020000F7 RID: 247
	public class Device
	{
		// Token: 0x0600063D RID: 1597 RVA: 0x0001E102 File Offset: 0x0001C302
		public Device(uint i)
		{
			this.index = i;
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x0001E126 File Offset: 0x0001C326
		// (set) Token: 0x0600063F RID: 1599 RVA: 0x0001E12E File Offset: 0x0001C32E
		public uint index { get; private set; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x0001E137 File Offset: 0x0001C337
		// (set) Token: 0x06000641 RID: 1601 RVA: 0x0001E13F File Offset: 0x0001C33F
		public bool valid { get; private set; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000642 RID: 1602 RVA: 0x0001E148 File Offset: 0x0001C348
		public bool connected
		{
			get
			{
				this.Update();
				return this.pose.bDeviceIsConnected;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000643 RID: 1603 RVA: 0x0001E16C File Offset: 0x0001C36C
		public bool hasTracking
		{
			get
			{
				this.Update();
				return this.pose.bPoseIsValid;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000644 RID: 1604 RVA: 0x0001E190 File Offset: 0x0001C390
		public bool outOfRange
		{
			get
			{
				this.Update();
				return this.pose.eTrackingResult == global::Valve.VR.ETrackingResult.Running_OutOfRange || this.pose.eTrackingResult == global::Valve.VR.ETrackingResult.Calibrating_OutOfRange;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x0001E1D0 File Offset: 0x0001C3D0
		public bool calibrating
		{
			get
			{
				this.Update();
				return this.pose.eTrackingResult == global::Valve.VR.ETrackingResult.Calibrating_InProgress || this.pose.eTrackingResult == global::Valve.VR.ETrackingResult.Calibrating_OutOfRange;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000646 RID: 1606 RVA: 0x0001E20C File Offset: 0x0001C40C
		public bool uninitialized
		{
			get
			{
				this.Update();
				return this.pose.eTrackingResult == global::Valve.VR.ETrackingResult.Uninitialized;
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x0001E234 File Offset: 0x0001C434
		public global::SteamVR_Utils.RigidTransform transform
		{
			get
			{
				this.Update();
				return new global::SteamVR_Utils.RigidTransform(this.pose.mDeviceToAbsoluteTracking);
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000648 RID: 1608 RVA: 0x0001E260 File Offset: 0x0001C460
		public global::UnityEngine.Vector3 velocity
		{
			get
			{
				this.Update();
				return new global::UnityEngine.Vector3(this.pose.vVelocity.v0, this.pose.vVelocity.v1, -this.pose.vVelocity.v2);
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x0001E2B0 File Offset: 0x0001C4B0
		public global::UnityEngine.Vector3 angularVelocity
		{
			get
			{
				this.Update();
				return new global::UnityEngine.Vector3(-this.pose.vAngularVelocity.v0, -this.pose.vAngularVelocity.v1, this.pose.vAngularVelocity.v2);
			}
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0001E300 File Offset: 0x0001C500
		public global::Valve.VR.VRControllerState_t GetState()
		{
			this.Update();
			return this.state;
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x0001E320 File Offset: 0x0001C520
		public global::Valve.VR.VRControllerState_t GetPrevState()
		{
			this.Update();
			return this.prevState;
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x0001E340 File Offset: 0x0001C540
		public global::Valve.VR.TrackedDevicePose_t GetPose()
		{
			this.Update();
			return this.pose;
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0001E360 File Offset: 0x0001C560
		public void Update()
		{
			bool flag = global::UnityEngine.Time.frameCount != this.prevFrameCount;
			if (flag)
			{
				this.prevFrameCount = global::UnityEngine.Time.frameCount;
				this.prevState = this.state;
				global::Valve.VR.CVRSystem system = global::Valve.VR.OpenVR.System;
				bool flag2 = system != null;
				if (flag2)
				{
					this.valid = system.GetControllerStateWithPose(global::SteamVR_Render.instance.trackingSpace, this.index, ref this.state, ref this.pose);
					this.UpdateHairTrigger();
				}
			}
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x0001E3DC File Offset: 0x0001C5DC
		public bool GetPress(ulong buttonMask)
		{
			this.Update();
			return (this.state.ulButtonPressed & buttonMask) > 0UL;
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0001E408 File Offset: 0x0001C608
		public bool GetPressDown(ulong buttonMask)
		{
			this.Update();
			return (this.state.ulButtonPressed & buttonMask) != 0UL && (this.prevState.ulButtonPressed & buttonMask) == 0UL;
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0001E444 File Offset: 0x0001C644
		public bool GetPressUp(ulong buttonMask)
		{
			this.Update();
			return (this.state.ulButtonPressed & buttonMask) == 0UL && (this.prevState.ulButtonPressed & buttonMask) > 0UL;
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0001E480 File Offset: 0x0001C680
		public bool GetPress(global::Valve.VR.EVRButtonId buttonId)
		{
			return this.GetPress(1UL << (int)buttonId);
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0001E4A0 File Offset: 0x0001C6A0
		public bool GetPressDown(global::Valve.VR.EVRButtonId buttonId)
		{
			return this.GetPressDown(1UL << (int)buttonId);
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0001E4C0 File Offset: 0x0001C6C0
		public bool GetPressUp(global::Valve.VR.EVRButtonId buttonId)
		{
			return this.GetPressUp(1UL << (int)buttonId);
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0001E4E0 File Offset: 0x0001C6E0
		public bool GetTouch(ulong buttonMask)
		{
			this.Update();
			return (this.state.ulButtonTouched & buttonMask) > 0UL;
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0001E50C File Offset: 0x0001C70C
		public bool GetTouchDown(ulong buttonMask)
		{
			this.Update();
			return (this.state.ulButtonTouched & buttonMask) != 0UL && (this.prevState.ulButtonTouched & buttonMask) == 0UL;
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0001E548 File Offset: 0x0001C748
		public bool GetTouchUp(ulong buttonMask)
		{
			this.Update();
			return (this.state.ulButtonTouched & buttonMask) == 0UL && (this.prevState.ulButtonTouched & buttonMask) > 0UL;
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x0001E584 File Offset: 0x0001C784
		public bool GetTouch(global::Valve.VR.EVRButtonId buttonId)
		{
			return this.GetTouch(1UL << (int)buttonId);
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0001E5A4 File Offset: 0x0001C7A4
		public bool GetTouchDown(global::Valve.VR.EVRButtonId buttonId)
		{
			return this.GetTouchDown(1UL << (int)buttonId);
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0001E5C4 File Offset: 0x0001C7C4
		public bool GetTouchUp(global::Valve.VR.EVRButtonId buttonId)
		{
			return this.GetTouchUp(1UL << (int)buttonId);
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0001E5E4 File Offset: 0x0001C7E4
		public global::UnityEngine.Vector2 GetAxis(global::Valve.VR.EVRButtonId buttonId = global::Valve.VR.EVRButtonId.k_EButton_Axis0)
		{
			this.Update();
			global::UnityEngine.Vector2 result;
			switch (buttonId)
			{
			case global::Valve.VR.EVRButtonId.k_EButton_Axis0:
				result = new global::UnityEngine.Vector2(this.state.rAxis0.x, this.state.rAxis0.y);
				break;
			case global::Valve.VR.EVRButtonId.k_EButton_Axis1:
				result = new global::UnityEngine.Vector2(this.state.rAxis1.x, this.state.rAxis1.y);
				break;
			case global::Valve.VR.EVRButtonId.k_EButton_Axis2:
				result = new global::UnityEngine.Vector2(this.state.rAxis2.x, this.state.rAxis2.y);
				break;
			case global::Valve.VR.EVRButtonId.k_EButton_Axis3:
				result = new global::UnityEngine.Vector2(this.state.rAxis3.x, this.state.rAxis3.y);
				break;
			case global::Valve.VR.EVRButtonId.k_EButton_Axis4:
				result = new global::UnityEngine.Vector2(this.state.rAxis4.x, this.state.rAxis4.y);
				break;
			default:
				result = global::UnityEngine.Vector2.zero;
				break;
			}
			return result;
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0001E6F8 File Offset: 0x0001C8F8
		public void TriggerHapticPulse(ushort durationMicroSec = 500, global::Valve.VR.EVRButtonId buttonId = global::Valve.VR.EVRButtonId.k_EButton_Axis0)
		{
			global::Valve.VR.CVRSystem system = global::Valve.VR.OpenVR.System;
			bool flag = system != null;
			if (flag)
			{
				uint unAxisId = (uint)(buttonId - global::Valve.VR.EVRButtonId.k_EButton_Axis0);
				system.TriggerHapticPulse(this.index, unAxisId, (char)durationMicroSec);
			}
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0001E72C File Offset: 0x0001C92C
		private void UpdateHairTrigger()
		{
			this.hairTriggerPrevState = this.hairTriggerState;
			float x = this.state.rAxis1.x;
			bool flag = this.hairTriggerState;
			if (flag)
			{
				bool flag2 = x < this.hairTriggerLimit - this.hairTriggerDelta || x <= 0f;
				if (flag2)
				{
					this.hairTriggerState = false;
				}
			}
			else
			{
				bool flag3 = x > this.hairTriggerLimit + this.hairTriggerDelta || x >= 1f;
				if (flag3)
				{
					this.hairTriggerState = true;
				}
			}
			this.hairTriggerLimit = (this.hairTriggerState ? global::UnityEngine.Mathf.Max(this.hairTriggerLimit, x) : global::UnityEngine.Mathf.Min(this.hairTriggerLimit, x));
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0001E7E4 File Offset: 0x0001C9E4
		public bool GetHairTrigger()
		{
			this.Update();
			return this.hairTriggerState;
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0001E804 File Offset: 0x0001CA04
		public bool GetHairTriggerDown()
		{
			this.Update();
			return this.hairTriggerState && !this.hairTriggerPrevState;
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0001E834 File Offset: 0x0001CA34
		public bool GetHairTriggerUp()
		{
			this.Update();
			return !this.hairTriggerState && this.hairTriggerPrevState;
		}

		// Token: 0x040006B3 RID: 1715
		private global::Valve.VR.VRControllerState_t state;

		// Token: 0x040006B4 RID: 1716
		private global::Valve.VR.VRControllerState_t prevState;

		// Token: 0x040006B5 RID: 1717
		private global::Valve.VR.TrackedDevicePose_t pose;

		// Token: 0x040006B6 RID: 1718
		private int prevFrameCount = -1;

		// Token: 0x040006B7 RID: 1719
		public float hairTriggerDelta = 0.1f;

		// Token: 0x040006B8 RID: 1720
		private float hairTriggerLimit;

		// Token: 0x040006B9 RID: 1721
		private bool hairTriggerState;

		// Token: 0x040006BA RID: 1722
		private bool hairTriggerPrevState;
	}

	// Token: 0x020000F8 RID: 248
	public enum DeviceRelation
	{
		// Token: 0x040006BC RID: 1724
		First,
		// Token: 0x040006BD RID: 1725
		Leftmost,
		// Token: 0x040006BE RID: 1726
		Rightmost,
		// Token: 0x040006BF RID: 1727
		FarthestLeft,
		// Token: 0x040006C0 RID: 1728
		FarthestRight
	}
}
