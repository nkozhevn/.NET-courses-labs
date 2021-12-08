using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_.NET_2
{
    class Threat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Source { get; set; }
        public string Obj { get; set; }
        public bool Confidentiality { get; set; }
        public bool Integrity { get; set; }
        public bool Reliability { get; set; }
        public string FormatId { get; set; }
        public override string ToString()
        {
            return $"Идентификатор УБИ: {Id}\n\nНаименование УБИ: {Name}\n\nОписание: {Info}" +
                $"\n\nИсточник угрозы (характеристика и потенциал нарушителя): { Source}\n\nОбъект воздействия: { Obj}\n\nНарушение конфиденциальности: " +
                $"{(Confidentiality ? "да" : "нет")}\n\nНарушение целостности: { (Reliability ? "да" : "нет")}\n\nНарушение доступности: " +
                $"{(Integrity ? "да" : "нет")}";
        }
    }
}
