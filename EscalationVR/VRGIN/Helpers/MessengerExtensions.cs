using System;
using System.Reflection;
using UnityEngine;

namespace VRGIN.Helpers
{
	// Token: 0x020000DB RID: 219
	public static class MessengerExtensions
	{
		// Token: 0x06000580 RID: 1408 RVA: 0x0001B790 File Offset: 0x00019990
		private static void InvokeIfExists(this object objectToCheck, string methodName, params object[] parameters)
		{
			global::System.Type type = objectToCheck.GetType();
			global::System.Reflection.MethodInfo method = type.GetMethod(methodName, 52);
			bool flag = method != null;
			if (flag)
			{
				method.Invoke(objectToCheck, parameters);
			}
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0001B7C8 File Offset: 0x000199C8
		public static void BroadcastToAll(this global::UnityEngine.GameObject gameobject, string methodName, params object[] parameters)
		{
			global::UnityEngine.MonoBehaviour[] components = gameobject.GetComponents<global::UnityEngine.MonoBehaviour>();
			foreach (global::UnityEngine.MonoBehaviour objectToCheck in components)
			{
				objectToCheck.InvokeIfExists(methodName, parameters);
			}
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0001B7FD File Offset: 0x000199FD
		public static void BroadcastToAll(this global::UnityEngine.Component component, string methodName, params object[] parameters)
		{
			component.gameObject.BroadcastToAll(methodName, parameters);
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0001B810 File Offset: 0x00019A10
		public static void SendMessageToAll(this global::UnityEngine.GameObject gameobject, string methodName, params object[] parameters)
		{
			global::UnityEngine.MonoBehaviour[] componentsInChildren = gameobject.GetComponentsInChildren<global::UnityEngine.MonoBehaviour>(true);
			foreach (global::UnityEngine.MonoBehaviour objectToCheck in componentsInChildren)
			{
				objectToCheck.InvokeIfExists(methodName, parameters);
			}
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0001B846 File Offset: 0x00019A46
		public static void SendMessageToAll(this global::UnityEngine.Component component, string methodName, params object[] parameters)
		{
			component.gameObject.SendMessageToAll(methodName, parameters);
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x0001B858 File Offset: 0x00019A58
		public static void SendMessageUpwardsToAll(this global::UnityEngine.GameObject gameobject, string methodName, params object[] parameters)
		{
			global::UnityEngine.Transform transform = gameobject.transform;
			while (transform != null)
			{
				transform.gameObject.BroadcastToAll(methodName, parameters);
				transform = transform.parent;
			}
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0001B891 File Offset: 0x00019A91
		public static void SendMessageUpwardsToAll(this global::UnityEngine.Component component, string methodName, params object[] parameters)
		{
			component.gameObject.SendMessageUpwardsToAll(methodName, parameters);
		}
	}
}
