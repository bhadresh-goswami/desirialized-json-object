using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Data;
using System.IO;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "";
            data = File.ReadAllText("jsondata.json");
            DataSet ds = new DataSet();

            jsonData[] dataObj = JsonConvert.DeserializeObject<jsonData[]>(data);

            //ConvertJsonStringToDataTable obj = new ConvertJsonStringToDataTable();
            //DataTable dt = obj.JsonStringToDataTable(data);

            //Console.WriteLine(dt.Rows.Count);

            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("id");
           // dt.Columns.Add("time");
            dt.Columns.Add("description");
            dt.Columns.Add("source");
            dt.Columns.Add("latitude");
            dt.Columns.Add("longitude");
            dt.Columns.Add("altitude");
            dt.Columns.Add("county");
            dt.Columns.Add("state");
            dt.Columns.Add("time");
            dt.Columns.Add("Brand.ProdNbr");
            dt.Columns.Add("pan");
            dt.Columns.Add("tilt");
            dt.Columns.Add("zoom");
            dt.Columns.Add("image_url");
            dt.Columns.Add("thumbnail_url");
            dt.Columns.Add("line");
            dt.Columns.Add("polygon");

            foreach (var item in dataObj)
            {
                DataRow dr = dt.NewRow();
                Dictionary<string, string> d = new Dictionary<string, string>();
                d = item.site;
                foreach (var key in d.Keys)
                {
                    dr[key] = d[key];
                }

                d = item.parameters;
                foreach (var key in d.Keys)
                {
                    dr[key] = d[key];
                }

                d = item.position;
                foreach (var key in d.Keys)
                {
                    dr[key] = d[key];
                }

                d = item.view;
                foreach (var key in d.Keys)
                {
                    dr[key] = d[key];
                }

                d = item.image;
                dr["image_url"] = d["url"];

                d = item.thumbnail;
                dr["thumbnail_url"] = d["url"];

                dr["name"] = item.name;
                dr["description"] = item.description;
                dr["source"] = item.source;

                dt.Rows.Add(dr);
            }

            Console.WriteLine(dt.Rows.Count);
            Console.ReadLine();

        }
    }

    public class jsonData
    {
        public string name;
        public string description;
        public string source;
        public Dictionary<string, string> site;
        public Dictionary<string, string> parameters;
        public Dictionary<string, string> position;
        public Dictionary<string, string> image;
        public Dictionary<string, string> thumbnail;
        public Dictionary<string, string> view;
    }
}
