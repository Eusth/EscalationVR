using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;

namespace EscalationVR
{
	// Token: 0x020000EC RID: 236
	public static class GameObjectExtensions
	{
		// Token: 0x060005F9 RID: 1529 RVA: 0x0001D154 File Offset: 0x0001B354
		public static global::System.Collections.Generic.IEnumerable<global::UnityEngine.MonoBehaviour> GetCameraEffects(this global::UnityEngine.GameObject go)
		{
			return global::System.Linq.Enumerable.Where<global::UnityEngine.MonoBehaviour>(go.GetComponents<global::UnityEngine.MonoBehaviour>(), new global::System.Func<global::UnityEngine.MonoBehaviour, bool>(global::EscalationVR.GameObjectExtensions.IsCameraEffect));
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0001D180 File Offset: 0x0001B380
		private static bool IsCameraEffect(global::UnityEngine.MonoBehaviour component)
		{
			return global::EscalationVR.GameObjectExtensions.IsImageEffect(component.GetType());
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x0001D1A0 File Offset: 0x0001B3A0
		public static int Level(this global::UnityEngine.GameObject go)
		{
			return go.transform.parent ? (go.transform.parent.gameObject.Level() + 1) : 0;
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x0001D1E0 File Offset: 0x0001B3E0
		private static bool IsImageEffect(global::System.Type type)
		{
			return type != null && (type.Name.EndsWith("Effect") || type.Name.Contains("AmbientOcclusion") || global::EscalationVR.GameObjectExtensions.IsImageEffect(type.BaseType));
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x0001D230 File Offset: 0x0001B430
		public static U CopyComponentFrom<T, U>(this global::UnityEngine.GameObject destination, T original) where T : global::UnityEngine.Component where U : T
		{
			global::System.Type typeFromHandle = typeof(T);
			U u = destination.AddComponent<U>();
			global::System.Reflection.FieldInfo[] fields = typeFromHandle.GetFields(20);
			foreach (global::System.Reflection.FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(u, fieldInfo.GetValue(original));
			}
			return u;
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x0001D298 File Offset: 0x0001B498
		public static T CopyComponentFrom<T>(this global::UnityEngine.GameObject destination, T original) where T : global::UnityEngine.Component
		{
			global::System.Type type = original.GetType();
			T t = destination.AddComponent(type) as T;
			global::System.Reflection.FieldInfo[] fields = type.GetFields(20);
			foreach (global::System.Reflection.FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(t, fieldInfo.GetValue(original));
			}
			return t;
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0001D30C File Offset: 0x0001B50C
		public static string GetPath(this global::UnityEngine.Component component)
		{
			return component.transform.parent ? (component.transform.parent.GetPath() + "/" + component.name) : component.name;
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0001D358 File Offset: 0x0001B558
		public static global::System.Collections.Generic.IEnumerable<global::UnityEngine.GameObject> Children(this global::UnityEngine.GameObject gameObject)
		{
			int num;
			for (int i = 0; i < gameObject.transform.childCount; i = num + 1)
			{
				yield return gameObject.transform.GetChild(i).gameObject;
				num = i;
			}
			yield break;
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0001D368 File Offset: 0x0001B568
		public static global::System.Collections.Generic.IEnumerable<global::UnityEngine.Transform> Children(this global::UnityEngine.Transform transform)
		{
			int num;
			for (int i = 0; i < transform.childCount; i = num + 1)
			{
				yield return transform.GetChild(i);
				num = i;
			}
			yield break;
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0001D378 File Offset: 0x0001B578
		public static global::System.Collections.Generic.IEnumerable<global::UnityEngine.Transform> Ancestors(this global::UnityEngine.Transform transform)
		{
			global::UnityEngine.Transform t = transform;
			while (t.parent)
			{
				t = t.parent;
				yield return t;
			}
			yield break;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0001D388 File Offset: 0x0001B588
		public static int Depth(this global::UnityEngine.Transform transform)
		{
			return global::System.Linq.Enumerable.Count<global::UnityEngine.Transform>(transform.Ancestors());
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x0001D3A5 File Offset: 0x0001B5A5
		public static global::System.Collections.Generic.IEnumerable<global::UnityEngine.GameObject> Descendants(this global::UnityEngine.GameObject gameObject)
		{
			global::System.Collections.Generic.Queue<global::UnityEngine.GameObject> queue = new global::System.Collections.Generic.Queue<global::UnityEngine.GameObject>();
			queue.Enqueue(gameObject);
			while (queue.Count > 0)
			{
				global::UnityEngine.GameObject obj = queue.Dequeue();
				foreach (global::UnityEngine.GameObject child in obj.Children())
				{
					yield return child;
					queue.Enqueue(child);
					child = null;
				}
				global::System.Collections.Generic.IEnumerator<global::UnityEngine.GameObject> enumerator = null;
				obj = null;
			}
			yield break;
			yield break;
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0001D3B8 File Offset: 0x0001B5B8
		public static global::System.Collections.Generic.IEnumerable<global::UnityEngine.Transform> Descendants(this global::UnityEngine.Transform transform)
		{
			return global::System.Linq.Enumerable.Select<global::UnityEngine.GameObject, global::UnityEngine.Transform>(transform.gameObject.Descendants(), (global::UnityEngine.GameObject d) => d.transform);
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0001D3FC File Offset: 0x0001B5FC
		public static global::UnityEngine.Transform FindDescendant(this global::UnityEngine.Transform transform, string name)
		{
			return global::System.Linq.Enumerable.FirstOrDefault<global::UnityEngine.Transform>(transform.Descendants(), (global::UnityEngine.Transform d) => d.name == name);
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0001D434 File Offset: 0x0001B634
		public static global::UnityEngine.Transform FindDescendant(this global::UnityEngine.Transform transform, global::System.Text.RegularExpressions.Regex name)
		{
			return global::System.Linq.Enumerable.FirstOrDefault<global::UnityEngine.Transform>(transform.Descendants(), (global::UnityEngine.Transform d) => name.IsMatch(d.name));
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0001D46C File Offset: 0x0001B66C
		public static global::System.Collections.Generic.IEnumerable<global::UnityEngine.GameObject> FindGameObjectsByTag(this global::UnityEngine.GameObject gameObject, string tag)
		{
			return global::System.Linq.Enumerable.Where<global::UnityEngine.GameObject>(gameObject.Descendants(), (global::UnityEngine.GameObject child) => child.CompareTag(tag));
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0001D4A4 File Offset: 0x0001B6A4
		public static global::UnityEngine.GameObject FindGameObjectByTag(this global::UnityEngine.GameObject gameObject, string tag)
		{
			return global::System.Linq.Enumerable.FirstOrDefault<global::UnityEngine.GameObject>(gameObject.FindGameObjectsByTag(tag));
		}
	}
}
