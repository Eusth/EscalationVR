using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using VRGIN.Core;

namespace VRGIN.Helpers
{
	// Token: 0x020000E7 RID: 231
	public static class UnityHelper
	{
		// Token: 0x060005C5 RID: 1477 RVA: 0x0001C010 File Offset: 0x0001A210
		public static global::UnityEngine.Shader GetShader(string name)
		{
			return global::VRGIN.Helpers.UnityHelper.LoadFromAssetBundle<global::UnityEngine.Shader>(global::VRGIN.Helpers.ResourceManager.SteamVR, name);
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0001C030 File Offset: 0x0001A230
		public static T LoadFromAssetBundle<T>(byte[] assetBundleBytes, string name) where T : global::UnityEngine.Object
		{
			string key = global::VRGIN.Helpers.UnityHelper.GetKey(assetBundleBytes);
			bool flag = !global::VRGIN.Helpers.UnityHelper._AssetBundles.ContainsKey(key);
			if (flag)
			{
				global::VRGIN.Helpers.UnityHelper._AssetBundles[key] = global::VRGIN.Helpers.UnityHelper.LoadAssetBundle(assetBundleBytes);
				bool flag2 = global::VRGIN.Helpers.UnityHelper._AssetBundles[key] == null;
				if (flag2)
				{
					global::VRGIN.Core.VRLog.Error("Looks like the asset bundle failed to load?", global::System.Array.Empty<object>());
				}
			}
			T result;
			try
			{
				global::VRGIN.Core.VRLog.Info("Loading: {0} ({1})", new object[]
				{
					name,
					key
				});
				name = name.Replace("Custom/", "");
				T t = global::VRGIN.Helpers.UnityHelper._AssetBundles[key].LoadAsset<T>(name);
				bool flag3 = !t;
				if (flag3)
				{
					global::VRGIN.Core.VRLog.Error("Failed to load {0}", new object[]
					{
						name
					});
				}
				result = ((!typeof(global::UnityEngine.Shader).IsAssignableFrom(typeof(T)) && !typeof(global::UnityEngine.ComputeShader).IsAssignableFrom(typeof(T))) ? global::UnityEngine.Object.Instantiate<T>(t) : t);
			}
			catch (global::System.Exception obj)
			{
				global::VRGIN.Core.VRLog.Error(obj);
				result = default(T);
			}
			return result;
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0001C16C File Offset: 0x0001A36C
		private static global::UnityEngine.AssetBundle LoadAssetBundle(byte[] bytes)
		{
			bool flag = global::VRGIN.Helpers.UnityHelper._LoadFromMemory != null;
			global::UnityEngine.AssetBundle result;
			if (flag)
			{
				result = (global::VRGIN.Helpers.UnityHelper._LoadFromMemory.Invoke(null, new object[]
				{
					bytes
				}) as global::UnityEngine.AssetBundle);
			}
			else
			{
				bool flag2 = global::VRGIN.Helpers.UnityHelper._CreateFromMemory != null;
				if (flag2)
				{
					result = (global::VRGIN.Helpers.UnityHelper._CreateFromMemory.Invoke(null, new object[]
					{
						bytes
					}) as global::UnityEngine.AssetBundle);
				}
				else
				{
					global::VRGIN.Core.VRLog.Error("Could not find a way to load AssetBundles!", global::System.Array.Empty<object>());
					result = null;
				}
			}
			return result;
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0001C1EC File Offset: 0x0001A3EC
		private static string CalculateChecksum(byte[] byteToCalculate)
		{
			int num = 0;
			foreach (byte b in byteToCalculate)
			{
				num += (int)b;
			}
			return (num & 255).ToString("X2");
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0001C234 File Offset: 0x0001A434
		private static string GetKey(byte[] assetBundleBytes)
		{
			return global::VRGIN.Helpers.UnityHelper.CalculateChecksum(assetBundleBytes);
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0001C24C File Offset: 0x0001A44C
		public static global::UnityEngine.Transform GetDebugBall(string name)
		{
			global::UnityEngine.Transform transform;
			bool flag = !global::VRGIN.Helpers.UnityHelper._DebugBalls.TryGetValue(name, ref transform) || !transform;
			if (flag)
			{
				transform = global::UnityEngine.GameObject.CreatePrimitive(0).transform;
				transform.transform.localScale *= 0.03f;
				global::VRGIN.Helpers.UnityHelper._DebugBalls[name] = transform;
			}
			return transform;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0001C2B8 File Offset: 0x0001A4B8
		public static void DrawDebugBall(global::UnityEngine.Transform transform)
		{
			global::VRGIN.Helpers.UnityHelper.GetDebugBall(transform.GetInstanceID().ToString()).position = transform.position;
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0001C2E5 File Offset: 0x0001A4E5
		public static void DrawRay(global::UnityEngine.Color color, global::UnityEngine.Vector3 origin, global::UnityEngine.Vector3 direction)
		{
			global::VRGIN.Helpers.UnityHelper.DrawRay(color, new global::UnityEngine.Ray(origin, direction.normalized));
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x0001C2FC File Offset: 0x0001A4FC
		public static void DrawRay(global::UnityEngine.Color color, global::UnityEngine.Ray ray)
		{
			global::VRGIN.Helpers.UnityHelper.RayDrawer rayDrawer;
			bool flag = !global::VRGIN.Helpers.UnityHelper._Rays.TryGetValue(color, ref rayDrawer) || !rayDrawer;
			if (flag)
			{
				rayDrawer = global::VRGIN.Helpers.UnityHelper.RayDrawer.Create(color, ray);
				global::VRGIN.Helpers.UnityHelper._Rays[color] = rayDrawer;
			}
			rayDrawer.Touch(ray);
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0001C348 File Offset: 0x0001A548
		public static global::UnityEngine.Transform CreateGameObjectAsChild(string name, global::UnityEngine.Transform parent, bool dontDestroy = false)
		{
			global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject(name);
			gameObject.transform.SetParent(parent, false);
			if (dontDestroy)
			{
				global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
			}
			return gameObject.transform;
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0001C384 File Offset: 0x0001A584
		public static global::UnityEngine.Texture2D LoadImage(string filePath)
		{
			string text = global::System.IO.Path.Combine(global::System.IO.Path.GetDirectoryName(global::System.Reflection.Assembly.GetExecutingAssembly().Location), "Images");
			filePath = global::System.IO.Path.Combine(text, filePath);
			global::UnityEngine.Texture2D texture2D = null;
			bool flag = global::System.IO.File.Exists(filePath);
			if (flag)
			{
				byte[] array = global::System.IO.File.ReadAllBytes(filePath);
				texture2D = new global::UnityEngine.Texture2D(2, 2);
				global::UnityEngine.ImageConversion.LoadImage(texture2D, array);
			}
			else
			{
				global::VRGIN.Core.VRLog.Warn("File " + filePath + " does not exist", global::System.Array.Empty<object>());
			}
			return texture2D;
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x0001C400 File Offset: 0x0001A600
		public static string[] GetLayerNames(int mask)
		{
			global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
			for (int i = 0; i <= 31; i++)
			{
				bool flag = (mask & 1 << i) != 0;
				if (flag)
				{
					list.Add(global::UnityEngine.LayerMask.LayerToName(i));
				}
			}
			return global::System.Linq.Enumerable.ToArray<string>(global::System.Linq.Enumerable.Where<string>(global::System.Linq.Enumerable.Select<string, string>(list, (string m) => m.Trim()), (string m) => m.Length > 0));
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0001C49C File Offset: 0x0001A69C
		public static T CopyComponent<T>(T original, global::UnityEngine.GameObject destination) where T : global::UnityEngine.Component
		{
			global::System.Type type = original.GetType();
			global::UnityEngine.Component component = destination.AddComponent(type);
			global::System.Reflection.FieldInfo[] fields = type.GetFields();
			foreach (global::System.Reflection.FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(component, fieldInfo.GetValue(original));
			}
			return component as T;
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0001C50C File Offset: 0x0001A70C
		public static void DumpScene(string path, bool onlyActive = false)
		{
			global::VRGIN.Core.VRLog.Info("Dumping scene...", global::System.Array.Empty<object>());
			global::VRGIN.Helpers.JSONArray jsonarray = new global::VRGIN.Helpers.JSONArray();
			foreach (global::UnityEngine.GameObject go2 in global::System.Linq.Enumerable.Where<global::UnityEngine.GameObject>(global::UnityEngine.Object.FindObjectsOfType<global::UnityEngine.GameObject>(), (global::UnityEngine.GameObject go) => go.transform.parent == null))
			{
				jsonarray.Add(global::VRGIN.Helpers.UnityHelper.AnalyzeNode(go2, onlyActive));
			}
			global::System.IO.File.WriteAllText(path, jsonarray.ToJSON(0));
			global::VRGIN.Core.VRLog.Info("Done!", global::System.Array.Empty<object>());
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0001C5BC File Offset: 0x0001A7BC
		public static void DumpObject(global::UnityEngine.GameObject obj, string path)
		{
			global::VRGIN.Core.VRLog.Info("Dumping object...", global::System.Array.Empty<object>());
			global::System.IO.File.WriteAllText(path, global::VRGIN.Helpers.UnityHelper.AnalyzeNode(obj, false).ToJSON(0));
			global::VRGIN.Core.VRLog.Info("Done!", global::System.Array.Empty<object>());
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x0001C5F4 File Offset: 0x0001A7F4
		public static global::System.Collections.Generic.IEnumerable<global::UnityEngine.GameObject> GetRootNodes()
		{
			return global::System.Linq.Enumerable.Where<global::UnityEngine.GameObject>(global::UnityEngine.Object.FindObjectsOfType<global::UnityEngine.GameObject>(), (global::UnityEngine.GameObject go) => go.transform.parent == null);
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0001C630 File Offset: 0x0001A830
		public static global::VRGIN.Helpers.JSONClass AnalyzeComponent(global::UnityEngine.Component c)
		{
			global::VRGIN.Helpers.JSONClass jsonclass = new global::VRGIN.Helpers.JSONClass();
			foreach (global::System.Reflection.FieldInfo fieldInfo in c.GetType().GetFields(20))
			{
				try
				{
					string text = global::VRGIN.Helpers.UnityHelper.FieldToString(fieldInfo.Name, fieldInfo.GetValue(c));
					bool flag = text != null;
					if (flag)
					{
						jsonclass[fieldInfo.Name] = text;
					}
				}
				catch (global::System.Exception ex)
				{
					global::VRGIN.Core.VRLog.Warn("Failed to get field {0}", new object[]
					{
						fieldInfo.Name
					});
				}
			}
			foreach (global::System.Reflection.PropertyInfo propertyInfo in c.GetType().GetProperties(20))
			{
				try
				{
					bool flag2 = propertyInfo.GetIndexParameters().Length == 0;
					if (flag2)
					{
						string text2 = global::VRGIN.Helpers.UnityHelper.FieldToString(propertyInfo.Name, propertyInfo.GetValue(c, null));
						bool flag3 = text2 != null;
						if (flag3)
						{
							jsonclass[propertyInfo.Name] = text2;
						}
					}
				}
				catch (global::System.Exception ex2)
				{
					global::VRGIN.Core.VRLog.Warn("Failed to get prop {0}", new object[]
					{
						propertyInfo.Name
					});
				}
			}
			return jsonclass;
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0001C788 File Offset: 0x0001A988
		public static global::VRGIN.Helpers.JSONClass AnalyzeNode(global::UnityEngine.GameObject go, bool onlyActive = false)
		{
			global::VRGIN.Helpers.JSONClass jsonclass = new global::VRGIN.Helpers.JSONClass();
			jsonclass["name"] = go.name;
			jsonclass["active"] = go.activeSelf.ToString();
			jsonclass["tag"] = go.tag;
			jsonclass["layer"] = global::UnityEngine.LayerMask.LayerToName(go.gameObject.layer);
			jsonclass["pos"] = go.transform.localPosition.ToString();
			jsonclass["rot"] = go.transform.localEulerAngles.ToString();
			jsonclass["scale"] = go.transform.localScale.ToString();
			global::VRGIN.Helpers.JSONClass jsonclass2 = new global::VRGIN.Helpers.JSONClass();
			foreach (global::UnityEngine.Component component in go.GetComponents<global::UnityEngine.Component>())
			{
				bool flag = component == null;
				if (flag)
				{
					string text = "NULL component: ";
					global::UnityEngine.Component component2 = component;
					global::VRGIN.Core.VRLog.Warn(text + ((component2 != null) ? component2.ToString() : null), global::System.Array.Empty<object>());
				}
				else
				{
					jsonclass2[component.GetType().Name] = global::VRGIN.Helpers.UnityHelper.AnalyzeComponent(component);
				}
			}
			global::VRGIN.Helpers.JSONArray jsonarray = new global::VRGIN.Helpers.JSONArray();
			foreach (global::UnityEngine.GameObject gameObject in go.Children())
			{
				bool flag2 = !onlyActive || gameObject.activeInHierarchy;
				if (flag2)
				{
					jsonarray.Add(global::VRGIN.Helpers.UnityHelper.AnalyzeNode(gameObject, onlyActive));
				}
			}
			jsonclass["Components"] = jsonclass2;
			jsonclass["Children"] = jsonarray;
			return jsonclass;
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0001C994 File Offset: 0x0001AB94
		private static string FieldToString(string memberName, object value)
		{
			bool flag = value == null;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				if (memberName != null)
				{
					if (memberName == "cullingMask")
					{
						return string.Join(", ", global::VRGIN.Helpers.UnityHelper.GetLayerNames((int)value));
					}
					if (memberName == "renderer")
					{
						return ((global::UnityEngine.Renderer)value).material.shader.name;
					}
				}
				bool flag2 = value is global::UnityEngine.Vector3;
				if (flag2)
				{
					global::UnityEngine.Vector3 vector = (global::UnityEngine.Vector3)value;
					result = string.Format("({0:0.000}, {1:0.000}, {2:0.000})", vector.x, vector.y, vector.z);
				}
				else
				{
					bool flag3 = value is global::UnityEngine.Vector2;
					if (flag3)
					{
						global::UnityEngine.Vector2 vector2 = (global::UnityEngine.Vector2)value;
						result = string.Format("({0:0.000}, {1:0.000})", vector2.x, vector2.y);
					}
					else
					{
						result = value.ToString();
					}
				}
			}
			return result;
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0001CA9C File Offset: 0x0001AC9C
		public static void SetPropertyOrField<T>(T obj, string name, object value)
		{
			global::System.Reflection.PropertyInfo property = typeof(T).GetProperty(name, 52);
			global::System.Reflection.FieldInfo field = typeof(T).GetField(name, 52);
			bool flag = property != null;
			if (flag)
			{
				property.SetValue(obj, value, null);
			}
			else
			{
				bool flag2 = field != null;
				if (flag2)
				{
					field.SetValue(obj, value);
				}
				else
				{
					global::VRGIN.Core.VRLog.Warn("Prop/Field not found!", global::System.Array.Empty<object>());
				}
			}
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0001CB20 File Offset: 0x0001AD20
		public static object GetPropertyOrField<T>(T obj, string name)
		{
			global::System.Reflection.PropertyInfo property = typeof(T).GetProperty(name, 52);
			global::System.Reflection.FieldInfo field = typeof(T).GetField(name, 52);
			bool flag = property != null;
			object result;
			if (flag)
			{
				result = property.GetValue(obj, null);
			}
			else
			{
				bool flag2 = field != null;
				if (flag2)
				{
					result = field.GetValue(obj);
				}
				else
				{
					global::VRGIN.Core.VRLog.Warn("Prop/Field not found!", global::System.Array.Empty<object>());
					result = null;
				}
			}
			return result;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0001CBA4 File Offset: 0x0001ADA4
		public static void SaveTexture(global::UnityEngine.RenderTexture rt, string pngOutPath)
		{
			global::UnityEngine.RenderTexture active = global::UnityEngine.RenderTexture.active;
			try
			{
				global::UnityEngine.Texture2D texture2D = new global::UnityEngine.Texture2D(rt.width, rt.height, 5, false);
				global::UnityEngine.RenderTexture.active = rt;
				texture2D.ReadPixels(new global::UnityEngine.Rect(0f, 0f, (float)rt.width, (float)rt.height), 0, 0);
				texture2D.Apply();
				global::System.IO.File.WriteAllBytes(pngOutPath, global::UnityEngine.ImageConversion.EncodeToPNG(texture2D));
				global::UnityEngine.Object.Destroy(texture2D);
			}
			finally
			{
				global::UnityEngine.RenderTexture.active = active;
			}
		}

		// Token: 0x04000685 RID: 1669
		private static global::UnityEngine.AssetBundle _SteamVR;

		// Token: 0x04000686 RID: 1670
		private static global::System.Collections.Generic.IDictionary<string, global::UnityEngine.AssetBundle> _AssetBundles = new global::System.Collections.Generic.Dictionary<string, global::UnityEngine.AssetBundle>();

		// Token: 0x04000687 RID: 1671
		private static readonly global::System.Reflection.MethodInfo _LoadFromMemory = typeof(global::UnityEngine.AssetBundle).GetMethod("LoadFromMemory", new global::System.Type[]
		{
			typeof(byte[])
		});

		// Token: 0x04000688 RID: 1672
		private static readonly global::System.Reflection.MethodInfo _CreateFromMemory = typeof(global::UnityEngine.AssetBundle).GetMethod("CreateFromMemoryImmediate", new global::System.Type[]
		{
			typeof(byte[])
		});

		// Token: 0x04000689 RID: 1673
		private static global::System.Collections.Generic.Dictionary<global::UnityEngine.Color, global::VRGIN.Helpers.UnityHelper.RayDrawer> _Rays = new global::System.Collections.Generic.Dictionary<global::UnityEngine.Color, global::VRGIN.Helpers.UnityHelper.RayDrawer>();

		// Token: 0x0400068A RID: 1674
		private static global::System.Collections.Generic.Dictionary<string, global::UnityEngine.Transform> _DebugBalls = new global::System.Collections.Generic.Dictionary<string, global::UnityEngine.Transform>();

		// Token: 0x02000227 RID: 551
		private class RayDrawer : global::VRGIN.Core.ProtectedBehaviour
		{
			// Token: 0x06000B55 RID: 2901 RVA: 0x000230A4 File Offset: 0x000212A4
			public static global::VRGIN.Helpers.UnityHelper.RayDrawer Create(global::UnityEngine.Color color, global::UnityEngine.Ray ray)
			{
				string text = "Ray Drawer (";
				global::UnityEngine.Color color2 = color;
				global::VRGIN.Helpers.UnityHelper.RayDrawer rayDrawer = new global::UnityEngine.GameObject(text + color2.ToString() + ")").AddComponent<global::VRGIN.Helpers.UnityHelper.RayDrawer>();
				rayDrawer.gameObject.AddComponent<global::UnityEngine.LineRenderer>();
				rayDrawer._Ray = ray;
				rayDrawer._Color = color;
				return rayDrawer;
			}

			// Token: 0x06000B56 RID: 2902 RVA: 0x000230FA File Offset: 0x000212FA
			public void Touch(global::UnityEngine.Ray ray)
			{
				this._LastTouch = global::UnityEngine.Time.time;
				this._Ray = ray;
				base.gameObject.SetActive(true);
			}

			// Token: 0x06000B57 RID: 2903 RVA: 0x0002311C File Offset: 0x0002131C
			protected override void OnStart()
			{
				base.OnStart();
				this.Renderer = base.GetComponent<global::UnityEngine.LineRenderer>();
				this.Renderer.SetColors(this._Color, this._Color);
				this.Renderer.SetVertexCount(2);
				this.Renderer.useWorldSpace = true;
				this.Renderer.material = global::VRGIN.Core.VR.Context.Materials.Unlit;
				this.Renderer.SetWidth(0.01f, 0.01f);
			}

			// Token: 0x06000B58 RID: 2904 RVA: 0x000231A0 File Offset: 0x000213A0
			protected override void OnUpdate()
			{
				base.OnUpdate();
				this.Renderer.SetPosition(0, (global::UnityEngine.Vector3.Distance(this._Ray.origin, global::VRGIN.Core.VR.Camera.transform.position) < 0.3f) ? (this._Ray.origin + this._Ray.direction * 0.3f) : this._Ray.origin);
				this.Renderer.SetPosition(1, this._Ray.origin + this._Ray.direction * 100f);
				this.CheckAge();
			}

			// Token: 0x06000B59 RID: 2905 RVA: 0x00023254 File Offset: 0x00021454
			private void CheckAge()
			{
				bool flag = global::UnityEngine.Time.time - this._LastTouch > 1f;
				if (flag)
				{
					base.gameObject.SetActive(false);
				}
			}

			// Token: 0x04000824 RID: 2084
			private global::UnityEngine.Ray _Ray;

			// Token: 0x04000825 RID: 2085
			private global::UnityEngine.Color _Color;

			// Token: 0x04000826 RID: 2086
			private float _LastTouch;

			// Token: 0x04000827 RID: 2087
			private global::UnityEngine.LineRenderer Renderer;
		}
	}
}
