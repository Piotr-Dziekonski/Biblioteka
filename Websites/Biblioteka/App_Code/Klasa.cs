using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Klasa
/// </summary>
public class Klasa
{
	public Klasa()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string _klasaUcznia;

    public string KlasaUcznia
    {
        get { return _klasaUcznia; }
        set { _klasaUcznia = value; }
    }
    private string _idKlasy;

    public string IdKlasy
    {
        get { return _idKlasy; }
        set { _idKlasy = value; }
    }
}