using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Zamowienia
/// </summary>
public class Wypozyczenia
{
	public Wypozyczenia()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string _idWypozyczenia;
    private string _ksiazka;
    private string _dataWypozyczenia;


    public string IdWypozyczenia
    {
        get { return _idWypozyczenia; }
        set { _idWypozyczenia = value; }
    }
    public string Ksiazka
    {
        get { return _ksiazka; }
        set { _ksiazka = value; }
    }
    public string DataWypozyczenia
    {
        get { return _dataWypozyczenia; }
        set { _dataWypozyczenia = value; }
    }
}