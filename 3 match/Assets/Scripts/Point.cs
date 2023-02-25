using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [Serializable]
public struct Point
{
    public int x;
    public int y;

    public Point(int nx, int ny){
        x = nx;
        y = ny;
    }
    public void Mult(int m){
        x *= m;
        y *= m;
    }
    public void Add(Point a){
        x+=a.x;
        y+=a.y;
    }
    public Vector2 ToVector2(){
        return new Vector2(x, y);
    }
    public bool IsEqual(Point p){
        return (x==p.x && y == p.y);
    }
    public static Point FromVector(Vector2 v){
        return new Point((int)v.x, (int)v.y);
    }
    public static Point FromVector(Vector3 v){
        return new Point((int)v.x, (int)v.y);
    }
    public static Point Mult(Point p , int m){
        return new Point(p.x*m, p.y*m);
    }
    public static Point Add(Point p , Point a){
        return new Point(p.x + a.x, p.y + a.y);
    }
    public static Point Clone(Point p){
        return new Point(p.x, p.y);
    }


    public static Point zero{
        get {return new Point(0, 0); }
    }
    public static Point unit{
        get {return new Point(1, 1); }
    }
    public static Point up{
        get {return new Point(0, 1); }
    }
    public static Point down{
        get {return new Point(0, -1); }
    }
    public static Point left{
        get {return new Point(-1, 0); }
    }
    public static Point right{
        get {return new Point(1, 0); }
    }
}
