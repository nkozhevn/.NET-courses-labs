using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_.NET_2
{
    class Pages
    {
        List<Threat> metrics;
        public int recOnPage = 15, pages;
        public Pages(List<Threat> bases)
        {
            metrics = bases;
            pages = metrics.Count / recOnPage - 1;
            if (metrics.Count % recOnPage != 0)
            {
                pages++;
            }
        }
        public List<Threat> First()
        {
            List<Threat> buffer = new List<Threat>();
            for (int i = 0; i < recOnPage; i++)
            {
                buffer.Add(metrics.ElementAt(i));
            }
            return buffer;
        }
        public List<Threat> Next(int page)
        {
            List<Threat> buffer = new List<Threat>();
            if (page == pages) { return Last(); }
            for (int i = recOnPage * page; i < (recOnPage * (page + 1)); i++)
            {
                buffer.Add(metrics.ElementAt(i));
            }
            return buffer;
        }
        public List<Threat> Prev(int page)
        {
            List<Threat> buffer = new List<Threat>();
            if (page == 1) { return First(); }
            for (int i = recOnPage * (page - 1); i < recOnPage * page; i++)
            {
                buffer.Add(metrics.ElementAt(i));
            }
            return buffer;
        }
        public List<Threat> Last()
        {
            List<Threat> buffer = new List<Threat>();
            if (metrics.Count % recOnPage == 0)
            {
                for (int i = metrics.Count - recOnPage; i < metrics.Count; i++)
                {
                    buffer.Add(metrics.ElementAt(i));
                }
                return buffer;
            }
            for (int i = metrics.Count - metrics.Count % recOnPage; i < metrics.Count; i++)
            {
                buffer.Add(metrics.ElementAt(i));
            }
            return buffer;
        }
    }
}
