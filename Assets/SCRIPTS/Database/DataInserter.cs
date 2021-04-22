using UnityEngine;
using System.Collections;

public class DataInserter : MonoBehaviour {

	public string People1;
	public string People2;
	public string People3;
	public string People4;
	public string People5;
	public string People6;
	public string People7;
	public string People8;

	public string Food1;
	public string Food2;
	public string Food3;
	public string Food4;
	public string Food5;
	public string Food6;
	public string Food7;
	public string Food8;

	string CreateUserURL = "localhost/LL/InsertUser.php";

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			CreateUser(People1, People2, People3, People4, People5, People6, People7, People8, Food1, Food2, Food3, Food4, Food5, Food6, Food7, Food8);
		}
	}

	public void CreateUser(string People1, string People2, string People3, string People4, string People5, string People6, string People7, string People8, string Food1, string Food2, string Food3, string Food4, string Food5, string Food6, string Food7, string Food8)
	{
		WWWForm form = new WWWForm();
		form.AddField("People1Post", People1);
		form.AddField("People2Post", People2);
		form.AddField("People3Post", People3);
		form.AddField("People4Post", People4);
		form.AddField("People5Post", People5);
		form.AddField("People6Post", People6);
		form.AddField("People7Post", People7);
		form.AddField("People8Post", People8);

		form.AddField("Food1Post", Food1);
		form.AddField("Food2Post", Food2);
		form.AddField("Food3Post", Food3);
		form.AddField("Food4Post", Food4);
		form.AddField("Food5Post", Food5);
		form.AddField("Food6Post", Food6);
		form.AddField("Food7Post", Food7);
		form.AddField("Food8Post", Food8);

		WWW www = new WWW(CreateUserURL, form);
	}
}
