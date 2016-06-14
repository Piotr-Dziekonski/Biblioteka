using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Liczbowe
/// </summary>
public class Liczbowe
{
	public Liczbowe()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _idKsiazki;

    public int IdKsiazki
    {
        get { return _idKsiazki; }
        set { _idKsiazki = value; }
    }
    private int _rokWydania;

    public int RokWydania
    {
        get { return _rokWydania; }
        set { _rokWydania = value; }
    }
    private int _kategoria;

    public int Kategoria
    {
        get { return _kategoria; }
        set { _kategoria = value; }
    }

    private int _idUcznia;

    public int IdUcznia
    {
        get { return _idUcznia; }
        set { _idUcznia = value; }
    }

    private string _klasa;

    public string Klasa
    {
        get { return _klasa; }
        set { _klasa = value; }
    }
    
}