using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ZamowionaKsiążka
{

    private int _id;
    private string _tytuł;
    private string _autor;
    private string _wydawnictwo;
    private string _kategoria;
    private int _ilosc;
    private int _dostepnych;



	public ZamowionaKsiążka()
	{
	    	

	}

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Tytuł
    {
        get { return _tytuł; }
        set { _tytuł = value; }
    }    
    public string Autor
    {
        get { return _autor; }
        set { _autor = value; }
    }
    public string Wydawnictwo
    {
        get { return _wydawnictwo; }
        set { _wydawnictwo = value; }
    }

    public string Kategoria
    {
        get { return _kategoria; }
        set { _kategoria = value; }
    }
    public int Ilosc
    {
        get { return _ilosc; }
        set { _ilosc = value; }
    }
    public int Dostepnych
    {
        get { return _dostepnych; }
        set { _dostepnych = value; }
    }

}