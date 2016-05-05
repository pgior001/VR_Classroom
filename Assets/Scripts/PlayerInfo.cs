﻿using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour
{

    public string fname;
    public string lname;
    public string gender;
    public string privilege;
    public string email;
    public string uid;


    public void initPlayer(string uid, string fname, string lname, string gender, string privilege, string email)
    {
        this.fname = fname;
        this.lname = lname;
        this.gender = gender;
        this.privilege = privilege;
        this.email = email;
        this.uid = uid;
    }

    public void initPlayer(string mysqlData)
    {

        string[] rows = mysqlData.Split(';');
        string row = rows[0];
        string[] fields = { "UID", "firstName", "lastName", "gender", "privilege", "email" };
        string[] fieldValues = new string[fields.Length];
        //foreach(string s in fields)
        for (int i = 0; i < fields.Length; ++i)
        {
            fieldValues[i] = GetValue(row, fields[i]);
        }

        //Debug.Log(GetValue(rows[0], "email"));

        initPlayer(fieldValues[0], fieldValues[1], fieldValues[2], fieldValues[3], fieldValues[4], fieldValues[5]);
    }

    public void resetInfo()
    {
        fname = null;
        lname = null;
        gender = null;
        privilege = null;
        email = null;
        uid = null;
    }

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        //transform.gameObject.tag = "PlayerInfo";
    }


    // Update is called once per frame
    void Update()
    {

    }


    string GetValue(string row, string name)
    {
        string value = row.Substring(row.IndexOf(name + ":") + name.Length + 1);
        if (value.Contains("|"))
            value = value.Remove(value.IndexOf("|"));
        return value;
    }
}