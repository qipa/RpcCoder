using UnityEngine;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


//引导步骤配置数据类
public class GuideStepsElement
{
	public int ID;               	//指引步骤id	指引步骤id
	public string Name;          	// 名字	名字
	public string GuideRule;     	//指引条件	指引条件 ? 指引类型 1：按钮，2：摇杆，3列表 ? View界面的名字 ? 下级的名字 按钮和摇杆为按钮名字，列表为列表名字 ? 列表的按钮 ? 如果是列表类型[1位置,0位置编号] 按钮的另外一种例子：[1,"Normal/UIBattle(Clone)","MenuAndSkill/RightBottomSkill/ExpandButton",1] 最后的1代表如果当前按钮没有显示，直接跳到下个流程
	public string GuideAnimation;	//指引动画	播放动画 ? 播放位置[X,Y]相对于控件的位置 ? 播放方式：1-单次，2-循环 [[200,0],2,0,1,30,"","看这里有惊喜",[240,150]]  只有文字的 [[200,0],2,0,1,30,"UIStar","",[0,0]]  只有特效的 [[200,0],2,0,1,30,"UIStar","看这里有惊喜",[230,150],[200,-100]]  文字和特效都有的 ? 播放次数：X次数(类型为单次时，此项无效，0为无限次) ？1 不翻转 2 翻转 3 左右镜像 4上下镜像 ？旋转角度，例如：30 表示逆时针旋转30° ? 资源路径：XXX\XXXX\XXX ? 字的内容：字符串 ? 预留坐标[X,Y]相对于控件的位置 可以不加加了之后 如果有动画和文本，文本走这个坐标

	public bool IsValidate = false;
	public GuideStepsElement()
	{
		ID = -1;
	}
};

//引导步骤配置封装类
public class GuideStepsTable
{

	private GuideStepsTable()
	{
		m_mapElements = new Dictionary<int, GuideStepsElement>();
		m_emptyItem = new GuideStepsElement();
		m_vecAllElements = new List<GuideStepsElement>();
	}
	private Dictionary<int, GuideStepsElement> m_mapElements = null;
	private List<GuideStepsElement>	m_vecAllElements = null;
	private GuideStepsElement m_emptyItem = null;
	private static GuideStepsTable sInstance = null;

	public static GuideStepsTable Instance
	{
		get
		{
			if( sInstance != null )
				return sInstance;	
			sInstance = new GuideStepsTable();
			return sInstance;
		}
	}

	public GuideStepsElement GetElement(int key)
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

  public List<GuideStepsElement> GetAllElement(Predicate<GuideStepsElement> matchCB = null)
	{
        if( matchCB==null || m_vecAllElements.Count == 0)
            return m_vecAllElements;
        return m_vecAllElements.FindAll(matchCB);
	}

	public bool Load()
	{
		
		string strTableContent = "";
		if( GameAssist.ReadCsvFile("GuideSteps.csv", out strTableContent ) )
			return LoadCsv( strTableContent );
		byte[] binTableContent = null;
		if( !GameAssist.ReadBinFile("GuideSteps.bin", out binTableContent ) )
		{
			Ex.Logger.Log("配置文件[GuideSteps.bin]未找到");
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
		if(vecLine.Count != 4)
		{
			Ex.Logger.Log("GuideSteps.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("GuideSteps.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("GuideSteps.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="GuideRule"){Ex.Logger.Log("GuideSteps.csv中字段[GuideRule]位置不对应"); return false; }
		if(vecLine[3]!="GuideAnimation"){Ex.Logger.Log("GuideSteps.csv中字段[GuideAnimation]位置不对应"); return false; }

		for(int i=0; i<nRow; i++)
		{
			GuideStepsElement member = new GuideStepsElement();
			readPos += GameAssist.ReadInt32Variant(binContent, readPos, out member.ID );
			readPos += GameAssist.ReadString( binContent, readPos, out member.Name);
			readPos += GameAssist.ReadString( binContent, readPos, out member.GuideRule);
			readPos += GameAssist.ReadString( binContent, readPos, out member.GuideAnimation);

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
		if(vecLine.Count != 4)
		{
			Ex.Logger.Log("GuideSteps.csv中列数量与生成的代码不匹配!");
			return false;
		}
		if(vecLine[0]!="ID"){Ex.Logger.Log("GuideSteps.csv中字段[ID]位置不对应"); return false; }
		if(vecLine[1]!="Name"){Ex.Logger.Log("GuideSteps.csv中字段[Name]位置不对应"); return false; }
		if(vecLine[2]!="GuideRule"){Ex.Logger.Log("GuideSteps.csv中字段[GuideRule]位置不对应"); return false; }
		if(vecLine[3]!="GuideAnimation"){Ex.Logger.Log("GuideSteps.csv中字段[GuideAnimation]位置不对应"); return false; }

		while(true)
		{
			vecLine = GameAssist.readCsvLine( strContent, ref contentOffset );
			if((int)vecLine.Count == 0 )
				break;
			if((int)vecLine.Count != (int)4)
			{
				return false;
			}
			GuideStepsElement member = new GuideStepsElement();
			member.ID=Convert.ToInt32(vecLine[0]);
			member.Name=vecLine[1];
			member.GuideRule=vecLine[2];
			member.GuideAnimation=vecLine[3];

			member.IsValidate = true;
			m_vecAllElements.Add(member);
			m_mapElements[member.ID] = member;
		}
		return true;
	}
};
