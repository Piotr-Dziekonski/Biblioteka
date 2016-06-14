using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RokSzkolny
/// </summary>
public class RokWydania
{
	public RokWydania()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _idRoku;

    public int IdRoku
    {
        get { return _idRoku; }
        set { _idRoku = value; }
    }
    private string _rok;

    public string Rok
    {
        get { return _rok; }
        set { _rok = value; }
    }

}