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

public class Mission
{
	private List<String> Astronautes;

	private List<String> Activites;
	

	/// <summary>
	/// adresse mémoire du fichier XML d'informations.
	/// C'est en le sérialisant (?) que l'on va remplir les autres champs de l'objet Mission
	/// </summary>
	private string Info
	{
		get;
		set;
	}

	private int jourJ
	{
		get;
		set;
	}

	private DateTime T0
	{
		get;
		set;
	}

	private int DureeEnJours
	{
		get;
		set;
	}

	public virtual Calendrier Calendrier
	{
		get;
		set;
	}

	public virtual Lieu LieuBase
	{
		get;
		set;
	}

	public virtual IEnumerable<Jour> Planning
	{
		get;
		set;
	}

	/// <summary>
	/// recuperation des 
	/// </summary>
	public virtual void chargerInfo()
	{
		throw new System.NotImplementedException();
	}

	public virtual void chargerPlanning()
	{
		throw new System.NotImplementedException();
	}

	public virtual void calculeJourJ()
	{
		throw new System.NotImplementedException();
	}

	public virtual List<String> getActivites()
	{
		throw new System.NotImplementedException();
	}

	public virtual int getJourJ()
	{
		throw new System.NotImplementedException();
	}

	public virtual DateTime getT0()
	{
		throw new System.NotImplementedException();
	}

	public virtual int getDuree()
	{
		throw new System.NotImplementedException();
	}

	public virtual void setDuree(object Integer nbJours)
	{
		throw new System.NotImplementedException();
	}

}

