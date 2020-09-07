using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using VRGIN.Helpers;

namespace EscalationVR
{
	// Token: 0x020000F2 RID: 242
	public class UnityHelper
	{
		// Token: 0x0600062B RID: 1579 RVA: 0x0001D968 File Offset: 0x0001BB68
		public static global::UnityEngine.Shader GetShader(string name)
		{
			return global::VRGIN.Helpers.UnityHelper.GetShader(name);
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0001D980 File Offset: 0x0001BB80
		public static void DumpScene(string path, bool onlyActive = false)
		{
			global::UnityEngine.Debug.Log("Dumping scene...");
			global::VRGIN.Helpers.JSONArray jsonarray = new global::VRGIN.Helpers.JSONArray();
			foreach (global::UnityEngine.GameObject go2 in global::System.Linq.Enumerable.Where<global::UnityEngine.GameObject>(global::UnityEngine.Object.FindObjectsOfType<global::UnityEngine.GameObject>(), (global::UnityEngine.GameObject go) => go.transform.parent == null))
			{
				jsonarray.Add(global::EscalationVR.UnityHelper.AnalyzeNode(go2, onlyActive));
			}
			global::System.IO.File.WriteAllText(path, jsonarray.ToJSON(0));
			global::UnityEngine.Debug.Log("Done!");
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0001DA28 File Offset: 0x0001BC28
		public static void DumpObject(global::UnityEngine.GameObject obj, string path)
		{
			global::UnityEngine.Debug.Log("Dumping object...");
			global::System.IO.File.WriteAllText(path, global::EscalationVR.UnityHelper.AnalyzeNode(obj, false).ToJSON(0));
			global::UnityEngine.Debug.Log("Done!");
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0001DA58 File Offset: 0x0001BC58
		public static global::System.Collections.Generic.IEnumerable<global::UnityEngine.GameObject> GetRootNodes()
		{
			return global::System.Linq.Enumerable.Where<global::UnityEngine.GameObject>(global::UnityEngine.Object.FindObjectsOfType<global::UnityEngine.GameObject>(), (global::UnityEngine.GameObject go) => go.transform.parent == null);
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0001DA94 File Offset: 0x0001BC94
		public static global::VRGIN.Helpers.JSONClass AnalyzeComponent(global::UnityEngine.Component c)
		{
			global::VRGIN.Helpers.JSONClass jsonclass = new global::VRGIN.Helpers.JSONClass();
			foreach (global::System.Reflection.FieldInfo fieldInfo in c.GetType().GetFields(20))
			{
				try
				{
					string text = global::EscalationVR.UnityHelper.FieldToString(fieldInfo.Name, fieldInfo.GetValue(c));
					bool flag = text != null;
					if (flag)
					{
						jsonclass[fieldInfo.Name] = text;
					}
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogWarningFormat("Failed to get field {0}", new object[]
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
						string text2 = global::EscalationVR.UnityHelper.FieldToString(propertyInfo.Name, propertyInfo.GetValue(c, null));
						bool flag3 = text2 != null;
						if (flag3)
						{
							jsonclass[propertyInfo.Name] = text2;
						}
					}
				}
				catch (global::System.Exception ex2)
				{
					global::UnityEngine.Debug.LogWarningFormat("Failed to get prop {0}", new object[]
					{
						propertyInfo.Name
					});
				}
			}
			return jsonclass;
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0001DBEC File Offset: 0x0001BDEC
		public static string EncodeParameterArgument(string argument, bool force = false)
		{
			bool flag = argument == null;
			if (flag)
			{
				throw new global::System.ArgumentNullException("argument");
			}
			bool flag2 = !force && argument.Length > 0 && argument.IndexOfAny(" \t\n\v\"".ToCharArray()) == -1;
			string result;
			if (flag2)
			{
				result = argument;
			}
			else
			{
				global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
				stringBuilder.Append('"');
				int num = 0;
				int i = 0;
				while (i < argument.Length)
				{
					char c = argument.get_Chars(i);
					char c2 = c;
					char c3 = c2;
					if (c3 == '"')
					{
						stringBuilder.Append('\\', num * 2 + 1);
						stringBuilder.Append(c);
						goto IL_B5;
					}
					if (c3 != '\\')
					{
						stringBuilder.Append('\\', num);
						stringBuilder.Append(c);
						goto IL_B5;
					}
					num++;
					IL_B8:
					i++;
					continue;
					IL_B5:
					num = 0;
					goto IL_B8;
				}
				stringBuilder.Append('\\', num * 2);
				stringBuilder.Append('"');
				result = stringBuilder.ToString();
			}
			return result;
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0001DCE4 File Offset: 0x0001BEE4
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
					global::UnityEngine.Debug.LogWarningFormat(text + ((component2 != null) ? component2.ToString() : null), global::System.Array.Empty<object>());
				}
				else
				{
					jsonclass2[component.GetType().Name] = global::EscalationVR.UnityHelper.AnalyzeComponent(component);
				}
			}
			global::VRGIN.Helpers.JSONArray jsonarray = new global::VRGIN.Helpers.JSONArray();
			foreach (global::UnityEngine.GameObject gameObject in go.Children())
			{
				bool flag2 = !onlyActive || gameObject.activeInHierarchy;
				if (flag2)
				{
					jsonarray.Add(global::EscalationVR.UnityHelper.AnalyzeNode(gameObject, onlyActive));
				}
			}
			jsonclass["Components"] = jsonclass2;
			jsonclass["Children"] = jsonarray;
			return jsonclass;
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0001DEF0 File Offset: 0x0001C0F0
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
						return string.Join(", ", global::EscalationVR.UnityHelper.GetLayerNames((int)value));
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

		// Token: 0x06000633 RID: 1587 RVA: 0x0001DFF8 File Offset: 0x0001C1F8
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

		// Token: 0x0400069D RID: 1693
		private static global::UnityEngine.AssetBundle _SteamVR;
	}
}
