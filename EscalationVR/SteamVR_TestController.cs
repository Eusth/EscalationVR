using System;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

// Token: 0x02000017 RID: 23
public class SteamVR_TestController : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060000E5 RID: 229 RVA: 0x00009EB0 File Offset: 0x000080B0
	private void OnDeviceConnected(params object[] args)
	{
		int num = (int)args[0];
		global::Valve.VR.CVRSystem system = global::Valve.VR.OpenVR.System;
		bool flag = system == null || system.GetTrackedDeviceClass((uint)num) != global::Valve.VR.ETrackedDeviceClass.Controller;
		if (!flag)
		{
			bool flag2 = (bool)args[1];
			bool flag3 = flag2;
			if (flag3)
			{
				global::UnityEngine.Debug.Log(string.Format("Controller {0} connected.", num));
				this.PrintControllerStatus(num);
				this.controllerIndices.Add(num);
			}
			else
			{
				global::UnityEngine.Debug.Log(string.Format("Controller {0} disconnected.", num));
				this.PrintControllerStatus(num);
				this.controllerIndices.Remove(num);
			}
		}
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x00009F52 File Offset: 0x00008152
	private void OnEnable()
	{
		global::SteamVR_Utils.Event.Listen("device_connected", new global::SteamVR_Utils.Event.Handler(this.OnDeviceConnected));
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x00009F6C File Offset: 0x0000816C
	private void OnDisable()
	{
		global::SteamVR_Utils.Event.Remove("device_connected", new global::SteamVR_Utils.Event.Handler(this.OnDeviceConnected));
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x00009F88 File Offset: 0x00008188
	private void PrintControllerStatus(int index)
	{
		global::SteamVR_Controller.Device device = global::SteamVR_Controller.Input(index);
		global::UnityEngine.Debug.Log("index: " + device.index.ToString());
		global::UnityEngine.Debug.Log("connected: " + device.connected.ToString());
		global::UnityEngine.Debug.Log("hasTracking: " + device.hasTracking.ToString());
		global::UnityEngine.Debug.Log("outOfRange: " + device.outOfRange.ToString());
		global::UnityEngine.Debug.Log("calibrating: " + device.calibrating.ToString());
		global::UnityEngine.Debug.Log("uninitialized: " + device.uninitialized.ToString());
		string text = "pos: ";
		global::UnityEngine.Vector3 pos = device.transform.pos;
		global::UnityEngine.Debug.Log(text + pos.ToString());
		global::UnityEngine.Debug.Log("rot: " + device.transform.rot.eulerAngles.ToString());
		global::UnityEngine.Debug.Log("velocity: " + device.velocity.ToString());
		global::UnityEngine.Debug.Log("angularVelocity: " + device.angularVelocity.ToString());
		int deviceIndex = global::SteamVR_Controller.GetDeviceIndex(global::SteamVR_Controller.DeviceRelation.Leftmost, global::Valve.VR.ETrackedDeviceClass.Controller, 0);
		int deviceIndex2 = global::SteamVR_Controller.GetDeviceIndex(global::SteamVR_Controller.DeviceRelation.Rightmost, global::Valve.VR.ETrackedDeviceClass.Controller, 0);
		global::UnityEngine.Debug.Log((deviceIndex == deviceIndex2) ? "first" : ((deviceIndex == index) ? "left" : "right"));
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x0000A130 File Offset: 0x00008330
	private void Update()
	{
		foreach (int num in this.controllerIndices)
		{
			global::SteamVR_Overlay instance = global::SteamVR_Overlay.instance;
			bool flag = instance && this.point && this.pointer;
			if (flag)
			{
				global::SteamVR_Utils.RigidTransform transform = global::SteamVR_Controller.Input(num).transform;
				this.pointer.transform.localPosition = transform.pos;
				this.pointer.transform.localRotation = transform.rot;
				global::SteamVR_Overlay.IntersectionResults intersectionResults = default(global::SteamVR_Overlay.IntersectionResults);
				bool flag2 = instance.ComputeIntersection(transform.pos, transform.rot * global::UnityEngine.Vector3.forward, ref intersectionResults);
				bool flag3 = flag2;
				if (flag3)
				{
					this.point.transform.localPosition = intersectionResults.point;
					this.point.transform.localRotation = global::UnityEngine.Quaternion.LookRotation(intersectionResults.normal);
				}
			}
			else
			{
				foreach (global::Valve.VR.EVRButtonId evrbuttonId in this.buttonIds)
				{
					bool pressDown = global::SteamVR_Controller.Input(num).GetPressDown(evrbuttonId);
					if (pressDown)
					{
						global::UnityEngine.Debug.Log(evrbuttonId.ToString() + " press down");
					}
					bool pressUp = global::SteamVR_Controller.Input(num).GetPressUp(evrbuttonId);
					if (pressUp)
					{
						global::UnityEngine.Debug.Log(evrbuttonId.ToString() + " press up");
						bool flag4 = evrbuttonId == global::Valve.VR.EVRButtonId.k_EButton_Axis1;
						if (flag4)
						{
							global::SteamVR_Controller.Input(num).TriggerHapticPulse(500, global::Valve.VR.EVRButtonId.k_EButton_Axis0);
							this.PrintControllerStatus(num);
						}
					}
					bool press = global::SteamVR_Controller.Input(num).GetPress(evrbuttonId);
					if (press)
					{
						global::UnityEngine.Debug.Log(evrbuttonId);
					}
				}
				foreach (global::Valve.VR.EVRButtonId buttonId in this.axisIds)
				{
					bool touchDown = global::SteamVR_Controller.Input(num).GetTouchDown(buttonId);
					if (touchDown)
					{
						global::UnityEngine.Debug.Log(buttonId.ToString() + " touch down");
					}
					bool touchUp = global::SteamVR_Controller.Input(num).GetTouchUp(buttonId);
					if (touchUp)
					{
						global::UnityEngine.Debug.Log(buttonId.ToString() + " touch up");
					}
					bool touch = global::SteamVR_Controller.Input(num).GetTouch(buttonId);
					if (touch)
					{
						global::UnityEngine.Vector2 axis = global::SteamVR_Controller.Input(num).GetAxis(buttonId);
						string text = "axis: ";
						global::UnityEngine.Vector2 vector = axis;
						global::UnityEngine.Debug.Log(text + vector.ToString());
					}
				}
			}
		}
	}

	// Token: 0x040000C5 RID: 197
	private global::System.Collections.Generic.List<int> controllerIndices = new global::System.Collections.Generic.List<int>();

	// Token: 0x040000C6 RID: 198
	private global::Valve.VR.EVRButtonId[] buttonIds = new global::Valve.VR.EVRButtonId[]
	{
		global::Valve.VR.EVRButtonId.k_EButton_ApplicationMenu,
		global::Valve.VR.EVRButtonId.k_EButton_Grip,
		global::Valve.VR.EVRButtonId.k_EButton_Axis0,
		global::Valve.VR.EVRButtonId.k_EButton_Axis1
	};

	// Token: 0x040000C7 RID: 199
	private global::Valve.VR.EVRButtonId[] axisIds = new global::Valve.VR.EVRButtonId[]
	{
		global::Valve.VR.EVRButtonId.k_EButton_Axis0,
		global::Valve.VR.EVRButtonId.k_EButton_Axis1
	};

	// Token: 0x040000C8 RID: 200
	public global::UnityEngine.Transform point;

	// Token: 0x040000C9 RID: 201
	public global::UnityEngine.Transform pointer;
}
