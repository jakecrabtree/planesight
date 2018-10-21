﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class APIWrapper {

    private static double lat;
    private static double lon;
    private static double alt;
    private static double speed;
    private static int flightNum;
    private static string flightCode;
    private static string departCode;
    private static string arriveCode;

    public static void initialize(string inFlightCode, int inFlightNum, string depart, string arrive)
    {
        flightCode = inFlightCode;
        flightNum = inFlightNum;
        departCode = depart;
        arriveCode = arrive;
        initialize();
    }

    public static void initialize()
    {
        string html = string.Empty;
        string url = @"https://planesight-hacktx2018.appspot.com/info?departCode=" + departCode + "&arriveCode=" + arriveCode + "&flightCode="
            + flightCode + "&flightNum=" + flightNum;
        ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }

        string[] airports = new string[] { html };
        List<string> lt = new List<string>();
        for (int i = 0; i < airports.Length; i++)
        {
            foreach (string s in airports[i].Split(new char[1] { ',' }))
            {
                lt.Add(s);
            }

        }

        lat = Double.Parse(lt[0]);
        lon = Double.Parse(lt[1]);
        alt = Double.Parse(lt[2]);
        speed = Double.Parse(lt[3]);
    }

    public static string getWeather(bool Fahrenheit) {
        string html = string.Empty;
        string url = @"https://planesight-hacktx2018.appspot.com/weather?lat=" + lat + "&lon=" + lon;
        ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }

        string[] airports = new string[] { html };
        List<string> lt = new List<string>();
        for (int i = 0; i < airports.Length; i++)
        {
            foreach (string s in airports[i].Split(new char[1] { ',' }))
            {
                lt.Add(s);
            }

        }
        return lt[1] + " degrees K";
    }

    public static List<String> getCity()
    {
        string html = string.Empty;
        string url = @"https://planesight-hacktx2018.appspot.com/weather?lat=" + lat + "&lon=" + lon;
        ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }

        string[] airports = new string[] { html };
        List<string> lt = new List<string>();
        for (int i = 0; i < airports.Length; i++)
        {
            foreach (string s in airports[i].Split(new char[1] { ',' }))
            {
                lt.Add(s);
            }

        }

        List<string> tup = new List<string>();
        tup.Add(lt[0]);
        string facts = getWiki(lt[0]);
        tup.Add(facts);
        return tup;
    }

    public static List<string> getLandMark() {
        string html = string.Empty;
        string url1 = @"https://planesight-hacktx2018.appspot.com/fact?lat=" + lat + "&lon=" + lon;
        ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url1);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }

        string[] airports = new string[] { html };
        List<string> lt = new List<string>();
        for (int i = 0; i < airports.Length; i++)
        {
            foreach (string s in airports[i].Split(new char[1] { ',' }))
            {
                lt.Add(s);
            }

        }

        List<string> tup = new List<string>();
        tup.Add(lt[0]);
        string facts = getWiki(lt[0]);
        tup.Add(facts);
        return tup;
    }

    public static string getWiki(string str)
    {
        string html = string.Empty;
        string url = @"https://planesight-hacktx2018.appspot.com/wiki?title=" + str;
        ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url1);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }

        return html;
    } 


    public static List<string> getAirports()
    {
        string html = string.Empty;
        string url = @"https://planesight-hacktx2018.appspot.com/airports";
        ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }

        string[] airports = new string[] { html };
        List<string> lt = new List<string>();
        for (int i = 0; i < airports.Length; i++)
        {
            foreach (string s in airports[i].Split(new char[1] { ',' }))
            {
                lt.Add(s.Substring(1,s.Length - 2));
            }

        }
        return lt;
    }

    public static bool MyRemoteCertificateValidationCallback(System.Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        bool isOk = true;
        // If there are errors in the certificate chain, look at each error to determine the cause.
        if (sslPolicyErrors != SslPolicyErrors.None)
        {
            for (int i = 0; i < chain.ChainStatus.Length; i++)
            {
                if (chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown)
                {
                    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                    bool chainIsValid = chain.Build((X509Certificate2)certificate);
                    if (!chainIsValid)
                    {
                        isOk = false;
                    }
                }
            }
        }
        return isOk;
    }




}
