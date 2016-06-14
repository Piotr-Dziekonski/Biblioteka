using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Uczniowie
/// </summary>
public class Uczniowie
{
	public Uczniowie()
	{
		
	}

    private string _id;
    private string _imie;
    private string _nazwisko;
    private string _klasa;
    private string _telefon;

    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Imie
    {
        get { return _imie; }
        set { _imie = value; }
    }
    public string Nazwisko
    {
        get { return _nazwisko; }
        set { _nazwisko = value; }
    }


    public string Klasa
    {
        get { return _klasa; }
        set { _klasa = value; }
    }
    public string Telefon
    {
        get { return _telefon; }
        set { _telefon = value; }
    }


}