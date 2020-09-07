using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace VRGIN.Core
{
	// Token: 0x020000A5 RID: 165
	public class ProtectedBehaviour : global::UnityEngine.MonoBehaviour
	{
		// Token: 0x0600031C RID: 796 RVA: 0x00011640 File Offset: 0x0000F840
		private string GetKey(string method)
		{
			return string.Format("{0}#{1}", base.GetType().FullName, method);
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00011668 File Offset: 0x0000F868
		protected void Start()
		{
			this.SafelyCall(new global::System.Action(this.OnStart));
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0001167F File Offset: 0x0000F87F
		protected void Awake()
		{
			this.SafelyCall(new global::System.Action(this.OnAwake));
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00011696 File Offset: 0x0000F896
		protected void Update()
		{
			this.SafelyCall(new global::System.Action(this.OnUpdate));
		}

		// Token: 0x06000320 RID: 800 RVA: 0x000116AD File Offset: 0x0000F8AD
		protected void LateUpdate()
		{
			this.SafelyCall(new global::System.Action(this.OnLateUpdate));
		}

		// Token: 0x06000321 RID: 801 RVA: 0x000116C4 File Offset: 0x0000F8C4
		protected void FixedUpdate()
		{
			this.SafelyCall(new global::System.Action(this.OnFixedUpdate));
		}

		// Token: 0x06000322 RID: 802 RVA: 0x000116DC File Offset: 0x0000F8DC
		protected void OnLevelWasLoaded(int level)
		{
			this.SafelyCall(delegate
			{
				this.OnLevel(level);
			});
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00011711 File Offset: 0x0000F911
		protected virtual void OnStart()
		{
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00011714 File Offset: 0x0000F914
		protected virtual void OnUpdate()
		{
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00011717 File Offset: 0x0000F917
		protected virtual void OnLateUpdate()
		{
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0001171A File Offset: 0x0000F91A
		protected virtual void OnFixedUpdate()
		{
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0001171D File Offset: 0x0000F91D
		protected virtual void OnAwake()
		{
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00011720 File Offset: 0x0000F920
		protected virtual void OnLevel(int level)
		{
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00011724 File Offset: 0x0000F924
		private void SafelyCall(global::System.Action action)
		{
			try
			{
				action.Invoke();
			}
			catch (global::System.Exception obj)
			{
				global::VRGIN.Core.VRLog.Error(obj);
			}
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0001175C File Offset: 0x0000F95C
		public static void DumpTable()
		{
			global::VRGIN.Core.VRLog.Info("DUMP", global::System.Array.Empty<object>());
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, double>> enumerator = global::VRGIN.Core.ProtectedBehaviour.PerformanceTable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				global::System.Text.StringBuilder stringBuilder2 = stringBuilder;
				string text = "{1}ms: {0}\n";
				global::System.Collections.Generic.KeyValuePair<string, double> keyValuePair = enumerator.Current;
				object key = keyValuePair.Key;
				keyValuePair = enumerator.Current;
				stringBuilder2.AppendFormat(text, key, keyValuePair.Value / (double)global::UnityEngine.Time.realtimeSinceStartup);
			}
			global::System.IO.File.WriteAllText("performance.txt", stringBuilder.ToString());
		}

		// Token: 0x0600032B RID: 811 RVA: 0x000117DE File Offset: 0x0000F9DE
		public void Invoke(global::System.Action action, float delayInSeconds)
		{
			base.StartCoroutine(this._Invoke(action, delayInSeconds));
		}

		// Token: 0x0600032C RID: 812 RVA: 0x000117F0 File Offset: 0x0000F9F0
		private global::System.Collections.IEnumerator _Invoke(global::System.Action action, float delay)
		{
			yield return new global::UnityEngine.WaitForSeconds(delay);
			try
			{
				action.Invoke();
				yield break;
			}
			catch (global::System.Exception ex)
			{
				global::System.Exception e = ex;
				global::VRGIN.Core.VRLog.Error(e);
				yield break;
			}
			yield break;
		}

		// Token: 0x04000569 RID: 1385
		private static global::System.Collections.Generic.IDictionary<string, double> PerformanceTable = new global::System.Collections.Generic.Dictionary<string, double>();
	}
}
