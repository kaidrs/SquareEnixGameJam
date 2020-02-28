using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class JasonBase
{
    public int          pbintBase           = 123;
    public float        pbfloatBase         = 1.23f;
    public double       pbdoubleBase        = 12.3d;
    public string       pbstringBase        = "123";
    public char         pbcharBase          = 'r';
    public byte         pbbyteBase          = 123;
    public Vector3      pbvector3Base       = new Vector3(1, 2, 3);
    public Quaternion   pbquaternionBase    = new Quaternion(1, 2, 3, 4);

    protected int         printBase            = 123;
    protected float       prfloatBase          = 1.23f;
    protected double      prdoubleBase         = 12.3d;
    protected string      prstringBase         = "123";
    protected char        prcharBase           = 'r';
    protected byte        prbyteBase           = 123;
    protected Vector3     prvector3Base        = new Vector3(1, 2, 3);
    protected Quaternion  prquaternionBase     = new Quaternion(1, 2, 3, 4);

    private int         pintBase            = 123;
    private float       pfloatBase          = 1.23f;
    private double      pdoubleBase         = 12.3d;
    private string      pstringBase         = "123";
    private char        pcharBase           = 'r';
    private byte        pbyteBase           = 123;
    private Vector3     pvector3Base        = new Vector3(1, 2, 3);
    private Quaternion  pquaternionBase     = new Quaternion(1, 2, 3, 4);

    static public int pbintStatBase = 123;

    public JasonBase(int pbintBase, float pbfloatBase, double pbdoubleBase, string pbstringBase, char pbcharBase, byte pbbyteBase, Vector3 pbvector3Base, Quaternion pbquaternionBase, int printBase, float prfloatBase, double prdoubleBase, string prstringBase, char prcharBase, byte prbyteBase, Vector3 prvector3Base, Quaternion prquaternionBase, int pintBase, float pfloatBase, double pdoubleBase, string pstringBase, char pcharBase, byte pbyteBase, Vector3 pvector3Base, Quaternion pquaternionBase)
    {
        this.pbintBase = pbintBase;
        this.pbfloatBase = pbfloatBase;
        this.pbdoubleBase = pbdoubleBase;
        this.pbstringBase = pbstringBase;
        this.pbcharBase = pbcharBase;
        this.pbbyteBase = pbbyteBase;
        this.pbvector3Base = pbvector3Base;
        this.pbquaternionBase = pbquaternionBase;
        this.printBase = printBase;
        this.prfloatBase = prfloatBase;
        this.prdoubleBase = prdoubleBase;
        this.prstringBase = prstringBase;
        this.prcharBase = prcharBase;
        this.prbyteBase = prbyteBase;
        this.prvector3Base = prvector3Base;
        this.prquaternionBase = prquaternionBase;
        this.pintBase = pintBase;
        this.pfloatBase = pfloatBase;
        this.pdoubleBase = pdoubleBase;
        this.pstringBase = pstringBase;
        this.pcharBase = pcharBase;
        this.pbyteBase = pbyteBase;
        this.pvector3Base = pvector3Base;
        this.pquaternionBase = pquaternionBase;
    }

    public JasonBase()
    {
    }

    public override string ToString()
    {
        return $"--- Base ---\n" +
            $"pbintBase{pbintBase}\n" +
            $"pbfloatBase     {pbfloatBase     }\n" +
            $"pbdoubleBase    {pbdoubleBase    }\n" +
            $"pbstringBase    {pbstringBase    }\n" +
            $"pbcharBase      {pbcharBase      }\n" +
            $"pbbyteBase      {pbbyteBase      }\n" +
            $"pbvector3Base   {pbvector3Base   }\n" +
            $"pbquaternionBase{pbquaternionBase}\n" +
            $"printBase       {printBase       }\n" +
            $"prfloatBase     {prfloatBase     }\n" +
            $"prdoubleBase    {prdoubleBase    }\n" +
            $"prstringBase    {prstringBase    }\n" +
            $"prcharBase      {prcharBase      }\n" +
            $"prbyteBase      {prbyteBase      }\n" +
            $"prvector3Base   {prvector3Base   }\n" +
            $"prquaternionBase{prquaternionBase}\n" +
            $"pintBase       {pintBase       }\n" +
            $"pfloatBase     {pfloatBase     }\n" +
            $"pdoubleBase    {pdoubleBase    }\n" +
            $"pstringBase    {pstringBase    }\n" +
            $"pcharBase      {pcharBase      }\n" +
            $"pbyteBase      {pbyteBase      }\n" +
            $"pvector3Base   {pvector3Base   }\n" +
            $"pquaternionBase{pquaternionBase}\n" +
            $"staticint {pbintStatBase}\n" +
            $"--- ---\n";

    }

}

public class JasonChild : JasonBase
{
    public int pbintChild = 123;
    public float pbfloatChild = 1.23f;
    public double pbdoubleChild = 12.3d;
    public string pbstringChild = "123";
    public char pbcharChild = 'r';
    public byte pbbyteChild = 123;
    public Vector3 pbvector3Child = new Vector3(1, 2, 3);
    public Quaternion pbquaternionChild = new Quaternion(1, 2, 3, 4);

    protected int printChild = 123;
    protected float prfloatChild = 1.23f;
    protected double prdoubleChild = 12.3d;
    protected string prstringChild = "123";
    protected char prcharChild = 'r';
    protected byte prbyteChild = 123;
    protected Vector3 prvector3Child = new Vector3(1, 2, 3);
    protected Quaternion prquaternionChild = new Quaternion(1, 2, 3, 4);

    private int pintChild = 123;
    private float pfloatChild = 1.23f;
    private double pdoubleChild = 12.3d;
    private string pstringChild = "123";
    private char pcharChild = 'r';
    private byte pbyteChild = 123;
    private Vector3 pvector3Child = new Vector3(1, 2, 3);
    private Quaternion pquaternionChild = new Quaternion(1, 2, 3, 4);

    public JasonChild()
    {
    }

    public JasonChild(int pbintBase, float pbfloatBase, double pbdoubleBase, string pbstringBase, char pbcharBase, byte pbbyteBase, Vector3 pbvector3Base, Quaternion pbquaternionBase, int printBase, float prfloatBase, double prdoubleBase, string prstringBase, char prcharBase, byte prbyteBase, Vector3 prvector3Base, Quaternion prquaternionBase, int pintBase, float pfloatBase, double pdoubleBase, string pstringBase, char pcharBase, byte pbyteBase, Vector3 pvector3Base, Quaternion pquaternionBase) : base(pbintBase, pbfloatBase, pbdoubleBase, pbstringBase, pbcharBase, pbbyteBase, pbvector3Base, pbquaternionBase, printBase, prfloatBase, prdoubleBase, prstringBase, prcharBase, prbyteBase, prvector3Base, prquaternionBase, pintBase, pfloatBase, pdoubleBase, pstringBase, pcharBase, pbyteBase, pvector3Base, pquaternionBase)
    {
    }

    public override string ToString()
    {
        return base.ToString() +
            $"--- Child ---\n" +
            $"pbintChild{pbintChild}\n" +
            $"pbfloatChild     {pbfloatChild     }\n" +
            $"pbdoubleChild    {pbdoubleChild    }\n" +
            $"pbstringChild    {pbstringChild    }\n" +
            $"pbcharChild      {pbcharChild      }\n" +
            $"pbbyteChild      {pbbyteChild      }\n" +
            $"pbvector3Child   {pbvector3Child   }\n" +
            $"pbquaternionChild{pbquaternionChild}\n" +
            $"printChild       {printChild       }\n" +
            $"prfloatChild     {prfloatChild     }\n" +
            $"prdoubleChild    {prdoubleChild    }\n" +
            $"prstringChild    {prstringChild    }\n" +
            $"prcharChild      {prcharChild      }\n" +
            $"prbyteChild      {prbyteChild      }\n" +
            $"prvector3Child   {prvector3Child   }\n" +
            $"prquaternionChild{prquaternionChild}\n" +
            $"pintChild       {pintChild       }\n" +
            $"pfloatChild     {pfloatChild     }\n" +
            $"pdoubleChild    {pdoubleChild    }\n" +
            $"pstringChild    {pstringChild    }\n" +
            $"pcharChild      {pcharChild      }\n" +
            $"pbyteChild      {pbyteChild      }\n" +
            $"pvector3Child   {pvector3Child   }\n" +
            $"pquaternionChild{pquaternionChild}\n" +
            $"--- ---\n";

    }
}

public class TestJson : MonoBehaviour
{
    public Dictionary<int, string> myDict;
    public JasonChild js;
    string encoded = "NaN";

    // Start is called before the first frame update
    void Start()
    {
        js = new JasonChild(456,456,456,"456",'b',111,new Vector3(4,5,6),new Quaternion(5,6,7,8), 456, 456, 456, "456", 'b', 111, new Vector3(4, 5, 6), new Quaternion(5, 6, 7, 8), 456, 456, 456, "456", 'b', 111, new Vector3(4, 5, 6), new Quaternion(5, 6, 7, 8));
        
    }

    public void EncodeJason()
    {
        Debug.Log(js);
        encoded = JsonUtility.ToJson(js);
        JasonChild.pbintStatBase = 321;
        Debug.Log(encoded);
    }

    public void DecodeJason()
    {
        var newjs = (JasonChild)JsonUtility.FromJson(encoded, typeof(JasonChild));
        Debug.Log(newjs);
    }

}
