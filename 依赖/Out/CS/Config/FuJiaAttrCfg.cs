using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//附加属性配置数据类
public class FuJiaAttrElement
{
	public int ID;               	//编号	ID
	public int STA;              	//根骨	根骨
	public int SPI;              	//精力	精力
	public int STR;              	//力量	力量
	public int INT;              	//智力	智力
	public int AGI;              	//敏捷	敏捷
	public int HP;               	//气血上限	气血上限
	public int reHP;             	//气血恢复速度	气血恢复速度
	public int MP;               	//法力上限	法力上限
	public int reMP;             	//法力恢复速度	法力恢复速度
	public int minPA;            	//最小物理攻击	最小物理攻击
	public int maxPA;            	//最大物理攻击	最大物理攻击
	public int minMA;            	//最小法术攻击	最小法术攻击
	public int maxMA;            	//最大法术攻击	最大法术攻击
	public int PD;               	//物理防御	物理防御
	public int MD;               	//法术防御	法术防御
	public int igPhi;            	//物理命中	物理命中
	public int igMdo;            	//法术命中	法术命中
	public int Pdo;              	//物理躲避	物理躲避
	public int Mdo;              	//法术躲避	法术躲避
	public int igPcr;            	//物理致命	物理致命
	public int igMcr;            	//法术致命	法术致命
	public int Pcr;              	//抗物理致命	抗物理致命
	public int Mcr;              	//抗法术致命	抗法术致命
	public int igPrd;            	//物理致命伤害	物理致命伤害
	public int igMrd;            	//法术致命伤害	法术致命伤害
	public int Prd;              	//抗物理致命伤害	抗物理致命伤害
	public int Mrd;              	//抗法术致命伤害	抗法术致命伤害
	public int igBlo;            	//破盾	破盾
	public int Blo;              	//格挡	格挡
	public int igBrd;            	//忽视格挡伤害减免	忽视格挡伤害减免
	public int Brd;              	//格挡伤害减免	格挡伤害减免
	public int igVEr;            	//强眩晕	强眩晕
	public int igSLr;            	//强睡眠	强睡眠
	public int igCHr;            	//强混乱	强混乱
	public int igABr;            	//强禁食	强禁食
	public int igSIr;            	//强沉默	强沉默
	public int igGRr;            	//强束缚	强束缚
	public int igPEr;            	//强石化	强石化
	public int VEr;              	//眩晕抗性	眩晕抗性
	public int SLr;              	//睡眠抗性	睡眠抗性
	public int CHr;              	//混乱抗性	混乱抗性
	public int ABr;              	//禁食抗性	禁食抗性
	public int SIr;              	//沉默抗性	沉默抗性
	public int GRr;              	//束缚抗性	束缚抗性
	public int PEr;              	//石化抗性	石化抗性
	public int igFr;             	//忽视火抗	忽视火抗
	public int igEr;             	//忽视电抗	忽视电抗
	public int igWr;             	//忽视风抗	忽视风抗
	public int igCr;             	//忽视冰抗	忽视冰抗
	public int igPr;             	//忽视毒抗	忽视毒抗
	public int igLr;             	//忽视光抗	忽视光抗
	public int igDr;             	//忽视暗抗	忽视暗抗
	public int Fr;               	//火抗性	火抗性
	public int Er;               	//电抗性	电抗性
	public int Wr;               	//风抗性	风抗性
	public int Cr;               	//冰抗性	冰抗性
	public int Pr;               	//毒抗性	毒抗性
	public int Lr;               	//光抗性	光抗性
	public int Dr;               	//暗抗性	暗抗性

	public bool IsValidate = false;
	public FuJiaAttrElement()
	{
		ID = -1;
	}
};

//附加属性配置封装类
public class FuJiaAttrTable
{

	private FuJiaAttrTable()
	{
		m_mapElements = new Dictionary<int, FuJiaAttrElement>();
		m_emptyItem = new FuJiaAttrElement();
		m_vecAllElements = new List<FuJiaAttrElement>();
	}
	private Dictionary<int, FuJiaAttrElement> m_mapElements = null;
	private List<FuJiaAttrElement>	m_vecAllElements = null;
	private FuJiaAttrElement m_emptyItem = null;
	private static FuJiaAttrTable sInstance = null;

	public static FuJiaAttrTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new FuJiaAttrTable();
			return sInstance;
		}
	}

	public FuJiaAttrElement GetElement(int key)
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

  public List<FuJiaAttrElement> GetAllElement(Predicate<FuJiaAttrElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("FuJiaAttr.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("FuJiaAttr.bin", out binTableContent ) )
		{
			Debug.Log("配置文件[FuJiaAttr.bin]未找到");
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
			Debug.Log("FuJiaAttr.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Debug.Log("FuJiaAttr.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="STA"){Debug.Log("FuJiaAttr.csv中字段[STA]位置不对应"); return false; }
		if(vecLine[2]!="SPI"){Debug.Log("FuJiaAttr.csv中字段[SPI]位置不对应"); return false; }
		if(vecLine[3]!="STR"){Debug.Log("FuJiaAttr.csv中字段[STR]位置不对应"); return false; }
		if(vecLine[4]!="INT"){Debug.Log("FuJiaAttr.csv中字段[INT]位置不对应"); return false; }
		if(vecLine[5]!="AGI"){Debug.Log("FuJiaAttr.csv中字段[AGI]位置不对应"); return false; }
		if(vecLine[6]!="HP"){Debug.Log("FuJiaAttr.csv中字段[HP]位置不对应"); return false; }
		if(vecLine[7]!="reHP"){Debug.Log("FuJiaAttr.csv中字段[reHP]位置不对应"); return false; }
		if(vecLine[8]!="MP"){Debug.Log("FuJiaAttr.csv中字段[MP]位置不对应"); return false; }
		if(vecLine[9]!="reMP"){Debug.Log("FuJiaAttr.csv中字段[reMP]位置不对应"); return false; }
		if(vecLine[10]!="minPA"){Debug.Log("FuJiaAttr.csv中字段[minPA]位置不对应"); return false; }
		if(vecLine[11]!="maxPA"){Debug.Log("FuJiaAttr.csv中字段[maxPA]位置不对应"); return false; }
		if(vecLine[12]!="minMA"){Debug.Log("FuJiaAttr.csv中字段[minMA]位置不对应"); return false; }
		if(vecLine[13]!="maxMA"){Debug.Log("FuJiaAttr.csv中字段[maxMA]位置不对应"); return false; }
		if(vecLine[14]!="PD"){Debug.Log("FuJiaAttr.csv中字段[PD]位置不对应"); return false; }
		if(vecLine[15]!="MD"){Debug.Log("FuJiaAttr.csv中字段[MD]位置不对应"); return false; }
		if(vecLine[16]!="igPhi"){Debug.Log("FuJiaAttr.csv中字段[igPhi]位置不对应"); return false; }
		if(vecLine[17]!="igMdo"){Debug.Log("FuJiaAttr.csv中字段[igMdo]位置不对应"); return false; }
		if(vecLine[18]!="Pdo"){Debug.Log("FuJiaAttr.csv中字段[Pdo]位置不对应"); return false; }
		if(vecLine[19]!="Mdo"){Debug.Log("FuJiaAttr.csv中字段[Mdo]位置不对应"); return false; }
		if(vecLine[20]!="igPcr"){Debug.Log("FuJiaAttr.csv中字段[igPcr]位置不对应"); return false; }
		if(vecLine[21]!="igMcr"){Debug.Log("FuJiaAttr.csv中字段[igMcr]位置不对应"); return false; }
		if(vecLine[22]!="Pcr"){Debug.Log("FuJiaAttr.csv中字段[Pcr]位置不对应"); return false; }
		if(vecLine[23]!="Mcr"){Debug.Log("FuJiaAttr.csv中字段[Mcr]位置不对应"); return false; }
		if(vecLine[24]!="igPrd"){Debug.Log("FuJiaAttr.csv中字段[igPrd]位置不对应"); return false; }
		if(vecLine[25]!="igMrd"){Debug.Log("FuJiaAttr.csv中字段[igMrd]位置不对应"); return false; }
		if(vecLine[26]!="Prd"){Debug.Log("FuJiaAttr.csv中字段[Prd]位置不对应"); return false; }
		if(vecLine[27]!="Mrd"){Debug.Log("FuJiaAttr.csv中字段[Mrd]位置不对应"); return false; }
		if(vecLine[28]!="igBlo"){Debug.Log("FuJiaAttr.csv中字段[igBlo]位置不对应"); return false; }
		if(vecLine[29]!="Blo"){Debug.Log("FuJiaAttr.csv中字段[Blo]位置不对应"); return false; }
		if(vecLine[30]!="igBrd"){Debug.Log("FuJiaAttr.csv中字段[igBrd]位置不对应"); return false; }
		if(vecLine[31]!="Brd"){Debug.Log("FuJiaAttr.csv中字段[Brd]位置不对应"); return false; }
		if(vecLine[32]!="igVEr"){Debug.Log("FuJiaAttr.csv中字段[igVEr]位置不对应"); return false; }
		if(vecLine[33]!="igSLr"){Debug.Log("FuJiaAttr.csv中字段[igSLr]位置不对应"); return false; }
		if(vecLine[34]!="igCHr"){Debug.Log("FuJiaAttr.csv中字段[igCHr]位置不对应"); return false; }
		if(vecLine[35]!="igABr"){Debug.Log("FuJiaAttr.csv中字段[igABr]位置不对应"); return false; }
		if(vecLine[36]!="igSIr"){Debug.Log("FuJiaAttr.csv中字段[igSIr]位置不对应"); return false; }
		if(vecLine[37]!="igGRr"){Debug.Log("FuJiaAttr.csv中字段[igGRr]位置不对应"); return false; }
		if(vecLine[38]!="igPEr"){Debug.Log("FuJiaAttr.csv中字段[igPEr]位置不对应"); return false; }
		if(vecLine[39]!="VEr"){Debug.Log("FuJiaAttr.csv中字段[VEr]位置不对应"); return false; }
		if(vecLine[40]!="SLr"){Debug.Log("FuJiaAttr.csv中字段[SLr]位置不对应"); return false; }
		if(vecLine[41]!="CHr"){Debug.Log("FuJiaAttr.csv中字段[CHr]位置不对应"); return false; }
		if(vecLine[42]!="ABr"){Debug.Log("FuJiaAttr.csv中字段[ABr]位置不对应"); return false; }
		if(vecLine[43]!="SIr"){Debug.Log("FuJiaAttr.csv中字段[SIr]位置不对应"); return false; }
		if(vecLine[44]!="GRr"){Debug.Log("FuJiaAttr.csv中字段[GRr]位置不对应"); return false; }
		if(vecLine[45]!="PEr"){Debug.Log("FuJiaAttr.csv中字段[PEr]位置不对应"); return false; }
		if(vecLine[46]!="igFr"){Debug.Log("FuJiaAttr.csv中字段[igFr]位置不对应"); return false; }
		if(vecLine[47]!="igEr"){Debug.Log("FuJiaAttr.csv中字段[igEr]位置不对应"); return false; }
		if(vecLine[48]!="igWr"){Debug.Log("FuJiaAttr.csv中字段[igWr]位置不对应"); return false; }
		if(vecLine[49]!="igCr"){Debug.Log("FuJiaAttr.csv中字段[igCr]位置不对应"); return false; }
		if(vecLine[50]!="igPr"){Debug.Log("FuJiaAttr.csv中字段[igPr]位置不对应"); return false; }
		if(vecLine[51]!="igLr"){Debug.Log("FuJiaAttr.csv中字段[igLr]位置不对应"); return false; }
		if(vecLine[52]!="igDr"){Debug.Log("FuJiaAttr.csv中字段[igDr]位置不对应"); return false; }
		if(vecLine[53]!="Fr"){Debug.Log("FuJiaAttr.csv中字段[Fr]位置不对应"); return false; }
		if(vecLine[54]!="Er"){Debug.Log("FuJiaAttr.csv中字段[Er]位置不对应"); return false; }
		if(vecLine[55]!="Wr"){Debug.Log("FuJiaAttr.csv中字段[Wr]位置不对应"); return false; }
		if(vecLine[56]!="Cr"){Debug.Log("FuJiaAttr.csv中字段[Cr]位置不对应"); return false; }
		if(vecLine[57]!="Pr"){Debug.Log("FuJiaAttr.csv中字段[Pr]位置不对应"); return false; }
		if(vecLine[58]!="Lr"){Debug.Log("FuJiaAttr.csv中字段[Lr]位置不对应"); return false; }
		if(vecLine[59]!="Dr"){Debug.Log("FuJiaAttr.csv中字段[Dr]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			FuJiaAttrElement member = new FuJiaAttrElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.STA );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SPI );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.STR );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.INT );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.AGI );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.HP );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.reHP );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MP );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.reMP );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.minPA );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.maxPA );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.minMA );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.maxMA );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.PD );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.MD );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igPhi );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igMdo );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Pdo );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Mdo );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igPcr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igMcr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Pcr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Mcr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igPrd );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igMrd );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Prd );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Mrd );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igBlo );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Blo );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igBrd );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Brd );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igVEr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igSLr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igCHr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igABr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igSIr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igGRr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igPEr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.VEr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SLr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.CHr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ABr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.SIr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.GRr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.PEr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igFr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igEr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igWr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igCr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igPr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igLr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.igDr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Fr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Er );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Wr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Cr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Pr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Lr );
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.Dr );

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
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
			Debug.Log("FuJiaAttr.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Debug.Log("FuJiaAttr.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="STA"){Debug.Log("FuJiaAttr.csv中字段[STA]位置不对应"); return false; }
		if(vecLine[2]!="SPI"){Debug.Log("FuJiaAttr.csv中字段[SPI]位置不对应"); return false; }
		if(vecLine[3]!="STR"){Debug.Log("FuJiaAttr.csv中字段[STR]位置不对应"); return false; }
		if(vecLine[4]!="INT"){Debug.Log("FuJiaAttr.csv中字段[INT]位置不对应"); return false; }
		if(vecLine[5]!="AGI"){Debug.Log("FuJiaAttr.csv中字段[AGI]位置不对应"); return false; }
		if(vecLine[6]!="HP"){Debug.Log("FuJiaAttr.csv中字段[HP]位置不对应"); return false; }
		if(vecLine[7]!="reHP"){Debug.Log("FuJiaAttr.csv中字段[reHP]位置不对应"); return false; }
		if(vecLine[8]!="MP"){Debug.Log("FuJiaAttr.csv中字段[MP]位置不对应"); return false; }
		if(vecLine[9]!="reMP"){Debug.Log("FuJiaAttr.csv中字段[reMP]位置不对应"); return false; }
		if(vecLine[10]!="minPA"){Debug.Log("FuJiaAttr.csv中字段[minPA]位置不对应"); return false; }
		if(vecLine[11]!="maxPA"){Debug.Log("FuJiaAttr.csv中字段[maxPA]位置不对应"); return false; }
		if(vecLine[12]!="minMA"){Debug.Log("FuJiaAttr.csv中字段[minMA]位置不对应"); return false; }
		if(vecLine[13]!="maxMA"){Debug.Log("FuJiaAttr.csv中字段[maxMA]位置不对应"); return false; }
		if(vecLine[14]!="PD"){Debug.Log("FuJiaAttr.csv中字段[PD]位置不对应"); return false; }
		if(vecLine[15]!="MD"){Debug.Log("FuJiaAttr.csv中字段[MD]位置不对应"); return false; }
		if(vecLine[16]!="igPhi"){Debug.Log("FuJiaAttr.csv中字段[igPhi]位置不对应"); return false; }
		if(vecLine[17]!="igMdo"){Debug.Log("FuJiaAttr.csv中字段[igMdo]位置不对应"); return false; }
		if(vecLine[18]!="Pdo"){Debug.Log("FuJiaAttr.csv中字段[Pdo]位置不对应"); return false; }
		if(vecLine[19]!="Mdo"){Debug.Log("FuJiaAttr.csv中字段[Mdo]位置不对应"); return false; }
		if(vecLine[20]!="igPcr"){Debug.Log("FuJiaAttr.csv中字段[igPcr]位置不对应"); return false; }
		if(vecLine[21]!="igMcr"){Debug.Log("FuJiaAttr.csv中字段[igMcr]位置不对应"); return false; }
		if(vecLine[22]!="Pcr"){Debug.Log("FuJiaAttr.csv中字段[Pcr]位置不对应"); return false; }
		if(vecLine[23]!="Mcr"){Debug.Log("FuJiaAttr.csv中字段[Mcr]位置不对应"); return false; }
		if(vecLine[24]!="igPrd"){Debug.Log("FuJiaAttr.csv中字段[igPrd]位置不对应"); return false; }
		if(vecLine[25]!="igMrd"){Debug.Log("FuJiaAttr.csv中字段[igMrd]位置不对应"); return false; }
		if(vecLine[26]!="Prd"){Debug.Log("FuJiaAttr.csv中字段[Prd]位置不对应"); return false; }
		if(vecLine[27]!="Mrd"){Debug.Log("FuJiaAttr.csv中字段[Mrd]位置不对应"); return false; }
		if(vecLine[28]!="igBlo"){Debug.Log("FuJiaAttr.csv中字段[igBlo]位置不对应"); return false; }
		if(vecLine[29]!="Blo"){Debug.Log("FuJiaAttr.csv中字段[Blo]位置不对应"); return false; }
		if(vecLine[30]!="igBrd"){Debug.Log("FuJiaAttr.csv中字段[igBrd]位置不对应"); return false; }
		if(vecLine[31]!="Brd"){Debug.Log("FuJiaAttr.csv中字段[Brd]位置不对应"); return false; }
		if(vecLine[32]!="igVEr"){Debug.Log("FuJiaAttr.csv中字段[igVEr]位置不对应"); return false; }
		if(vecLine[33]!="igSLr"){Debug.Log("FuJiaAttr.csv中字段[igSLr]位置不对应"); return false; }
		if(vecLine[34]!="igCHr"){Debug.Log("FuJiaAttr.csv中字段[igCHr]位置不对应"); return false; }
		if(vecLine[35]!="igABr"){Debug.Log("FuJiaAttr.csv中字段[igABr]位置不对应"); return false; }
		if(vecLine[36]!="igSIr"){Debug.Log("FuJiaAttr.csv中字段[igSIr]位置不对应"); return false; }
		if(vecLine[37]!="igGRr"){Debug.Log("FuJiaAttr.csv中字段[igGRr]位置不对应"); return false; }
		if(vecLine[38]!="igPEr"){Debug.Log("FuJiaAttr.csv中字段[igPEr]位置不对应"); return false; }
		if(vecLine[39]!="VEr"){Debug.Log("FuJiaAttr.csv中字段[VEr]位置不对应"); return false; }
		if(vecLine[40]!="SLr"){Debug.Log("FuJiaAttr.csv中字段[SLr]位置不对应"); return false; }
		if(vecLine[41]!="CHr"){Debug.Log("FuJiaAttr.csv中字段[CHr]位置不对应"); return false; }
		if(vecLine[42]!="ABr"){Debug.Log("FuJiaAttr.csv中字段[ABr]位置不对应"); return false; }
		if(vecLine[43]!="SIr"){Debug.Log("FuJiaAttr.csv中字段[SIr]位置不对应"); return false; }
		if(vecLine[44]!="GRr"){Debug.Log("FuJiaAttr.csv中字段[GRr]位置不对应"); return false; }
		if(vecLine[45]!="PEr"){Debug.Log("FuJiaAttr.csv中字段[PEr]位置不对应"); return false; }
		if(vecLine[46]!="igFr"){Debug.Log("FuJiaAttr.csv中字段[igFr]位置不对应"); return false; }
		if(vecLine[47]!="igEr"){Debug.Log("FuJiaAttr.csv中字段[igEr]位置不对应"); return false; }
		if(vecLine[48]!="igWr"){Debug.Log("FuJiaAttr.csv中字段[igWr]位置不对应"); return false; }
		if(vecLine[49]!="igCr"){Debug.Log("FuJiaAttr.csv中字段[igCr]位置不对应"); return false; }
		if(vecLine[50]!="igPr"){Debug.Log("FuJiaAttr.csv中字段[igPr]位置不对应"); return false; }
		if(vecLine[51]!="igLr"){Debug.Log("FuJiaAttr.csv中字段[igLr]位置不对应"); return false; }
		if(vecLine[52]!="igDr"){Debug.Log("FuJiaAttr.csv中字段[igDr]位置不对应"); return false; }
		if(vecLine[53]!="Fr"){Debug.Log("FuJiaAttr.csv中字段[Fr]位置不对应"); return false; }
		if(vecLine[54]!="Er"){Debug.Log("FuJiaAttr.csv中字段[Er]位置不对应"); return false; }
		if(vecLine[55]!="Wr"){Debug.Log("FuJiaAttr.csv中字段[Wr]位置不对应"); return false; }
		if(vecLine[56]!="Cr"){Debug.Log("FuJiaAttr.csv中字段[Cr]位置不对应"); return false; }
		if(vecLine[57]!="Pr"){Debug.Log("FuJiaAttr.csv中字段[Pr]位置不对应"); return false; }
		if(vecLine[58]!="Lr"){Debug.Log("FuJiaAttr.csv中字段[Lr]位置不对应"); return false; }
		if(vecLine[59]!="Dr"){Debug.Log("FuJiaAttr.csv中字段[Dr]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)60)
			{
				return false;
			}
			FuJiaAttrElement member = new FuJiaAttrElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.STA=Convert.ToInt32(vecLine[1]);
			member.SPI=Convert.ToInt32(vecLine[2]);
			member.STR=Convert.ToInt32(vecLine[3]);
			member.INT=Convert.ToInt32(vecLine[4]);
			member.AGI=Convert.ToInt32(vecLine[5]);
			member.HP=Convert.ToInt32(vecLine[6]);
			member.reHP=Convert.ToInt32(vecLine[7]);
			member.MP=Convert.ToInt32(vecLine[8]);
			member.reMP=Convert.ToInt32(vecLine[9]);
			member.minPA=Convert.ToInt32(vecLine[10]);
			member.maxPA=Convert.ToInt32(vecLine[11]);
			member.minMA=Convert.ToInt32(vecLine[12]);
			member.maxMA=Convert.ToInt32(vecLine[13]);
			member.PD=Convert.ToInt32(vecLine[14]);
			member.MD=Convert.ToInt32(vecLine[15]);
			member.igPhi=Convert.ToInt32(vecLine[16]);
			member.igMdo=Convert.ToInt32(vecLine[17]);
			member.Pdo=Convert.ToInt32(vecLine[18]);
			member.Mdo=Convert.ToInt32(vecLine[19]);
			member.igPcr=Convert.ToInt32(vecLine[20]);
			member.igMcr=Convert.ToInt32(vecLine[21]);
			member.Pcr=Convert.ToInt32(vecLine[22]);
			member.Mcr=Convert.ToInt32(vecLine[23]);
			member.igPrd=Convert.ToInt32(vecLine[24]);
			member.igMrd=Convert.ToInt32(vecLine[25]);
			member.Prd=Convert.ToInt32(vecLine[26]);
			member.Mrd=Convert.ToInt32(vecLine[27]);
			member.igBlo=Convert.ToInt32(vecLine[28]);
			member.Blo=Convert.ToInt32(vecLine[29]);
			member.igBrd=Convert.ToInt32(vecLine[30]);
			member.Brd=Convert.ToInt32(vecLine[31]);
			member.igVEr=Convert.ToInt32(vecLine[32]);
			member.igSLr=Convert.ToInt32(vecLine[33]);
			member.igCHr=Convert.ToInt32(vecLine[34]);
			member.igABr=Convert.ToInt32(vecLine[35]);
			member.igSIr=Convert.ToInt32(vecLine[36]);
			member.igGRr=Convert.ToInt32(vecLine[37]);
			member.igPEr=Convert.ToInt32(vecLine[38]);
			member.VEr=Convert.ToInt32(vecLine[39]);
			member.SLr=Convert.ToInt32(vecLine[40]);
			member.CHr=Convert.ToInt32(vecLine[41]);
			member.ABr=Convert.ToInt32(vecLine[42]);
			member.SIr=Convert.ToInt32(vecLine[43]);
			member.GRr=Convert.ToInt32(vecLine[44]);
			member.PEr=Convert.ToInt32(vecLine[45]);
			member.igFr=Convert.ToInt32(vecLine[46]);
			member.igEr=Convert.ToInt32(vecLine[47]);
			member.igWr=Convert.ToInt32(vecLine[48]);
			member.igCr=Convert.ToInt32(vecLine[49]);
			member.igPr=Convert.ToInt32(vecLine[50]);
			member.igLr=Convert.ToInt32(vecLine[51]);
			member.igDr=Convert.ToInt32(vecLine[52]);
			member.Fr=Convert.ToInt32(vecLine[53]);
			member.Er=Convert.ToInt32(vecLine[54]);
			member.Wr=Convert.ToInt32(vecLine[55]);
			member.Cr=Convert.ToInt32(vecLine[56]);
			member.Pr=Convert.ToInt32(vecLine[57]);
			member.Lr=Convert.ToInt32(vecLine[58]);
			member.Dr=Convert.ToInt32(vecLine[59]);

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
