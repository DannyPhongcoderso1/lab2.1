using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System;

namespace lab2._1
{
    internal class Program
    {
        public static Vector[] tonghop = new Vector[10];
        static void Main(string[] args)
        {
            Random hailoaivector = new Random();

            for (int i = 0; i < 10; i++)
            {
                
                if (hailoaivector.Next(0,2)==0)
                {
                    tonghop[i] = new Vector2D();
                    
                }
                else
                {
                    tonghop[i] = new Vector3D();
                }
                Console.Write($"{i}. ");
                tonghop[i].ShowInfo();
            }

            Console.WriteLine("nhap loai vector ban muon tinh: ");
            string L =Console.ReadLine();
            if (L == "2d" || L == "2D")
            {
                Vector2D v = new Vector2D();
                v.Sum(tonghop);
                v.OrtchVector(tonghop);
            }
            else if(L =="3d"||L=="3D")
            {
                Vector3D v = new Vector3D();
                v.Sum(tonghop);
                v.OrtchVector(tonghop);    
            }
                

        }
    }

    public abstract class  Vector
    {
        public abstract void ShowInfo();

        public abstract void Sum(Vector[] v);

        public abstract void OrtchVector(Vector[] v);
        
    }

    public class Vector2D:Vector
    {
        private float x;
        private float y;

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }

        public Vector2D()
        {
            Random random = new Random();
            x = random.Next(-10, 10);
            y = random.Next(-10, 10);
        }
        public Vector2D (float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override void ShowInfo() 
        {
            Console.WriteLine($"({x},{y})");
        }
        public override void Sum(Vector[] hai) 
        {
            Console.WriteLine("nhap hai vi tri vector ban muon cong: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a>=0 && b>=0 && a<hai.Length && b<hai.Length)
            {
                if (hai[a] is Vector2D v2_1 && hai[b] is Vector2D v2_2)
                {
                    Vector2D sum = new Vector2D(x,y);
                    sum.x = v2_1.x + v2_2.x;
                    sum.y = v2_1.y + v2_2.y;
                    Console.WriteLine($"({sum.x},{sum.y})");
                }
                else
                {
                    Console.WriteLine("khong cung loai vector");
                }
            }
            
        }
        public override void OrtchVector(Vector[] hai) 
        {
            Console.WriteLine("nhap hai vi tri vector ban muon tinh tich: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a >= 0 && b >= 0 && a < hai.Length && b < hai.Length)
            {
                if (hai[a] is Vector2D v2_1 && hai[b] is Vector2D v2_2)
                {
                    float orth;
                    orth=v2_1.x * v2_2.x + v2_1.y*v2_2.y;

                    if (orth == 0)
                    {
                        Console.WriteLine($"{v2_1}, {v2_2}");
                    }
                    else
                    {
                        Console.WriteLine("cap vector nay khong truc giao");
                    }
                }
                else
                {
                    Console.WriteLine("hai vector khong cung loai");
                }
            }
        }
    }
    
    public class Vector3D:Vector
    {
        private float x;
        private float y;
        private float z;

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }

        public Vector3D()
        {
            Random random = new Random();
            x = random.Next(-10, 10);
            y = random.Next(-10, 10);
            z = random.Next(-10, 10);
        }
        public Vector3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override void ShowInfo() 
        {
            Console.WriteLine($"({x},{y},{z})");
        }
        public override void Sum(Vector[] ba) 
        {
            Console.WriteLine("nhap hai vi tri ban muon cong: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a >= 0 && b >= 0 && a < ba.Length && b < ba.Length)
            { if (ba[a] is Vector3D v3_1 && ba[b] is Vector3D v3_2)
                {
                    Vector3D sum = new Vector3D(x, y, z);
                    sum.x = v3_1.x + v3_2.x;
                    sum.y = v3_1.y + v3_2.y;
                    sum.z = v3_1.z + v3_2.z;
                    Console.WriteLine($"({sum.x},{sum.y},{sum.z})");
                }
                else
                { 
                    Console.WriteLine("Hai vector khong cung loai");
                }
            }
        }
        public override void OrtchVector(Vector[] ba) 
        {

            Console.WriteLine("nhap hai vi tri vector ban muon tinh tich: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a >= 0 && b >= 0 && a < ba.Length && b < ba.Length)
            {
                if (ba[a] is Vector3D v3_1 && ba[b] is Vector3D v3_2)
                {
                    float orth;
                    orth = v3_1.x * v3_2.x + v3_1.y * v3_2.y +v3_1.z*v3_2.z;

                    if (orth == 0)
                    {
                        Console.WriteLine($"{v3_1}, {v3_2}");
                    }
                    else
                    {
                        Console.WriteLine("cap vector khong truc giao");
                    }
                }
                else
                {
                    Console.WriteLine("hai vector khong cung loai");
                }
            }
        }
    }
}

