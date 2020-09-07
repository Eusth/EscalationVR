using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;

namespace VRGIN.Helpers
{
	// Token: 0x020000D6 RID: 214
	public static class GameObjectExtensions
	{
		// Token: 0x0600055E RID: 1374 RVA: 0x0001AC94 File Offset: 0x00018E94
		public static global::System.Collections.Generic.IEnumerable<global::UnityEngine.MonoBehaviour> GetCameraEffects(this global::UnityEngine.GameObject go)
		{
			return global::System.Linq.Enumerable.Where<global::UnityEngine.MonoBehaviour>(go.GetComponents<global::UnityEngine.MonoBehaviour>(), new global::System.Func<global::UnityEngine.MonoBehaviour, bool>(global::VRGIN.Helpers.GameObjectExtensions.IsCameraEffect));
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x0001ACC0 File Offset: 0x00018EC0
		private static bool IsCameraEffect(global::UnityEngine.MonoBehaviour component)
		{
			return global::VRGIN.Helpers.GameObjectExtensions.IsImageEffect(component.GetType());
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0001ACE0 File Offset: 0x00018EE0
		public static int Level(this global::UnityEngine.GameObject go)
		{
			return go.transform.parent ? (go.transform.parent.gameObject.Level() + 1) : 0;
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0001AD20 File Offset: 0x00018F20
		private static bool IsImageEffect(global::System.Type type)
		{
			return type != null && (type.Name.EndsWith("Effect") || type.Name.Contains("AmbientOcclusion") || global::VRGIN.Helpers.GameObjectExtensions.IsImageEffect(type.BaseType));
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0001AD70 File Offset: 0x00018F70
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

		// Token: 0x06000563 RID: 1379 RVA: 0x0001ADD8 File Offset: 0x00018FD8
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

		// Token: 0x06000564 RID: 1380 RVA: 0x0001AE4C File Offset: 0x0001904C
		public static string GetPath(this global::UnityEngine.Component component)
		{
			return component.transform.parent ? (component.transform.parent.GetPath() + "/" + component.name) : component.name;
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x0001AE98 File Offset: 0x00019098
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

		// Token: 0x06000566 RID: 1382 RVA: 0x0001AEA8 File Offset: 0x000190A8
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

		// Token: 0x06000567 RID: 1383 RVA: 0x0001AEB8 File Offset: 0x000190B8
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

		// Token: 0x06000568 RID: 1384 RVA: 0x0001AEC8 File Offset: 0x000190C8
		public static int Depth(this global::UnityEngine.Transform transform)
		{
			return global::System.Linq.Enumerable.Count<global::UnityEngine.Transform>(transform.Ancestors());
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0001AEE5 File Offset: 0x000190E5
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

		// Token: 0x0600056A RID: 1386 RVA: 0x0001AEF8 File Offset: 0x000190F8
		public static global::System.Collections.Generic.IEnumerable<global::UnityEngine.Transform> Descendants(this global::UnityEngine.Transform transform)
		{
			return global::System.Linq.Enumerable.Select<global::UnityEngine.GameObject, global::UnityEngine.Transform>(transform.gameObject.Descendants(), (global::UnityEngine.GameObject d) => d.transform);
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0001AF3C File Offset: 0x0001913C
		public static global::UnityEngine.Transform FindDescendant(this global::UnityEngine.Transform transform, string name)
		{
			return global::System.Linq.Enumerable.FirstOrDefault<global::UnityEngine.Transform>(transform.Descendants(), (global::UnityEngine.Transform d) => d.name == name);
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0001AF74 File Offset: 0x00019174
		public static global::UnityEngine.Transform FindDescendant(this global::UnityEngine.Transform transform, global::System.Text.RegularExpressions.Regex name)
		{
			return global::System.Linq.Enumerable.FirstOrDefault<global::UnityEngine.Transform>(transform.Descendants(), (global::UnityEngine.Transform d) => name.IsMatch(d.name));
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0001AFAC File Offset: 0x000191AC
		public static global::System.Collections.Generic.IEnumerable<global::UnityEngine.GameObject> FindGameObjectsByTag(this global::UnityEngine.GameObject gameObject, string tag)
		{
			return global::System.Linq.Enumerable.Where<global::UnityEngine.GameObject>(gameObject.Descendants(), (global::UnityEngine.GameObject child) => child.CompareTag(tag));
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0001AFE4 File Offset: 0x000191E4
		public static global::UnityEngine.GameObject FindGameObjectByTag(this global::UnityEngine.GameObject gameObject, string tag)
		{
			return global::System.Linq.Enumerable.FirstOrDefault<global::UnityEngine.GameObject>(gameObject.FindGameObjectsByTag(tag));
		}
	}
}
