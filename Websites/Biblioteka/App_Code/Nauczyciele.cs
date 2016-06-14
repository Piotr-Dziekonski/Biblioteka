using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Nauczyciele
/// </summary>
public class Nauczyciele
{
	public Nauczyciele()
	{
		
	}

    private int _IDNauczyciela;
    private string _imie;
    private string _nazwisko;

    public string Nazwisko
    {
        get { return _nazwisko; }
        set { _nazwisko = value; }
    }

    public int IDNauczyciela
    {
        get { return _IDNauczyciela; }
        set { _IDNauczyciela = value; }
    }

    public string Imie
    {
        get { return _imie; }
        set { _imie = value; }
    }

}