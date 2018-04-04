using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.DAL
{
    public class DummyData
    {
        public static List<Section> getSections()
        {
            List<Section> sections = new List<Section>()
            {
                new Section()
                {
                    SectionName = "Platwork",
                    Job = "Knyping"
                },
                new Section()
                {
                    SectionName = "TMS",
                    Job = "Drilling"
                }, new Section()
                {
                    SectionName = "OVB",
                    Job = "Sawing"
                }, new Section()
                {
                    SectionName = "Magazine",
                    Job = "Service"
                },
            };
            return sections;
        }
        public static List<Employee> getEmployee(CrmContext context)
        {
            List<Employee> employee = new List<Employee>()
            {
                new Employee()
                {
                     FirstName ="Michael",
                     LastName="Brant",
                    SectionName = context.Sections.Find("OVB").SectionName,
                    Age = 32,
                     Adress = "Green Str.73"
                },
                new Employee()
                {
                    FirstName ="Marteen",
                    LastName="Lowang",
                    SectionName = context.Sections.Find("OVB").SectionName,
                    Age = 30,
                    Adress = "Gennep"
                },
                new Employee()
                {
                    FirstName ="Hosein",
                    LastName="Yapici",
                    SectionName = context.Sections.Find("Platwork").SectionName,
                    Age = 37,
                    Adress = "Milsbeek"
                },
                new Employee()
                {
                FirstName ="Tan",
                LastName="Nyago",
                SectionName = context.Sections.Find("TMS").SectionName,
                Age = 50,
                Adress = "Nijmwegen"
                }


            };
            return employee;
        }

    }
}