using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxManager : MonoBehaviour
{
    public GameObject box;
    private Transform t;

    public string[] citiesList;
    public string[] streetsList;
    public string[] firstNamesList;
    public string[] lastNamesList;

    //To address
    [System.NonSerialized]
    public string toCity;
    [System.NonSerialized]
    public string toStreet;
    [System.NonSerialized]
    public string toHouseNum;
    [System.NonSerialized]
    public string toZipNum;

    //From address
    [System.NonSerialized]
    public string fromCity;
    [System.NonSerialized]
    public string fromStreet;
    [System.NonSerialized]
    public string fromHouseNum;
    [System.NonSerialized]
    public string fromZipNum;

    //First name
    [System.NonSerialized]
    public string firstName;
    //Last name
    [System.NonSerialized]
    public string lastName;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(GetRandomName() + GetHomeAddress());
        }
    }

    public void spawnBox()
    {
        print("spawn box");

        Instantiate(box, t.position, Quaternion.identity);
    }

    int GetRandomNumber(int range)
    {
        return Random.Range(0, range);
    }

    string GetRandomName()
    {
        //create first and last names
        firstName = firstNamesList[GetRandomNumber(firstNamesList.Length)];
        lastName = lastNamesList[GetRandomNumber(lastNamesList.Length)];

        return firstName + " " + lastName;
    }

    string GetHomeAddress()
    {
        toCity = citiesList[GetRandomNumber(citiesList.Length)];
        toStreet = streetsList[GetRandomNumber(streetsList.Length)];
        fromCity = citiesList[GetRandomNumber(citiesList.Length)];
        fromStreet = streetsList[GetRandomNumber(streetsList.Length)];

        int length = Random.Range(1, 6);
        string totalAddressTo = "";
        for (int i = 0; i < length; i++)
        {
            totalAddressTo += Random.Range(0, 10).ToString();
        }
        length = Random.Range(1, 6);
        string totalAddressFrom = "";
        for (int i = 0; i < length; i++)
        {
            totalAddressFrom += Random.Range(0, 10).ToString();
        }

        string totalZipTo = "";
        for (int i = 0; i < 5; i++)
        {
            totalZipTo += Random.Range(0, 10).ToString();
        }
        string totalZipFrom = "";
        for (int i = 0; i < 5; i++)
        {
            totalZipFrom += Random.Range(0, 10).ToString();
        }

        return "To: " + totalAddressTo + " " + toStreet + ", " + toCity + " " + totalZipTo + "\n" +
               "From: " + totalAddressFrom + " " + fromStreet + ", " + fromCity + " " + totalZipFrom;
    }
}
