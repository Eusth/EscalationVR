using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using VRGIN.Helpers;
using VRGIN.Native;
using VRGIN.Visuals;

namespace VRGIN.Core
{
	// Token: 0x020000AF RID: 175
	public class VRGUI : global::VRGIN.Core.ProtectedBehaviour, global::VRGIN.Core.IScreenGrabber
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000383 RID: 899 RVA: 0x000128A2 File Offset: 0x00010AA2
		// (set) Token: 0x06000384 RID: 900 RVA: 0x000128A9 File Offset: 0x00010AA9
		public static int Width { get; private set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000385 RID: 901 RVA: 0x000128B1 File Offset: 0x00010AB1
		// (set) Token: 0x06000386 RID: 902 RVA: 0x000128B8 File Offset: 0x00010AB8
		public static int Height { get; private set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000387 RID: 903 RVA: 0x000128C0 File Offset: 0x00010AC0
		// (set) Token: 0x06000388 RID: 904 RVA: 0x000128C8 File Offset: 0x00010AC8
		public global::VRGIN.Visuals.SimulatedCursor SoftCursor { get; private set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000389 RID: 905 RVA: 0x000128D4 File Offset: 0x00010AD4
		public static global::VRGIN.Core.VRGUI Instance
		{
			get
			{
				bool flag = !global::VRGIN.Core.VRGUI._Instance;
				if (flag)
				{
					global::VRGIN.Core.VRGUI._Instance = new global::UnityEngine.GameObject("VRGIN_GUI").AddComponent<global::VRGIN.Core.VRGUI>();
					bool simulateCursor = global::VRGIN.Core.VR.Context.SimulateCursor;
					if (simulateCursor)
					{
						global::VRGIN.Core.VRGUI._Instance.SoftCursor = global::VRGIN.Visuals.SimulatedCursor.Create();
						global::VRGIN.Core.VRGUI._Instance.SoftCursor.transform.SetParent(global::VRGIN.Core.VRGUI._Instance.transform, false);
						global::VRGIN.Core.VRLog.Info("Cursor is simulated", global::System.Array.Empty<object>());
					}
				}
				return global::VRGIN.Core.VRGUI._Instance;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600038A RID: 906 RVA: 0x00012962 File Offset: 0x00010B62
		// (set) Token: 0x0600038B RID: 907 RVA: 0x0001296A File Offset: 0x00010B6A
		public global::UnityEngine.RenderTexture uGuiTexture { get; private set; }

		// Token: 0x0600038C RID: 908 RVA: 0x00012974 File Offset: 0x00010B74
		public bool IsInterested(global::UnityEngine.Camera camera)
		{
			return this.FindCameraMapping(camera) != null;
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600038D RID: 909 RVA: 0x00012990 File Offset: 0x00010B90
		// (set) Token: 0x0600038E RID: 910 RVA: 0x00012998 File Offset: 0x00010B98
		public global::UnityEngine.RenderTexture IMGuiTexture { get; private set; }

		// Token: 0x0600038F RID: 911 RVA: 0x000129A4 File Offset: 0x00010BA4
		internal bool Owns(global::UnityEngine.Camera cam)
		{
			return this._CameraMappings.ContainsKey(cam);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x000129C2 File Offset: 0x00010BC2
		public void Listen()
		{
			this._Listeners++;
		}

		// Token: 0x06000391 RID: 913 RVA: 0x000129D3 File Offset: 0x00010BD3
		public void Unlisten()
		{
			this._Listeners--;
		}

		// Token: 0x06000392 RID: 914 RVA: 0x000129E4 File Offset: 0x00010BE4
		protected override void OnAwake()
		{
			global::VRGIN.Native.WindowsInterop.RECT clientRect = global::VRGIN.Native.WindowManager.GetClientRect();
			global::VRGIN.Core.VRGUI.Width = clientRect.Right - clientRect.Left;
			global::VRGIN.Core.VRGUI.Height = clientRect.Bottom - clientRect.Top;
			this.uGuiTexture = new global::UnityEngine.RenderTexture(global::UnityEngine.Screen.width, global::UnityEngine.Screen.height, 24, 7);
			this.uGuiTexture.Create();
			this.IMGuiTexture = new global::UnityEngine.RenderTexture(global::UnityEngine.Screen.width, global::UnityEngine.Screen.height, 0, 7);
			this.IMGuiTexture.Create();
			base.transform.localPosition = global::UnityEngine.Vector3.zero;
			base.transform.localRotation = global::UnityEngine.Quaternion.identity;
			base.transform.gameObject.AddComponent<global::VRGIN.Core.VRGUI.FastGUI>();
			base.transform.gameObject.AddComponent<global::VRGIN.Core.VRGUI.SlowGUI>();
			float num = (float)global::UnityEngine.Screen.height * 0.5f;
			float num2 = (float)global::UnityEngine.Screen.width * 0.5f;
			this._VRGUICamera = new global::UnityEngine.GameObject("VRGIN_GUICamera").AddComponent<global::UnityEngine.Camera>();
			this._VRGUICamera.transform.SetParent(base.transform, false);
			bool flag = global::VRGIN.Core.VR.Context.PreferredGUI == global::VRGIN.Core.GUIType.IMGUI;
			if (flag)
			{
				this._VRGUICamera.transform.position = new global::UnityEngine.Vector3(num2, num, -1f);
				this._VRGUICamera.transform.rotation = global::UnityEngine.Quaternion.identity;
				this._VRGUICamera.orthographicSize = num;
			}
			this._VRGUICamera.cullingMask = global::VRGIN.Core.VR.Context.UILayerMask;
			this._VRGUICamera.depth = 1f;
			this._VRGUICamera.nearClipPlane = global::VRGIN.Core.VR.Context.GuiNearClipPlane;
			this._VRGUICamera.farClipPlane = global::VRGIN.Core.VR.Context.GuiFarClipPlane;
			this._VRGUICamera.targetTexture = this.uGuiTexture;
			this._VRGUICamera.backgroundColor = global::UnityEngine.Color.clear;
			this._VRGUICamera.clearFlags = 2;
			this._VRGUICamera.orthographic = true;
			this._VRGUICamera.useOcclusionCulling = false;
			this._Graphics = typeof(global::UnityEngine.UI.GraphicRegistry).GetField("m_Graphics", 36);
			this._Registry = (this._Graphics.GetValue(global::UnityEngine.UI.GraphicRegistry.instance) as global::System.Collections.IDictionary);
			global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00012C28 File Offset: 0x00010E28
		private bool IsUnprocessed(global::UnityEngine.Canvas c)
		{
			return c.renderMode == null || (c.renderMode == 1 && c.worldCamera != this._VRGUICamera && c.worldCamera.targetTexture == null);
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00012C78 File Offset: 0x00010E78
		protected void CatchCanvas()
		{
			this._VRGUICamera.targetTexture = this.uGuiTexture;
			global::System.Collections.Generic.List<global::UnityEngine.Canvas> list = global::System.Linq.Enumerable.ToList<global::UnityEngine.Canvas>(global::System.Linq.Enumerable.Where<global::UnityEngine.Canvas>(this._Registry.Keys as global::System.Collections.Generic.ICollection<global::UnityEngine.Canvas>, (global::UnityEngine.Canvas c) => c));
			foreach (global::UnityEngine.Canvas canvas in global::System.Linq.Enumerable.Where<global::UnityEngine.Canvas>(list, new global::System.Func<global::UnityEngine.Canvas, bool>(this.IsUnprocessed)))
			{
				bool flag = global::VRGIN.Core.VR.Interpreter.IsIgnoredCanvas(canvas);
				if (!flag)
				{
					global::VRGIN.Core.VRLog.Info("Add {0} [Layer: {1}, SortingLayer: {2}, SortingOrder: {3}, RenderMode: {4}, Camera: {5}, Position: {6} ]", new object[]
					{
						canvas.name,
						global::UnityEngine.LayerMask.LayerToName(canvas.gameObject.layer),
						canvas.sortingLayerName,
						canvas.sortingOrder,
						canvas.renderMode,
						canvas.worldCamera,
						canvas.transform.position
					});
					canvas.renderMode = 1;
					canvas.worldCamera = this._VRGUICamera;
					bool flag2 = (1 << canvas.gameObject.layer & global::VRGIN.Core.VR.Context.UILayerMask) == 0;
					if (flag2)
					{
						int layer = global::UnityEngine.LayerMask.NameToLayer(global::VRGIN.Core.VR.Context.UILayer);
						canvas.gameObject.layer = layer;
						foreach (global::UnityEngine.Transform transform in canvas.gameObject.GetComponentsInChildren<global::UnityEngine.Transform>())
						{
							transform.gameObject.layer = layer;
						}
					}
					bool enforceDefaultGUIMaterials = global::VRGIN.Core.VR.Context.EnforceDefaultGUIMaterials;
					if (enforceDefaultGUIMaterials)
					{
						foreach (global::UnityEngine.UI.Graphic graphic in canvas.gameObject.GetComponentsInChildren<global::UnityEngine.UI.Graphic>())
						{
							graphic.material = graphic.defaultMaterial;
						}
					}
					bool guialternativeSortingMode = global::VRGIN.Core.VR.Context.GUIAlternativeSortingMode;
					if (guialternativeSortingMode)
					{
						global::UnityEngine.UI.GraphicRaycaster component = canvas.GetComponent<global::UnityEngine.UI.GraphicRaycaster>();
						bool flag3 = component;
						if (flag3)
						{
							global::UnityEngine.Object.DestroyImmediate(component);
							global::VRGIN.Core.VRGUI.SortingAwareGraphicRaycaster obj = canvas.gameObject.AddComponent<global::VRGIN.Core.VRGUI.SortingAwareGraphicRaycaster>();
							global::VRGIN.Helpers.UnityHelper.SetPropertyOrField<global::VRGIN.Core.VRGUI.SortingAwareGraphicRaycaster>(obj, "ignoreReversedGraphics", global::VRGIN.Helpers.UnityHelper.GetPropertyOrField<global::UnityEngine.UI.GraphicRaycaster>(component, "ignoreReversedGraphics"));
							global::VRGIN.Helpers.UnityHelper.SetPropertyOrField<global::VRGIN.Core.VRGUI.SortingAwareGraphicRaycaster>(obj, "blockingObjects", global::VRGIN.Helpers.UnityHelper.GetPropertyOrField<global::UnityEngine.UI.GraphicRaycaster>(component, "blockingObjects"));
							global::VRGIN.Helpers.UnityHelper.SetPropertyOrField<global::VRGIN.Core.VRGUI.SortingAwareGraphicRaycaster>(obj, "m_BlockingMask", global::VRGIN.Helpers.UnityHelper.GetPropertyOrField<global::UnityEngine.UI.GraphicRaycaster>(component, "m_BlockingMask"));
						}
					}
				}
			}
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00012F18 File Offset: 0x00011118
		protected override void OnUpdate()
		{
			bool confineMouse = global::VRGIN.Core.VR.Context.ConfineMouse;
			if (confineMouse)
			{
				global::UnityEngine.Cursor.lockState = 2;
			}
			this.EnsureCameraTargets();
			bool flag = this._Listeners > 0;
			if (flag)
			{
				this.CatchCanvas();
			}
			bool flag2 = this._Listeners < 0;
			if (flag2)
			{
				global::VRGIN.Core.VRLog.Warn("Numbers don't add up!", global::System.Array.Empty<object>());
			}
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00012F79 File Offset: 0x00011179
		protected override void OnLevel(int level)
		{
			base.OnLevel(level);
			this._CheckedCameras.Clear();
			this._CameraMappings.Clear();
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00012F9C File Offset: 0x0001119C
		internal void OnAfterGUI()
		{
			bool flag = global::UnityEngine.Event.current.type == 7;
			if (flag)
			{
				global::UnityEngine.RenderTexture.active = this._PrevRT;
			}
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00012FCC File Offset: 0x000111CC
		internal void OnBeforeGUI()
		{
			bool flag = global::UnityEngine.Event.current.type == 7;
			if (flag)
			{
				this._PrevRT = global::UnityEngine.RenderTexture.active;
				global::UnityEngine.RenderTexture.active = this.IMGuiTexture;
				global::UnityEngine.GL.Clear(true, true, global::UnityEngine.Color.clear);
			}
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00013014 File Offset: 0x00011214
		public void AddGrabber(global::VRGIN.Core.IScreenGrabber grabber)
		{
			bool flag = !this._ScreenGrabbers.Contains(grabber);
			if (flag)
			{
				this._ScreenGrabbers.Insert(0, grabber);
				this.RejudgeAll();
			}
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0001304C File Offset: 0x0001124C
		public void RemoveGrabber(global::VRGIN.Core.IScreenGrabber grabber)
		{
			this._ScreenGrabbers.Remove(grabber);
			this.RejudgeAll();
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00013064 File Offset: 0x00011264
		public global::System.Collections.Generic.IEnumerable<global::VRGIN.Core.IScreenGrabber> ScreenGrabbers
		{
			get
			{
				return this._ScreenGrabbers;
			}
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0001307C File Offset: 0x0001127C
		private void RejudgeAll()
		{
			global::System.Collections.Generic.List<global::UnityEngine.Camera> list = global::System.Linq.Enumerable.ToList<global::UnityEngine.Camera>(this._CheckedCameras);
			foreach (global::UnityEngine.Camera camera in list)
			{
				this.AddCamera(camera);
			}
		}

		// Token: 0x0600039D RID: 925 RVA: 0x000130DC File Offset: 0x000112DC
		public void AddCamera(global::UnityEngine.Camera camera)
		{
			global::VRGIN.Core.VRLog.Info("Trying to find a GUI mapping for camera {0}", new object[]
			{
				camera.name
			});
			global::VRGIN.Core.IScreenGrabber screenGrabber = this.FindCameraMapping(camera);
			bool flag = screenGrabber != null;
			if (flag)
			{
				this._CameraMappings[camera] = screenGrabber;
				screenGrabber.OnAssign(camera);
				global::VRGIN.Core.VRLog.Info("Assigned camera {0} to {1}", new object[]
				{
					camera.name,
					screenGrabber
				});
			}
			this._CheckedCameras.Add(camera);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00013158 File Offset: 0x00011358
		private void EnsureCameraTargets()
		{
			global::System.Collections.Generic.List<global::UnityEngine.Camera> list = new global::System.Collections.Generic.List<global::UnityEngine.Camera>();
			foreach (global::System.Collections.Generic.KeyValuePair<global::UnityEngine.Camera, global::VRGIN.Core.IScreenGrabber> keyValuePair in this._CameraMappings)
			{
				bool flag = !keyValuePair.Key;
				if (flag)
				{
					list.Add(keyValuePair.Key);
				}
				else
				{
					bool flag2 = keyValuePair.Key.targetTexture != global::System.Linq.Enumerable.FirstOrDefault<global::UnityEngine.RenderTexture>(keyValuePair.Value.GetTextures());
					if (flag2)
					{
						keyValuePair.Key.targetTexture = global::System.Linq.Enumerable.FirstOrDefault<global::UnityEngine.RenderTexture>(keyValuePair.Value.GetTextures());
					}
				}
			}
			foreach (global::UnityEngine.Camera camera in list)
			{
				this._CameraMappings.Remove(camera);
			}
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00013260 File Offset: 0x00011460
		private global::VRGIN.Core.IScreenGrabber FindCameraMapping(global::UnityEngine.Camera camera)
		{
			foreach (global::VRGIN.Core.IScreenGrabber screenGrabber in this._ScreenGrabbers)
			{
				bool flag = screenGrabber.Check(camera);
				if (flag)
				{
					return screenGrabber;
				}
			}
			bool flag2 = this.Check(camera);
			global::VRGIN.Core.IScreenGrabber result;
			if (flag2)
			{
				result = this;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x000132D8 File Offset: 0x000114D8
		public bool Check(global::UnityEngine.Camera camera)
		{
			return global::VRGIN.Core.VR.Interpreter.IsUICamera(camera);
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x000132F5 File Offset: 0x000114F5
		public global::System.Collections.Generic.IEnumerable<global::UnityEngine.RenderTexture> GetTextures()
		{
			yield return this.uGuiTexture;
			yield return this.IMGuiTexture;
			yield break;
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00013305 File Offset: 0x00011505
		public void OnAssign(global::UnityEngine.Camera camera)
		{
			this._VRGUICamera.depth = global::UnityEngine.Mathf.Min(this._VRGUICamera.depth, camera.depth - 1f);
		}

		// Token: 0x0400058A RID: 1418
		private static global::VRGIN.Core.VRGUI _Instance;

		// Token: 0x0400058B RID: 1419
		private global::System.Collections.IDictionary _Registry;

		// Token: 0x0400058F RID: 1423
		private global::System.Collections.Generic.List<global::VRGIN.Core.IScreenGrabber> _ScreenGrabbers = new global::System.Collections.Generic.List<global::VRGIN.Core.IScreenGrabber>();

		// Token: 0x04000592 RID: 1426
		private global::System.Reflection.FieldInfo _Graphics;

		// Token: 0x04000593 RID: 1427
		private global::UnityEngine.RenderTexture _PrevRT = null;

		// Token: 0x04000594 RID: 1428
		private global::UnityEngine.Camera _VRGUICamera;

		// Token: 0x04000595 RID: 1429
		private int _Listeners;

		// Token: 0x04000596 RID: 1430
		private global::System.Collections.Generic.IDictionary<global::UnityEngine.Camera, global::VRGIN.Core.IScreenGrabber> _CameraMappings = new global::System.Collections.Generic.Dictionary<global::UnityEngine.Camera, global::VRGIN.Core.IScreenGrabber>();

		// Token: 0x04000597 RID: 1431
		private global::System.Collections.Generic.HashSet<global::UnityEngine.Camera> _CheckedCameras = new global::System.Collections.Generic.HashSet<global::UnityEngine.Camera>();

		// Token: 0x020001FF RID: 511
		private class FastGUI : global::UnityEngine.MonoBehaviour
		{
			// Token: 0x06000A8C RID: 2700 RVA: 0x00021200 File Offset: 0x0001F400
			private void OnGUI()
			{
				global::UnityEngine.GUI.depth = int.MaxValue;
				bool flag = global::UnityEngine.Event.current.type == 7;
				if (flag)
				{
					base.SendMessage("OnBeforeGUI");
				}
			}
		}

		// Token: 0x02000200 RID: 512
		private class SlowGUI : global::UnityEngine.MonoBehaviour
		{
			// Token: 0x06000A8E RID: 2702 RVA: 0x00021244 File Offset: 0x0001F444
			private void OnGUI()
			{
				global::UnityEngine.GUI.depth = int.MinValue;
				bool flag = global::UnityEngine.Event.current.type == 7;
				if (flag)
				{
					base.SendMessage("OnAfterGUI");
				}
			}
		}

		// Token: 0x02000201 RID: 513
		private class SortingAwareGraphicRaycaster : global::UnityEngine.UI.GraphicRaycaster
		{
			// Token: 0x17000155 RID: 341
			// (get) Token: 0x06000A90 RID: 2704 RVA: 0x00021288 File Offset: 0x0001F488
			private global::UnityEngine.Canvas Canvas
			{
				get
				{
					bool flag = this._Canvas != null;
					global::UnityEngine.Canvas canvas;
					if (flag)
					{
						canvas = this._Canvas;
					}
					else
					{
						this._Canvas = base.GetComponent<global::UnityEngine.Canvas>();
						canvas = this._Canvas;
					}
					return canvas;
				}
			}

			// Token: 0x17000156 RID: 342
			// (get) Token: 0x06000A91 RID: 2705 RVA: 0x000212C8 File Offset: 0x0001F4C8
			public override int priority
			{
				get
				{
					return this.GetOrder();
				}
			}

			// Token: 0x17000157 RID: 343
			// (get) Token: 0x06000A92 RID: 2706 RVA: 0x000212E0 File Offset: 0x0001F4E0
			public override int sortOrderPriority
			{
				get
				{
					return this.GetOrder();
				}
			}

			// Token: 0x17000158 RID: 344
			// (get) Token: 0x06000A93 RID: 2707 RVA: 0x000212F8 File Offset: 0x0001F4F8
			public override int renderOrderPriority
			{
				get
				{
					return this.GetOrder();
				}
			}

			// Token: 0x06000A94 RID: 2708 RVA: 0x00021310 File Offset: 0x0001F510
			private int GetOrder()
			{
				return -this.Canvas.sortingOrder;
			}

			// Token: 0x04000795 RID: 1941
			private global::UnityEngine.Canvas _Canvas;
		}
	}
}
