using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using VRGIN.Core;

namespace VRGIN.Helpers
{
	// Token: 0x020000DC RID: 220
	public class Profiler : global::VRGIN.Core.ProtectedBehaviour
	{
		// Token: 0x06000587 RID: 1415 RVA: 0x0001B8A4 File Offset: 0x00019AA4
		public static void FindHotPaths(global::VRGIN.Helpers.Profiler.Callback callback)
		{
			bool flag = !global::UnityEngine.GameObject.Find("Profiler");
			if (flag)
			{
				global::VRGIN.Helpers.Profiler profiler = new global::UnityEngine.GameObject("Profiler").AddComponent<global::VRGIN.Helpers.Profiler>();
				profiler._Callback = callback;
			}
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x0001B8E1 File Offset: 0x00019AE1
		protected override void OnStart()
		{
			base.OnStart();
			base.StartCoroutine(this.Measure());
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x0001B8F8 File Offset: 0x00019AF8
		private global::System.Collections.IEnumerator Measure()
		{
			global::System.Collections.Generic.List<global::UnityEngine.GameObject> queue = global::System.Linq.Enumerable.ToList<global::UnityEngine.GameObject>(global::System.Linq.Enumerable.Where<global::UnityEngine.GameObject>(global::System.Linq.Enumerable.Except<global::UnityEngine.GameObject>(global::VRGIN.Helpers.UnityHelper.GetRootNodes(), new global::UnityEngine.GameObject[]
			{
				base.gameObject
			}), (global::UnityEngine.GameObject n) => !n.name.StartsWith("VRGIN") && !n.name.StartsWith("[")));
			yield return base.StartCoroutine(this.MeasureFramerate(30));
			double startInterval = this._CurrentInterval;
			global::VRGIN.Core.VRLog.Info("Starting to profile! This might take a while...", global::System.Array.Empty<object>());
			while (queue.Count > 0)
			{
				global::UnityEngine.GameObject obj = global::System.Linq.Enumerable.First<global::UnityEngine.GameObject>(queue);
				queue.RemoveAt(0);
				bool flag = !obj.activeInHierarchy;
				if (!flag)
				{
					obj.SetActive(false);
					yield return base.StartCoroutine(this.MeasureFramerate(30));
					obj.SetActive(true);
					double impact = startInterval / this._CurrentInterval;
					global::VRGIN.Core.VRLog.Info("{0}{1}: {2:0.00}", new object[]
					{
						string.Join("", global::System.Linq.Enumerable.ToArray<string>(global::System.Linq.Enumerable.Repeat<string>(" ", obj.transform.Depth()))),
						obj.name,
						impact
					});
					bool flag2 = impact > 1.1499999761581421;
					if (flag2)
					{
						queue.InsertRange(0, obj.Children());
						foreach (global::UnityEngine.Behaviour component in global::System.Linq.Enumerable.Where<global::UnityEngine.Behaviour>(obj.GetComponents<global::UnityEngine.Behaviour>(), (global::UnityEngine.Behaviour c) => c.enabled))
						{
							component.enabled = false;
							yield return base.StartCoroutine(this.MeasureFramerate(30));
							component.enabled = true;
							impact = startInterval / this._CurrentInterval;
							global::VRGIN.Core.VRLog.Info("{0}{1} [{2}]: {3:0.000}", new object[]
							{
								string.Join("", global::System.Linq.Enumerable.ToArray<string>(global::System.Linq.Enumerable.Repeat<string>(" ", obj.transform.Depth()))),
								obj.name,
								component.GetType().Name,
								impact
							});
							component = null;
						}
						global::System.Collections.Generic.IEnumerator<global::UnityEngine.Behaviour> enumerator = null;
					}
					yield return null;
					obj = null;
				}
			}
			global::VRGIN.Core.VRLog.Info("Done!", global::System.Array.Empty<object>());
			this._Callback();
			global::UnityEngine.Object.Destroy(base.gameObject);
			yield break;
			yield break;
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x0001B907 File Offset: 0x00019B07
		private global::System.Collections.IEnumerator MeasureFramerate(int sampleCount)
		{
			yield return new global::UnityEngine.WaitForSeconds(0.01f);
			long[] samples = new long[sampleCount];
			yield return null;
			global::System.Diagnostics.Stopwatch stopwatch = new global::System.Diagnostics.Stopwatch();
			stopwatch.Start();
			int num;
			for (int i = 0; i < sampleCount; i = num + 1)
			{
				stopwatch.Reset();
				stopwatch.Start();
				yield return null;
				samples[i] = stopwatch.ElapsedMilliseconds;
				num = i;
			}
			this._CurrentInterval = global::System.Linq.Enumerable.Average(samples);
			yield return new global::UnityEngine.WaitForSeconds(0.01f);
			yield break;
		}

		// Token: 0x0400066B RID: 1643
		private const int DEFAULT_SAMPLE_COUNT = 30;

		// Token: 0x0400066C RID: 1644
		private const float INTERVAL_TIME = 0.01f;

		// Token: 0x0400066D RID: 1645
		private global::VRGIN.Helpers.Profiler.Callback _Callback;

		// Token: 0x0400066E RID: 1646
		private double _CurrentInterval;

		// Token: 0x02000222 RID: 546
		// (Invoke) Token: 0x06000B3E RID: 2878
		public delegate void Callback();
	}
}
