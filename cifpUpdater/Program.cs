using System;
using System.Collections.Generic;
using System.IO;

namespace cifpUpdater
{
    class Fixs
    {
        public String facilityId;
        public String fixId;
        public String id;
        public String magVar;

        public Fixs(String i, String fid, String key, String mv)
        {
            facilityId = i;
            fixId = fid;
            id = key;
            magVar = mv;
        }
    }

    class Navaids
    {
        public String facilityId;
        public String navId;
        public String id;
        public String magVar;
        public String name;

        public Navaids(String i, String nid, String key, String mv, String nm)
        {
            facilityId = i;
            navId = nid;
            id = key;
            magVar = mv;
            name = nm;
        }
    }

    class Ils
    {
        public String facilityId;
        public String runway;
        public String idCode;
        public String id;
        public String magVar;

        public Ils(String i, String r, String idc, String key, String mv)
        {
            facilityId = i;
            runway = r;
            idCode = idc;
            id = key;
            magVar = mv;
        }
    }

    class Airport
    {
        public String facilityId;
        public String id;
        public String magVar;

        public Airport(String i, String key, String mv)
        {
            facilityId = i;
            id = key;
            magVar = mv;
        }
    }

    class Program
    {
        static StreamReader sr = new StreamReader("cifpSorted.txt");

        static StreamWriter sw = new StreamWriter("cifpOut.txt");

        static StreamReader cifpFix = new StreamReader("cifpFix.txt");

        static StreamReader cifpNavaids1 = new StreamReader("cifpNavaids1.txt");
        static StreamReader cifpNavaids2 = new StreamReader("cifpNavaids2.txt");
        static StreamReader cifpNavaids3 = new StreamReader("cifpNavaids3.txt");
        static StreamReader cifpNavaids4 = new StreamReader("cifpNavaids4.txt");

        static StreamReader cifpIls = new StreamReader("cifpIls.txt");

        static StreamReader cifpAirport = new StreamReader("cifpAirport.txt");

        static List<Fixs> fixs = new List<Fixs>();

        static List<Navaids> navaids1 = new List<Navaids>();
        static List<Navaids> navaids2 = new List<Navaids>();
        static List<Navaids> navaids3 = new List<Navaids>();
        static List<Navaids> navaids4 = new List<Navaids>();

        static List<Ils> ils = new List<Ils>();

        static List<Airport> airports = new List<Airport>();

        static void Main(string[] args)
        {
            String rec = cifpFix.ReadLine();

            while (!cifpFix.EndOfStream)
            {
                String[] f = rec.Split('~');

                Fixs o = new Fixs(f[0], f[1], f[2], f[3]);

                fixs.Add(o);

                rec = cifpFix.ReadLine();
            }

            cifpFix.Close();

            rec = cifpNavaids1.ReadLine();

            while (!cifpNavaids1.EndOfStream)
            {
                String[] f = rec.Split('~');

                Navaids o = new Navaids(f[0], f[1], f[2], f[3], f[4]);

                navaids1.Add(o);

                rec = cifpNavaids1.ReadLine();
            }

            cifpNavaids1.Close();

            rec = cifpNavaids2.ReadLine();

            while (!cifpNavaids2.EndOfStream)
            {
                String[] f = rec.Split('~');

                Navaids o = new Navaids(f[0], f[1], f[2], f[3], f[4]);

                navaids2.Add(o);

                rec = cifpNavaids2.ReadLine();
            }

            cifpNavaids2.Close();

            rec = cifpNavaids3.ReadLine();

            while (!cifpNavaids3.EndOfStream)
            {
                String[] f = rec.Split('~');

                Navaids o = new Navaids(f[0], f[1], f[2], f[3], f[4]);

                navaids3.Add(o);

                rec = cifpNavaids3.ReadLine();
            }

            cifpNavaids3.Close();

            rec = cifpNavaids4.ReadLine();

            while (!cifpNavaids4.EndOfStream)
            {
                String[] f = rec.Split('~');

                Navaids o = new Navaids(f[0], f[1], f[2], f[3], f[4]);

                navaids4.Add(o);

                rec = cifpNavaids4.ReadLine();
            }

            cifpNavaids4.Close();

            rec = cifpIls.ReadLine();

            while (!cifpIls.EndOfStream)
            {
                String[] f = rec.Split('~');

                Ils o = new Ils(f[0], f[1], f[2], f[3], f[4]);

                ils.Add(o);

                rec = cifpIls.ReadLine();
            }

            cifpIls.Close();

            rec = cifpAirport.ReadLine();

            while (!cifpAirport.EndOfStream)
            {
                String[] f = rec.Split('~');

                Airport o = new Airport(f[0], f[1], f[2]);

                airports.Add(o);

                rec = cifpAirport.ReadLine();
            }

            cifpAirport.Close();

            rec = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                ProcessRecord(rec);

                rec = sr.ReadLine();
            }

            ProcessRecord(rec);

            sr.Close();

            sw.Close();
        }

        static void ProcessRecord(String rec)
        {
            String[] f = rec.Split('~');

            sw.Write(f[0]);
            sw.Write("~");
            sw.Write(f[1]);
            sw.Write("~");
            sw.Write(f[2]);
            sw.Write("~");
            sw.Write(f[3]);
            sw.Write("~");
            sw.Write(f[4]);
            sw.Write("~");
            sw.Write(f[5]);
            sw.Write("~");
            sw.Write(f[6]);
            sw.Write("~");
            sw.Write(f[7]);
            sw.Write("~");
            sw.Write(f[8]);
            sw.Write("~");
            sw.Write(f[9]);
            sw.Write("~");
            sw.Write(f[10]);
            sw.Write("~");
            sw.Write(f[11]);
            sw.Write("~");
            sw.Write(f[12]);
            sw.Write("~");
            sw.Write(f[13]);
            sw.Write("~");
            sw.Write(f[14]);
            sw.Write("~");

            ProcessWaypoint(f[0], f[5], f[9]);

            sw.Write(sw.NewLine);
        }

        public static void ProcessWaypoint(String facility, String point, String navaid)
        {
            // waypoint is an outer marker or navaid
            if ((point.Length == 2) || (point.Length == 3))
            {
                WritePoint(facility, point);

                sw.Write("~");
            }

            // waypoint possibly airport
            if ((point.Length == 4) && !point.Contains("RW"))
            {
                Airport ra = LookupAirport(facility);

                if (ra != null)
                {
                    sw.Write(ra.id);
                    sw.Write("~");
                    sw.Write(ra.magVar);
                    sw.Write("~");
                }
                else
                {
                    sw.Write("~");
                    sw.Write("~");
                }
            }

            // waypoint is a fix
            if ((point.Length == 5) && !point.Contains("RW"))
            {
                Fixs rf = LookupFix(facility, point);

                if (rf != null)
                {
                    sw.Write(rf.id);
                    sw.Write("~");
                    sw.Write(rf.magVar);
                    sw.Write("~");
                }
                else
                {
                    sw.Write("~");
                    sw.Write("~");
                }
            }

            // waypoint is the runway
            if ((point.Contains("RW")) && (point.Length > 3))
            {
                sw.Write("~");
                sw.Write("~");
            }

            // waypoint is empty
            if (point.Length == 0)
            {
                sw.Write("~");
                sw.Write("~");
            }

            // navaid is empty
            if (navaid.Length == 0)
            {
                sw.Write("~");
            }

            // navaid is an outer marker
            if (navaid.Length == 2)
            {
                Navaids rn = LookupNavaid(navaids3, facility, navaid);

                if (rn != null)
                {
                    sw.Write(rn.id);
                    sw.Write("~");
                    sw.Write(rn.magVar);
                }
                else
                {
                    rn = LookupNavaid(navaids4, facility, navaid);

                    if (rn != null)
                    {
                        sw.Write(rn.id);
                        sw.Write("~");
                        sw.Write(rn.magVar);
                    }
                    else
                    {
                        sw.Write("~");
                    }
                }
            }

            // navaid is a navaid
            if (navaid.Length == 3)
            {
                Navaids rn = LookupNavaid(navaids1, facility, navaid);

                if (rn != null)
                {
                    sw.Write(rn.id);
                    sw.Write("~");
                    sw.Write(rn.magVar);
                }
                else
                {
                    rn = LookupNavaid(navaids2, facility, navaid);

                    if (rn != null)
                    {
                        sw.Write(rn.id);
                        sw.Write("~");
                        sw.Write(rn.magVar);
                    }
                    else
                    {
                        sw.Write("~");
                    }
                }
            }

            // navaid is ils
            if (navaid.Length == 4)
            {
                Ils ils = LookupIls(facility, navaid);

                if (ils != null)
                {
                    sw.Write(ils.id);
                    sw.Write("~");
                    sw.Write(ils.magVar);
                }
                else
                {
                    sw.Write("~");
                }
            }

            // navaid is a fix
            if ((navaid.Length == 5) && !navaid.Contains("RW"))
            {
                Fixs rf = LookupFix(facility, navaid);

                if (rf != null)
                {
                    sw.Write(rf.id);
                    sw.Write("~");
                    sw.Write(rf.magVar);
                }
                else
                {
                    sw.Write("~");
                }
            }

        }

        public static void WritePoint(String facility, String point)
        {
            // point is an outer marker
            if (point.Length == 2)
            {
                Navaids rn = LookupNavaid(navaids3, facility, point);

                if (rn != null)
                {
                    sw.Write(rn.id);
                    sw.Write("~");
                    sw.Write(rn.magVar);

                    return;
                }
                else
                {
                    rn = LookupNavaid(navaids4, facility, point);

                    if (rn != null)
                    {
                        sw.Write(rn.id);
                        sw.Write("~");
                        sw.Write(rn.magVar);

                        return;
                    }
                    else
                    {
                        sw.Write("~");

                        return;
                    }
                }
            }

            // point is a navaid
            if (point.Length == 3)
            {
                Navaids rn = LookupNavaid(navaids1, facility, point);

                if (rn != null)
                {
                    sw.Write(rn.id);
                    sw.Write("~");
                    sw.Write(rn.magVar);

                    return;
                }
                else
                {
                    sw.Write("~");

                    return;
                }
            }

            // point is a fix
            if ((point.Length == 5) && !point.Contains("RW"))
            {
                Fixs rf = LookupFix(facility, point);

                if (rf != null)
                {
                    sw.Write(rf.id);
                    sw.Write("~");
                    sw.Write(rf.magVar);
                }
                else
                {
                    sw.Write("~");
                }
            }
        }

        public static Fixs LookupFix(String facilityId, String ident)
        {
            foreach(Fixs f in fixs)
            {
                if (f.facilityId == facilityId)
                {
                    if (f.fixId == ident)
                    {
                        return f;
                    }
                }
            }

            return null;
        }

        public static Navaids LookupNavaid(List<Navaids> nl, String facilityId, String ident)
        {
            foreach (Navaids n in nl)
            {
                if (n.facilityId == facilityId)
                {
                    if (n.navId == ident)
                    {
                        return n;
                    }
                }
            }

            return null;
        }

        public static Ils LookupIls(String facilityId, String ident)
        {
            foreach (Ils i in ils)
            {
                if (i.facilityId == facilityId)
                {
                    if (i.idCode == ident)
                    {
                        return i;
                    }
                }
            }

            return null;
        }

        public static Airport LookupAirport(String facilityId)
        {
            foreach (Airport a in airports)
            {
                if (a.facilityId == facilityId)
                {
                    return a;
                }
            }

            return null;
        }
    }
}
