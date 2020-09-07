using System;

namespace VRGIN.Helpers
{
	// Token: 0x020000D0 RID: 208
	internal class JSONLazyCreator : global::VRGIN.Helpers.JSONNode
	{
		// Token: 0x06000523 RID: 1315 RVA: 0x0001A3C6 File Offset: 0x000185C6
		public JSONLazyCreator(global::VRGIN.Helpers.JSONNode aNode)
		{
			this.m_Node = aNode;
			this.m_Key = null;
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0001A3EC File Offset: 0x000185EC
		public JSONLazyCreator(global::VRGIN.Helpers.JSONNode aNode, string aKey)
		{
			this.m_Node = aNode;
			this.m_Key = aKey;
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0001A414 File Offset: 0x00018614
		private void Set(global::VRGIN.Helpers.JSONNode aVal)
		{
			bool flag = this.m_Key == null;
			if (flag)
			{
				this.m_Node.Add(aVal);
			}
			else
			{
				this.m_Node.Add(this.m_Key, aVal);
			}
			this.m_Node = null;
		}

		// Token: 0x170000EA RID: 234
		public override global::VRGIN.Helpers.JSONNode this[int aIndex]
		{
			get
			{
				return new global::VRGIN.Helpers.JSONLazyCreator(this);
			}
			set
			{
				this.Set(new global::VRGIN.Helpers.JSONArray
				{
					value
				});
			}
		}

		// Token: 0x170000EB RID: 235
		public override global::VRGIN.Helpers.JSONNode this[string aKey]
		{
			get
			{
				return new global::VRGIN.Helpers.JSONLazyCreator(this, aKey);
			}
			set
			{
				this.Set(new global::VRGIN.Helpers.JSONClass
				{
					{
						aKey,
						value
					}
				});
			}
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0001A4DC File Offset: 0x000186DC
		public override void Add(global::VRGIN.Helpers.JSONNode aItem)
		{
			this.Set(new global::VRGIN.Helpers.JSONArray
			{
				aItem
			});
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0001A500 File Offset: 0x00018700
		public override void Add(string aKey, global::VRGIN.Helpers.JSONNode aItem)
		{
			this.Set(new global::VRGIN.Helpers.JSONClass
			{
				{
					aKey,
					aItem
				}
			});
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0001A528 File Offset: 0x00018728
		public static bool operator ==(global::VRGIN.Helpers.JSONLazyCreator a, object b)
		{
			bool flag = b == null;
			return flag || a == b;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0001A54C File Offset: 0x0001874C
		public static bool operator !=(global::VRGIN.Helpers.JSONLazyCreator a, object b)
		{
			return !(a == b);
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0001A568 File Offset: 0x00018768
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return flag || this == obj;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0001A58C File Offset: 0x0001878C
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0001A5A4 File Offset: 0x000187A4
		public override string ToString()
		{
			return "";
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0001A5BC File Offset: 0x000187BC
		public override string ToString(string aPrefix)
		{
			return "";
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0001A5D4 File Offset: 0x000187D4
		public override string ToJSON(int prefix)
		{
			return "";
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x0001A5EC File Offset: 0x000187EC
		// (set) Token: 0x06000534 RID: 1332 RVA: 0x0001A610 File Offset: 0x00018810
		public override int AsInt
		{
			get
			{
				global::VRGIN.Helpers.JSONData aVal = new global::VRGIN.Helpers.JSONData(0);
				this.Set(aVal);
				return 0;
			}
			set
			{
				global::VRGIN.Helpers.JSONData aVal = new global::VRGIN.Helpers.JSONData(value);
				this.Set(aVal);
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000535 RID: 1333 RVA: 0x0001A630 File Offset: 0x00018830
		// (set) Token: 0x06000536 RID: 1334 RVA: 0x0001A65C File Offset: 0x0001885C
		public override float AsFloat
		{
			get
			{
				global::VRGIN.Helpers.JSONData aVal = new global::VRGIN.Helpers.JSONData(0f);
				this.Set(aVal);
				return 0f;
			}
			set
			{
				global::VRGIN.Helpers.JSONData aVal = new global::VRGIN.Helpers.JSONData(value);
				this.Set(aVal);
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x0001A67C File Offset: 0x0001887C
		// (set) Token: 0x06000538 RID: 1336 RVA: 0x0001A6B0 File Offset: 0x000188B0
		public override double AsDouble
		{
			get
			{
				global::VRGIN.Helpers.JSONData aVal = new global::VRGIN.Helpers.JSONData(0.0);
				this.Set(aVal);
				return 0.0;
			}
			set
			{
				global::VRGIN.Helpers.JSONData aVal = new global::VRGIN.Helpers.JSONData(value);
				this.Set(aVal);
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x0001A6D0 File Offset: 0x000188D0
		// (set) Token: 0x0600053A RID: 1338 RVA: 0x0001A6F4 File Offset: 0x000188F4
		public override bool AsBool
		{
			get
			{
				global::VRGIN.Helpers.JSONData aVal = new global::VRGIN.Helpers.JSONData(false);
				this.Set(aVal);
				return false;
			}
			set
			{
				global::VRGIN.Helpers.JSONData aVal = new global::VRGIN.Helpers.JSONData(value);
				this.Set(aVal);
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600053B RID: 1339 RVA: 0x0001A714 File Offset: 0x00018914
		public override global::VRGIN.Helpers.JSONArray AsArray
		{
			get
			{
				global::VRGIN.Helpers.JSONArray jsonarray = new global::VRGIN.Helpers.JSONArray();
				this.Set(jsonarray);
				return jsonarray;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x0001A738 File Offset: 0x00018938
		public override global::VRGIN.Helpers.JSONClass AsObject
		{
			get
			{
				global::VRGIN.Helpers.JSONClass jsonclass = new global::VRGIN.Helpers.JSONClass();
				this.Set(jsonclass);
				return jsonclass;
			}
		}

		// Token: 0x04000659 RID: 1625
		private global::VRGIN.Helpers.JSONNode m_Node = null;

		// Token: 0x0400065A RID: 1626
		private string m_Key = null;
	}
}
