using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//等级对应属性配置数据类
public class LVAttrElement
{
	public int LV;               	//编号	等级
	public string STA;           	//根骨	根骨
	public string SPI;           	//精力	精力
	public string STR;           	//力量	力量
	public string INT;           	//智力	智力
	public string AGI;           	//敏捷	敏捷
	public string HP;            	//气血上限	气血上限
	public string reHP;          	//气血恢复速度	气血恢复速度
	public string MP;            	//法力上限	法力上限
	public string reMP;          	//法力恢复速度	法力恢复速度
	public string minPA;         	//最小物理攻击	最小物理攻击
	public string maxPA;         	//最大物理攻击	最大物理攻击
	public string minMA;         	//最小法术攻击	最小法术攻击
	public string maxMA;         	//最大法术攻击	最大法术攻击
	public string PD;            	//物理防御	物理防御
	public string MD;            	//法术防御	法术防御
	public string igPhi;         	//物理命中	物理命中
	public string igMdo;         	//法术命中	法术命中
	public string Pdo;           	//物理躲避	物理躲避
	public string Mdo;           	//法术躲避	法术躲避
	public string igPcr;         	//物理致命	物理致命
	public string igMcr;         	//法术致命	法术致命
	public string Pcr;           	//抗物理致命	抗物理致命
	public string Mcr;           	//抗法术致命	抗法术致命
	public string igPrd;         	//物理致命伤害	物理致命伤害
	public string igMrd;         	//法术致命伤害	法术致命伤害
	public string Prd;           	//抗物理致命伤害	抗物理致命伤害
	public string Mrd;           	//抗法术致命伤害	抗法术致命伤害
	public string igBlo;         	//破盾	破盾
	public string Blo;           	//格挡	格挡
	public string igBrd;         	//忽视格挡伤害减免	忽视格挡伤害减免
	public string Brd;           	//格挡伤害减免	格挡伤害减免
	public string igVEr;         	//强眩晕	强眩晕
	public string igSLr;         	//强睡眠	强睡眠
	public string igCHr;         	//强混乱	强混乱
	public string igABr;         	//强禁食	强禁食
	public string igSIr;         	//强沉默	强沉默
	public string igGRr;         	//强束缚	强束缚
	public string igPEr;         	//强石化	强石化
	public string VEr;           	//眩晕抗性	眩晕抗性
	public string SLr;           	//睡眠抗性	睡眠抗性
	public string CHr;           	//混乱抗性	混乱抗性
	public string ABr;           	//禁食抗性	禁食抗性
	public string SIr;           	//沉默抗性	沉默抗性
	public string GRr;           	//束缚抗性	束缚抗性
	public string PEr;           	//石化抗性	石化抗性
	public string igFr;          	//忽视火抗	忽视火抗
	public string igEr;          	//忽视电抗	忽视电抗
	public string igWr;          	//忽视风抗	忽视风抗
	public string igCr;          	//忽视冰抗	忽视冰抗
	public string igPr;          	//忽视毒抗	忽视毒抗
	public string igLr;          	//忽视光抗	忽视光抗
	public string igDr;          	//忽视暗抗	忽视暗抗
	public string Fr;            	//火抗性	火抗性
	public string Er;            	//电抗性	电抗性
	public string Wr;            	//风抗性	风抗性
	public string Cr;            	//冰抗性	冰抗性
	public string Pr;            	//毒抗性	毒抗性
	public string Lr;            	//光抗性	光抗性
	public string Dr;            	//暗抗性	暗抗性

	public bool IsValidate = false;
	public LVAttrElement()
	{
		LV = -1;
	}
};

//等级对应属性配置封装类
public class LVAttrTable
{

	private LVAttrTable()
	{
		m_mapElements = new Dictionary<int, LVAttrElement>();
		m_emptyItem = new LVAttrElement();
		m_vecAllElements = new List<LVAttrElement>();
	}
	private Dictionary<int, LVAttrElement> m_mapElements = null;
	private List<LVAttrElement>	m_vecAllElements = null;
	private LVAttrElement m_emptyItem = null;
	private static LVAttrTable sInstance = null;

	public static LVAttrTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new LVAttrTable();
			return sInstance;
		}
	}

	public LVAttrElement GetElement(int key)
	{
		if( m_mapElements.ContainsKey(key) )
			return m_mapElements[key];
		return null;
	}

	public int GetElementCount()
	{
		return m_mapElements.Count;
	}
	public bool HasElement(int key)
	{
		return m_mapElements.ContainsKey(key);
	}

  public List<LVAttrElement> GetAllElement(Predicate<LVAttrElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("LVAttr.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("LVAttr.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[LVAttr.bin]未找到");
			return false;
		}
		return LoadBin(binTableContent);
	}


	public bool LoadBin(byte[] binContent)
	{
		m_mapElements.Clear();
		m_vecAllElements.Clear();
		int nCol, nRow;
		int readPos = 0;
		readPos += GameAssist.ReadInt32Variant( binContent, readPos, out nCol );
		readPos += GameAssist.ReadInt32Variant( binContent, readPos, out nRow );
		List<string> vecLine = new List<string>(nCol);
		List<int> vecHeadType = new List<int>(nCol);
        string tmpStr;
        int tmpInt;
		for( int i=0; i<nCol; i++ )
		{
            readPos += GameAssist.ReadString(binContent, readPos, out tmpStr);
            readPos += GameAssist.ReadInt32Variant(binContent, readPos, out tmpInt);
            vecLine.Add(tmpStr);
            vecHeadType.Add(tmpInt);
		}
		if(vecLine.Count != 60)
		{
			Ex.Logger.Log("LVAttr.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="LV"){Ex.Logger.Log("LVAttr.csv中字段[LV]位置不对应"); return false; }
		if(vecLine[1]!="STA"){Ex.Logger.Log("LVAttr.csv中字段[STA]位置不对应"); return false; }
		if(vecLine[2]!="SPI"){Ex.Logger.Log("LVAttr.csv中字段[SPI]位置不对应"); return false; }
		if(vecLine[3]!="STR"){Ex.Logger.Log("LVAttr.csv中字段[STR]位置不对应"); return false; }
		if(vecLine[4]!="INT"){Ex.Logger.Log("LVAttr.csv中字段[INT]位置不对应"); return false; }
		if(vecLine[5]!="AGI"){Ex.Logger.Log("LVAttr.csv中字段[AGI]位置不对应"); return false; }
		if(vecLine[6]!="HP"){Ex.Logger.Log("LVAttr.csv中字段[HP]位置不对应"); return false; }
		if(vecLine[7]!="reHP"){Ex.Logger.Log("LVAttr.csv中字段[reHP]位置不对应"); return false; }
		if(vecLine[8]!="MP"){Ex.Logger.Log("LVAttr.csv中字段[MP]位置不对应"); return false; }
		if(vecLine[9]!="reMP"){Ex.Logger.Log("LVAttr.csv中字段[reMP]位置不对应"); return false; }
		if(vecLine[10]!="minPA"){Ex.Logger.Log("LVAttr.csv中字段[minPA]位置不对应"); return false; }
		if(vecLine[11]!="maxPA"){Ex.Logger.Log("LVAttr.csv中字段[maxPA]位置不对应"); return false; }
		if(vecLine[12]!="minMA"){Ex.Logger.Log("LVAttr.csv中字段[minMA]位置不对应"); return false; }
		if(vecLine[13]!="maxMA"){Ex.Logger.Log("LVAttr.csv中字段[maxMA]位置不对应"); return false; }
		if(vecLine[14]!="PD"){Ex.Logger.Log("LVAttr.csv中字段[PD]位置不对应"); return false; }
		if(vecLine[15]!="MD"){Ex.Logger.Log("LVAttr.csv中字段[MD]位置不对应"); return false; }
		if(vecLine[16]!="igPhi"){Ex.Logger.Log("LVAttr.csv中字段[igPhi]位置不对应"); return false; }
		if(vecLine[17]!="igMdo"){Ex.Logger.Log("LVAttr.csv中字段[igMdo]位置不对应"); return false; }
		if(vecLine[18]!="Pdo"){Ex.Logger.Log("LVAttr.csv中字段[Pdo]位置不对应"); return false; }
		if(vecLine[19]!="Mdo"){Ex.Logger.Log("LVAttr.csv中字段[Mdo]位置不对应"); return false; }
		if(vecLine[20]!="igPcr"){Ex.Logger.Log("LVAttr.csv中字段[igPcr]位置不对应"); return false; }
		if(vecLine[21]!="igMcr"){Ex.Logger.Log("LVAttr.csv中字段[igMcr]位置不对应"); return false; }
		if(vecLine[22]!="Pcr"){Ex.Logger.Log("LVAttr.csv中字段[Pcr]位置不对应"); return false; }
		if(vecLine[23]!="Mcr"){Ex.Logger.Log("LVAttr.csv中字段[Mcr]位置不对应"); return false; }
		if(vecLine[24]!="igPrd"){Ex.Logger.Log("LVAttr.csv中字段[igPrd]位置不对应"); return false; }
		if(vecLine[25]!="igMrd"){Ex.Logger.Log("LVAttr.csv中字段[igMrd]位置不对应"); return false; }
		if(vecLine[26]!="Prd"){Ex.Logger.Log("LVAttr.csv中字段[Prd]位置不对应"); return false; }
		if(vecLine[27]!="Mrd"){Ex.Logger.Log("LVAttr.csv中字段[Mrd]位置不对应"); return false; }
		if(vecLine[28]!="igBlo"){Ex.Logger.Log("LVAttr.csv中字段[igBlo]位置不对应"); return false; }
		if(vecLine[29]!="Blo"){Ex.Logger.Log("LVAttr.csv中字段[Blo]位置不对应"); return false; }
		if(vecLine[30]!="igBrd"){Ex.Logger.Log("LVAttr.csv中字段[igBrd]位置不对应"); return false; }
		if(vecLine[31]!="Brd"){Ex.Logger.Log("LVAttr.csv中字段[Brd]位置不对应"); return false; }
		if(vecLine[32]!="igVEr"){Ex.Logger.Log("LVAttr.csv中字段[igVEr]位置不对应"); return false; }
		if(vecLine[33]!="igSLr"){Ex.Logger.Log("LVAttr.csv中字段[igSLr]位置不对应"); return false; }
		if(vecLine[34]!="igCHr"){Ex.Logger.Log("LVAttr.csv中字段[igCHr]位置不对应"); return false; }
		if(vecLine[35]!="igABr"){Ex.Logger.Log("LVAttr.csv中字段[igABr]位置不对应"); return false; }
		if(vecLine[36]!="igSIr"){Ex.Logger.Log("LVAttr.csv中字段[igSIr]位置不对应"); return false; }
		if(vecLine[37]!="igGRr"){Ex.Logger.Log("LVAttr.csv中字段[igGRr]位置不对应"); return false; }
		if(vecLine[38]!="igPEr"){Ex.Logger.Log("LVAttr.csv中字段[igPEr]位置不对应"); return false; }
		if(vecLine[39]!="VEr"){Ex.Logger.Log("LVAttr.csv中字段[VEr]位置不对应"); return false; }
		if(vecLine[40]!="SLr"){Ex.Logger.Log("LVAttr.csv中字段[SLr]位置不对应"); return false; }
		if(vecLine[41]!="CHr"){Ex.Logger.Log("LVAttr.csv中字段[CHr]位置不对应"); return false; }
		if(vecLine[42]!="ABr"){Ex.Logger.Log("LVAttr.csv中字段[ABr]位置不对应"); return false; }
		if(vecLine[43]!="SIr"){Ex.Logger.Log("LVAttr.csv中字段[SIr]位置不对应"); return false; }
		if(vecLine[44]!="GRr"){Ex.Logger.Log("LVAttr.csv中字段[GRr]位置不对应"); return false; }
		if(vecLine[45]!="PEr"){Ex.Logger.Log("LVAttr.csv中字段[PEr]位置不对应"); return false; }
		if(vecLine[46]!="igFr"){Ex.Logger.Log("LVAttr.csv中字段[igFr]位置不对应"); return false; }
		if(vecLine[47]!="igEr"){Ex.Logger.Log("LVAttr.csv中字段[igEr]位置不对应"); return false; }
		if(vecLine[48]!="igWr"){Ex.Logger.Log("LVAttr.csv中字段[igWr]位置不对应"); return false; }
		if(vecLine[49]!="igCr"){Ex.Logger.Log("LVAttr.csv中字段[igCr]位置不对应"); return false; }
		if(vecLine[50]!="igPr"){Ex.Logger.Log("LVAttr.csv中字段[igPr]位置不对应"); return false; }
		if(vecLine[51]!="igLr"){Ex.Logger.Log("LVAttr.csv中字段[igLr]位置不对应"); return false; }
		if(vecLine[52]!="igDr"){Ex.Logger.Log("LVAttr.csv中字段[igDr]位置不对应"); return false; }
		if(vecLine[53]!="Fr"){Ex.Logger.Log("LVAttr.csv中字段[Fr]位置不对应"); return false; }
		if(vecLine[54]!="Er"){Ex.Logger.Log("LVAttr.csv中字段[Er]位置不对应"); return false; }
		if(vecLine[55]!="Wr"){Ex.Logger.Log("LVAttr.csv中字段[Wr]位置不对应"); return false; }
		if(vecLine[56]!="Cr"){Ex.Logger.Log("LVAttr.csv中字段[Cr]位置不对应"); return false; }
		if(vecLine[57]!="Pr"){Ex.Logger.Log("LVAttr.csv中字段[Pr]位置不对应"); return false; }
		if(vecLine[58]!="Lr"){Ex.Logger.Log("LVAttr.csv中字段[Lr]位置不对应"); return false; }
		if(vecLine[59]!="Dr"){Ex.Logger.Log("LVAttr.csv中字段[Dr]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			LVAttrElement member = new LVAttrElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.LV );
			readPos += GameAssist.ReadString( binContent, readPos, out member.STA);
			readPos += GameAssist.ReadString( binContent, readPos, out member.SPI);
			readPos += GameAssist.ReadString( binContent, readPos, out member.STR);
			readPos += GameAssist.ReadString( binContent, readPos, out member.INT);
			readPos += GameAssist.ReadString( binContent, readPos, out member.AGI);
			readPos += GameAssist.ReadString( binContent, readPos, out member.HP);
			readPos += GameAssist.ReadString( binContent, readPos, out member.reHP);
			readPos += GameAssist.ReadString( binContent, readPos, out member.MP);
			readPos += GameAssist.ReadString( binContent, readPos, out member.reMP);
			readPos += GameAssist.ReadString( binContent, readPos, out member.minPA);
			readPos += GameAssist.ReadString( binContent, readPos, out member.maxPA);
			readPos += GameAssist.ReadString( binContent, readPos, out member.minMA);
			readPos += GameAssist.ReadString( binContent, readPos, out member.maxMA);
			readPos += GameAssist.ReadString( binContent, readPos, out member.PD);
			readPos += GameAssist.ReadString( binContent, readPos, out member.MD);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igPhi);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igMdo);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Pdo);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Mdo);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igPcr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igMcr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Pcr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Mcr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igPrd);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igMrd);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Prd);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Mrd);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igBlo);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Blo);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igBrd);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Brd);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igVEr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igSLr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igCHr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igABr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igSIr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igGRr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igPEr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.VEr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.SLr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.CHr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.ABr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.SIr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.GRr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.PEr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igFr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igEr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igWr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igCr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igPr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igLr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.igDr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Fr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Er);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Wr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Cr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Pr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Lr);
			readPos += GameAssist.ReadString( binContent, readPos, out member.Dr);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.LV] = member;
		}
		return true;
	}
	public bool LoadCsv(string strContent)
	{
		if( strContent.Length == 0 )
			return false;
		m_mapElements.Clear();
		m_vecAllElements.Clear();
		int contentOffset = 0;
		List<string> vecLine;
		vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
		if(vecLine.Count != 60)
		{
			Ex.Logger.Log("LVAttr.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="LV"){Ex.Logger.Log("LVAttr.csv中字段[LV]位置不对应"); return false; }
		if(vecLine[1]!="STA"){Ex.Logger.Log("LVAttr.csv中字段[STA]位置不对应"); return false; }
		if(vecLine[2]!="SPI"){Ex.Logger.Log("LVAttr.csv中字段[SPI]位置不对应"); return false; }
		if(vecLine[3]!="STR"){Ex.Logger.Log("LVAttr.csv中字段[STR]位置不对应"); return false; }
		if(vecLine[4]!="INT"){Ex.Logger.Log("LVAttr.csv中字段[INT]位置不对应"); return false; }
		if(vecLine[5]!="AGI"){Ex.Logger.Log("LVAttr.csv中字段[AGI]位置不对应"); return false; }
		if(vecLine[6]!="HP"){Ex.Logger.Log("LVAttr.csv中字段[HP]位置不对应"); return false; }
		if(vecLine[7]!="reHP"){Ex.Logger.Log("LVAttr.csv中字段[reHP]位置不对应"); return false; }
		if(vecLine[8]!="MP"){Ex.Logger.Log("LVAttr.csv中字段[MP]位置不对应"); return false; }
		if(vecLine[9]!="reMP"){Ex.Logger.Log("LVAttr.csv中字段[reMP]位置不对应"); return false; }
		if(vecLine[10]!="minPA"){Ex.Logger.Log("LVAttr.csv中字段[minPA]位置不对应"); return false; }
		if(vecLine[11]!="maxPA"){Ex.Logger.Log("LVAttr.csv中字段[maxPA]位置不对应"); return false; }
		if(vecLine[12]!="minMA"){Ex.Logger.Log("LVAttr.csv中字段[minMA]位置不对应"); return false; }
		if(vecLine[13]!="maxMA"){Ex.Logger.Log("LVAttr.csv中字段[maxMA]位置不对应"); return false; }
		if(vecLine[14]!="PD"){Ex.Logger.Log("LVAttr.csv中字段[PD]位置不对应"); return false; }
		if(vecLine[15]!="MD"){Ex.Logger.Log("LVAttr.csv中字段[MD]位置不对应"); return false; }
		if(vecLine[16]!="igPhi"){Ex.Logger.Log("LVAttr.csv中字段[igPhi]位置不对应"); return false; }
		if(vecLine[17]!="igMdo"){Ex.Logger.Log("LVAttr.csv中字段[igMdo]位置不对应"); return false; }
		if(vecLine[18]!="Pdo"){Ex.Logger.Log("LVAttr.csv中字段[Pdo]位置不对应"); return false; }
		if(vecLine[19]!="Mdo"){Ex.Logger.Log("LVAttr.csv中字段[Mdo]位置不对应"); return false; }
		if(vecLine[20]!="igPcr"){Ex.Logger.Log("LVAttr.csv中字段[igPcr]位置不对应"); return false; }
		if(vecLine[21]!="igMcr"){Ex.Logger.Log("LVAttr.csv中字段[igMcr]位置不对应"); return false; }
		if(vecLine[22]!="Pcr"){Ex.Logger.Log("LVAttr.csv中字段[Pcr]位置不对应"); return false; }
		if(vecLine[23]!="Mcr"){Ex.Logger.Log("LVAttr.csv中字段[Mcr]位置不对应"); return false; }
		if(vecLine[24]!="igPrd"){Ex.Logger.Log("LVAttr.csv中字段[igPrd]位置不对应"); return false; }
		if(vecLine[25]!="igMrd"){Ex.Logger.Log("LVAttr.csv中字段[igMrd]位置不对应"); return false; }
		if(vecLine[26]!="Prd"){Ex.Logger.Log("LVAttr.csv中字段[Prd]位置不对应"); return false; }
		if(vecLine[27]!="Mrd"){Ex.Logger.Log("LVAttr.csv中字段[Mrd]位置不对应"); return false; }
		if(vecLine[28]!="igBlo"){Ex.Logger.Log("LVAttr.csv中字段[igBlo]位置不对应"); return false; }
		if(vecLine[29]!="Blo"){Ex.Logger.Log("LVAttr.csv中字段[Blo]位置不对应"); return false; }
		if(vecLine[30]!="igBrd"){Ex.Logger.Log("LVAttr.csv中字段[igBrd]位置不对应"); return false; }
		if(vecLine[31]!="Brd"){Ex.Logger.Log("LVAttr.csv中字段[Brd]位置不对应"); return false; }
		if(vecLine[32]!="igVEr"){Ex.Logger.Log("LVAttr.csv中字段[igVEr]位置不对应"); return false; }
		if(vecLine[33]!="igSLr"){Ex.Logger.Log("LVAttr.csv中字段[igSLr]位置不对应"); return false; }
		if(vecLine[34]!="igCHr"){Ex.Logger.Log("LVAttr.csv中字段[igCHr]位置不对应"); return false; }
		if(vecLine[35]!="igABr"){Ex.Logger.Log("LVAttr.csv中字段[igABr]位置不对应"); return false; }
		if(vecLine[36]!="igSIr"){Ex.Logger.Log("LVAttr.csv中字段[igSIr]位置不对应"); return false; }
		if(vecLine[37]!="igGRr"){Ex.Logger.Log("LVAttr.csv中字段[igGRr]位置不对应"); return false; }
		if(vecLine[38]!="igPEr"){Ex.Logger.Log("LVAttr.csv中字段[igPEr]位置不对应"); return false; }
		if(vecLine[39]!="VEr"){Ex.Logger.Log("LVAttr.csv中字段[VEr]位置不对应"); return false; }
		if(vecLine[40]!="SLr"){Ex.Logger.Log("LVAttr.csv中字段[SLr]位置不对应"); return false; }
		if(vecLine[41]!="CHr"){Ex.Logger.Log("LVAttr.csv中字段[CHr]位置不对应"); return false; }
		if(vecLine[42]!="ABr"){Ex.Logger.Log("LVAttr.csv中字段[ABr]位置不对应"); return false; }
		if(vecLine[43]!="SIr"){Ex.Logger.Log("LVAttr.csv中字段[SIr]位置不对应"); return false; }
		if(vecLine[44]!="GRr"){Ex.Logger.Log("LVAttr.csv中字段[GRr]位置不对应"); return false; }
		if(vecLine[45]!="PEr"){Ex.Logger.Log("LVAttr.csv中字段[PEr]位置不对应"); return false; }
		if(vecLine[46]!="igFr"){Ex.Logger.Log("LVAttr.csv中字段[igFr]位置不对应"); return false; }
		if(vecLine[47]!="igEr"){Ex.Logger.Log("LVAttr.csv中字段[igEr]位置不对应"); return false; }
		if(vecLine[48]!="igWr"){Ex.Logger.Log("LVAttr.csv中字段[igWr]位置不对应"); return false; }
		if(vecLine[49]!="igCr"){Ex.Logger.Log("LVAttr.csv中字段[igCr]位置不对应"); return false; }
		if(vecLine[50]!="igPr"){Ex.Logger.Log("LVAttr.csv中字段[igPr]位置不对应"); return false; }
		if(vecLine[51]!="igLr"){Ex.Logger.Log("LVAttr.csv中字段[igLr]位置不对应"); return false; }
		if(vecLine[52]!="igDr"){Ex.Logger.Log("LVAttr.csv中字段[igDr]位置不对应"); return false; }
		if(vecLine[53]!="Fr"){Ex.Logger.Log("LVAttr.csv中字段[Fr]位置不对应"); return false; }
		if(vecLine[54]!="Er"){Ex.Logger.Log("LVAttr.csv中字段[Er]位置不对应"); return false; }
		if(vecLine[55]!="Wr"){Ex.Logger.Log("LVAttr.csv中字段[Wr]位置不对应"); return false; }
		if(vecLine[56]!="Cr"){Ex.Logger.Log("LVAttr.csv中字段[Cr]位置不对应"); return false; }
		if(vecLine[57]!="Pr"){Ex.Logger.Log("LVAttr.csv中字段[Pr]位置不对应"); return false; }
		if(vecLine[58]!="Lr"){Ex.Logger.Log("LVAttr.csv中字段[Lr]位置不对应"); return false; }
		if(vecLine[59]!="Dr"){Ex.Logger.Log("LVAttr.csv中字段[Dr]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)60)
			{
				return false;
			}
			LVAttrElement member = new LVAttrElement();
			member.LV=Convert.ToInt32(vecLine[0]);
			member.STA=vecLine[1];
			member.SPI=vecLine[2];
			member.STR=vecLine[3];
			member.INT=vecLine[4];
			member.AGI=vecLine[5];
			member.HP=vecLine[6];
			member.reHP=vecLine[7];
			member.MP=vecLine[8];
			member.reMP=vecLine[9];
			member.minPA=vecLine[10];
			member.maxPA=vecLine[11];
			member.minMA=vecLine[12];
			member.maxMA=vecLine[13];
			member.PD=vecLine[14];
			member.MD=vecLine[15];
			member.igPhi=vecLine[16];
			member.igMdo=vecLine[17];
			member.Pdo=vecLine[18];
			member.Mdo=vecLine[19];
			member.igPcr=vecLine[20];
			member.igMcr=vecLine[21];
			member.Pcr=vecLine[22];
			member.Mcr=vecLine[23];
			member.igPrd=vecLine[24];
			member.igMrd=vecLine[25];
			member.Prd=vecLine[26];
			member.Mrd=vecLine[27];
			member.igBlo=vecLine[28];
			member.Blo=vecLine[29];
			member.igBrd=vecLine[30];
			member.Brd=vecLine[31];
			member.igVEr=vecLine[32];
			member.igSLr=vecLine[33];
			member.igCHr=vecLine[34];
			member.igABr=vecLine[35];
			member.igSIr=vecLine[36];
			member.igGRr=vecLine[37];
			member.igPEr=vecLine[38];
			member.VEr=vecLine[39];
			member.SLr=vecLine[40];
			member.CHr=vecLine[41];
			member.ABr=vecLine[42];
			member.SIr=vecLine[43];
			member.GRr=vecLine[44];
			member.PEr=vecLine[45];
			member.igFr=vecLine[46];
			member.igEr=vecLine[47];
			member.igWr=vecLine[48];
			member.igCr=vecLine[49];
			member.igPr=vecLine[50];
			member.igLr=vecLine[51];
			member.igDr=vecLine[52];
			member.Fr=vecLine[53];
			member.Er=vecLine[54];
			member.Wr=vecLine[55];
			member.Cr=vecLine[56];
			member.Pr=vecLine[57];
			member.Lr=vecLine[58];
			member.Dr=vecLine[59];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.LV] = member;
		}
		return true;
	}
};
