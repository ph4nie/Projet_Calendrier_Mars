﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Activite
{
	private double heureDebut
	{
		get;
		set;
	}

	private double heureFin
	{
		get;
		set;
	}

	private List<String> Astronautes
	{
		get;
		set;
	}

	private string Descriptif
	{
		get;
		set;
	}

	/// <summary>
	/// valeur prise dans la List Activités de Mission
	/// </summary>
	private string Categorie
	{
		get;
		set;
	}

	private bool SortieExt
	{
		get;
		set;
	}

	public virtual Lieu Lieu
	{
		get;
		set;
	}

	public virtual Jour Date
	{
		get;
		set;
	}

	public virtual void getSortieExt()
	{
		throw new System.NotImplementedException();
	}

	public virtual void setSortieExt()
	{
		throw new System.NotImplementedException();
	}

	public virtual List<String> getAstronautes()
	{
		throw new System.NotImplementedException();
	}

	public virtual double getHeureDeb()
	{
		throw new System.NotImplementedException();
	}

	public virtual double getHeureFin()
	{
		throw new System.NotImplementedException();
	}

	public virtual void setHeureDeb(object double newHdeb)
	{
		throw new System.NotImplementedException();
	}

	public virtual void setHeureFin(object double newHfin)
	{
		throw new System.NotImplementedException();
	}

}

